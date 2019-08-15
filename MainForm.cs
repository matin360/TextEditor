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

namespace WindowsFormsApp1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string extension = ".txt";
            string fileName = Guid.NewGuid().ToString();

            if (FoldBrowseDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = FoldBrowseDialog.SelectedPath;
                string createdPath = $"{selectedPath}\\{DateTime.Now.ToString("yyyy - MM - dd").ToString()}";
                if (!Directory.Exists(createdPath))
                {
                    Directory.CreateDirectory(createdPath);
                }
                string fullPath = $@"{createdPath}\{fileName}{extension}";
                if (!File.Exists(fullPath))
                {
                    byte[] vs = null;
                    using (FileStream fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                    {
                        vs = Encoding.UTF8.GetBytes(rtxbx_text.Text);
                        fs.Write(vs, 0, vs.Length);
                        fs.Close(); 
                    }
                }
            }
        }
    }
}
