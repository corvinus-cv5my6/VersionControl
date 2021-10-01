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

namespace UserMaintenance
{
    public partial class Form1 : Form
    {
        BindingList<UserMaintenance.Entities.User> users = new BindingList<UserMaintenance.Entities.User>();
        public Form1()
        {
            InitializeComponent();
            label1.Text = Resource1.FullName; // label1
          //  label2.Text = Resource1.FirstName; // label2
            button1.Text = Resource1.Add; // button1
            listBox1.DataSource = users;
            listBox1.ValueMember = "ID";
            listBox1.DisplayMember = "FullName";
            button2.Text = Resource1.WriteInFile;

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var u = new UserMaintenance.Entities.User()
            {
                FullName = textBox1.Text,

            };
            users.Add(u);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
          
            if (sfd.ShowDialog() != DialogResult.OK) return;

            using (StreamWriter sw = new StreamWriter(sfd.FileName, false, Encoding.UTF8))
            {
                foreach (var u in users)
                {
                    sw.WriteLine(string.Format(
                        "{0};{1}",
                        u.ID,
                        u.FullName));
                } 
            
            }
           }
    }
}
