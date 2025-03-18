namespace BoardGames
{
    internal class Program
    {

        static void Main()
        {
            Console.Clear();
            int x = 0;
            Console.WriteLine("HEY! Welcomer ot my collection of Board Games!");
            Console.WriteLine("Which one would you like to play?");
            Console.WriteLine("\n");
            Console.WriteLine("(1) Tic Tac Toe");
            Console.WriteLine("(2) Connect Four");
            string choice = Console.ReadLine();
            try
            {
                x = Convert.ToInt32(choice);
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                Main();
            }

            if (x == 1)
            {
                TicTacToe game = new TicTacToe(3, 3);
                game.GameStart();
            }
            else if(x == 2)
            {
                ConnectFour game = new ConnectFour(7, 6);
                game.GameStart();
            }
            else
            {
                Console.WriteLine("Invalid Input");
                Thread.Sleep(1000);
                Main();
            }

        }
    }
}