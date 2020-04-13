﻿using FinTool.Data.Models;
using FinTool.Data.Services;
using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace FinTool.Logic
{
    public class Helper
    {
        // the file that has the transactions.  For now, this is hardcoded.
        private const string inputFile = @"C:\Git\FinTool\FinTool.Data\Test_Transactions.txt";

        // loads transactions from input file into the database
        public static void LoadInputFile(ITransactionRepository transactionRepository, IRegExStringRepository regExStringRepository)
        {
            using (var reader = new StreamReader(inputFile))
            {
                while (!reader.EndOfStream)
                {
                    var tokens = reader.ReadLine().Replace("\\", "").Replace("\"", "").Split(',');
                    var transaction = new Transaction()
                    {
                        Date = DateTime.Parse(tokens[0]),
                        Amount = Decimal.Parse(tokens[1]),
                        Description = tokens[4],
                        RegExString = GetRegExString(regExStringRepository, tokens[4]),
                    };
                    transactionRepository.Create(transaction);
                }
            }
        }

        // get the regular expression string that finds a match to the description string
        private static RegExString GetRegExString(IRegExStringRepository regExStringRepository, string description)
        {
            foreach (var r in regExStringRepository.GetAll())
            {
                if (!String.IsNullOrEmpty(r.SearchString) && Regex.Match(description, r.SearchString).Success)
                    return r;
            }
            return regExStringRepository.GetAll().First(m => m.SearchString == "");
        }

    }
}