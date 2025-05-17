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
            int _loseRound = 0;
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
                while (_round < 3)
                {
                    Console.Clear();
                    WriteStatistic(_userName, _userAge, _round, _winRound, _loseRound);
                    Console.WriteLine($"We will play 3 rounds. It`s {_round+1} round. Ready to play? \ny - if you want to play, n - if don`t.");
                    choice = Console.ReadKey().KeyChar;
                    if (choice == 'y')
                    {
                        Console.Clear();
                        _round++;
                        int _machineWeaponNumber = MachineChooseWeapon();
                        int _userWeaponNumber = UserChooseWeapon();
                        WriteWhoWinRound(_machineWeaponNumber, _userWeaponNumber, _winRound, _loseRound, out _winRound, out  _loseRound);
                        WriteBattleField(_userName, _machineWeaponNumber, _userWeaponNumber);
                    }
                    else if (choice == 'n')
                    {
                        Console.Clear();
                        Console.WriteLine("\nOk. when it`s over. Bye!");
                        _toPlay = false;
                        break;
                    }
                    else
                        continue;

                    Console.WriteLine("Tap any key to play next round.");
                    Console.ReadKey();
                }

                while (_toPlay)
                {
                    Console.Clear();
                    Console.WriteLine("Final statistics:");
                    WriteStatistic(_userName, _userAge, _round, _winRound, _loseRound);
                    if (_winRound > _loseRound)
                        GreetingUser(_userName);
                    else if (_winRound < _loseRound)
                        ComfortingUser(_userName);
                    else
                        DiscussTheDraw(_userName);

                    Console.WriteLine("Do you want play new battle? \ny - if you want to play, n - if don`t.");
                    char choiceNewBattle = Console.ReadKey().KeyChar;
                    if (choiceNewBattle == 'y')
                    {
                        Console.Clear();
                        _round = 0;
                        _winRound = 0;
                        _loseRound = 0;
                    }
                    else if (choiceNewBattle == 'n')
                    {
                        Console.WriteLine("\nOk. when it`s over. Bye!");
                        _toPlay = false;
                    }
                    else
                    {
                        Console.WriteLine("\n I don`t know this answer. Try again!");
                    }
                }

            }
        }

        private static void DiscussTheDraw(string userName)
        {
            Random random = new Random();
            int discussCount = random.Next(0, 3);
            switch (discussCount)
            {
                case 1:
                    Console.WriteLine($"{userName}, it looks like a draw.");
                    break;
                case 2:
                    Console.WriteLine($"It`s was great battle but no one won.");
                    break;
                default:
                    Console.WriteLine($"Good work {userName}. We need one more battle to decide who won.");
                    break;
            }
        }

        private static void ComfortingUser(string userName)
        {
            Random random = new Random();
            int comfortingCount = random.Next(0, 3);
            switch (comfortingCount)
            {
                case 1:
                    Console.WriteLine($"Sorry, {userName}! You lose the battle!");
                    break;
                case 2:
                    Console.WriteLine($"{userName}, bro! It`s was good battle but you lose.");
                    break;
                default:
                    Console.WriteLine($"Well, {userName}, you lose. You did great! Maybe next time.");
                    break;
            }
        }

        private static void GreetingUser(string userName)
        {
            Random random = new Random();
            int greetingCount = random.Next(0, 3);
            switch (greetingCount)
            {
                case 1:
                    Console.WriteLine($"Congratulations, {userName}! You won the battle!");
                    break;
                case 2:
                    Console.WriteLine($"Congratulations, {userName}! It`s was good battle but I lose!");
                    break;
                default:
                    Console.WriteLine($"Unbelievable! {userName}, you won! You did great!");
                    break;
            }
        }

        private static void WriteWhoWinRound(int machineWeaponNumber, int userWeaponNumber, int winRound, int loseRound, out int winResult, out int loseResult)
        {
            if (machineWeaponNumber == 0 && userWeaponNumber == 1 || machineWeaponNumber == 1 && userWeaponNumber == 2 || machineWeaponNumber == 2 && userWeaponNumber == 0)
            {
                Console.WriteLine("You win this round!");
                winRound++;
            }
            else if (machineWeaponNumber == 0 && userWeaponNumber == 2 || machineWeaponNumber == 1 && userWeaponNumber == 0 || machineWeaponNumber == 2 && userWeaponNumber == 1)
            {
                Console.WriteLine("You lose this round!");
                loseRound++;
            }
            else
            {
                Console.WriteLine("Draw");
            }
            winResult = winRound;
            loseResult = loseRound;
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
                if (int.TryParse(Console.ReadKey().KeyChar.ToString(), out int resultData) && resultData >= 0 && resultData < 3)
                {
                    Console.WriteLine();
                    result = resultData;
                    askWeapon = false;
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("I don`t know this weapon. Try again.");
                }
            }
            return result;
        }
        private static void WriteBattleField(string name, int machineWeaponNumber, int userWeaponNumber)
        {
            string machine = "Machine";
            string threw = "threw";
            var machineWeapon = (Weapon)machineWeaponNumber;
            var userWeapon = (Weapon)userWeaponNumber;
            var nameMachineWeapon = machineWeapon.ToString();
            var nameUserWeapon = userWeapon.ToString();
            int totalLenght = (1 + machine.Length + 1 + threw.Length + 1 + nameMachineWeapon.Length) + 4 + (1 + name.Length + 1 + threw.Length + 1 + nameUserWeapon.Length);
            
            char[] horizontalLine = new char[totalLenght];
            for (int i = 0; i < totalLenght; i++)
            {
                horizontalLine[i] = '=';
            }
            foreach (var c in horizontalLine) 
                Console.Write(c);
            Console.WriteLine();
            Console.WriteLine($"={machine} {threw} {machineWeapon} VS {name} {threw} {userWeapon}=");
            foreach (var c in horizontalLine)
                Console.Write(c);
            Console.WriteLine();
            
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

        private static void WriteStatistic(string name, int age, int round, int winRound, int loseRound)
        {
            Console.WriteLine($"{name}, {age} years old.");
            Console.WriteLine($"Number of rounds played: {round}");
            Console.WriteLine($"Number of winning rounds: {winRound}");
            Console.WriteLine($"Number of losing rounds: {loseRound}");
        }
    }
}