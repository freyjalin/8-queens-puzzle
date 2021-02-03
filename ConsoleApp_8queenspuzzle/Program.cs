using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_8queenspuzzle
{
    class Program
    {
        const int N = 8;
        static void Main(string[] args)
        {
            int count = 0;
            string[,] board = new string[N, N];


            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = ".";
                }
            }

            int[] pointer = new int[N];
            for (int i = 0; i < N; i++)
            {
                pointer[i] = -1;
            }

            for (int j = 0; ;)
            {
                pointer[j]++;

                if (pointer[j] == N)
                {
                    board[pointer[j] - 1, j] = ".";
                    pointer[j] = -1;
                    j--;
                    if (j == -1)
                    {
                        Console.WriteLine("Done.");
                        break;
                    }
                }
                else
                {
                    board[pointer[j], j] = "Q";
                    if (pointer[j] != 0)
                    {
                        board[pointer[j] - 1, j] = ".";
                    }
                    if (SolutionCheck(board))
                    {
                        j++;
                        if (j == N)
                        {
                            j--;
                            count++;
                            Console.WriteLine("Solution" + count.ToString() + ":");
                            for (int p = 0; p < N; p++)
                            {
                                for (int q = 0; q < N; q++)
                                {
                                    Console.Write(board[p, q] + " ");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            Console.ReadKey();
        }
        public static bool SolutionCheck(string[,] board)
        {
            //Row check
            for (int i = 0; i < N; i++)
            {
                int checkSum = 0;
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == "Q") {
                        checkSum++;
                    }
                    
                }
                if (checkSum > 1)
                {
                    return false;
                }
            }
            //Main diagonal check
            //above
            for (int i = 0, j = N - 2; j >= 0; j--)
            {
                int checkSum = 0;
                for (int p = i, q = j; q < N; p++, q++)
                {
                    if (board[p, q] == "Q")
                    {
                        checkSum++;
                    }
                    
                }
                if (checkSum > 1)
                {
                    return false;
                }
            }
            //below
            for (int i = 1, j = 0; i < N - 1; i++)
            {
                int checkSum = 0;
                for (int p = i, q = j; p < N; p++, q++)
                {
                    if (board[p, q] == "Q")
                    {
                        checkSum++;
                    }
                }
                if (checkSum > 1)
                {
                    return false;
                }
            }
            //Minor diagonal check
            //above
            for (int i = 0, j = 1; j < N; j++)
            {
                int checkSum = 0;
                for (int p = i, q = j; q >= 0; p++, q--)
                {
                    if (board[p, q] == "Q")
                    {
                        checkSum++;
                    }
                }
                if (checkSum > 1)
                {
                    return false;
                }
            }
            //below
            for (int i = 1, j = N - 1; i < N - 1; i++)
            {
                int checkSum = 0;
                for (int p = i, q = j; p < N; p++, q--)
                {
                    if (board[p, q] == "Q")
                    {
                        checkSum++;
                    }
                }
                if (checkSum > 1)
                {
                    return false;
                }
            }
            return true;
        }
    }


}
