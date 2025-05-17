using System;

namespace BDPracticWork1
{
    internal class Program
    {
        // public static string userName;
        public static void Main(string[] args)
        {
            string _userName = "";
            int _userAge = 0;
            int _round = 0;
            int _winRound = 0;
            bool _toPlay = false;
            
            Console.WriteLine("Do you want to play a game Paper Scissors Stone? \ny - if you want to play, n - if don`t.");
            char choice = Console.ReadKey().KeyChar;
            
            if (choice == 'y')
            {
                Console.Clear();
                (string name, int age) userData = AskUserData();
                _userName = userData.name;
                _userAge = userData.age;
                if (_userAge >= 12)
                    _toPlay = true;
                else 
                    Console.WriteLine("Sorry, but you are too young for this game");
            }
            else if (choice == 'n')
                Console.WriteLine("\nOk. when it`s over. Bye!");
            else
                Console.WriteLine("\nWrong answer. It`s over. Bye!");

            while (_toPlay)
            {
                Console.Clear();
                WriteStatistic(_userName, _userAge, _round, _winRound);
                Console.WriteLine("Play a round up to 2 wins. Ready? \ny - if you want to play, n - if don`t.\n");
                choice = Console.ReadKey().KeyChar;
                if (choice == 'y')
                {
                    Console.Clear();
                    int machineWeaponNumber = MachineChooseWeapon();
                    int userWeaponNumber = UserChooseWeapon();

                    var machineWeapon = (Weapon)machineWeaponNumber;
                    Console.WriteLine($"Machine weapon: {machineWeapon}");
                    var userWeapon = (Weapon)userWeaponNumber;
                    Console.WriteLine($"User weapon: {userWeapon}");


                }
                else if (choice == 'n')
                {
                    Console.WriteLine("\nOk. when it`s over. Bye!");
                    _toPlay = false;
                }
                else
                    Console.WriteLine("\nWrong answer. \ny - if you want to play, n - if don`t.");
                
                
                
                
                
                Console.ReadLine();
            }
        }

        private static int MachineChooseWeapon()
        {
            Random random = new Random();
            return random.Next(0, 3);
        }

        private static int UserChooseWeapon()
        {
            Console.WriteLine("Choose your weapon:");
            Console.WriteLine($"0 it`s {Weapon.Paper}");
            Console.WriteLine($"1 it`s {Weapon.Scissors}");
            Console.WriteLine($"2 it`s {Weapon.Stone}");
            int result = 0;
            bool askWeapon = true;
            while (askWeapon)
            {
                if (int.TryParse(Console.ReadLine(), out int resultData) && resultData >= 0 && resultData < 3)
                {
                    result = resultData;
                    askWeapon = false;
                }
                else
                    Console.WriteLine("I don`t know this weapon. Try again.");
            }
            return result;
        }
        private static void WriteBattleField(string name)
        {
            string machine = "Machine";
            int totalLenght = 1 + machine.Length + 4 + name.Length + 1;
            char[] horizontalLine = new char[totalLenght];
            for (int i = 0; i < totalLenght; i++)
            {
                horizontalLine[i] = '=';
            }
            foreach (var c in horizontalLine) 
                Console.Write(c);
            Console.WriteLine();
            Console.WriteLine($"={machine} VS {name}=");
            foreach (var c in horizontalLine) 
                Console.Write(c);
            
        }
        private static (string, int) AskUserData()
        {
            Console.WriteLine("Enter your name:");
            string userName = Console.ReadLine();
            bool age = true;
            int userAge = 0;
            Console.WriteLine("Enter your age:");
            while (age)
            {
                if (int.TryParse(Console.ReadLine(), out int dataAge))
                {
                    userAge = dataAge;
                    age = false;
                }
                else
                    Console.WriteLine("Wrong answer. Enter your age:");
            }
            return (userName, userAge);
        }

        private static void WriteStatistic(string name, int age, int round, int winRound)
        {
            Console.WriteLine($"{name}, {age} years old.");
            Console.WriteLine($"Number of games played: {round}");
            Console.WriteLine($"Winning round: {winRound}");
        }
    }
}