﻿using System.Globalization;
using SpellCheckTool.Interop;

namespace SpellCheckTool
{
    internal sealed class SpellChecker
    {
        private static readonly SpellCheckerFactory factory;
        private readonly ISpellChecker checker;

        static SpellChecker()
        {
            factory = new SpellCheckerFactory();
        }

        public SpellChecker(CultureInfo culture)
        {
            string cultureName = culture.ToString(); //e.g. en-US
            checker = factory.CreateSpellChecker(cultureName);
        }

        public void AutoCorrect(string from, string to)
        {
            checker.AutoCorrect(from, to);
        }
    }
}