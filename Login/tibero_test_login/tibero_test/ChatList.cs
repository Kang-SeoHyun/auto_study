using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tibero_test
{
    public partial class ChatList : Form
    {
        // 이전 Home 폼을 저장하기 위한 변수
        private Home home;
        public ChatList(Home home)
        {
            this.home = home;
            InitializeComponent();
        }

        private void chat_list_Load(object sender, EventArgs e)
        {
            
        }
        protected override void OnClosed(EventArgs e)
        {
            home.Show();
        }
    }
}
