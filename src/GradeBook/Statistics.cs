using System;

namespace src.GradeBook
{
    public class Statistics
    {
        public double Avarage
        {
            get
            {
                return Sum / Count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Avarage)
                {
                    case var d when d >= 90:
                        return 'A';

                    case var d when (80 <= d && d < 89):
                        return 'B';

                    case var d when (70 <= d && d < 79):
                        return 'C';

                    case var d when (60 <= d && d < 69):
                        return 'D';

                    case var d when (50 <= d && d < 59):
                        return 'E';

                    default:
                        return 'F';

                }//shift alt f reformat
            }
        }
        public double Sum;
        public int Count;

        public void Add(double number)
        {
            Sum += number;
            Count += 1;
            High = Math.Max(number, High);
            Low = Math.Min(number, Low);
        }

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;
            Sum = 0.0;
            Count = 0;
        }

    }
}