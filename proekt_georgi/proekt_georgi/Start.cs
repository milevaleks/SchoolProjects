using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    public class Start
    {
        static string[] playerCards = new string[11];
        static string hitOrStay = "";
        static int total = 0, count = 1, dealerTotal = 0;
        static Random cardRandomizer = new Random();
        static bool asd = false;
        static double all;
        static double currentBet;

        public void Main(double balance)
        {
            all = balance;
            

            dealerTotal = cardRandomizer.Next(15, 22);
            playerCards[0] = Deal();
            playerCards[1] = Deal();

            if(all > 0)
            { 
                do
                {
                    Console.WriteLine("Welcome to Blackjack! You were dealed " + playerCards[0] + " and " + playerCards[1] + ". \nYour total is " + total + ".\nYour balance is:" + all + "\nWould you like to hit or stay? h for hit s for stay.");
                    hitOrStay = Console.ReadLine().ToLower();
                }
                while (!hitOrStay.Equals("h") && !hitOrStay.Equals("s"));
                
                Bet();
            }
            else
            {
                Console.Write(" ");
            }
            

        }

        public void Bet()
        {
            Console.Write("How much money you want to bet: ");
            double bet = double.Parse(Console.ReadLine());

            if(bet > all)
            {
                Console.WriteLine("You cannot bet more money than your balance! Your balance is: " + all);
                Bet();
            }           
            else
            {
                currentBet = bet;
                Game();
            }

        }

        public void Game()
        {

            if (hitOrStay.Equals("h"))
            {
                Hit();
            }
            else if (hitOrStay.Equals("s"))
            {
                if (total > dealerTotal && total <= 21)
                {
                    Console.WriteLine("\nCongrats! You won the game! The dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n");
                    all += currentBet * 2;
                    Console.WriteLine("Your current balance is: " + all);
                    PlayAgain();


                }
                else if (total < dealerTotal)
                {
                    Console.WriteLine("\nSorry, you lost! The dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n");
                    all -= currentBet;
                    Console.WriteLine("Your current balance is: " + all);
                    PlayAgain();
                }
            }

            if (asd == false)
            {
                Console.ReadLine();
            }
            else
            {
                Console.Write("");
            }

        }

        public string Deal()
        {
            string Card = "";
            int cards = cardRandomizer.Next(1, 14);

            switch (cards)
            {
                case 1:
                    Card = "Two"; total += 2;
                    break;
                case 2:
                    Card = "Three"; total += 3;
                    break;
                case 3:
                    Card = "Four"; total += 4;
                    break;
                case 4:
                    Card = "Five"; total += 5;
                    break;
                case 5:
                    Card = "Six"; total += 6;
                    break;
                case 6:
                    Card = "Seven"; total += 7;
                    break;
                case 7:
                    Card = "Eight"; total += 8;
                    break;
                case 8:
                    Card = "Nine"; total += 9;
                    break;
                case 9:
                    Card = "Ten"; total += 10;
                    break;
                case 10:
                    Card = "Jack"; total += 10;
                    break;
                case 11:
                    Card = "Queen"; total += 10;
                    break;
                case 12:
                    Card = "King"; total += 10;
                    break;
                case 13:
                    Card = "Ace"; total += 11;
                    break;
                default:
                    Card = "2"; total += 2;
                    break;
            }
            return Card;
        }

        public void Hit()
        {
            count += 1;
            playerCards[count] = Deal();
            Console.WriteLine("\nYou were dealed a(n) " + playerCards[count] + ".\nYour new total is " + total + ".");

            if (total.Equals(21))
            {
                Console.WriteLine("\nYou got Blackjack! The dealer's total was " + dealerTotal + ".\nWould you like to play again?");
                all += currentBet * 2;
                Console.WriteLine("Your current balance is: " + all);
                PlayAgain();
            }
            else if (total > 21)
            {
                Console.WriteLine("\nYou busted, therefore you lost. Sorry. The dealer's total was " + dealerTotal + ".\nWould you like to play again? y/n");
                all -= currentBet;
                Console.WriteLine("Your current balance is: " + all);
                PlayAgain();
            }
            else if (total < 21)
            {
                do
                {
                    Console.WriteLine("\nWould you like to hit or stay? h for hit s for stay");
                    hitOrStay = Console.ReadLine().ToLower();
                }
                while (!hitOrStay.Equals("h") && !hitOrStay.Equals("s"));

                Game();
            }
        }

        public void PlayAgain()
        {
            string playAgain = "";

            do
            {
                playAgain = Console.ReadLine().ToLower();
            }
            while (!playAgain.Equals("y") && !playAgain.Equals("n"));

            if (playAgain.Equals("y"))
            {
                Console.WriteLine("\nPress enter to restart the game!");
                Console.ReadLine();
                Console.Clear();
                dealerTotal = 0;
                count = 1;
                total = 0;

                Main(all);
            }
            else if (playAgain.Equals("n"))
            {
                asd = true;
            }
        }

    }
}
