using MovieSelector2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieSelector2.View
{
    /// <summary>
    /// Interaction logic for TurniejWindow.xaml
    /// </summary>
    public partial class TurniejWindow : Window
    {
        public TurniejWindow(TurniejWindowVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
