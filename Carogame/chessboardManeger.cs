using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Carogame
{
    public class ChessboardManeger : chessboardManegerBase1
    {
        #region Properties 
        private Panel chessboard;

        public Panel Chessboard
        {
            get { return chessboard; }
            set { chessboard = value; }
        }
        private int currentPlayer;
        private PictureBox playerMark;
        private TextBox playerName { get; }

        public List<Player> Player { get; }
        private List<List<Button>> matrix;
        private event EventHandler < ButtonClickEvent> playerMarks;
        public event EventHandler<ButtonClickEvent> PlayerMarks
        {
            add
            {
                playerMarks += value;
            }
            remove
            {
                playerMarks -= value;
            }
        }


        private event EventHandler endGames;
        public event EventHandler EndGames
        {
            add
            {
                endGames += value;
            }
            remove
            {
                endGames -= value;
            }
        }
        private Stack<PlayInfo> PlayTimeLine;
        public Stack<PlayInfo> playTimeLine
        {
            get { return PlayTimeLine; }
            set
            {
                PlayTimeLine = value;
            }
        }


        #endregion

        #region Initialize
        public ChessboardManeger(Panel chessboard, TextBox playerName, PictureBox playerMark)
        {
            this.chessboard = chessboard;
            this.playerName = playerName;
            this.playerMark = playerMark;
            this.Player = new List<Player>() {
             new Player (" Phúc", Image.FromFile(Application.StartupPath + "\\Resources\\p1.png")),
                          new Player (" Ngọc", Image.FromFile(Application.StartupPath + "\\Resources\\p2.png"))
            };

        }




        #endregion

        #region Methods        
        //tạo bàn cờ

        public void DrawChessBoard()
        {
            chessboard.Enabled = true;
            chessboard.Controls.Clear();
            PlayTimeLine = new Stack<PlayInfo>();

            currentPlayer = 0;
            ChangePlayer();





            matrix = new List<List<Button>>();
            Button oldButton = new Button()
            {
                Width = 0,
                Location = new Point(0, 0)
            };
            for (int i = 0; i < cons.CHESS_BOARD_HEIGHT; i++)
            {
                matrix.Add(new List<Button>());

                for (int j = 0; j < cons.CHESS_BOARD_WIDTH; j++)
                {

                    Button btn = new Button()
                    {
                        Width = cons.CHESS_WIDH,
                        Height = cons.CHESS_HEIGHT,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y)
                        ,
                        BackgroundImageLayout = ImageLayout.Stretch,
                        Tag = i.ToString()
                    };
                    btn.Click += btn_click;
                    chessboard.Controls.Add(btn);
                    matrix[i].Add(btn);
                    oldButton = btn;
                }
                oldButton.Location = new Point(0, oldButton.Location.Y + cons.CHESS_HEIGHT);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }
        }

        private void btn_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage != null)
                return;

            Mark(btn);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), currentPlayer));
            currentPlayer = currentPlayer == 1 ? 0 : 1;


            ChangePlayer();

            if (playerMarks != null)
                playerMarks(this, new ButtonClickEvent(GetChessPoint(btn)));

            if (isEndGame(btn))
            {
                EndGame();
            }

        }
        public void ortherPlayerMark(Point point)
        {
            Button btn1 = matrix[point.Y][point.X];
            if (btn1.BackgroundImage != null)
                return;

            Mark(btn1);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn1), currentPlayer));
            currentPlayer = currentPlayer == 1 ? 0 : 1;


            ChangePlayer();
             
          
            if (isEndGame(btn1))
            {
                EndGame();
            }

        }
  

        public void EndGame()
        {
            if (endGames != null)
                endGames(this, new EventArgs());
                    }
        public Boolean undo()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            bool isUndo1 = UndoAStep();
            bool isUndo2 = UndoAStep();

            PlayInfo oldPoint = PlayTimeLine.Peek();
            currentPlayer = oldPoint.CurrentPlayer == 1 ? 0 : 1;

            return isUndo1 && isUndo2;
        }

        private bool UndoAStep()
        {
            if (PlayTimeLine.Count <= 0)
                return false;

            PlayInfo olPoint = PlayTimeLine.Pop();
            Button btn = matrix[olPoint.Point.Y][olPoint.Point.X];

            btn.BackgroundImage = null;

            if (PlayTimeLine.Count <= 0)
            {
                currentPlayer = 0;
            }
            else
            {
                olPoint = PlayTimeLine.Peek();
            }

            ChangePlayer();

            return true;
        }
        private bool isEndGame(Button btn)
        {

            return (isEndHorizontal(btn) || isEndVertical(btn) || isEndPrimaryDialog(btn)  || isEndsub(btn));

        }
        private Point GetChessPoint(Button btn)
        {

            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = matrix[vertical].IndexOf(btn);
            Point poi = new Point(horizontal, vertical);
            return poi;
        }
        private bool isEndHorizontal(Button btn)
        {
            Point poi = GetChessPoint(btn);
            int countLeft = 0;

            for(int i=poi.X; i >= 0; i-- ){
                if (matrix[poi.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countLeft++;
                }
                else
                    break;

            }
            int countRight = 0;
            for (int i = poi.X+1; i < cons.CHESS_BOARD_WIDTH; i++)
            {
                if (matrix[poi.Y][i].BackgroundImage == btn.BackgroundImage)
                {
                    countRight++;
                }
                else
                    break;

            }

            return countLeft + countRight == 5;
            
        }
        private bool isEndVertical(Button btn)
        {

            Point poi = GetChessPoint(btn);
            int countTop = 0;

            for (int i = poi.Y; i >= 0; i--)
            {
                if (matrix[i][poi.X].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;

            }
            int countBottom = 0;
            for (int i = poi.Y + 1; i < cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (matrix[i][poi.X].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;

            }

            return countBottom + countTop == 5;

        }
        private bool isEndPrimaryDialog(Button btn)
        {

            Point poi = GetChessPoint(btn);
            int countTop = 0;

            for (int i = 0; i <=  poi.X ; i++)
            {
                if (poi.X + i > cons.CHESS_BOARD_WIDTH || poi.Y - i < 0)
                {
                    break;
                }
                if (matrix[poi.Y - i][poi.X + i ].BackgroundImage == btn.BackgroundImage)
                {
                    countTop++;
                }
                else
                    break;

            }
            int countBottom = 0;
            for (int i = 1; i <= cons.CHESS_BOARD_WIDTH - poi.X; i++)
            {
                if (poi.Y + i >= cons.CHESS_BOARD_HEIGHT || poi.X - i < 0)
                    break;
                if (matrix[poi.Y + i][poi.X - i].BackgroundImage == btn.BackgroundImage)
                {
                    countBottom++;
                }
                else
                    break;

            }

            return countBottom + countTop == 5;
        }
        private bool isEndsub(Button btn)
        {

            return false;

        }
       
       
       
        public void ChangePlayer()
        {
            playerName.Text = Player[currentPlayer].Name;
            playerMark.Image = Player[currentPlayer].Mark1;
        }
        private void Mark( Button btn)
        {
            btn.BackgroundImage = Player[currentPlayer].Mark1;
        }

        #endregion

    }

    public class ButtonClickEvent : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint
        {
            get { return clickedPoint; }
            set { clickedPoint = value; }
        }

        public ButtonClickEvent(Point point)
        {
            this.ClickedPoint = point;
        }
    }

}
