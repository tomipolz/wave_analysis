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

namespace WaveGenAnalysis
{
    public partial class FormList : Form
    {
        List<string> FormListItems = new List<string>();

        public FormList(List<string> AxisData)
        {
            InitializeComponent();
            FormListItems = AxisData;
        }

        private void FormAxisList_Load(object sender, EventArgs e)
        {
            labelMain.Text = "Item count " + FormListItems.Count().ToString();
            listBoxAxisItems.DataSource = FormListItems;
            listBoxAxisItems.Refresh();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV|*csv";
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.FileName = "Wave";



            string WriteString = "";
            foreach (string ListItem in FormListItems)
            {
                //Console.WriteLine(ListItem);
                if (WriteString != "") { WriteString += "\r"; }
                WriteString = WriteString + ListItem;
            }

            if (WriteString == "") { return; }

            switch (saveFileDialog.ShowDialog())
            {
                case System.Windows.Forms.DialogResult.OK:
                    File.WriteAllBytes(saveFileDialog.FileName, Encoding.ASCII.GetBytes(WriteString));
                    break;
            }
            this.Close();
        }
    }
}
