using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.IO;

namespace BattleShip
{
    public partial class Shooting : Form
    {
        public static ShipRelated MyShips;  
        public  static ShipRelated OpponentShips;
         public Shooting()
        {
            InitializeComponent();
        }

        bool turn;
        int currentbutton;
        int count = 0;
        int location = 0;
        int hostbuttonleft = 20;
        int clientbuttonleft = 20;
        private void Shooting_Load(object sender, EventArgs e)
        {
            int i, j;
            if (Player.Host==true)
            {
               turn = true;        
            }
            else
            {
                turn = false;
            }
            Threads();
            OpponentShips = new ShipRelated();
            for (i = 0; i < 10; i++)
            {
                for(j = 0; j < 10; j++)
                {
  
                    Cell cell = new Cell();
                    Button button = new Button();
                    button.Name=count.ToString();
                    button.BackColor = Color.White;
                    button.Size = new Size(50, 50);
                    button.Visible = true;
                    button.BackColor = Color.White;
                    button.Location = new Point(60 + (50 * j), 60 + (50 * i));
                    cell.button1 = button;
                    cell.SetOccupied(false);
                    OpponentShips.newcont[location] = cell; 
                    OpponentShips.newcont[location].button1.Click += new EventHandler(Button_Click);
                    Controls.Add(OpponentShips.newcont[location].button1);
                    count++;
                    location++;
                    
                }
            }
            location = 0;
            count = 0;
            for (i = 0; i < 10; i++) 
            {
                for (j = 0; j < 10; j++)
                {
                    MyShips.newcont[location].button1.Name= count.ToString();
                    MyShips.newcont[location].button1.Location = new Point(630 + (50 * j), 60 + (50 * i)); 
                    Controls.Add(MyShips.newcont[location].button1);
                   count++;
                   location++;
                }
            }
        }
        public void Threads()
        {
            Thread thread;
            if (Player.Host == true)
            {
                thread = new Thread(new ThreadStart(HostTurn));


            }
            else
            {
                thread = new Thread(new ThreadStart(ClientTurn));
            }
            thread.Start();
        }
        private void Button_Click(object sender, EventArgs e)
        {
            if (!turn)
            {
                return;
            }
            Button button = sender as Button;
            if (Player.Host)
            {
                if (hostbuttonleft == 0 && clientbuttonleft!=0)
                {
                    YouWon youWon = new YouWon();
                    youWon.Show();
                    this.Hide();

                }
                else if (clientbuttonleft == 0)
                {
                    YouLost youLost = new YouLost();
                    youLost.Show();
                    this.Hide();

                }
            }
            if (!Player.Host)
            {
                if (clientbuttonleft == 0 && hostbuttonleft!=0)
                {
                    YouWon youWon = new YouWon();
                    youWon.Show();
                    this.Hide();

                }
                else if (hostbuttonleft == 0)
                {
                    YouLost youLost = new YouLost();
                    youLost.Show();
                    this.Hide();

                }
            }
            if (button.BackColor== Color.Navy || button.BackColor == Color.Red)
            {
                AlreadyHit hit= new AlreadyHit();
                hit.Show();
                return;
            }
            currentbutton=Convert.ToInt32(button.Name);
            if (Player.Host)
            {
                Player.HostSendButton(button.Name);
                
            }
            else
            {
                
                Player.ClientSendButton(button.Name); 
                
            }
            
            turn = false;
        }

        private void HostTurn()
        {
            while (true)
            {
                string takenbuttonN = Player.HostReceiveButton();
                
                if (takenbuttonN == "ButtonRed")
                {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.Red;
                    hostbuttonleft--;
                 
                }
               else if (takenbuttonN == "ButtonNavy")
                { 
                  OpponentShips.newcont[currentbutton].button1.BackColor = Color.Navy;
                }
                
                else
                {
                    if (MyShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied()) 
                    {
                        Player.HostSendButton("ButtonRed");
                       
                        clientbuttonleft--;
                     

                    }
                    else if(!MyShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Player.HostSendButton("ButtonNavy");
                       

                    }
                    MyShips.newcont[Convert.ToInt32(takenbuttonN)].button1.BackColor = Color.Black;
                    turn = true;
                }
                
            }

        }
        private void ClientTurn()  
        {
            while (true)
           {
                string takenbuttonN = Player.ClientReceiveButton();
               
                if (takenbuttonN == "ButtonRed")
                {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.Red;
                    clientbuttonleft--;
                       
                  
                }
               else if (takenbuttonN == "ButtonNavy")
                {
                    OpponentShips.newcont[currentbutton].button1.BackColor = Color.Navy;
                }

                
                else
                {
                    if(MyShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Player.ClientSendButton("ButtonRed");
                     
                        hostbuttonleft--;
                     
                    }
                    else if(!MyShips.newcont[Convert.ToInt32(takenbuttonN)].IsOccupied())
                    {
                        Player.ClientSendButton("ButtonNavy");
                      
                        
                    }
                    MyShips.newcont[Convert.ToInt32(takenbuttonN)].button1.BackColor = Color.Black;
                    turn = true;
                }

            }
        }

    }
}
