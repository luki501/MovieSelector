using GalaSoft.MvvmLight.Command;
using MovieSelector2.Model;

namespace MovieSelector2.ViewModel
{
    public class WindowDialogVM : ObservedObject
    {
        public bool OK { get; set; }
        public string Tekst { get; set; }

        public WindowDialogVM(string tekst)
        {
            Tekst = tekst;
            OnPropertyChanged("Tekst");
            OK = true;
        }

        private RelayCommand<bool> clickCommand;
        public RelayCommand<bool> ClickCommand
        {
            get
            {
                if (clickCommand == null)
                    clickCommand = new RelayCommand<bool>(Click);
                return clickCommand;
            }
        }

        private void Click(bool ok)
        {
            OK = ok;
        }
    }
}
