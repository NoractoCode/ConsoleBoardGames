namespace BoardGames
{
    internal class Program
    {

        static void Main()
        {

            int x = 0;

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
                if (choice.ToLower() == "exit")
                {
                    break;
                }
                else
                {
                    try
                    {
                        x = Convert.ToInt32(choice);
                    }
                    catch { }
                    if (x == 1)
                    {
                        TicTacToe game = new TicTacToe(3, 3);
                        game.GameStart();
                    }
                    else if (x == 2)
                    {
                        ConnectFour game = new ConnectFour(7, 6);
                        game.GameStart();
                    }
                    else if (x == 3)
                    {
                        Othello game = new Othello(8, 8);
                        game.GameStart();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        Thread.Sleep(1000);
                    }
                }
                x = 0;
            }
            while (x == 0);
        }
    }
}