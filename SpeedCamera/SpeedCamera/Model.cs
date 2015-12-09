using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GtDev.SpeedCamera
{
    public class Model : BindableBase
    {
        public int SelectedCarIndex { get; set; }
        public bool ProgressBarVisibility { get; set; }

        public Model()
        {
            cars.CollectionChanged += Cars_CollectionChanged;
            cars.Add(new Car());
            RefreshCommand = new DelegateCommand(RefreshExecute);
            AddCarCommand = new DelegateCommand(AddCarExecute);
            RemoveCommand = new DelegateCommand(RemoveExecute);
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
            this.OnPropertyChanged("Cars");
        }

        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.OnPropertyChanged("Cars");
        }

        #region commands

        public ICommand AddCarCommand { get; set; }

        void AddCarExecute(object obj)
        {
            Car car = new Car { Name = "..." };
            Cars.Add(car);
            SelectedCarIndex = Cars.Count - 1;
        }

        public ICommand RemoveCommand { get; set; }

        void RemoveExecute(object obj)
        {
            if (Cars.Count > SelectedCarIndex)
                Cars.RemoveAt(SelectedCarIndex);
        }
        public ICommand RefreshCommand { get; set; }

        void RefreshExecute(object obj)
        {
            ProgressBarVisibility = true;

            List<Task<mvdgovbyServiceReference.GetExtResponse>> tasks = new List<Task<mvdgovbyServiceReference.GetExtResponse>>();

            foreach (Car car in Cars)
            {
                Task<mvdgovbyServiceReference.GetExtResponse> task = Refresh(car);
                tasks.Add(task);
            }
            Task.WaitAll(tasks.ToArray());
            ProgressBarVisibility = false;
        }

        private async Task<mvdgovbyServiceReference.GetExtResponse> Refresh(Car car)
        {
            mvdgovbyServiceReference.AjaxSoapClient client = new mvdgovbyServiceReference.AjaxSoapClient();

            //client.GetExtCompleted += client_GetExtCompleted;
            return await client.GetExtAsync(Constants.GuidControl,
                $"{car.LastName} {car.FirstName} {car.MiddleName}",
                // "примачук александр викторович",
                //"АВА",
                car.Series,
            //    "137435"
                car.Number);
        }

        #endregion
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
