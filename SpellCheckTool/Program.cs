using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpellCheckTool.Interop;

namespace SpellCheckTool
{
    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Expected two arguments:");
                Console.WriteLine("spellchecktool teh the");
                return;
            }

            var factory = new SpellCheckerFactory();
            var checker = factory.CreateSpellChecker("en-us");
            checker.AutoCorrect(args[0], args[1]);
        }
    }
}
