using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class chatlist : Form
    {
        string regName;
        string roomName;

        public chatlist()
        {
            InitializeComponent();
        }

        private bool TextCheck()
        {
            if (this.textBox1.Text != "" && this.textBox2.Text != "")
            {
                return true;
            }
            else
                return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TextCheck())
            {
                regName = this.textBox1.Text;
                roomName = this.textBox2.Text;
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }
            else
                return;
            ListViewItem lvi = new ListViewItem(new string[] {regName, roomName});
            this.listView1.Items.Add(lvi);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count > 0)
            {
                int index = this.listView1.FocusedItem.Index;
                this.listView1.Items.RemoveAt(index);
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems.Count == 1)
            {
                string regName = listView1.SelectedItems[0].SubItems[0].Text;
                string roomName = listView1.SelectedItems[0].SubItems[1].Text;
                
                ClientForm clientForm = new ClientForm(regName, roomName, txtName.Text);
                clientForm.Connect();
                clientForm.Show();
            }
        }
    }
}
