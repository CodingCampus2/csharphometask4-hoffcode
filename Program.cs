using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static char CELL_ALIVE = '1';
        static char CELL_DEAD = '0';

        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                char[,] initialBoard = task.Board;
                char[,] board = (char[,])initialBoard.Clone();

                int height = board.GetLength(1);
                int width = board.GetLength(0);

                for (int y = 0; y < height; ++y)
                {
                    for (int x = 0; x < width; ++x)
                    {
                        board[x, y] = ProcessCell(x, y, initialBoard);
                    }
                }

                return board;
            };

            Task4.CheckSolver(TaskSolver);
        }

        static int CountAliveNeighbors(int x, int y, char[,] board)
        {
            int height = board.GetLength(1);
            int width = board.GetLength(0);

            int count = 0;

            for (int i = -1; i < 2; ++i)
            {
                for (int j = -1; j < 2; ++j)
                {
                    int currentX = x + i;
                    int currentY = y + j;

                    if (currentX >= 0 && currentX < width
                        && currentY >= 0 && currentY < height
                        && !(i == 0 && j == 0))
                    {
                        if (board[currentX, currentY] == CELL_ALIVE)
                        {
                            ++count;
                        }
                    }
                }
            }

            return count;
        }

        static char ProcessCell(int x, int y, char[,] board)
        {
            int aliveNeighbors = CountAliveNeighbors(x, y, board);

            if (board[x, y] == CELL_ALIVE)
            {
                if (aliveNeighbors < 2 || aliveNeighbors > 3)
                {
                    return CELL_DEAD;
                }
                else
                {
                    return CELL_ALIVE;
                }
            }
            else
            {
                if (aliveNeighbors == 3)
                {
                    return CELL_ALIVE;
                }
                else
                {
                    return CELL_DEAD;
                }
            }
        }
    }
}
