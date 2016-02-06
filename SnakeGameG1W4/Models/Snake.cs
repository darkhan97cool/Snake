using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameG1W4.Models
{
    public class Snake : Drawer
    {
        public Snake()
        {
            color = ConsoleColor.Green;
            sign = 'o';
        }

        public void move(int dx, int dy)
        {



            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            //Если  змея уходит за пределы карты
            //то сделать так чтобы она появилась с противоположной стороны
            if (body[0].x + dx < 0) dx = dx + 48;
            if (body[0].y + dy < 0) dy = dy + 48;
            if (body[0].x + dx > 48) dx = dx - 48;
            if (body[0].y + dy > 48) dy = dy - 48;
            body[0].x += dx;
            body[0].y += dy;

            for (int i = 0; i < Game.wall.body.Count; i++)
            {
                if (body[0].x == Game.wall.body[i].x &&
                    body[0].y == Game.wall.body[i].y)
                {
                    Game.GameOver = true;
                    Console.ReadKey();
                }
            }

            // checking eating food
            if (body[0].x == Game.food.body[0].x &&
                body[0].y == Game.food.body[0].y)
            {
                Game.foodeaten++;
                //проверка вдруг мы сьели 4 с предыдущего
                if (Game.foodeaten % 4 - 1 == 0)
                    
                {
                    Console.WriteLine("YOU WON 1 level!!!");
                    Console.ReadKey();
                    Game.wall = new Wall(Game.foodeaten / 4 + 1);
                    


                    Game.snake = new Snake();
                    Game.food = new Food();
                    Game.food.NewRandomPosition();
                    Game.snake.body.Add(new Point(0, 0));
                    //    Program.game.Init();
                }
                Console.ReadKey();

                Game.food.NewRandomPosition();
                body.Add(new Point(0, 0));
            }

        }

    }
}
