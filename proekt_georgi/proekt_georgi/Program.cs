using System;
using System.Speech.Synthesis;
using System.Threading;

namespace Blackjack
{
    class Blackjack
    {      
        static void Main(string[] args)
        {
            using (SpeechSynthesizer synth = new System.Speech.Synthesis.SpeechSynthesizer())
            {
                Console.Title = "Blackjack";
                Console.WriteLine("Please enter your name followed by a comma then the number of the talbe");
                synth.Speak("Please enter your name followed by a comma then the number of the talbe");
                string bjtn = Console.ReadLine();
                Console.Clear();
                Console.Title = bjtn;
            }

            Console.Write("Please enter your balance: ");
            double balance = double.Parse(Console.ReadLine());

            Start start = new Start();
            start.Main(balance);          
        }        
    }
}