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

            var factory = new SpellCheckerFactory();
            string cultureName = CultureInfo.CurrentCulture.ToString(); //e.g. en-US
            var checker = factory.CreateSpellChecker(cultureName);
            checker.AutoCorrect(args[0], args[1]);
        }

        private static void ShowHelp()
        {
            Console.WriteLine(Resources.ExpectedTwoArguments);
            Console.WriteLine(Resources.ExampleInvocation);
        }
    }
}
