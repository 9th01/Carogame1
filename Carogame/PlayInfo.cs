using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Carogame
{
    public class PlayInfo
    {
        private Point point;

        public Point Point
        {
            get { return point; }
            set { point = value; }

        }
 private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

       
        public PlayInfo(Point point, int CurrentPlayer)
        {
            this.Point = point;
            this.CurrentPlayer = currentPlayer;
        }
    }
}
