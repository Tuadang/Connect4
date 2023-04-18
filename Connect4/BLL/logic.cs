using static Connect4.View.view;

namespace Connect4.Classes
{
    public class logic
    {
        public bool checkDimensions(int rows, int columns)
        {
            if (rows >= 4 && rows <= 10 && columns >= 4 && columns <= 10) { return true; }
            else { return false; }
        }

        public static int FullBoard(char[,] board, int columns)
        {
            int full = 0;
            for (int i = 0; i <= columns; ++i)
            {
                if (board[1, i] != '*')
                {
                    ++full;
                }
            }

            return full;
        }

        public static int CheckFour(char[,] board, playerInfo activePlayer, int rows, int columns)
        {
            char XO = activePlayer.playerID;
            int win = 0;

            for (int i = rows; i >= 1; --i)
            {

                for (int ix = columns; ix >= 1; --ix)
                {

                    if (board[i, ix] == XO &&
                        board[i - 1, ix - 1] == XO &&
                        board[i - 2, ix - 2] == XO &&
                        board[i - 3, ix - 3] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                        board[i, ix - 1] == XO &&
                        board[i, ix - 2] == XO &&
                        board[i, ix - 3] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                        board[i - 1, ix] == XO &&
                        board[i - 2, ix] == XO &&
                        board[i - 3, ix] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                        board[i - 1, ix + 1] == XO &&
                        board[i - 2, ix + 2] == XO &&
                        board[i - 3, ix + 3] == XO)
                    {
                        win = 1;
                    }

                    if (board[i, ix] == XO &&
                         board[i, ix + 1] == XO &&
                         board[i, ix + 2] == XO &&
                         board[i, ix + 3] == XO)
                    {
                        win = 1;
                    }
                }

            }

            return win;
        }

        public static void CheckBellow(char[,] board, playerInfo activePlayer, int dropChoice, int row)
        {
            int turn = 0;

            do
            {
                if (board[row - 1, dropChoice] != 'X' && board[row - 1, dropChoice] != 'O')
                {
                    board[row - 1, dropChoice] = activePlayer.playerID;
                    turn = 1;
                }
                else
                {
                    --row;
                }
            } while (turn != 1);
        }
    }
}
