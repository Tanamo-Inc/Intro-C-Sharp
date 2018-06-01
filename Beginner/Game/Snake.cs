using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Game
{
    /*
    *A structure is a value type data type.
    *It helps you to make a single variable hold related data of various data types.
    *The struct keyword is used for creating a structure.
    */
    struct Position
    {
        public int row;
        public int col;

        public Position(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

    }


    /*
    *A structure stored on the stack, but a class is a reference type and is stored on the heap.
    *A Class supports both inheritance and Polymorphism but a Structure doesn't.
    *All the struct members are public by defaults but class members are private by defaults.
    */
    class Snake
    {
        static void Main(string[] args)
        {
            Logi();
      
        }


        private  static void Logi()
        {

            byte right = 0;
            byte left = 1;
            byte down = 2;
            byte up = 3;
            int lastFoodTime = 0;
            int foodDissapearTime = 8000;
            int negativePoints = 0;

            double sleepTime = 100;
            int direction = right;


            //****Generator****//
            Random generator = new Random();


            //****Directions****//
            Position[] dirx = new Position[]
            {
                new Position(0, 1), // right
                new Position(0, -1), // left
                new Position(1, 0), // down
                new Position(-1, 0), // up
            };

         
            Console.BufferHeight = Console.WindowHeight;
            lastFoodTime = Environment.TickCount;


            //****Obstacles****//
            List<Position> obs = new List<Position>()
            {
                new Position(12, 12),
                new Position(14, 20),
                new Position(7, 7),
                new Position(19, 19),
                new Position(6, 9),
            };
            foreach (Position obstacle in obs)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(obstacle.col, obstacle.row);
                Console.Write("#");
            }

            //****Body****//
            Queue<Position> body = new Queue<Position>();
            for (int i = 0; i <= 10; i++)
            {
                body.Enqueue(new Position(0, i));
            }

            Position food;
            do
            {
                food = new Position(generator.Next(0, Console.WindowHeight), generator.Next(0, Console.WindowWidth));
            }
            while (body.Contains(food) || obs.Contains(food));
            Console.SetCursorPosition(food.col, food.row);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("@");

            foreach (Position position in body)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("*");
            }

            while (true)
            {
                negativePoints++;

                if (Console.KeyAvailable)
                {
                    //Game Inputs
                    ConsoleKeyInfo gameInput = Console.ReadKey();

                    if (gameInput.Key == ConsoleKey.LeftArrow)
                    {
                        if (direction != right) direction = left;
                    }
                    if (gameInput.Key == ConsoleKey.RightArrow)
                    {
                        if (direction != left) direction = right;
                    }
                    if (gameInput.Key == ConsoleKey.UpArrow)
                    {
                        if (direction != down) direction = up;
                    }
                    if (gameInput.Key == ConsoleKey.DownArrow)
                    {
                        if (direction != up) direction = down;
                    }
                }

                Position snakeHead = body.Last();
                Position nextDirection = dirx[direction];

                Position snakeNewHead = new Position(snakeHead.row + nextDirection.row, snakeHead.col + nextDirection.col);

                if (snakeNewHead.col < 0) snakeNewHead.col = Console.WindowWidth - 1;
                if (snakeNewHead.row < 0) snakeNewHead.row = Console.WindowHeight - 1;
                if (snakeNewHead.row >= Console.WindowHeight) snakeNewHead.row = 0;
                if (snakeNewHead.col >= Console.WindowWidth) snakeNewHead.col = 0;

                if (body.Contains(snakeNewHead) || obs.Contains(snakeNewHead))
                {
                    Console.SetCursorPosition(0, 0);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game over!");
                    int userPoints = (body.Count - 6) * 100 - negativePoints;
                    //if (userPoints < 0) userPoints = 0;
                    userPoints = Math.Max(userPoints, 0);
                    Console.WriteLine("Your points are: {0}", userPoints);
                    return;
                }

                Console.SetCursorPosition(snakeHead.col, snakeHead.row);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("*");
                body.Enqueue(snakeNewHead);

                Console.SetCursorPosition(snakeNewHead.col, snakeNewHead.row);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (direction == right) Console.Write(">");
                if (direction == left) Console.Write("<");
                if (direction == up) Console.Write("^");
                if (direction == down) Console.Write("v");


                if (snakeNewHead.col == food.col && snakeNewHead.row == food.row)
                {
                    // feeding the snake
                    do
                    {
                        food = new Position(generator.Next(0, Console.WindowHeight),
                            generator.Next(0, Console.WindowWidth));
                    }
                    while (body.Contains(food) || obs.Contains(food));
                    lastFoodTime = Environment.TickCount;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("@");
                    sleepTime--;

                    Position obstacle = new Position();
                    do
                    {
                        obstacle = new Position(generator.Next(0, Console.WindowHeight),
                            generator.Next(0, Console.WindowWidth));
                    }
                    while (body.Contains(obstacle) ||
                        obs.Contains(obstacle) ||
                        (food.row != obstacle.row && food.col != obstacle.row));
                    obs.Add(obstacle);
                    Console.SetCursorPosition(obstacle.col, obstacle.row);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("#");
                }
                else
                {
                    // moving...
                    Position last = body.Dequeue();
                    Console.SetCursorPosition(last.col, last.row);
                    Console.Write(" ");
                }

                if (Environment.TickCount - lastFoodTime >= foodDissapearTime)
                {
                    negativePoints = negativePoints + 50;
                    Console.SetCursorPosition(food.col, food.row);
                    Console.Write(" ");
                    do
                    {
                        food = new Position(generator.Next(0, Console.WindowHeight),
                            generator.Next(0, Console.WindowWidth));
                    }
                    while (body.Contains(food) || obs.Contains(food));
                    lastFoodTime = Environment.TickCount;
                }

                Console.SetCursorPosition(food.col, food.row);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("@");

                sleepTime -= 0.01;

                Thread.Sleep((int)sleepTime);
            }



        }












    }
}
