using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_System_Management
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV (*.csv) | *.csv";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string[] readAllLine = File.ReadAllLines(openFileDialog.FileName);

                string readAllText = File.ReadAllText(openFileDialog.FileName);
                for (int i = 1; i < readAllLine.Length; i++)
                {
                    string allDATARAW = readAllLine[i];
                    string[] allDATASplited = allDATARAW.Split(',');
                    this.dataGridView1.Rows.Add(allDATASplited[0], allDATASplited[1], allDATASplited[2], allDATASplited[3], allDATASplited[4], allDATASplited[5]);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV(*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                {
                    int columnCount = dataGridView1.Columns.Count;
                    string column = "";
                    string[] outputCSV = new string[dataGridView1.Rows.Count + 1];
                    for (int i = 0; i < columnCount; i++)
                    {
                        column += dataGridView1.Columns[i].HeaderText.ToString() + ",";
                    }
                    outputCSV[0] += column;
                    for (int i = 1; (i - 1) < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < columnCount; j++)
                        {
                            outputCSV[i] += dataGridView1.Rows[i - 1].Cells[j].Value.ToString() + ",";
                        }
                    }
                    File.WriteAllLines(saveFileDialog.FileName, outputCSV, Encoding.UTF8);
                }
            }
        }

        internal void UserPassword(string UserName, string User)
        {
            string UserName1Show = UserName;
            this.textBoxUserName1.Text = UserName1Show.ToString();
            string UserShow = User;
            this.textBoxId.Text = UserShow.ToString();
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            string Major = comboBoxMajor.Text;
            string SSID = textBoxSSID.Text;
            string Stodent_Id = textBoxStudent_Id.Text;
            string Name = textBoxName.Text;
            string UserName = textBoxUserName.Text;
            string Password = textBoxPassword.Text;
            string Null = "null";

            int n = dataGridView1.Rows.Add();

            if (Major == "Staff")
            {
                Staff staff = new Staff();

                staff.Name = Name;
                staff.SSID = SSID;
                staff.Username = UserName;
                staff.Password = Password;

                dataGridView1.Rows[n].Cells[0].Value = Null;
                dataGridView1.Rows[n].Cells[1].Value = staff.SSID;
                dataGridView1.Rows[n].Cells[2].Value = Null;
                dataGridView1.Rows[n].Cells[3].Value = staff.Name;
                dataGridView1.Rows[n].Cells[4].Value = staff.Username;
                dataGridView1.Rows[n].Cells[5].Value = staff.Password;
            }

            if (Major == "Teacher")
            {
                Teacher teacher = new Teacher();

                teacher.Major = Major;
                teacher.SSID = SSID;
                teacher.Name = Name;

                dataGridView1.Rows[n].Cells[0].Value = teacher.Major;
                dataGridView1.Rows[n].Cells[1].Value = teacher.SSID;
                dataGridView1.Rows[n].Cells[2].Value = Null;
                dataGridView1.Rows[n].Cells[3].Value = teacher.Name;
                dataGridView1.Rows[n].Cells[4].Value = Null;
                dataGridView1.Rows[n].Cells[5].Value = Null;
            }

            if (Major == "Student")
            {
                Student student = new Student();

                student.Major = Major;
                student.SSID = SSID;
                student.Student_Id = Stodent_Id;
                student.Name = Name;

                dataGridView1.Rows[n].Cells[0].Value = student.Major;
                dataGridView1.Rows[n].Cells[1].Value = student.SSID;
                dataGridView1.Rows[n].Cells[2].Value = student.Student_Id;
                dataGridView1.Rows[n].Cells[3].Value = student.Name;
                dataGridView1.Rows[n].Cells[4].Value = Null;
                dataGridView1.Rows[n].Cells[5].Value = Null;
            }

            comboBoxMajor.Text = null;
            textBoxSSID.Text = "";
            textBoxStudent_Id.Text = "";
            textBoxName.Text = "";
            textBoxUserName.Text = "";
            textBoxPassword.Text = "";
        }
    }
}
