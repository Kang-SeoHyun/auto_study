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
    public partial class partial : Form
    {
        cData _Data= new cData();
        public partial()
        {
            InitializeComponent();
        }

        private void partial_Load(object sender, EventArgs e)
        {
            EnumItem[] ei = (EnumItem[])Enum.GetValues(typeof(EnumItem));
            foreach (EnumItem item in ei)
            {
                cboxitem1.Items.Add(item.ToString());
            }
            foreach (EnumRate item in (EnumRate[])Enum.GetValues(typeof(EnumRate)))
            {
                cboxitem2.Items.Add(item.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _Data.fDataResult();
            _Data.StrItem = cboxitem1.Text;
            _Data.IRate = (int)Enum.Parse(typeof(EnumRate), cboxitem2.Text);
            _Data.iCount = (int)numcnt.Value;

            if (!String.IsNullOrEmpty(_Data.StrError))
            {
                textBox2.Text = _Data.StrError;
                return;
            }

            double dPrice = _Data.fItemPrice();
            listBox1.Items.Add(_Data.fResult(dPrice));

            _Data.DTotalPrice = dPrice;
            textBox1.Text = _Data.DTotalPrice.ToString() + "원";

            //_Data.StrItem = "hi"; // 이게 SET
            //string dd = _Data.StrItem; // 이게 GET

            //if(cboxitem1.Text != null)
            //{
            //    _Data.SetStrItem(cboxitem1.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Error");
            //}
            //_Data.iRate = int.Parse(cboxitem2.Text);
            //_Data.iCount = (int)numcnt.Value;
        }
    }
}
