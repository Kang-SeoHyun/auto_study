using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dori_study
{
    // 뒤에 값 중복되면 안됨!
    public enum EnumItem
    {
        고기 = 10000,
        과자 = 2000,
        계란 = 500,
        물 = 800,
        라면 = 1200,
        즉석식품 = 5600,
        냉동식품 = 8500,
    }

    public enum EnumRate
    {
        할인_3 = 3,
        할인_5 = 5,
        할인_10 = 10,
        할인_20 = 20,
        사장할인_80 = 80,
    }
    //internal class EnumClass
    //{
    //}
}
