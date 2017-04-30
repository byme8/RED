using System.Windows.Controls;
using REDBlend.Assets.Resources.UI.ViewModels;

namespace REDBlend.Assets.Resources.UI.Views
{
    /// <summary>
    /// Interaction logic for CategoriesView.xaml
    /// </summary>
    public partial class CategoriesView : UserControl
    {
        public CategoriesView()
        {
            InitializeComponent();
            this.DataContext = new CategoriesViewModel();
        }
    }
}
