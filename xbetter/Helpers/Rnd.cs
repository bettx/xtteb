using System;
using System.Diagnostics;

// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMethodReturnValue.Global

namespace xbetter.Helpers
{
    public static class Rnd
    {
        private static readonly Random random = new Random();

        private static readonly object randomLocker = new object();

        [DebuggerHidden]
        public static int Next()
        {
            lock(randomLocker) return random.Next();
        }

        [DebuggerHidden]
        public static int Next(int max)
        {
            lock(randomLocker) return random.Next(max);
        }

        [DebuggerHidden]
        public static int Next(int min, int max)
        {
            lock(randomLocker) return random.Next(min, max);
        }

        /*[DebuggerHidden]
        public static double NextDouble()
        {
            lock(randomLocker) return random.Next();
        }*/


        /*[DebuggerHidden]
        public static void NextBytes(byte[] buffer)
        {
            lock(randomLocker) random.NextBytes(buffer);
        }*/

        [DebuggerHidden]
        public static bool Chance(int percent = 50) => Next(100) < percent;
    }

}
