using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotePadApp
{
    public partial class FrmMain : Form
    {
        public bool IsModify { get; set; }
        private string firstfileName = "noname.txt";
        private string currentfileName = "noname.txt";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Text = $"{currentfileName} - 내 메모장";
        }

        private void 새로만들기NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO : 이미 작업중인 파일이 있으면 저장처리
            ProcessSaveFileBeforeClose();

            TxtMain.Text = "";
            IsModify = false;
            currentfileName = firstfileName;

            this.Text = $"{currentfileName} - 내 메모장";
        }

        private void 열기OToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();
            openFileDialog1.Filter = "Text file(*.txt)|*.txt|Log file(*.log)|*.log";
            openFileDialog1.ShowDialog();

            currentfileName = openFileDialog1.FileName;
            this.Text = $"{currentfileName} - 내 메모장";

            try
            {
                StreamReader sr = File.OpenText(currentfileName);
                TxtMain.Text = sr.ReadToEnd();

                IsModify = false;
                sr.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void 저장SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentfileName == firstfileName)
            {
                saveFileDialog1.Filter = "Text file(*.txt)|*.txt|Log file(*.log)|*.log";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    currentfileName = saveFileDialog1.FileName;
            }

            StreamWriter sw = File.CreateText(currentfileName);
            sw.WriteLine(TxtMain.Text);

            IsModify = false;
            sw.Close();

            this.Text = $"{currentfileName} - 내 메모장";
        }

        public void ProcessSaveFileBeforeClose()
        {
            if (IsModify)
            {
                DialogResult answer = MessageBox.Show("변경사항이 있습니다. 저장하시겠습니까?", "저장", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(answer == DialogResult.Yes)
                {
                    if(currentfileName == firstfileName)
                    {
                        saveFileDialog1.Filter = "Text file(*.txt)|*.txt|Log file(*.log)|*.log";
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            
                            StreamWriter sw = File.CreateText(saveFileDialog1.FileName);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                        else
                        {
                            
                            StreamWriter sw = File.CreateText(currentfileName);
                            sw.WriteLine(TxtMain.Text);
                            sw.Close();
                        }
                    }
                }
            }
        }

        private void 닫기XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessSaveFileBeforeClose();
            Environment.Exit(0);
        }

        private void 복사하기CToolStripMenuItem_Click(object sender, EventArgs e)
        {

            /*if(TxtMain.Text != null)
            {
                Clipboard.SetDataObject(TxtMain.Text);
                MessageBox.Show(TxtMain.Text);
            }*/

            var contents = ActiveControl as RichTextBox;
            if (contents != null)
            {
                Clipboard.SetDataObject(contents.SelectedText);
                MessageBox.Show(contents.SelectedText);
            }
        }

        private void 붙여넣기PToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var contents = ActiveControl as RichTextBox;
            if (contents != null)
            {
                IDataObject data = Clipboard.GetDataObject();
                contents.SelectedText = data.GetData(DataFormats.Text).ToString();
                IsModify = true;
            }
        }

        private void 프로그램정보AToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new AboutThis();
            form.ShowDialog();
        }

        private void TxtMain_TextChanged(object sender, EventArgs e)
        {
            IsModify = true;
            this.Text = $"{currentfileName}* - 내 메모장";
        }
    }
}
