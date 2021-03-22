using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WpfPracticeApp.BusinessLogic
{
    // 데이터 바인딩 (업데이트) 상속
    public class Car : Notifier
    {
        private double speed;
        // 주고 받을 때 추가적인 처리를 하고 싶으면
        // { get ; set ; } 말고 { get { ~;} set { ~;} }
        public double Speed 
        {
            get
            {
                return speed;
            }
            set
            {
                if (value > 350)
                {
                    speed = 350;
                }
                else
                {
                    speed = value;
                }
                // 속성값 바뀐 것을 알려줌 (프로그램에)
                OnPropertyChanged("Speed");
            } 
        }
        // System.Windows.Media.Color
        private Color mainColor;
        public Color MainColor { 
            get
            {
                return mainColor;
            } 
            set
            {
                mainColor = value;
                OnPropertyChanged("MainColor");
            }
                }
        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDiveLicense { get; set; }
    }
}
