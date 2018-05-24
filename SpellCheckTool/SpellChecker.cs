﻿// <copyright file="SpellChecker.cs" company="David Bremner">
// Copyright (c) David Bremner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Globalization;
using SpellCheckTool.Interop;

namespace SpellCheckTool
{
    /// <summary>
    /// This class is a wrapper for the COM <see cref="ISpellChecker"/> interface.
    /// </summary>
    internal sealed class SpellChecker
    {
        /// <summary>
        /// singleton
        /// </summary>
        private static readonly SpellCheckerFactory Factory = new SpellCheckerFactory();

        private readonly ISpellChecker checker;

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellChecker"/> class.
        /// </summary>
        /// <param name="culture">culture to create a spell checker for</param>
        public SpellChecker(CultureInfo culture)
        {
            if (culture == null)
            {
                throw new ArgumentNullException(nameof(culture));
            }

            string cultureName = culture.ToString(); // e.g. en-US
            checker = Factory.CreateSpellChecker(cultureName);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpellChecker"/> class.
        /// </summary>
        /// <param name="cultureName">e.g. en-US</param>
        public SpellChecker(string cultureName)
        {
            checker = Factory.CreateSpellChecker(cultureName);
        }

        /// <summary>
        /// Add an autocorrection to the autocorrection list.
        /// </summary>
        /// <param name="from">word to replace</param>
        /// <param name="to">what to replace it with</param>
        public void AutoCorrect(string from, string to)
        {
            if (string.IsNullOrWhiteSpace(from))
            {
                throw new ArgumentException(Resources.ArgumentMayNotBeNullOrWhiteSpace, nameof(from));
            }

            if (string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentException(Resources.ArgumentMayNotBeNullOrWhiteSpace, nameof(to));
            }

            checker.AutoCorrect(from, to);
        }
    }
}
