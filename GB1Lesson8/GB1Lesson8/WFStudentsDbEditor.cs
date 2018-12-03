using GB1Lesson8.DBModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GB1Lesson8
{
    public partial class WFStudentsDbEditor : Form
    {
        private enum ModeOpen { Create, Open, Save };

        private BindingSource BindingSource = new BindingSource();
        private StudentService StudentService = new StudentService();
        private StudentRepository StudentRepository;

        private string LogFilePath;
        private string CurrentOpenedFile;

        public WFStudentsDbEditor()
        {
            InitializeComponent();
            InitTimeTick();
            RefreshLabels();
        }

        private void RefreshLabels()
        {
            DebugLabel.Text = LogFilePath ?? "";
            CurrentFileBottomToolStripLabel.Text = CurrentOpenedFile ?? "";
        }

        private void InitTimeTick()
        {
            Timer timer = new Timer();
            timer.Start();
            timer.Tick += (object sender, EventArgs e) => CurrentTimeBottomToolsTipLabel.Text = DateTime.Now.ToLongTimeString();
            CurrentTimeBottomToolsTipLabel.Text = DateTime.Now.ToLongTimeString();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            const string message = "Are you sure?";
            const string caption = "Exit Db Editor";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if (StudentRepository != null && !StudentRepository.StateIsSaved)
                {
                    ConfirmAction(sender, e);
                }

                Close();
            }
        }

        private void ConfirmAction(object sender, EventArgs e)
        {
            const string message = "You have unsaved data. Do you want to save it?";
            const string caption = "Unsaved data detected";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                SaveChangedData(sender, e);
            }

            return;
        }

        private void InvalidFileDialog()
        {
            const string message = "Provided file can't be read.\r\nFile is invalid or broken.\r\nChoose another one.";
            const string caption = "Ivanlid file";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void AboutMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Simple App For Adding Info About Students.\r\n" +
                "Author: Ivanov Sergey Valentinovich\r\n" +
                "(c) s.val.ivanov@yandex.ru 2018\r\n" +
                "All rights reserved."
                );
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            FileDialogOperation(sender, e, ModeOpen.Open);
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            FileDialogOperation(sender, e, ModeOpen.Open);
        }

        private void CreateNewDbButton_Click(object sender, EventArgs e)
        {
            FileDialogOperation(sender, e, ModeOpen.Create);
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            FileDialogOperation(sender, e, ModeOpen.Save);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            SaveChangedData(sender, e);
        }

        private void SaveChangedData(object sender, EventArgs e)
        {
            if (StudentRepository == null)
            {
                FileDialogOperation(sender, e, ModeOpen.Save);
            }

            StudentRepository.SaveStudents((List<Student>)BindingSource.DataSource);
        }

        private void FileDialogOperation(object sender, EventArgs e, ModeOpen modeOpen)
        {
            FileDialog dialog;

            if (StudentRepository != null && !StudentRepository.StateIsSaved && modeOpen != ModeOpen.Save)
            {
                ConfirmAction(sender, e);
            }

            if (modeOpen == ModeOpen.Open)
            {
                dialog = new OpenFileDialog()
                {
                    Filter = StudentRepository.AvailableDbFileExtensionsFilter
                };
            }
            else
            {
                dialog = new SaveFileDialog()
                {
                    Filter = StudentRepository.AvailableDbFileExtensionsFilter
                };
            }

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CurrentOpenedFile = dialog.FileName;

                StudentRepository = StudentRepository.BindToFile(dialog.FileName);
                if (modeOpen == ModeOpen.Create)
                {
                    BindingSource.DataSource = StudentRepository.GetEmptyStudentsLIst();
                    StudentsDataGreedView.DataSource = BindingSource;
                }
                else if (modeOpen == ModeOpen.Save)
                {
                    StudentRepository.SaveStudents((List<Student>)BindingSource.DataSource);
                }
                else
                {
                    try
                    {
                        BindingSource.DataSource = StudentRepository.LoadStudents();
                        StudentsDataGreedView.DataSource = BindingSource;
                    }
                    catch (InvalidOperationException exception)
                    {
                        StudentService.SaveParseErrors(exception, out LogFilePath);
                        InvalidFileDialog();
                    }
                }
            };

            RefreshLabels();
        }

        private void CsvImportMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog()
            {
                Filter = StudentService.AvailableImportFileExtensionsFilter
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            BindingSource.DataSource = StudentService.GetStudentsListFromFile(dialog.FileName, out LogFilePath);
            StudentsDataGreedView.DataSource = BindingSource;

            SetRepositoryStateToFalse();

            RefreshLabels();
        }

        private void StudentsDataGreedView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetRepositoryStateToFalse();
        }

        private void StudentsDataGreedView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            SetRepositoryStateToFalse();
        }

        private void SetRepositoryStateToFalse()
        {
            if (StudentRepository != null)
            {
                StudentRepository.StateIsSaved = false;
            }
        }
    }
}
