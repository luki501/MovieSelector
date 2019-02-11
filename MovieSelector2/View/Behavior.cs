using MovieSelector2.Model;
using MovieSelector2.ViewModel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Media;

namespace MovieSelector2.View
{    
    public class ZamykanieProgramu : Behavior<Window>
    {        
        protected override void OnAttached()
        {
            Window window = this.AssociatedObject;
            if (window != null)
                window.Closing += Window_Closing;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            throw new NotImplementedException();
        }        
    }    

    public class NowyFilm : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }        
        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            var parent = VisualTreeHelper.GetParent(sender as Button);
            EdycjaFilmuPage page = new EdycjaFilmuPage();
            while (!(parent is MainWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            EdycjaFilmuPageVM vm = new EdycjaFilmuPageVM();
            page.DataContext = vm;
            Switcher.mainWindowSwitcher = parent as MainWindow;
            Switcher.Switch(page);
        }
    }

    public class EdytujFilm : Behavior<Button>
    {        
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(sender as Button);
            EdycjaFilmuPage page = new EdycjaFilmuPage();
            while (!(parent is MainWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);                
            }
            Film film = ((parent as MainWindow).DataContext as MainWindowVM).FilmZaznaczony;
            if (film != null)
            {
                EdycjaFilmuPageVM vm = new EdycjaFilmuPageVM(film);
                page.DataContext = vm;                
                Switcher.mainWindowSwitcher = parent as MainWindow;
                Switcher.Switch(page);
            }
        }
    }

    public class ClosePage : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(sender as Button);
            while (!(parent is MainWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            MainPage page = new MainPage(parent as MainWindow);
            Switcher.mainWindowSwitcher = parent as MainWindow;
            Switcher.Switch(page);
        }
    }

    public class CloseWindow : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Window window = Window.GetWindow(btn);
            window.Close();
        }
    }

    public class PobierzDaneFilmu : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(sender as Button);
            while (!(parent is EdycjaFilmuPage))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            EdycjaFilmuPageVM vm =  (parent as EdycjaFilmuPage).DataContext as EdycjaFilmuPageVM;
            Film film = vm.FilmEdytowany;
            JObject elements = film.PobierzDaneZMovieDb();
            WindowMovieDB window = new WindowMovieDB(vm.FilmEdytowany, elements);
            window.ShowDialog();
            vm.OdswiezDane();
        }
    }
    public class StartTurnieju : Behavior<Button>
    {
        protected override void OnAttached()
        {
            Button button = this.AssociatedObject;
            if (button != null)
                button.Click += Button_Click;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var parent = VisualTreeHelper.GetParent(sender as Button);            
            while (!(parent is MainWindow))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }            
            ((parent as MainWindow).DataContext as MainWindowVM).StartTurnieju();
            List<Film> filmy = ((parent as MainWindow).DataContext as MainWindowVM).FilmyTurniejowe;
            List<string> gracze = ((parent as MainWindow).DataContext as MainWindowVM).ListaGraczy.ToList();            
            if (filmy != null && gracze != null)
            {                
                TurniejWindowVM vm = new TurniejWindowVM(gracze, filmy);
                TurniejWindow window = new TurniejWindow(vm);
                window.Show();
            }
        }
    }
    public static class WebBrowserUtility
    {
        public static readonly DependencyProperty BindableSourceProperty =
            DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            WebBrowser browser = o as WebBrowser;
            if (browser != null)
            {
                string uri = e.NewValue as string;                
                browser.Source = !String.IsNullOrEmpty(uri) ? new Uri(uri) : null;
                browser.Navigate(browser.Source);
            }
        }
    }
    public class DataGridSelectedItemsBlendBehavior : Behavior<DataGrid>
    {       
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItems", typeof(ObservableCollection<object>),
            typeof(DataGridSelectedItemsBlendBehavior),
            new FrameworkPropertyMetadata(null)
            {
                BindsTwoWayByDefault = true
            });

        public ObservableCollection<object> SelectedItems
        {
            get
            {
                return (ObservableCollection<object>)GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += OnSelectionChanged;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.SelectedItems != null)
            {
                var selectedItems = this.SelectedItems.ToList();
                foreach (var obj in selectedItems)
                {
                    var rowContainer = this.AssociatedObject.ItemContainerGenerator.ContainerFromItem(obj) as DataGridRow;
                    if (rowContainer != null)
                    {
                        rowContainer.IsSelected = true;
                    }
                }
            }
            else
                this.SelectedItems = new ObservableCollection<object>();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (this.AssociatedObject != null)
            {
                this.AssociatedObject.SelectionChanged -= OnSelectionChanged;
                this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            }
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems != null && e.AddedItems.Count > 0 && this.SelectedItems != null)
            {
                foreach (object obj in e.AddedItems)
                    this.SelectedItems.Add(obj);
            }

            if (e.RemovedItems != null && e.RemovedItems.Count > 0 && this.SelectedItems != null)
            {
                foreach (object obj in e.RemovedItems)
                    this.SelectedItems.Remove(obj);
            }
        }
    }
}
