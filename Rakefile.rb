require 'rubygems'    

sh "bundle install --system"
Gem.clear_paths

require 'albacore'
require 'rake/clean'
require 'git'
require 'set'

include FileUtils

solution_file = FileList["*.sln"].first
project_name = "BowlingKata"
commit = Git.open(".").log.first.sha[0..10] rescue 'na'
version = IO.readlines('VERSION')[0] rescue "0.0.0.0"

CLEAN.include("main/**/bin", "main/**/obj", "tests/**/obj", "tests/**/bin", "gem/lib/**", ".svn")

CLOBBER.include("**/_*", "packages/*", "**/*.user", "**/*.cache", "**/*.suo")

desc 'Default build'
task :default => ["build:all"]

desc 'Setup requirements to build and deploy'
task :setup => ["setup:dep"]

desc "Run all unit tests"
task :test => ["test:all"]

namespace :setup do
	desc "Setup dependencies for nuget packages"
	task :dep do
		FileList["**/packages.config"].each do |file|
			sh "nuget install #{file} /OutputDirectory Packages"
		end
	end
end

namespace :build do

	desc "Build the project"
	msbuild :all, :config, :needs => :setup do |msb, args|
		msb.properties :configuration => args[:config] || :Debug
		msb.targets :Build
		msb.solution = solution_file
	end

	desc "Rebuild the project"
	task :re => ["clean", "build:all"]
end

namespace :test do
	
	nunit_cmd = "Packages/NUnit.2.5.10.11092/tools/nunit-console.exe"
	
	desc 'Run all tests'
	nunit :all => [:default] do |n|
		n.command = nunit_cmd
		n.assemblies FileList["tests/**/bin/debug/**/*.Tests.dll"]
	end
	
end

namespace :version do
	task :show do 
		puts "Current version is: #{version}"
	end
end

namespace :util do
	task :clean_folder, :folder do |t, args|
		rm_rf(args.folder)
		Dir.mkdir(args.folder) unless File.directory? args.folder
	end
		
	assemblyinfo :update_version do |asm|
		asm.version = version
		asm.company_name = "MavenThought Inc."
		asm.product_name = "MavenThought Commons (sha #{commit})"
		asm.copyright = "MavenThought Inc. 2006 - #{DateTime.now.year}"
		asm.output_file = "main/GlobalAssemblyInfo.cs"
	end	

	task :build_release => [:update_version] do 
		Rake::Task["build:all"].invoke(:Release)
		Rake::Task["test"].invoke
	end
end
