using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string from = txtFrom.Text;
            string to = txtTo.Text;
            string msgMoved = (from + " was moved to " + to);

            try
            {
               if (!File.Exists(from))
                {
                    using (FileStream fs = File.Create(from)) { }
                }

                if (File.Exists(to))
                    File.Delete(to);

                File.Move(from, to);
                MessageBox.Show(msgMoved);

                if (File.Exists(from))
                {
                    MessageBox.Show("From is still in original location.");
                }
                else
                {
                    MessageBox.Show("File is no longer in original location");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void btnReadMe_Click_1(object sender, EventArgs e)
        {
            frmReadMe readit = new frmReadMe();
            readit.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
