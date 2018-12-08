using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GB1Lesson7
{
    public partial class WFMainForm : Form
    {
        public WFMainForm()
        {
            InitializeComponent();
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MenuItemGameDoubler_Click(object sender, EventArgs e)
        {
            Form WFDoubler = new WFDoubler
            {
                MdiParent = this
            };

            WFDoubler.Show();
        }

        private void MenuItemGameGuessNumber_Click(object sender, EventArgs e)
        {
            Form WFGuessNumber = new WFGuessNumber
            {
                MdiParent = this
            };

            WFGuessNumber.Show();
        }
    }
}
