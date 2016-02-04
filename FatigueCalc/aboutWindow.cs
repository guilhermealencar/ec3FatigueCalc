using System;
using System.Windows.Forms;

namespace FatigueCalc
{
    public partial class aboutWindow : Form
    {
        public aboutWindow()
        {
            InitializeComponent();
        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void informaçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void janelaSobre_Load(object sender, EventArgs e)
        {

        }

        // ##################################################################
        // método para fechar a janela quando se pressionar esc
        // ##################################################################
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
