namespace GtDev.SpeedCamera
{
    public class Model : BindableBase
    {


        //private List<Car> _cars;
        //public List<Car> Groups
        //{
        //    get { return _cars; }
        //    set { SetProperty(ref _cars, value); }
        //}


        public string Test
        {
            get { return GetProperty<string>(); }
            set { SetProperty(value); }
        }

    }

    //public class Car
    //{
    //    public string LastName
    //    {
    //        get { return appSettings.Contains("LastName") ? (string)appSettings["LastName"] : string.Empty; }
    //        set
    //        {
    //            appSettings["LastName"] = value;
    //            appSettings.Save();
    //            NotifyPropertyChanged();
    //            NotifyPropertyChanged("ParametersReady");
    //        }
    //    }

    //    public string FirstName
    //    {
    //        get { return appSettings.Contains("FirstName") ? (string)appSettings["FirstName"] : string.Empty; }
    //        set
    //        {
    //            appSettings["FirstName"] = value;
    //            appSettings.Save();
    //            NotifyPropertyChanged();
    //            NotifyPropertyChanged("ParametersReady");
    //        }
    //    }

    //    public string MiddleName
    //    {
    //        get { return appSettings.Contains("MiddleName") ? (string)appSettings["MiddleName"] : string.Empty; }
    //        set
    //        {
    //            appSettings["MiddleName"] = value;
    //            appSettings.Save();
    //            NotifyPropertyChanged();
    //            NotifyPropertyChanged("ParametersReady");
    //        }
    //    }



    //    public string Series
    //    {
    //        get { return appSettings.Contains("Series") ? (string)appSettings["Series"] : string.Empty; }
    //        set
    //        {
    //            appSettings["Series"] = value;
    //            appSettings.Save();
    //            NotifyPropertyChanged();
    //            NotifyPropertyChanged("ParametersReady");
    //        }
    //    }

    //    public string Number
    //    {
    //        get { return appSettings.Contains("Number") ? (string)appSettings["Number"] : string.Empty; }
    //        set
    //        {
    //            appSettings["Number"] = value;
    //            appSettings.Save();
    //            NotifyPropertyChanged();
    //            NotifyPropertyChanged("ParametersReady");
    //        }
    //    }

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
