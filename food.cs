using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGameG1W4.Models
{
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Yellow;
            sign = '$';
        }
        public void NewRandomPosition()
        {
            int x = new Random().Next(0,20)  ;
            int y = new Random().Next(0,20)  ;

            bool foodPaste = false;
            while(!foodPaste)
            {
                 x = new Random().Next(0, 20);
                 y = new Random().Next(0, 20);
                foodPaste = true;
                 

                for(int i = 0; i< Game.wall.body.Count; i++)
                {
                    if(x == Game.wall.body[i].x &&
                        y == Game.wall.body[i].y)
                    {
                        foodPaste = false;
                        break;
                    }
                }
            }

            if (body.Count == 0)
                body.Add(new Point(x, y));
            else {
                body[0].x = x;
                body[0].y = y;
            }

        }
    }
}