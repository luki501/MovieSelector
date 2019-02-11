using System.Windows;
using MovieSelector2.ViewModel;

namespace MovieSelector2.View
{
    /// <summary>
    /// Interaction logic for WindowDialog.xaml
    /// </summary>
    public partial class WindowDialog : Window
    {
        public WindowDialog(string tekst)
        {
            InitializeComponent();
            this.DataContext = new WindowDialogVM(tekst);
        }
    }
}
