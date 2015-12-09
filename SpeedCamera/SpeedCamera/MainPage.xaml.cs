using Newtonsoft.Json;
using System.Linq;
using Windows.Storage;
using Windows.UI.Xaml.Controls;

namespace GtDev.SpeedCamera
{

    public sealed partial class MainPage : Page
    {
        private ApplicationDataContainer appSettings = ApplicationData.Current.RoamingSettings;

        public Model Model
        {
            get
            {
                return (Model)DataContext;
            }
        }

        public MainPage()
        {
            this.InitializeComponent();
            DataContext = appSettings.Values.Keys.Contains(Constants.StateKey) ?
                JsonConvert.DeserializeObject<Model>((string)appSettings.Values[Constants.StateKey])
                : new Model();

            ((Model)DataContext).PropertyChanged += MainPage_PropertyChanged;
        }

        private void MainPage_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            appSettings.Values[Constants.StateKey] = JsonConvert.SerializeObject(DataContext);
        }

        private void wvResult_DoubleTapped(object sender, Windows.UI.Xaml.Input.DoubleTappedRoutedEventArgs e)
        {
            ((WebView)sender).NavigateToString(
"<html><body><h2>This is an HTML fragment</h2></body></html>");
        }
    }
}

