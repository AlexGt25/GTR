using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace GtDev.SpeedCamera
{
    public class Model : BindableBase
    {
        public Model()
        {
            cars.CollectionChanged += Cars_CollectionChanged;
            cars.Add(new Car());
        }

        private void Cars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    ((Car)item).PropertyChanged += Model_PropertyChanged;
                }
            }
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged("Cars");
        }

        private ObservableCollection<Car> cars = new ObservableCollection<Car>();
        public ObservableCollection<Car> Cars
        {
            get { return cars; }
            set { SetProperty(ref cars, value); }
        }

        private string test;
        public string Test
        {
            get { return test; }
            set { SetProperty(ref test, value); }
        }
    }

    public class Car : BindableBase
    {
        private string name;
        private string lastName;
        private string firstName;
        private string middleName;
        private string series;
        private string number;

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                SetProperty(ref lastName, value);
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                SetProperty(ref firstName, value);
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                SetProperty(ref middleName, value);
            }
        }

        public string Series
        {
            get
            {
                return series;
            }

            set
            {
                SetProperty(ref series, value);
            }
        }

        public string Number
        {
            get
            {
                return number;
            }

            set
            {
                SetProperty(ref number, value);
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                SetProperty(ref name, value);
            }
        }
    }

  

    //    public bool ParametersReady
    //    {
    //        get
    //        {
    //            return
    //                !string.IsNullOrEmpty(LastName) &&
    //                !string.IsNullOrEmpty(FirstName) &&
    //                !string.IsNullOrEmpty(MiddleName) &&
    //                !string.IsNullOrEmpty(Series) &&
    //                !string.IsNullOrEmpty(Number);
    //        }
    //    }
    //}
}
