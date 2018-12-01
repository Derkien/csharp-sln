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
    public partial class WFGuessNumber : Form
    {
        private const string InitialResultText = "Enter number and press submit";
        private NumberGuesser NumberGuesser = new NumberGuesser();

        public WFGuessNumber()
        {
            InitializeComponent();

            RefreshLabels();
        }

        private void RefreshLabels(string Text = "")
        {
            ResultTextLabel.Text = Text != "" ? Text : InitialResultText;
            TryCountLabel.Text = NumberGuesser.TryCount.ToString();
        }

        private void EndGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure?";
            const string caption = "Exit game";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void NewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NumberGuesser.RestartGame();

            RefreshLabels();
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            RefreshLabels(NumberGuesser.GetCheckUserInputResult(TextBox.Text));

            TextBox.Clear();
        }
    }
}
