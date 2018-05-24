// <copyright file="Program.cs" company="David Bremner">
// Copyright (c) David Bremner. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Globalization;

namespace SpellCheckTool
{
    /// <summary>
    /// entry point
    /// </summary>
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
