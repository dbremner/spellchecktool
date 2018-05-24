using System;
using System.Globalization;

namespace SpellCheckTool
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                ShowHelp();
                return;
            }

            var checker = new SpellChecker(CultureInfo.CurrentCulture);
            string from = args[0];
            string to = args[1];
            checker.AutoCorrect(from, to);
        }

        private static void ShowHelp()
        {
            Console.WriteLine(Resources.ExpectedTwoArguments);
            Console.WriteLine(Resources.ExampleInvocation);
        }
    }
}
