// <copyright file="SpellChecker.cs" company="David Bremner">
// Copyright (c) David Bremner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System.Globalization;
using SpellCheckTool.Interop;

namespace SpellCheckTool
{
    internal sealed class SpellChecker
    {
        private static readonly SpellCheckerFactory Factory = new SpellCheckerFactory();

        private readonly ISpellChecker checker;

        public SpellChecker(CultureInfo culture)
        {
            string cultureName = culture.ToString(); // e.g. en-US
            checker = Factory.CreateSpellChecker(cultureName);
        }

        public void AutoCorrect(string from, string to)
        {
            checker.AutoCorrect(from, to);
        }
    }
}
