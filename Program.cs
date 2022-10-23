using System;
using System.Numerics;

namespace TicTacCahllengeNet5
{
    internal class Program
    {
        static char[,] playField =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };
        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player, input);
                }
            
                do
                {
                    SetField();
                    //restarMap(playField);
            
                    if (horizontalCheckWinner() || verticalCheckWinner() || diagonalCheckWinner()
                            || diagonalInverseCheckWinner())
                    {
                        System.Environment.Exit(1);
                    }
                    Console.Write($"\nPlayer {player}: Choose your field! ");
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine()[0]);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Not an integer");
                    }
                } while (!inputCorrect);
            } while (true);
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("    |      |     ");
            Console.WriteLine(" {0}  |   {1}  |   {2}   ", playField[0,0], playField[0,1], playField[0, 2]);
            Console.WriteLine("____|______|______");
            Console.WriteLine("    |      |     ");
            Console.WriteLine(" {0}  |   {1}  |   {2}   ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine("____|______|______");
            Console.WriteLine("    |      |     ");
            Console.WriteLine(" {0}  |   {1}  |   {2}   ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("____|______|______");
            Console.WriteLine("    |      |     ");
            Console.WriteLine("    |      |     ");
            Console.WriteLine("    |      |     ");
        }

        public static void EnterXorO(int player, int input)
        {
            char value = (char)input;
            char playerSign = player == 1 ? 'X' : 'O';

            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    if (value.Equals(playField[i, j]))
                    {
                        playField[i, j] = playerSign;
                        //Console.WriteLine($"field[{i}][{j}]: {playField[i, j]}" );
                    }

                }
                    
            }
        }
        
        public static bool horizontalCheckWinner()
        {
            int xCounter = 0;
            int yCounter = 0;
            for (int i = 0; i < playField.GetLength(0); i++)
            {
                for (int j = 0; j < playField.GetLength(1); j++)
                {
                    if(playField[i, j] == 'X') xCounter++;
                    if(playField[i, j] == 'O') yCounter++;
                }
                xCounter = xCounter == 3 ? xCounter : 0;
                yCounter = yCounter == 3 ? yCounter : 0;
            }

            if (xCounter == 3)
            {
                Console.Write("\nPlayer 2 Wins! ");
                Console.ReadKey();
                return true;
            }
            if (yCounter == 3)
            {
                Console.Write("\nPlayer 1 Wins! ");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        public static bool verticalCheckWinner()
        {
            int xCounter = 0;
            int yCounter = 0;
            //Vertical checking
            for (int j = 0; j < playField.GetLength(0); j++)
            {
                for (int i = 0; i < playField.GetLength(1); i++)
                {
                    if (playField[i, j] == 'X') xCounter++;
                    if (playField[i, j] == 'O') yCounter++;
                }
                xCounter = xCounter == 3 ? xCounter : 0;
                yCounter = yCounter == 3 ? yCounter : 0;
            }

            if (xCounter == 3)
            {
                Console.Write("\nPlayer 2 Wins! ");
                Console.ReadKey();
                return true;
            }
            if (yCounter == 3)
            {
                Console.Write("\nPlayer 1 Wins! ");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        public static bool diagonalCheckWinner()
        {
            int xCounter = 0;
            int yCounter = 0;
            //diagonal izquierda derecha
            for (int i = 0, j = 0; i < playField.GetLength(0); i++, j++)
            {
                if (playField[i, j] == 'X') xCounter++;
                if (playField[i, j] == 'O') yCounter++;
            }

            if (xCounter == 3)
            {
                Console.Write("\nPlayer 2 Wins! ");
                Console.ReadKey();
                return true;
            }
            if (yCounter == 3)
            {
                Console.Write("\nPlayer 1 Wins! ");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        public static bool diagonalInverseCheckWinner()
        {
            int xCounter = 0;
            int yCounter = 0;
            //diagonal izquierda derecha
            for (int i = 0, j = 2; i < playField.GetLength(0); i++, j--)
            {
                if (playField[i, j] == 'X') xCounter++;
                if (playField[i, j] == 'O') yCounter++;
            }

            if (xCounter == 3)
            {
                Console.Write("\nPlayer 2 Wins! ");
                Console.ReadKey();
                return true;
            }
            if (yCounter == 3)
            {
                Console.Write("\nPlayer 1 Wins! ");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        public static void restarMap(char[,] playField)
        {
            char[,] map = {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };
            playField = map;
        }
    }
}
