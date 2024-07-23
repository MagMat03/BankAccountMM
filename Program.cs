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
                Console.WriteLine($"Stan konta: {account.Balance} PLN");
                    break;
                 case "2":
                    Console.Write("Podaj kwotę wpłaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        account.Deposit(depositAmount);
                        Console.WriteLine("Wpłata zakończona sukcesem.");
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kwota.");
                    }
                    break;
                case "3":
                    Console.Write("Podaj kwotę wypłaty: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal withdrawalAmount))
                    {
                        if (account.Withdraw(withdrawalAmount))
                        {
                            Console.WriteLine("Wypłata zakończona sukcesem.");
                        }
                        else
                        {
                            Console.WriteLine("Nie można wypłacić więcej niż jest na koncie.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa kwota.");
                    }
                    break;
                case "4":
                    Console.WriteLine("Historia operacji:");
                    foreach (var operation in account.GetOperations())
                    {
                        Console.WriteLine(operation);
                    }
                    break;
                case "5":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Nieznana opcja.");
                    break;
            }
        }
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            bool exit = false;

            while (!exit)
            {
                ShowMenu();
                string choice = Console.ReadLine();
                HandleUserChoice(choice, account, ref exit);
                Console.WriteLine();
            }
        }
            
        
    }
}