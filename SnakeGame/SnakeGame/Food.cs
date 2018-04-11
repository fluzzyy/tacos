using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SnakeGame
{
    public class Food
    {
        public Rectangle Piece;
        private int x, y, width = 10, height = 10;

        public Food(Random rand)
        {
            generate(rand);
            Piece=new Rectangle(x,y, width,height);
        }

        public void draw(Graphics graphics)
        {
            Piece.X = x;
            Piece.Y = y;
            graphics.FillRectangle(Brushes.Black,Piece);
        }

        public void generate(Random rand)
        {
            x = rand.Next(0, 30) * 10;
            y = rand.Next(0, 20) * 10;
        }
    }
}
