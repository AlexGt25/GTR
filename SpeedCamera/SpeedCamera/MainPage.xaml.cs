using Windows.UI.Xaml.Controls;

namespace GtDev.SpeedCamera
{
    public sealed partial class MainPage : Page
    {
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
        }

    }
}
