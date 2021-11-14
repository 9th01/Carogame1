using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Carogame
{
    [Serializable]
    class SocketData
    {
        private int command;

        public int Command { get => command; set => command = value; }

        private Point point;
         public Point Point
        {
            get { return point; }
            set { point = value;  }
        }

        public string Message { get => message; set => message = value; }

        private string message;

        public SocketData ( int command,String message , Point point )
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
        }

    }
    public enum SocketCommand
    {
        SEND_POINT,
        NOTYF,
        NEW_GAME,
        RQ_NEWGAME,
        QUIT,
        END_GAME,
        TIME_OUT,
        START   
    }
    

}
