using System;


namespace Order.Management
{
    public static class Utility
    {
        public static void PrintLine(int tableWidth)
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(int tableWidth, params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row = $"{row}{AlignCentre(column, width)}|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? $"{text.Substring(0, width - 3)}..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        // User Console Input
        public static string GetUserInputString()
        {
            string input = Console.ReadLine();
            while (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("please enter valid details");
                input = Console.ReadLine();
            }
            return input;
        }

        public static DateTime GetUserInputDate()
        {
            DateTime dueDate;
            string input = Console.ReadLine();
            while (!DateTime.TryParse(input, out dueDate))
            {
                Console.WriteLine("Please input correct date time format");
                input = Console.ReadLine();
            }

            return dueDate;
        }

        public static int GetUserInputNumber()
        {
            var number = 0;
            var input = GetUserInputString();

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out number))
            {
                Console.WriteLine("please enter valid number");
                input = Console.ReadLine();
            }

            return number;
        }
    }
}
