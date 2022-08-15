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
    public partial class PlacementError : Form
    {
        public PlacementError()
        {
            InitializeComponent();
        }

        private void errorbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
