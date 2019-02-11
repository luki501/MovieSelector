using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace MovieSelector2.View
{
    public static class Switcher
    {
        public static MainWindow mainWindowSwitcher;
        public static MainPage mainPageSwitcher;

        public static void Switch(Page newPage)
        {
            if (mainWindowSwitcher != null)
                mainWindowSwitcher.Navigate(newPage);
            else if (mainPageSwitcher != null)
                mainPageSwitcher.Navigate(newPage);
            mainWindowSwitcher = null;
            mainPageSwitcher = null;
        }
    }
}
