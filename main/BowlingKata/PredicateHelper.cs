using System;

namespace BowlingKata
{
    public static class PredicateHelper
    {
        public static void OrThrow<T>(this bool predicate) where T : Exception, new()
        {
            if (!predicate)
            {
                throw new T();
            }
        }

        public static T Then<T>(this bool predicate, T nextBall)
        {
            return predicate ? nextBall : default(T);
        }
    }
}