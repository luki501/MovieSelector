using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector2.Model
{
    public abstract class ObservedObject : INotifyPropertyChanged
    {
        // zmiana w kolekcji
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(params string[] nazwyWlasnosci)
        {
            if (PropertyChanged != null)
            {
                foreach (string wlasnosc in nazwyWlasnosci)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(wlasnosc));
                }
            }
        }
    }
}
