using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace card_against_humanity_Project
{
    public partial class Miki_and_Lior : Form
    {
        public Miki_and_Lior()
        {
            InitializeComponent();
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Game g = new Game();
            g.Show();
        }
    }
}