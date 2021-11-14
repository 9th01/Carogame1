using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Carogame
{
    public class chessboardManegerBase1
    {
        
        private List<Player> players;
        private int currentPlayer;

        public int CurrentPlayer {
            get => currentPlayer; 
            set => currentPlayer = value; 
        }
        private TextBox playerName; 
        public TextBox PlayerName { get => playerName; 
            set => playerName = value; }
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
      

        private PictureBox playerMark;

        private List<List<Button>> matrix;
  public List<List<Button>> Matrix { get => matrix; 
            set => matrix = value; }
        public List<Player> Players { get => players; set => players = value; }
    }


}