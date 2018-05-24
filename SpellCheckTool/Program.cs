using System;
using System.Globalization;
using SpellCheckTool.Interop;

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

            var checker = CreateChecker(CultureInfo.CurrentCulture);
            string from = args[0];
            string to = args[1];
            checker.AutoCorrect(from, to);
        }

        private static void ShowHelp()
        {
            Console.WriteLine(Resources.ExpectedTwoArguments);
            Console.WriteLine(Resources.ExampleInvocation);
        }

        private static ISpellChecker CreateChecker(CultureInfo culture)
        {
            var factory = new SpellCheckerFactory();
            string cultureName = culture.ToString(); //e.g. en-US
            var checker = factory.CreateSpellChecker(cultureName);
            return checker;
        }
    }
}
