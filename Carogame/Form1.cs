using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Carogame
{
    public partial class Form1 : Form
    {
        #region Properties

        ChessboardManeger chessboard;
        SocketManeger socket;
        #endregion
        public Form1()
        {
            InitializeComponent();
             chessboard = new ChessboardManeger(pnlChessBoard,tntName,picBox2);
            chessboard.EndGames += Chessboard_Endgame;
            chessboard.PlayerMarks += chessboard_PlayerMarks;
            prsCoolDown.Step = cons.COOL_DOWN_STEP;
            prsCoolDown.Maximum = cons.COOL_DOWN_TIME;
            prsCoolDown.Value = 0;

            tmCoolDown.Interval = cons.COOL_DOWN_INTERVAL;

            socket = new SocketManeger();
            NewGame();

        }
        #region Methods

        void EndGame()
        {
            tmCoolDown.Stop();

            pnlChessBoard.Enabled = false;
        }
        void NewGame()
        {
            prsCoolDown.Value = 0;
            tmCoolDown.Stop();

            chessboard.DrawChessBoard();   
            
        }
        void Undo()
        {
            chessboard.undo();
            prsCoolDown.Value = 0;

        }
        void Quit()
        {
            Application.Exit();
        }

        private void chessboard_PlayerMarks(object sender, ButtonClickEvent e)
        {
            tmCoolDown.Start();
            pnlChessBoard.Enabled = false;
            prsCoolDown.Value = 0;
            socket.send(new SocketData((int)SocketCommand.SEND_POINT, "", e.ClickedPoint));
            Listen();
        }

        private void Chessboard_Endgame(object sender, EventArgs e)
        {
            EndGame();
            socket.send(new SocketData((int)SocketCommand.END_GAME, "",new Point()));

        }


        //tạo bàn cờ

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tnt_TextChanged(object sender, EventArgs e)
        {

        }

        private void tntName_TextChanged(object sender, EventArgs e)
        {

        }

       

        private void prsCoolDown_Click(object sender, EventArgs e)
        {
            prsCoolDown.PerformStep();
            if(prsCoolDown.Value >= prsCoolDown.Maximum)
            { 
                EndGame();
                socket.send(new SocketData((int)SocketCommand.TIME_OUT, "", new Point()));


            }
        }

        private void picBox2_Click(object sender, EventArgs e)
        {

        }

        

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            socket.send(new SocketData((int)SocketCommand.RQ_NEWGAME, "",new Point()));

        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }

        private void quytToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
            else
            {
                try
                {
                    socket.send(new SocketData((int)SocketCommand.QUIT, "", new Point()));
                }
                catch { }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;

            if (!socket.ConnectServer())
            {
                socket.isServer = true;
                pnlChessBoard.Enabled = false;
                btnLan.Enabled = false;
                btnStrart.Enabled = true;
                tntName.Text = chessboard.Player[0].Name;
                socket.CreateServer();
                MessageBox.Show("Nhấn START đến khi tìm được đối thủ", "Hướng dẫn");

            }
            else
            {

                socket.isServer = false;
                pnlChessBoard.Enabled = false;
                btnLan.Enabled = false;
                tntName.Text = chessboard.Player[1].Name;
                MessageBox.Show("Đã kết nối", "Thông báo");
                socket.send(new SocketData((int)SocketCommand.START, "Đã tìm thấy đối thủ", new Point()));

                Listen();

            }


        }

        private void Form1_Show(object sender, EventArgs e)
        {
            txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(txbIP.Text))
            {
                txbIP.Text = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
            }
        }
        void Listen()
        {

            
                Thread listenThread = new Thread(() =>
                {try
                    {
                        SocketData data = (SocketData)socket.Receive();
                        ProcessData(data);

                    }
                    catch { }
                    
                    });
                listenThread.IsBackground = true;
                listenThread.Start();
            



        }

        private void ProcessData(SocketData data)
        {
            switch (data.Command)
            {
                case (int)SocketCommand.NOTYF:
                    MessageBox.Show(data.Message);
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = true;
                    }));
                    if (!socket.isServer)
                    {
                        chessboard.CurrentPlayer = 1;
                        chessboard.ChangePlayer();
                    }
                    break;
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prsCoolDown.Value = 0;
                        pnlChessBoard.Enabled = true;
                        tmCoolDown.Start();
                        chessboard.ortherPlayerMark(data.Point);
                    }));
                    break;
                case (int)SocketCommand.RQ_NEWGAME:
                    if (MessageBox.Show("Đối thủ muốn chơi ván mới", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                        socket.send(MessageBox.Show("Chơi tiếp đi :)))"));
                    else
                    {
                        socket.send(new SocketData((int)SocketCommand.NEW_GAME,"", new Point()));
                        this.Invoke((MethodInvoker)(() =>
                        {
                            NewGame();
                            pnlChessBoard.Enabled = false;
                        }));
                        if (socket.isServer)
                        {
                            chessboard.CurrentPlayer = 1;
                            chessboard.ChangePlayer();
                        }
                    }
                    break;
                case (int)SocketCommand.END_GAME:
                    int check = 0;
                    if (chessboard.CurrentPlayer == 0) check = 1;
                    MessageBox.Show(chessboard.Player[check].Name, "Winner");
                    break;
                case (int)SocketCommand.TIME_OUT:
                    MessageBox.Show("Hết Thời Gian ");
                    break;
                case (int)SocketCommand.QUIT:
                    tmCoolDown.Stop();
                    MessageBox.Show("Đối thủ đã thoát", "Thông báo");
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGame();
                        pnlChessBoard.Enabled = false;
                    }));
                    if (socket.isServer)
                    {
                        socket.CloseConnect();
                    }
                    btnLan.Enabled = true;
                    newGameToolStripMenuItem.Enabled = false;
                    break;
                case (int)SocketCommand.START:
                    MessageBox.Show(data.Message);
                    newGameToolStripMenuItem.Enabled = true;
                    pnlChessBoard.Enabled = true;
                    break;
                default:
                    break;
            }

            Listen();
        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Listen();
        }
    }

}
