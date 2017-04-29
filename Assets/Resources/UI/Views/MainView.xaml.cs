using System.Windows.Controls;
using REDBlend.Assets.UI.ViewModels;

namespace REDBlend.Assets.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            this.InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
