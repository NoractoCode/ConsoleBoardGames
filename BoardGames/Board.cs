namespace BoardGames
{
    public class Board
    {
        private int X { get; set; } // Boards X Value
        private int Y { get; set; } // Boards Y Value (Max 26)
        public string[] Grid { get; set; } // Grid Values (Max of 999 Spaces)
        private bool Numbers { get; set; } // Turn Grid Numbers on or Off
        private bool Initialize = true; // Set to true until initial setup is complete.
        public Board(int x, int y, string[] grid, bool numbers)
        {
            X = x;
            Y = y;
            Grid = grid;
            Numbers = numbers;
        }

        public virtual void InitializeBoard()
        {
            int z;
            do
            {
                for (z = 0; z < Grid.Length; ++z)
                {
                    if (Numbers == true && Initialize == true) //Writes Numbers inside of Grid if enabled
                    {
                        if (z + 1 < 10)
                        {
                            Grid[z] = $" {z + 1} ";
                        }
                        else if (z + 1 < 100)
                        {
                            Grid[z] = $" {z + 1}";
                        }
                        else if (z + 1 < 1000)
                        {
                            Grid[z] = $"{z + 1}";
                        }
                    }
                    else if (Numbers == false && Initialize == true)
                    {
                        for (z = 0; z < Grid.Length; ++z)
                        {
                            Grid[z] = "   ";
                        }
                    }
                }
            }
            while (z < Grid.Length);
            Initialize = false;
        }

        public virtual void BoardState() //Generates Game Board via x and y axis input and adds an array of changeable string variables for game engine
        {
            int z, column = X, rows = 1, line = 1, num = 1, x, y;
            x = X;
            y = Y;
            char[] letter = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            int rowNumber = 0;

            Console.Write(" "); // writes numbers above board dependant on boards X value
            for (z = (x - column); z < x; ++z)
            {
                if (num < 10)
                {
                    Console.Write($"  {num} ");
                    ++num;
                }
                else
                {
                    Console.Write($"  {num}");
                    ++num;
                }


            }
            Console.WriteLine("");
            Console.Write(" ");
            for (z = (x - column); z < x; ++z)
            {
                Console.Write("╦═══");
            }
            Console.WriteLine("╦");
            do
            {
                Console.Write($"{letter[rowNumber]}"); // Writes Letters along board dependant on boards Y value
                ++rowNumber;
                for (z = (x - column); z < x; ++z)
                {
                    Console.Write("║");
                    Console.Write(Grid[z]);
                }
                Console.WriteLine("║");
                Console.Write(" ");
                if (line < y)
                {

                    for (z = (x - column); z < x; ++z)
                    {
                        Console.Write("╬═══");
                    }
                    Console.WriteLine("╬");
                    line++;
                }
                else
                {

                    for (z = (x - column); z < x; ++z)
                    {
                        Console.Write("╩═══");
                    }
                    Console.WriteLine("╩");
                }

                rows = rows + 1;
                x = x + X;
            }
            while (rows <= y);
            Initialize = false; // Disaples overwriting of Grid[] Values
        }
    }
}
