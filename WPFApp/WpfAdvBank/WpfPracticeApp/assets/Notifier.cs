using System.ComponentModel;

// INotifyPropertyChanged (Interface)
// 속성(Property) 값이 변경되었음을 클라이언트에게 알림
public class Notifier : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        if (PropertyChanged != null)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
