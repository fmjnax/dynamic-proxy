using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TripleTriadOffline.Classes;

namespace TripleTriadOffline.Forms
{
    public partial class Splash : Form
    {
        int x = 0;
        public Splash()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (x > 5)
            {
                Form lobby = new Lobby();
                timer1.Enabled = false;
                Game game = new Game();
                game.Start();
                this.Close();
            }
            x++;
        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }
    }
}
