using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace dori_study
{

    /// <summary>
    /// 변수, partial 붙어있는 클래스는 같은 클래스라고 보면 됨.
    /// </summary>
    partial class cData
    {
        private double _dTotalPrice = 0.0;
        public double DTotalPrice 
        { 
            get => _dTotalPrice;
            set
            {
                _dTotalPrice += value;
            }
        }

        private string _strItem = string.Empty;
        public string StrItem
        {
            //get 
            //{ 
            //    return strItem; 
            //}
            //// 위가 예전 자주 보던 형식
            //set => strItem = value; 
            set 
            {
                if (String.IsNullOrEmpty(value))
                {
                    _strError = "물건이 선택되지 않았습니다.";
                }else
                {
                    _strItem = value;
                }
            }
        }

        private int _iRate = 0; // 애는 숨기고 밑에서 public으로 바꾼걸 캡슐화라고 함.
        public int IRate
        {
            ///get => _iRate;
            set
            {
                if (value > 20)
                {
                    _strError = "사장님만 가능한 할인입니다.";
                }
                else
                {
                    _iRate = value;
                }
            }
        }

        public string StrError
        {
            get
            {
                return _strError;
            }
            // 읽기전용이니까 get만 있으면 됨.
            // set => _strError = value;
        }

        private string _strError = string.Empty;
        public int iCount = 0;


        //// 1번 버전 - 더 많이 사용 - 위에서 해봄
        //public string StrItem { get => strItem; set => strItem = value; }
        
        //// 2번 버전
        //public string GetStrItem()
        //{
        //    return StrItem;
        //}
        //public void SetStrItem(string value)
        //{
        //    StrItem = value;
        //}
    }

    /// <summary>
    /// 수식 계산
    /// </summary>
    partial class cData
    {
        public double fItemPrice()
        {
            double dprice = 0;
            int iItemPrice = 0;

            if (String.IsNullOrEmpty(_strError))
            { 
                iItemPrice = (int)(Enum.Parse(typeof(EnumItem), _strItem));
                dprice = iItemPrice - Math.Round((double)iItemPrice * (double)_iRate / 100, 2);
            }
            return dprice * iCount;
        }
    }

    partial class cData
    {
        public string fResult(double dprice)
        {
            if (_iRate == 0)
            {
                return string.Format("{0} X {1} : {2}원)", _strItem, iCount, dprice);
            }
            else
            {
                return string.Format("{0} X {1} : {2}원 (할인율 : {3}%) )", _strItem, iCount, dprice, _iRate);
            }
        }

        public void fDataResult()
        {
            _strError = string.Empty;   
            _strItem = string.Empty;
            _iRate = 0;
            iCount = 0;
        }
    }
}
