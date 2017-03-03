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
    public partial class Challenge : Form
    {
        GameRules ruleSet = new GameRules();
        public Challenge()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnChallenge_Click(object sender, EventArgs e)
        {
            Game.SelectCards(ruleSet);
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void Challenge_Load(object sender, EventArgs e)
        {

        }

        private void lblBalamb_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbOpen.Checked = true;
            ruleSet.open = true;
        }

        private void lblGalbaldia_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbSame.Checked = true;
            ruleSet.same = true;
        }

        private void lblDollet_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbRandom.Checked = true;
            cbElemental.Checked = true;
            ruleSet.random = true;
            ruleSet.elemental = true;
        }

        private void lblFH_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbElemental.Checked = true;
            cbSuddenDeath.Checked = true;
            ruleSet.elemental = true;
            ruleSet.suddenDeath = true;
        }

        private void lblTrabia_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbRandom.Checked = true;
            cbPlus.Checked = true;
            ruleSet.random = true;
            ruleSet.plus = true;
        }

        private void lblCentra_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbSame.Checked = true;
            cbPlus.Checked = true;
            cbRandom.Checked = true;
            ruleSet.same = true;
            ruleSet.plus = true;
            ruleSet.random = true;
        }

        private void lblEsthar_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbElemental.Checked = true;
            cbSameWall.Checked = true;
            ruleSet.elemental = true;
            ruleSet.sameWall = true;
        }

        private void lblLunar_Click(object sender, EventArgs e)
        {
            UncheckRules();
            cbSame.Checked = true;
            cbPlus.Checked = true;
            cbElemental.Checked = true;
            cbSameWall.Checked = true;
            cbRandom.Checked = true;
            cbSuddenDeath.Checked = true;
            ruleSet.same = true;
            ruleSet.plus = true;
            ruleSet.elemental = true;
            ruleSet.sameWall = true;
            ruleSet.random = true;
            ruleSet.suddenDeath = true;
        }

        private void lblCustom_Click(object sender, EventArgs e)
        {
            UncheckRules();
        }

        private void UncheckRules()
        {
            foreach (Control control in this.Controls)
            {
                if (control is CheckBox)
                {
                    CheckBox cb = (CheckBox)control;
                    cb.Checked = false;
                }
            }

            ruleSet.clear();
        }

        private void cbOpen_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.open = cbOpen.Checked == true ? true : false;
        }

        private void cbSame_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.same = cbSame.Checked == true ? true : false;
        }

        private void cbRandom_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.random = cbRandom.Checked == true ? true : false;
        }

        private void cbElemental_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.elemental = cbElemental.Checked == true ? true : false;
        }

        private void cbSuddenDeath_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.suddenDeath = cbSuddenDeath.Checked == true ? true : false;
        }

        private void cbPlus_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.plus = cbPlus.Checked == true ? true : false;
        }

        private void cbSameWall_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.sameWall = cbSameWall.Checked == true ? true : false;
        }

        private void cbChaos_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.chaos = cbChaos.Checked == true ? true : false;
        }

        private void cbCombo_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.combo = cbCombo.Checked == true ? true : false;
        }

        private void cbFallenAce_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.fallenAce = cbFallenAce.Checked == true ? true : false;
        }

        private void cbOrder_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.order = cbOrder.Checked == true ? true : false;
        }

        private void cbReverse_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.reverse = cbReverse.Checked == true ? true : false;
        }

        private void cbSwap_CheckedChanged(object sender, EventArgs e)
        {
            ruleSet.swap = cbSwap.Checked == true ? true : false;
        }
    }
}
