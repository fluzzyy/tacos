using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;

namespace SnakeGame
{
   public class Snake
   {
       public Rectangle[] Body;
       private int x = 0, y = 0, width = 10, height = 10;

       public Snake()
       {
           
       }

       public void Draw()
       {

       }

       public void Draw(Graphics graphics)
       {

       }

       public void Move(int direction)
       {

       }

       public void Grow()
       {
           List<Rectangle> temp = Body.ToList();
           temp.Add((new Rectangle(Body[Body.Length-1].X,Body[Body.Length-1].Y,width,height)));
           Body = Body.ToArray();
       }
   }
}
