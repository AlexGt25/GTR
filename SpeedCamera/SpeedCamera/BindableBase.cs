using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;

namespace GtDev.SpeedCamera
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ApplicationDataContainer appSettings = ApplicationData.Current.RoamingSettings;

        protected T GetProperty<T>([CallerMemberName] String propertyName = null)
        {
            return appSettings.Values.Keys.Contains(propertyName) ? (T)appSettings.Values[propertyName] : default(T);
        }


        protected void SetProperty<T>(T value, [CallerMemberName] String propertyName = null)
        {
            //       if (object.Equals(storage, value)) return false;

            appSettings.Values[propertyName] = value;
            this.OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var eventHandler = this.PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
