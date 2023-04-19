using System.Data.Common;
using System.Numerics;
using static Connect4.View.view;

namespace Connect4.Classes
{
    public class logic
    {
        public bool CheckDimensions(int rows, int columns)
        {
            if (rows >= 4 && rows <= 10 && columns >= 4 && columns <= 10) { return true; }
            else { return false; }
        }

        public static int FullBoard(char[,] board, int columns)
        {
            int full = 0;

            for (int i = 0; i < columns; ++i)
            {
                if (board[1, i] != '*')
                {
                    full++;
                }
            }
            return full;
        }

        public static bool CheckFour(char[,] board, playerInfo activePlayer, int rows, int columns)
        {
            char XO = activePlayer.playerID;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Horizontal
                    if (i + 3 < columns)
                    {
                        if (board[i, j] == XO &&
                            board[i + 1, j] == XO &&
                            board[i + 2, j] == XO &&
                            board[i + 3, j] == XO)
                        { return true; }
                    }

                    // Vertical 
                    if (j + 3 < columns)
                    {
                        if (board[i, j] == XO &&
                            board[i, j + 1] == XO &&
                            board[i, j + 2] == XO &&
                            board[i, j + 3] == XO)
                        { return true; }
                    }

                    // Diagonal up
                    if (i - 3 >= 0 && j + 3 < columns)
                    {
                        if (board[i, j] == XO &&
                        board[i - 1, j + 1] == XO &&
                        board[i - 2, j + 2] == XO &&
                        board[i - 3, j + 3] == XO)
                        { return true; }
                    }

                    // Diagonal down
                    if (i + 3 < columns && j + 3 < rows)
                    {
                        if (board[i, j] == XO &&
                        board[i + 1, j + 1] == XO &&
                        board[i + 2, j + 2] == XO &&
                        board[i + 3, j + 3] == XO)
                        { return true; }
                    }
                }
            }

            return false;
        }

        public static void CheckBellow(char[,] board, playerInfo activePlayer, int dropChoice, int row)
        {
            bool able = false;

            do
            {
                if (board[row - 1, dropChoice] != 'X' && board[row - 1, dropChoice] != 'O')
                {
                    board[row - 1, dropChoice] = activePlayer.playerID;
                    able = true;
                }
                else
                {
                    --row;
                }
            } while (able == false);
        }
    }
}
