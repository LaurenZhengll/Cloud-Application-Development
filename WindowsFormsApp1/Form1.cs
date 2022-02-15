using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        TaskAllocation taskAllocation = null;
        Configuration configuration = null;

        private void openTANFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            taskAllocation = new TaskAllocation(openFileDialog.FileName);
            bool TanValid = taskAllocation.TanFileValidation();

            configuration = new Configuration(taskAllocation.ConfigFilepath);
            bool csvValid = configuration.CsvFileValidation();

            taskAllocation.AllocationOutput();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
