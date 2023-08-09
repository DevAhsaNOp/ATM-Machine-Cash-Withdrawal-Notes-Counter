using System;
using System.Collections.Generic;
using System.Linq;

namespace ATMMachineAmountWithDrawalCurrencyNotesCount
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] availableNotes = { 5000, 1000, 500 };
            int[] noteCount = { 0, 8, 5 };

            int withdrawalAmount = 8000;

            DispenseCurrencyNotes(availableNotes, noteCount, withdrawalAmount);
            Console.ReadLine();
        }

        static void DispenseCurrencyNotes(int[] availableNotes, int[] noteCount, int withdrawalAmount)
        {
            Dictionary<int, int> notesToWithdraw = new Dictionary<int, int>();

            for (int i = 0; i < availableNotes.Length; i++)
            {
                int notesToDispense = withdrawalAmount / availableNotes[i];

                if (notesToDispense <= noteCount[i] && notesToDispense != 0)
                {
                    withdrawalAmount -= notesToDispense * availableNotes[i];
                    notesToWithdraw.Add(availableNotes[i], notesToDispense);
                }
            }

            if (withdrawalAmount == 0)
            {
                notesToWithdraw.Select(item => $"Dispensing {item.Value} notes of {item.Key}").ToList().ForEach(Console.WriteLine);
                Console.WriteLine("Withdrawal successful");
            }
            else
            {
                Console.WriteLine("Insufficient notes to dispense the requested amount");
            }
        }
    }
}
