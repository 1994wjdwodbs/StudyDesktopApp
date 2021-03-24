using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestApp
{
    // ObservableCollection
    // : 항목이 추가 또는 제거되거나 전체 목록이 새로 고쳐진 경우 알림을 제공하는 동적 데이터 컬렉션을 나타냅니다.
    // - INotifyCollectionChanged (interface)
    // : 항목이 추가 및 제거되거나 전체 목록이 지워진 경우, 동적 변경 내용을 수신기에 알립니다.
    // - INotifyPropertyChanged (interface)
    // : 속성 값이 변경되었음을 클라이언트에 알립니다.
    class PersonList : ObservableCollection<Person>
    {
        public PersonList()
        {
            this.Add(new Person() { FirstName="Willa", LastName="Cather"});
            this.Add(new Person("Isak", "Dinensen"));
            this.Add(new Person("Victor", "Hugo"));
            Add(new Person("Jules", "Verne"));
        }
    }
}
