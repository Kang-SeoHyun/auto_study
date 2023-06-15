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
    public partial class array : Form
    {
        public array()
        {
            InitializeComponent();
            ArrayTest();
            ArrayClassTest();
        }

        private void ArrayTest()
        {
            string strTest1 = "가 나 다 라";
            strTest1.ToLower();
            string[] strTest2 = { "가", "나", "다", "라" };

            int[] arrayTest1 = { 12, 9, 18, 21, 14, 19, 23, 31 };
            int[] arrayTest2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] arrayTest3 = new int[5];
            arrayTest3[2] = 3;
            arrayTest3[3] = 4;
            // arrayTest3[10] = 4;

            // 2차원 배열
            int[,] arrayTest4 = new int[2, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 } };
        }

        private void ArrayClassTest()
        {
            int[] iTest = { 10, 20, 30, 40, 50 };

            int i = iTest.Length;
            // Array 클래스에 Clear 메소드
            Array.Clear(iTest, 2, 2);
            i = iTest.Length;

            Array.Resize(ref iTest, 10);
            i = iTest.Length;

            int iSearch30 = Array.IndexOf(iTest, 50);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            int[] day = { 12, 9, 18, 21, 14, 19, 23 };
            lblArrayCnt.Text = String.Format("전체 자료수 : {0}", day.Length);

            for (int i = 0; i < day.Length; i++)
            {
                dataGridView1[string.Format("colDay{0}", (i+1).ToString()), 0].Value = day[i];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            int[,] day = { { 12, 9, 18, 21, 14, 19, 23 }, { 7, 22, 37, 3, 16, 2, 15 } };
            lblArrayCnt.Text = String.Format("전체 자료수 : {0}", day.Length);

            dataGridView1.Rows.Add();
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    // string.Format("colDay{0}", (i+1).ToString()) -> 이렇게 표현가능
                    string str1 = "colDay" + (i+1).ToString();
                    dataGridView1[str1, j].Value = day[j, i];
                }
            }
        }
    }
}
