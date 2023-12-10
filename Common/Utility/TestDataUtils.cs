namespace Task_TMajdan.Src.Support
{
    using System;

    internal class TestDataUtils
    {
        private static readonly Random Rnd = new Random();

        public static int GenerateRandomNumber(int maxValue, int minValue = 1)
        {
            return Rnd.Next(minValue, maxValue);
        }
    }
}