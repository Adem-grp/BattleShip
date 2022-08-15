using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;

namespace BattleShip
{
    public class Cell : Button
    {
        protected bool occupied;
        public Button button1;

        public Cell()
        {
            
            button1 = new Button();
            occupied = false;
        }
        public bool IsOccupied() { return occupied; }
        public void SetOccupied(bool occupied1) { occupied = occupied1; }
    }
    public  class ShipRelated : Cell
    {
        public   Cell[][] container; 
        public  Cell [] newcont = new Cell[100]; 
        public  int battleshipcount;
        public  int cruisercount;
        public  int destroyercount;
        public  int submarinecount;
        public static int[] buttons = new int[100];
        public ShipRelated()
        {
            
            container = new Cell[10][];
            int i;
            
            for (i = 0; i < 10; i++)
            {
               
                container[i] = new Cell[10];
            }
            battleshipcount = 0;
            cruisercount = 0;
            destroyercount = 0;
            submarinecount = 0;

        }
        

    }
}
