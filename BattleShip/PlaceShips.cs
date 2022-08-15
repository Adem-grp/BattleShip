using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleShip
{
    public partial class PlaceShips : Form
    {

        public  ShipRelated PlacedShips;
        public static Shooting ShootingBoard1;


        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.ContinueClient = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(684, 142);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(209, 24);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(684, 182);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(209, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // ContinueClient
            // 
            this.ContinueClient.Location = new System.Drawing.Point(691, 257);
            this.ContinueClient.Name = "ContinueClient";
            this.ContinueClient.Size = new System.Drawing.Size(209, 79);
            this.ContinueClient.TabIndex = 3;
            this.ContinueClient.Text = "Continue";
            this.ContinueClient.UseVisualStyleBackColor = true;
            this.ContinueClient.Click += new System.EventHandler(this.ContinueClient_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(691, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(202, 106);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "1xBatlleship\n2xCruiser\n3xDestroyer\n4xSubmarine\nTotal: 10 Ships\n";
            // 
            // PlaceShips
            // 
            this.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.ClientSize = new System.Drawing.Size(912, 590);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.ContinueClient);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Name = "PlaceShips";
            this.Load += new System.EventHandler(this.PlaceShips_Load);
            this.ResumeLayout(false);

        }
        
        public PlaceShips()
        {
            InitializeComponent();
            comboBox1.DataSource = Enum.GetValues(typeof(OccupationType));
            comboBox2.DataSource = Enum.GetValues(typeof(Axis));
            
        }
        private void PlaceShips_Load(object sender, EventArgs e)
        {
            int i, j;
            PlacedShips = new ShipRelated();
            ContinueClient.Enabled = false;
            for (i = 0; i < 10; i++)
            {
                for (j = 0; j < 10; j++)
                {
                    Cell cell = new Cell();
                    Button button = new Button();
                    if (i == 0)
                    {
                        button.Name = j.ToString();
                    }
                    if (i != 0)
                    {
                        button.Name = i.ToString() + j.ToString();
                    }
                    button.BackColor = Color.White;
                    button.Size = new Size(50, 50);
                    button.Visible = true;
                    button.Location = new Point(60 + (50 * j), 60 + (50 * i));
                    cell.button1 = button;
                    cell.SetOccupied(false);
                    PlacedShips.container[i][j]= cell;
                    PlacedShips.container[i][j].button1.Click += new EventHandler(Button_Click);
                    Controls.Add(PlacedShips.container[i][j].button1);
                }
            }

        }
        private bool Placing_Error(int num2,int num3)
        {
            int count2, count3,i;
            count2= num2;
            count3= num3;
            PlacementError placementerror = new PlacementError();
            if (comboBox2.SelectedItem.ToString() == "Vertical")
            {
                if(comboBox1.SelectedItem.ToString() == "Battleship")
                {
                    for (i = 0; i < 4; i++)
                    {
                        if(PlacedShips.container[count3++][count2].IsOccupied() == true)
                        {   
                            placementerror.Show();
                            return true;
                        }
                        if (count3 > 6)
                        {
                            count3 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Cruiser")
                {
                    for(i = 0; i < 3; i++)
                    {
                        if (PlacedShips.container[count3++][count2].IsOccupied() == true)
                        {
                            placementerror.Show();
                            return true;
                        }
                        if (count3 > 7)
                        {
                            count3 = 0;
                        }
                    }
                }
                if(comboBox1.SelectedItem.ToString() == "Destroyer")
                {
                    for(i=0; i < 2; i++)
                    {
                        if (PlacedShips.container[count3++][count2].IsOccupied() == true)
                        {
                            placementerror.Show();
                            return true;
                        }
                        if (count3 > 8)
                        {
                            count3 = 0;
                        }
                    }
                }
            }
            if(comboBox2.SelectedItem.ToString() =="Horizontal"|| comboBox2.SelectedItem.ToString() == "Vertical")
            {
                if (comboBox1.SelectedItem.ToString() == "Submarine")
                {
                    if (PlacedShips.container[count3][count2].IsOccupied())
                    {
                        placementerror.Show();
                        return true;
                    }
                }
            }
            if (comboBox2.SelectedItem.ToString() == "Horizontal")
            {
                if (comboBox1.SelectedItem.ToString() == "Battleship")
                {
                    for (i = 0; i < 4; i++)
                    {
                        if (PlacedShips.container[count3][count2++].IsOccupied()==true)
                        {
                            placementerror.Show();
                            return true;
                            
                        }
                        if (count2 > 6)
                        {
                            count2 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Cruiser")
                {
                    for (i = 0; i < 3; i++)
                    {
                        if (PlacedShips.container[count3][count2++].IsOccupied()==true)
                        {
                            placementerror.Show();
                            return true;
                            
                        }
                        if (count2 > 7)
                        {
                            count2 = 0;
                        }
                    }
                }
                if (comboBox1.SelectedItem.ToString() == "Destroyer")
                {
                    for (i = 0; i < 2; i++)
                    {
                        if (PlacedShips.container[count3][count2++].IsOccupied() == true)
                        {
                            placementerror.Show();
                            return true;
                        }
                        if (count2 > 8)
                        {
                            count2 = 0;
                        }
                    }
                }
            }
            return false;
        }
        private void Add_BattleshipVertical(int num2,int num3)
        {
            int i;
            if (num3 <= 6)
            {
                for (i = 0; i < 4; i++)
                {
                    PlacedShips.container[num3][num2].SetOccupied(true);
                    PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;


                }

            }
            else if (num3 > 6)
            {
                for (i = 0; i < 4; i++)
                {
                    if (num3 <= 9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;

                    }
                    else
                    {
                        num3 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                       
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;

                    }
                }
            }
        }

        private void Add_BattleshipHorizontal(int num2,int num3)
        {
            int i;
            if (num2 <= 6)
            {
                for (i = 0; i < 4; i++)
                {
                    PlacedShips.container[num3][num2].SetOccupied(true);   
                    PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 6)
            {
                for (i = 0; i < 4; i++)
                {
                    if (num2 <=9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }
        }
       
        private void Button_Click(object sender, EventArgs e)  
        {
            Button button= sender as Button;
            
            int num1 = Convert.ToInt32(button.Name);
            int num2 = num1 % 10;
            int num3 = num1 / 10;
            if (comboBox2.SelectedItem.ToString() == "Vertical")
            {
                if (PlacedShips.battleshipcount < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Battleship")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_BattleshipVertical(num2, num3);
                            PlacedShips.battleshipcount++;
                        }
                    }
                   
                }

                if (PlacedShips.cruisercount < 2)
                {
                    if (comboBox1.SelectedItem.ToString() == "Cruiser")
                    {
                        
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_CruiserVertical(num2, num3);
                            PlacedShips.cruisercount++;
                        }
                        
                    }
                    
                }
                if(PlacedShips.destroyercount < 3)
                {
                    if(comboBox1.SelectedItem.ToString() == "Destroyer")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_DestroyerVertical(num2, num3);
                            PlacedShips.destroyercount++;
                        }
                    }
                   
                }
            }
            if (comboBox2.SelectedItem.ToString() == "Horizontal")
            {
                if (PlacedShips.battleshipcount < 1)
                {
                    if (comboBox1.SelectedItem.ToString() == "Battleship")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_BattleshipHorizontal(num2, num3);
                            PlacedShips.battleshipcount++;
                        }
                    }

                }
                if (PlacedShips.cruisercount < 2)
                {
                    if (comboBox1.SelectedItem.ToString() == "Cruiser")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_CruiserHorizontal(num2, num3);
                            PlacedShips.cruisercount++;
                        }
                    }
                    
                }
                if (PlacedShips.destroyercount < 3)
                {
                    if(comboBox1.SelectedItem.ToString() == "Destroyer")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            Add_DestroyerHorizontal(num2, num3);
                            PlacedShips.destroyercount++;
                        }
                    }
                    

                }
                
            }
            if (PlacedShips.submarinecount < 4)
            {
                if (comboBox1.SelectedItem.ToString() == "Submarine")
                {
                    if (comboBox2.SelectedItem.ToString() == "Vertical" || comboBox2.SelectedItem.ToString() == "Horizontal")
                    {
                        if (Placing_Error(num2, num3) == false)
                        {
                            PlacedShips.container[num3][num2].SetOccupied(true);
                            
                            PlacedShips.container[num3][num2].button1.BackColor = Color.Green;
                            PlacedShips.submarinecount++;
                        }
                    }
                }
            }
            if (PlacedShips.battleshipcount + PlacedShips.cruisercount + PlacedShips.destroyercount + PlacedShips.submarinecount == 10)
            {
                ContinueClient.Enabled = true;
            }
            
        }
        private void Add_DestroyerHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 8)
            {
                for (i = 0; i < 2; i++)
                { 
                    PlacedShips.container[num3][num2].SetOccupied(true);   
                    PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 8)
            {
                for (i = 0; i < 2; i++)
                {
                    if (num2 <= 9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }

        }
        private void Add_DestroyerVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 8)
            {
                for (i = 0; i < 2; i++)
                {
                    PlacedShips.container[num3][num2].SetOccupied(true);   
                    PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                }

            }
            else if (num3 > 8)
            {
                for (i = 0; i < 2; i++)
                {
                    if (num3 <= 9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num3 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                }
            }
        }

        private void Add_CruiserVertical(int num2, int num3)
        {
            int i;
            if (num3 <= 7)
            {
                for (i = 0; i < 3; i++)
                { 
                    PlacedShips.container[num3][num2].SetOccupied(true);   
                    PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                }

            }
            else if (num3 > 7)
            {
                for (i = 0; i < 3; i++)
                {
                    if (num3 <= 9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num3 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3++][num2].button1.BackColor = Color.Green;
                    }
                }
            }
        }
        private void Add_CruiserHorizontal(int num2, int num3)
        {
            int i;
            if (num2 <= 7)
            {
                for (i = 0; i < 3; i++)
                { 
                    PlacedShips.container[num3][num2].SetOccupied(true);   
                    PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                }
            }
            else if (num2 > 7)
            {
                for (i = 0; i < 3; i++)
                {
                    if (num2 <= 9)
                    {
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                    else
                    {
                        num2 = 0;
                        PlacedShips.container[num3][num2].SetOccupied(true);
                        PlacedShips.container[num3][num2++].button1.BackColor = Color.Green;
                    }
                }
            }
        }


        private void PlaceShips_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        public enum Axis
        {
            [Description("Empty")]
            ChooseAxis,
            [Description("Horizontal")]
            Horizontal,
            [Description("Vertical")]
            Vertical
        }
       public enum OccupationType 
        {
            [Description("Empty1")]
            ChooseShip,

            [Description("4*1Battleship")]
            Battleship,

            [Description("3*2Cruiser")]
            Cruiser,

            [Description("2*3Destroyer")]
            Destroyer,

            [Description("1*4Submarine")]
            Submarine

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e){}
  
        private void ContinueClient_Click(object sender, EventArgs e)
        {
            this.Hide();
            Shooting.MyShips = new ShipRelated();
            Shooting.MyShips = PlacedShips;
            int i, j, count1=0;
            for (i = 0; i < 10; i++)
            {
               for (j = 0; j < 10; j++)
                {
                    Shooting.MyShips.newcont[count1] = Shooting.MyShips.container[i][j];
                    count1++;
                }
            }
            ShootingBoard1 = new Shooting();
            ShootingBoard1.Show();

        }
    }
}
