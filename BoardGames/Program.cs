namespace BoardGames
{
    internal class Program
    {

        static void Main()
        {

            bool loop = true;

            do
            {
                Console.Clear();
                Console.WriteLine("\n");
                Console.WriteLine("HEY! Welcome to my collection of Board Games!");
                Console.WriteLine("Which one would you like to play?");
                Console.WriteLine("\n");
                Console.WriteLine("Type 'exit' to leave");
                Console.WriteLine("\n");
                Console.WriteLine("(1) Tic Tac Toe");
                Console.WriteLine("(2) Connect Four");
                Console.WriteLine("(3) Othello");
                string choice = Console.ReadLine();

                switch (choice.ToLower())
                {
                    case "1":
                        TicTacToe gameOne = new TicTacToe(3, 3);
                        gameOne.GameStart();
                        break;
                    case "2":
                        ConnectFour gameTwo = new ConnectFour(7, 6);
                        gameTwo.GameStart();
                        break;
                    case "3":
                        Othello gameThree = new Othello(8, 8);
                        gameThree.GameStart();
                        break;
                    case "exit":
                        loop = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            while (loop == true);
        }
    }
}