using System.Security.AccessControl;

namespace SelectionStatementExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            GuessingGame(GamePrep());
            GetUserFavoriteSubject();

            Print("Press enter to end the program.\n");
            GetLine();
        }

        static int GamePrep()
        {
            // Avoiding magic numbers
            int favNum = 13;
            int randNum = new Random().Next(1000);

            Print("Would you like to guess my favorite number or would you\n"
                + "like to try guessing a random positive number of my choice?\n"
                + "[F]avorite | [R]andom:\n");

            string userChoice = GetLine().ToLower();

            while (!userChoice.Equals("f") && !userChoice.Equals("r"))
            {
                Print("Please only reply with 'F' or 'R'.\n");
                userChoice = GetLine().ToLower();
            }

            if (userChoice.Equals("f"))
                return favNum;
            else
                return randNum;
        }

        static void GuessingGame(int answer)
        {
            Print("Please input your guess:");

            int userGuess = 0;

            while (userGuess != answer)
            {
                while (!int.TryParse(GetLine(), out userGuess))
                {
                    Print("Pleae input an integer.\n");
                }

                if (userGuess < answer)
                    Print("Incorrect! Your guess was too low.\n");

                if (userGuess > answer)
                    Print("Incorrect! Your guess was too high.\n");
            }

            Print("You guessed it!\n");
        }

        static void GetUserFavoriteSubject()
        {
            Print("Since we're here, what is your favorite subject?\n"
                + "Art, History, Gym, Math, Science, or something else?\n");

            switch(GetLine().ToLower())
            {
                case "art": Print("Have you heard of the artist Camille Pissarro? He's very good!\n"); break;
                case "history": Print("Have you heard of Simo Häyhä? If not, you should research him!\n"); break;
                case "gym": Print("Gym huh? You must know of Louis Uni then!\n"); break;
                case "math": Print("You must be a big fan of Josiah Willard Gibbs and Oliver Heaviside then!\n"); break;
                case "science": Print("You should check out Dr. Enrico Camporeale's work if you haven't!\n"); break;
                default: Print("Interesting choice!\n"); break;
            }
        }

        static void Print(string text)
        {
            Console.Write(text);
        }

        static string GetLine()
        {
            return Console.ReadLine();
        }
    }
}
