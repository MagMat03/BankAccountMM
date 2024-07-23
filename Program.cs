using System;
using System.Collections.Generic;

namespace BankAccountApp 
{
    public class BankAccount
    {
        public decimal Balance {get; private set;}
        private List<string> operations;

        public BankAccount()
        {
            Balance=0;
            operations=new List<string>();
        }
        public void Deposit(decimal amount)
        {
            Balance+= amount;
            operations.Add($"Wpłata:+{amount} PLN");
        }
        public bool Withdraw(decimal amount)
        {
            if(amount > Balance)
            {
                return false;
            }

            Balance -=amount;
            operations.Add($"Wypłata: -{amount} PLN");
            return true;
        }

        public List<string> GetOperations()
        {
            return new List<string>(operations);
        }
    }
    
    class Program 
    {
        static void ShowMenu()
        {
            Console.WriteLine("wybierz opcję: ");
            Console.WriteLine("1. Pokaż stan konta");
            Console.WriteLine("2. Dodaj wpłatę");
            Console.WriteLine("3. Wykonaj wypłatę");
            Console.WriteLine("4. Pokaż historię operacji");
            Console.WriteLine("5. Wyjdź");
            Console.Write("Twój wybór: ");
        }

        static void HandleUserChoice(string choice, BankAccount account, ref bool exit)
        {
            switch (choice)
            {
                case "1":
                
            }
        }
    }
}