using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Carogame
{
   public class Player
    {
        private string name; //ctrl + R +E ( để sinh ra hàm đóng gói )

        public string Name { 
            get => name;
            set => name = value; }
       

        private Image Mark; 
        public Image Mark1 { get => Mark; set => Mark = value; }
        public Player(string name , Image Mark)
        {
            this.Name = name;
            this.Mark1= Mark;
        }
    }

   
}
