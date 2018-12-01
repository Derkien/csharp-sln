using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GB1Lesson7
{
    public partial class WFDoubler : Form
    {
        private Doubler Doubler;

        public WFDoubler()
        {
            InitializeComponent();
            ListLastOperations.ListViewItemSorter = Comparer<ListViewItem>.Create(
                (x, y) =>
                {
                    if (x.Index == y.Index)
                    {
                        return 0;
                    }

                    return x.Index < y.Index ? -1 : 1;
                }
            );

            InitializeGameState();
        }

        private void InitializeGameState()
        {
            Doubler = new Doubler();

            ResetOperationList();
        }

        private void MenuItemNewGame_Click(object sender, EventArgs e)
        {
            InitializeGameState();
        }

        private void ButtonPlusOne_Click(object sender, EventArgs e)
        {
            Doubler.MakePlusOne();
            AddLastOperation();
        }

        private void ButtonMultiplyByTwo_Click(object sender, EventArgs e)
        {
            Doubler.MakeMultByTwo();
            AddLastOperation();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            Doubler.ResetCurrentNumberAndOperationStack();

            ResetOperationList();
        }

        private void ButtonRevert_Click(object sender, EventArgs e)
        {
            if (Doubler.RevertOperation())
            {
                RemoveLastOperation();
            }
        }

        private void RemoveLastOperation()
        {
            RefreshLabelsAndButtons();
            ListLastOperations.Items.RemoveAt(0);
            ListLastOperations.Sort();

        }

        private void AddLastOperation()
        {
            RefreshLabelsAndButtons();
            ListLastOperations.Items.Insert(0, Doubler.GetLastOperationName());
        }

        private void ResetOperationList()
        {
            RefreshLabelsAndButtons();
            ListLastOperations.Items.Clear();
        }

        private void RefreshLabelsAndButtons()
        {
            LabelCurrentNumber.Text = Doubler.GetCurrentNumberValue();
            LabelExpectedNumber.Text = Doubler.GetExpectedResult();
            LabelTotalOperationsCount.Text = Doubler.GetOperationsCount().ToString();

            if (Doubler.IsPlayerWon())
            {
                LabelGameStatusBar.Text = "You won! Press New game to start again!";
                SetValueModifierButtonsState(false);

                return;
            }
            else if (Doubler.IsPlayerLoose())
            {
                LabelGameStatusBar.Text = "Oops, you loose! Press New game to try again!";
                SetValueModifierButtonsState(false);

                return;
            }

            LabelGameStatusBar.Text = "Get expected number in minimum actions!";
            SetValueModifierButtonsState(true);
        }

        private void SetValueModifierButtonsState(bool buttonState)
        {
            ButtonMultiplyByTwo.Enabled = buttonState;
            ButtonPlusOne.Enabled = buttonState;
        }

        private ListViewItem CreateNewListItem(string ListItemText)
        {
            return new ListViewItem(ListItemText);
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure?";
            const string caption = "Exit game";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }
    }
}
