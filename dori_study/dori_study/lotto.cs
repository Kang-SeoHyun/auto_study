using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dori_study
{
    public partial class lotto : Form
    {
        public lotto()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            // 나중에 리스트 배울 것!
            // List<int> list = new List<int>();

            int[] arr = new int[6];

            StringBuilder sb = new StringBuilder();
            // 난수 발생 용 함수
            // 실무에선 ㅂㄹ안씀 - 게임쪽은 씀
            Random rd = new Random();

            int i = -1;
            while (++i < 6)
            {
                int rdNum = rd.Next(1, 46);
                while (Array.IndexOf(arr, rdNum) != -1)
                    rdNum = rd.Next(1, 46);
                arr[i] = rdNum;
                // sb.Append(rdNum.ToString() + " ");
            }
            Array.Sort(arr);
            for (int j = 0; j < 6; j++)
            {
                if (arr[j] < 10)
                    sb.Append("" + arr[j].ToString());
                else
                    sb.Append(arr[j].ToString());
                if (j < 5)
                    sb.Append(". ");
            }
            lblResult.Text = sb.ToString();
            listBox1.Items.Add(sb.ToString());      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rd = new Random();

            int num = int.Parse(tboxNumber.Text);
            int check;
            int cnt = 0;
            if (num < 1 || num > 100)
            {
                MessageBox.Show("1 ~ 100 사이의 숫자를 선택해주세용");
                return;
            }
            do
            {
                check = rd.Next(1, 101);
                cnt++;
            } while (num != check);
            lblResult2.Text = string.Format("- 뽑은 숫자 {0}을 {1}회만에 찾았습니다.", num, cnt);
        }
    }
}
