﻿using Newtonsoft.Json;
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

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ((Model)DataContext).Cars.Add(new Car() { Name = "..." });
            pCars.SelectedIndex = pCars.Items.Count - 1;
        }

        private void AppBarButton_Click_1(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (pCars.Items.Any())
                ((Model)DataContext).Cars.RemoveAt(pCars.SelectedIndex);
        }
    }
}
