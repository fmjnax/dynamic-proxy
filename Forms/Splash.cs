using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                lobby.Show();
                this.Close();
            }
            x++;
        }

        private void Splash_Load(object sender, EventArgs e)
        {
            var masterDeckCards = from r in TripleTriadOffline.Classes.Global.masterDeckXml.Descendants("card")

            select new
            {
                ID = r.Element("id").Value,
                DisplayName = r.Element("displayName").Value,
                FileName = r.Element("fileName").Value,
                Left = r.Element("left").Value,
                Top = r.Element("top").Value,
                Right = r.Element("right").Value,
                Bottom = r.Element("bottom").Value,
                Level = r.Element("level").Value
            };
        }
    }
}
