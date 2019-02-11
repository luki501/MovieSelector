using GalaSoft.MvvmLight.Command;
using MovieSelector2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSelector2.ViewModel
{
    public class EdycjaFilmuPageVM : ObservedObject
    {
        #region fields
        private Film filmEdytowany;
        public Film FilmEdytowany { get { return filmEdytowany; } set { filmEdytowany = value; OnPropertyChanged("FilmEdytowany"); } }
        #endregion

        #region commands
        private RelayCommand zapiszFilmCommand;
        
        public RelayCommand ZapiszFilmCommand
        {
            get
            {
                if (zapiszFilmCommand == null)
                    zapiszFilmCommand = new RelayCommand(ZapiszFilm);
                return zapiszFilmCommand;
            }
        }

        #endregion

        #region constructors
        public EdycjaFilmuPageVM()
        {
            FilmEdytowany = new Film(new FilmEF());
        }
        public EdycjaFilmuPageVM(Film film)
        {
            FilmEdytowany = film;
        }
        #endregion

        #region methods
        private void ZapiszFilm()
        {
            bool ok = filmEdytowany.Save();            
        }
        public void OdswiezDane()
        {
            OnPropertyChanged("FilmEdytowany");
        }
        #endregion
    }
}
