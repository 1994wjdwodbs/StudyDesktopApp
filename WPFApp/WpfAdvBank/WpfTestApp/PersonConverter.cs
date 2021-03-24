using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfTestApp
{
    // IMultiValueConverter (interface)
    // System.Windows.Data.MultiBinding에서 사용자 지정 논리를 적용할 방법을 제공합니다.
    class PersonConverter : IMultiValueConverter
    {
        // Convert, ConvertBack 반드시 구현

        //     소스 값을 바인딩 대상의 값으로 변환합니다. 데이터 바인딩 엔진이 소스 바인딩에서 바인딩 대상으로 값을 전파할 때 이 메서드를 호출합니다.
        //
        // 매개 변수:
        //   values:
        //     System.Windows.Data.MultiBinding의 소스 바인딩에서 생성하는 값의 배열입니다. System.Windows.DependencyProperty.UnsetValue
        //     값은 변환에 제공할 값이 소스 바인딩에 없음을 나타냅니다.
        //
        //   targetType:
        //     바인딩 대상 속성의 형식입니다.
        //
        //   parameter:
        //     사용할 변환기 매개 변수입니다.
        //
        //   culture:
        //     변환기에서 사용할 문화권입니다.
        //
        // 반환 값:
        //     변환된 값입니다. 메서드에서 null을 반환하는 경우 유효한 null 값이 사용됩니다. System.Windows.DependencyProperty.System.Windows.DependencyProperty.UnsetValue의
        //     반환 값은 변환기가 값을 생성하지 않았으며 바인딩이 System.Windows.Data.BindingBase.FallbackValue를 사용할
        //     수 있는 경우 그 값을 사용하거나, 사용할 수 없는 경우 기본값을 사용함을 나타냅니다. System.Windows.Data.Binding.System.Windows.Data.Binding.DoNothing의
        //     반환 값은 바인딩이 값을 전송하지 않거나 System.Windows.Data.BindingBase.FallbackValue 또는 기본값을
        //     사용함을 나타냅니다.
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string name;

            switch ((string)parameter)
            {
                case "FormatLastFirst":
                    name = values[1] + ", " + values[0];
                    break;
                default:
                    name = values[0] + ", " + values[1];
                    break;
            }

            return name;
        }

        //     바인딩 대상 값을 소스 바인딩 값으로 변환합니다.
        //
        // 매개 변수:
        //   value:
        //     바인딩 대상에서 생성하는 값입니다.
        //
        //   targetTypes:
        //     변환할 형식의 배열입니다. 배열 길이는 메서드에서 반환하도록 제안되는 값의 개수와 형식을 나타냅니다.
        //
        //   parameter:
        //     사용할 변환기 매개 변수입니다.
        //
        //   culture:
        //     변환기에서 사용할 문화권입니다.
        //
        // 반환 값:
        //     대상 값에서 소스 값으로 다시 변환된 값의 배열입니다.
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            var splitValues = ((string)value).Split(' ');
            return splitValues;
        }
    }
}
