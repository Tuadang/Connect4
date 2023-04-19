using Connect4.Classes;

namespace Connect4.View
{
    public class view
    {
        public struct playerInfo
        {
            public String playerName;
            public char playerID;
        };

        public playerInfo playerOne = new playerInfo();
        public playerInfo playerTwo = new playerInfo();
        public char[,] board = new char[9, 10];
        public int dropChoice, full, again, rows = 6, columns = 7;
        public logic logic = new logic();
        public string strRows, strColumns;
        public bool win = false;

        public void startGame()
        {
            Console.WriteLine("Let's Play Connect 4");

            do
            {
                Console.WriteLine("How big do you want the field? (min 4x4, max 10x10)");

                // Ask for amount of rows user would like and check if input is an int
                do
                {
                    Console.Write("How many rows would you like: ");
                    strRows = Console.ReadLine();
                }
                // Loop untill user types stop
                while (!int.TryParse(strRows, out rows));

                // Ask for amount of columns user would like and check if input is an int
                do
                {
                    Console.Write("How many columns would you like: ");
                    strColumns = Console.ReadLine();
                }
                // Loop untill user types stop
                while (!int.TryParse(strColumns, out columns));

                if (logic.CheckDimensions(rows, columns))
                {
                    board = new char[rows, columns];
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a valid playing field.");
                    Console.WriteLine();
                }
            }
            // Check dimensions in the logic layer
            while (!logic.CheckDimensions(rows, columns));

            Console.WriteLine("Player One please enter your name: ");
            playerOne.playerName = Console.ReadLine();
            playerOne.playerID = 'X';

            Console.WriteLine("Player Two please enter your name: ");
            playerTwo.playerName = Console.ReadLine();
            playerTwo.playerID = 'O';

            full = 0;
            again = 0;

            DisplayBoard(board, rows, columns);

            do
            {
                dropChoice = PlayerDrop(board, playerOne, columns);
                logic.CheckBellow(board, playerOne, dropChoice, rows);

                DisplayBoard(board, rows, columns);

                win = logic.CheckFour(board, playerOne, rows, columns);

                if (win)
                {
                    PlayerWin(playerOne);
                    again = restart(board);
                    if (again == 2)
                    {
                        break;
                    }
                }

                dropChoice = PlayerDrop(board, playerTwo, columns);
                logic.CheckBellow(board, playerTwo, dropChoice, rows);

                DisplayBoard(board, rows, columns);

                win = logic.CheckFour(board, playerTwo, rows, columns);

                if (win)
                {
                    PlayerWin(playerTwo);
                    again = restart(board);
                    if (again == 2)
                    {
                        break;
                    }
                }

                full = logic.FullBoard(board, columns);

                if (full == 7)
                {
                    Console.WriteLine("The board is full, it is a draw!");
                    again = restart(board);
                }

            } while (again != 2);
        }

        static int PlayerDrop(char[,] board, playerInfo activePlayer, int columns)
        {
            int dropChoice;

            Console.WriteLine(activePlayer.playerName + "'s Turn ");
            do
            {
                Console.WriteLine($"Please enter a number between 1 and {columns}: ");
                dropChoice = Convert.ToInt32(Console.ReadLine()) - 1;
            } while (dropChoice < 1 || dropChoice > 7);

            while (board[1, dropChoice] == 'X' || board[1, dropChoice] == 'O')
            {
                Console.WriteLine("That row is full, please enter a new row: ");
                dropChoice = Convert.ToInt32(Console.ReadLine());
            }

            return dropChoice;
        }

        static void DisplayBoard(char[,] board, int rows, int columns)
        {
            int i, ix;

            for (i = 0; i < rows; i++)
            {
                Console.Write("|");
                for (ix = 0; ix < columns; ix++)
                {
                    if (board[i, ix] != 'X' && board[i, ix] != 'O')
                        board[i, ix] = '*';

                    Console.Write(board[i, ix]);

                }

                Console.Write("| \n");
            }

        }

        static void PlayerWin(playerInfo activePlayer)
        {
            Console.WriteLine(activePlayer.playerName + " Connected Four, You Win!");
        }

        static int restart(char[,] board)
        {
            int restart;

            Console.WriteLine("Would you like to restart? Yes(1) No(2): ");
            restart = Convert.ToInt32(Console.ReadLine());
            if (restart == 1)
            {
                for (int i = 1; i <= 6; i++)
                {
                    for (int ix = 1; ix <= 7; ix++)
                    {
                        board[i, ix] = '*';
                    }
                }
            }
            else
                Console.WriteLine("Goodbye!");
            return restart;
        }
    }
}