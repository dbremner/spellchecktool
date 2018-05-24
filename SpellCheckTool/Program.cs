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
                Console.WriteLine("Expected two arguments:");
                Console.WriteLine("spellchecktool teh the");
                return;
            }

            var factory = new SpellCheckerFactory();
            string cultureName = CultureInfo.CurrentCulture.ToString(); //e.g. en-US
            var checker = factory.CreateSpellChecker(cultureName);
            checker.AutoCorrect(args[0], args[1]);
        }
    }
}
