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
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace BattleShip
{
    public partial class StartPage : Form
    {
        bool connection=false;
        public StartPage()
        {
            InitializeComponent();
        }
        public void Thread()
        {
            Thread thread;
            thread = new Thread(Connectserver);
            thread.Start();
        }
        public void Connectserver()
        {
            if (Player.Host == true)
            {
                if (Player.HostConnect() == true)
                {
                    connection = true;
                    

                }
            }
            else
            {
                if (Player.ClientConnect() == true)
                {
                    connection = true;
                    
                }
            }
        }
        private void StartPage_Load(object sender, EventArgs e)
        {
            Form.CheckForIllegalCrossThreadCalls = true;
            
        }

        private void Exitbutton_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
           
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connection == true)
            {
                PlaceShips placeships = new PlaceShips();
                this.Hide();
                placeships.Show();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Player.Host = true;
                button2.Text = "Connected";
                
            }
            else
            {
                Player.Host = false;
                button2.Text = "Connected";
                
            }
            Thread();
        }
    }
}
