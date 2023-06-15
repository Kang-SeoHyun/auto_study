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
    public partial class list_Box : Form
    {
        public list_Box()
        {
            InitializeComponent();
        }

        private enum enumDay
        {
            Monday , // = 0
            Tuesday, // = 1
            Wednesday, // 숫자지정 가능 만약 안하면 01234임
            Thursday, 
            Friday,
            Saturday,
            Sunday ,
        }

        private enum enumTime
        {
            morning,
            afternoon,
            evening,
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Day.Items.Add(enumDay.Monday.ToString());
            Day.Items.Add(enumDay.Tuesday.ToString());
            Day.Items.Add(enumDay.Wednesday.ToString());
            Day.Items.Add(enumDay.Thursday.ToString());
            Day.Items.Add(enumDay.Friday.ToString());
            Day.Items.Add(enumDay.Saturday.ToString());
            Day.Items.Add(enumDay.Sunday.ToString());

            Time.Items.Add(enumTime.morning.ToString());
            Time.Items.Add(enumTime.afternoon.ToString());
            Time.Items.Add(enumTime.evening.ToString());
        }

        private void result1_Click(object sender, EventArgs e)
        {
            try
            {
                string strResult = name.Text + "랑 " + Day.SelectedItem.ToString() + "에 " + Time.SelectedItem.ToString() + "때 보기로 했습니다.";
                tBoxResult.Text = strResult;
            }
            catch
            {
                tBoxResult.Text = "약속 없어용";
            }
        }

        private void result2_Click(object sender, EventArgs e)
        {
            tBoxResult.Text = TextLoad(name.Text, Day.SelectedItem.ToString(), Time.SelectedItem.ToString());
        }

        private void tBoxResult_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 여기다가 함수 설명 넣으면 됨. 오 함수 위에 마우스 올리면 설명 뜸 개쩔어
        /// </summary>
        /// <param name="strName"> 여기는 인자 설명 넣으면 됨.</param>
        /// <param name="strDay">주석 세번 누르면 됨.</param>
        /// <param name="strTime">씨샵 자동완성 개쩌네.</param>
        /// <returns>누구누구랑 언제 몇시에 보기로 함 을 리턴하는 함수!</returns>
        private string TextLoad (string strName,  string strDay, string strTime)
        {
            string strResult = String.Format("{0}랑 {1}에 {2}때 보기로 했슴둥 ~", strName, strDay, strTime);
            
            return strResult;
        }
    }
}
