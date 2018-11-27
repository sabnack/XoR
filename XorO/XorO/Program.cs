using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorO
{
    class Program
    {
        static void Main(string[] args)
        {
            const int z = 3;
            int[,] arr0 = new int[z, z];
            int x = 0;
            int y = 0;
            int[,] arrX = new int[z, z];
            int step = 0;
            int count = 0;
            
            ConsoleKeyInfo info;
            do
            {
                Console.Clear();

                print(x, y, z, arr0, arrX, step);
                if (testWin(arr0,arrX)==1)
                {
                    Console.WriteLine("Выиграл первый игрок");
                    break;
                }
                if(testWin(arr0, arrX) == 2)
                {
                    Console.WriteLine("выиграл второй игрок");
                    break;
                }

                if (count == 9)
                {
                    Console.WriteLine("Ничья!");
                    break;
                }

                info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Enter)
                {
                    
                    if (arrX[x, y] == 1 || arr0[x, y] == 1)
                    {
                        continue;
                    }
                    else
                    { 
                        if (step % 2 == 0)
                        {
                            
                                arrX[x, y] = 1;
                                count++;
                        }
                        else
                        {
                                arr0[x, y] = 1;
                                count++;
                        }
                        step++;
                    }
                }

                if (info.Key == ConsoleKey.RightArrow)
                {
                    if (testcoordinates(x, y + 1, z))
                    {
                        continue;
                    }
                    y++;
                }
                if (info.Key == ConsoleKey.LeftArrow)
                {
                    if (testcoordinates(x, y - 1, z))
                    {
                        continue;
                    }
                    y--;
                }
                if (info.Key == ConsoleKey.DownArrow)
                {
                    if (testcoordinates(x + 1, y, z))
                    {
                        continue;
                    }
                    x++;
                }
                if (info.Key == ConsoleKey.UpArrow)
                {
                    if (testcoordinates(x - 1, y, z))
                    {
                        continue;
                    }
                    x--;
                }
            } while (info.Key != ConsoleKey.Escape);

        }
        static bool testcoordinates(int x, int y, int z)
        {
            if (x == z || y == z || x < 0 || y < 0) return true;
            return false;
        }
        static int testWin(int[,] arr0, int[,] arrX)
        {
            if (arrX[0, 0] + arrX[1, 1] + arrX[2, 2] == 3) return 1;
            if (arr0[0, 0] + arr0[1, 1] + arr0[2, 2] == 3) return 2;
            if (arrX[2, 0] + arrX[1, 1] + arrX[0, 2] == 3) return 1;
            if (arr0[2, 0] + arr0[1, 1] + arr0[0, 2] == 3) return 2;
            if (arrX[0, 0] + arrX[0, 1] + arrX[0, 2] == 3) return 1;
            if (arr0[0, 0] + arr0[0, 1] + arr0[0, 2] == 3) return 2;
            if (arrX[1, 0] + arrX[1, 1] + arrX[1, 2] == 3) return 1;
            if (arr0[1, 0] + arr0[1, 1] + arr0[1, 2] == 3) return 2;
            if (arrX[2, 0] + arrX[2, 1] + arrX[2, 2] == 3) return 1;
            if (arr0[2, 0] + arr0[2, 1] + arr0[2, 2] == 3) return 2;
            if (arrX[0, 0] + arrX[1, 0] + arrX[2, 0] == 3) return 1;
            if (arr0[0, 0] + arr0[1, 0] + arr0[2, 0] == 3) return 2;
            if (arrX[0, 1] + arrX[1, 1] + arrX[2, 1] == 3) return 1;
            if (arr0[0, 1] + arr0[1, 1] + arr0[2, 1] == 3) return 2;
            if (arrX[0, 2] + arrX[1, 2] + arrX[2, 2] == 3) return 1;
            if (arr0[0, 2] + arr0[1, 2] + arr0[2, 2] == 3) return 2;

            return 0;
        }
        static void print(int x, int y, int z, int[,] arr0, int[,] arrX, int step)
        {
            Console.WriteLine("┌─┬─┬─┐");
            for (int i = 0; i < z; i++)
            {
                if (i!=0) Console.WriteLine("├─┼─┼─┤");
                for (int j = 0; j < z; j++)
                {
                    Console.Write("│");
                    if (arrX[i, j] == 1) Console.Write("X");
                    else if (arr0[i, j] == 1) Console.Write("0");
                    else if (i == x && j == y) Console.Write("*");
                    else Console.Write(" ");
                }
                Console.Write("│");
                if (i == 0)
                {
                    if (step % 2 == 0)
                        Console.Write("   Ходит Первый игрок - X");
                    else Console.Write("   Ходит Второй игрок - O");
                }
                
                Console.WriteLine();
            }
            Console.WriteLine("└─┴─┴─┘");
        }
    }
}
