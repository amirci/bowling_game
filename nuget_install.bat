for /D %%d in (tests\*) do if exist %%d\packages.config nuget install %%d\packages.config -o packages
