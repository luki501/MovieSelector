using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MovieSelector2.Model;
using System.Collections.ObjectModel;


namespace MovieSelector2.ViewModel
{
    public class MainWindowVM : ObservedObject
    {
        #region fields
        private Filmy listaFilmow;
        private ObservableCollection<string> listaGraczy;
        private bool isTylkoZaznaczone;
        private string szukanaFrazaTytul;
        private string szukanaFrazaOsoba;
        private string szukanaFrazaGatunek;
        private string szukanaMinLokata;
        private int iloscFilmow;
        private int pulaFilmow;
        private string wybranyGracz;
        private int szukanaMinLokataInt;
        private ObservableCollection<object> selectedItems;

        public Filmy ListaFilmow { get { return listaFilmow; } set { listaFilmow = value; OnPropertyChanged("ListaFilmowView"); } }
        public ObservableCollection<string> ListaGraczy { get { return listaGraczy; } set { listaGraczy = value; } }
        public bool IsTylkoZaznaczone { get { return isTylkoZaznaczone; } set { isTylkoZaznaczone = value; OnPropertyChanged("ListaFilmowView"); } }
        public string SzukanaFrazaTytul { get { return szukanaFrazaTytul.ToLower(); } set { szukanaFrazaTytul = value; OnPropertyChanged("ListaFilmowView"); } }
        public string SzukanaFrazaOsoba { get { return szukanaFrazaOsoba.ToLower(); } set { szukanaFrazaOsoba = value; OnPropertyChanged("ListaFilmowView"); } }
        public string SzukanaFrazaGatunek { get { return szukanaFrazaGatunek.ToLower(); } set { szukanaFrazaGatunek = value; OnPropertyChanged("ListaFilmowView"); } }        
        public Film FilmZaznaczony { get { return ListaFilmow.WybranyFilm; } set { ListaFilmow.WybranyFilm = value; } }
        public List<Film> FilmyTurniejowe { get; set; }
        private IDialogService dialogService;
        public ObservableCollection<string> RodzajeTurniejow { get; set; }
        public int PulaFilmow { get { return pulaFilmow; } set { if (value < iloscFilmow) pulaFilmow = iloscFilmow; else pulaFilmow = value; } }
        public int IloscFilmow { get { return iloscFilmow; } set { if (value > pulaFilmow) iloscFilmow = pulaFilmow; else iloscFilmow = value; } }
        public int IdRodzajuTurnieju { get; set; }
        public string WybranyGracz { get { return wybranyGracz; } set { wybranyGracz = value; OnPropertyChanged("ListaFilmowView"); } }
        public ObservableCollection<object> FilmyZaznaczone { get { return selectedItems; } set { selectedItems = value; } }
        public string SzukanaMinLokata { get { return szukanaMinLokata; }
            set
            {
                szukanaMinLokata = value;
                if (!Int32.TryParse(szukanaMinLokata, out szukanaMinLokataInt))
                    szukanaMinLokataInt = 0;
                OnPropertyChanged("ListaFilmowView");
            }
        }
        public ObservableCollection<Film> ListaFilmowView
        {
            get
            {
                if (WybranyGracz.Equals(""))
                    return new ObservableCollection<Film>(ListaFilmow.Where(f => (!f.IsObejrzany || !IsTylkoZaznaczone)
                && (SzukanaFrazaTytul.Equals("") || f.Tytul.ToLower().Contains(szukanaFrazaTytul) || f.TytulOrg.ToLower().Contains(szukanaFrazaTytul))
                && (SzukanaFrazaOsoba.Equals("") || f.Rezyseria.ToLower().Contains(szukanaFrazaOsoba) || f.Obsada.ToLower().Contains(SzukanaFrazaOsoba))
                && (SzukanaFrazaGatunek.Equals("") || f.Kategoria.ToLower().Contains(SzukanaFrazaGatunek))
                && f.Lokata >= szukanaMinLokataInt));
                else
                    return WybraneFilmyDlaGracza(wybranyGracz);
            }
        }

        private ObservableCollection<Film> WybraneFilmyDlaGracza(string wybranyGracz)
        {
            try
            {
                return new ObservableCollection<Film>(
                    listaFilmow.Where(f => !f.IsObejrzany
                && f.ListaSkreslen.Sum(s => s.Ilosc) > 10
                && (f.ListaSkreslen.Where(s => s.Nick.Equals(wybranyGracz)).Sum(s => s.Ilosc) > 0 && f.ListaSkreslen.Sum(s => s.Ilosc) / f.ListaSkreslen.Where(s => s.Nick.Equals(wybranyGracz)).Sum(s => s.Ilosc) > 10
                    || f.ListaSkreslen.Where(s => s.Nick.Equals(wybranyGracz)).Sum(s => s.Ilosc) == 0)
                ));
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        #region commands
        private RelayCommand usunFilmCommand;
        private RelayCommand loadedCommand;
        private RelayCommand<string> dodajGraczaCommand;
        private RelayCommand ustawJakoObejrzanyCommand;
        private RelayCommand<string> filmyDlaGraczaCommand;

        public RelayCommand UsunFilmCommand
        {
            get
            {
                if (usunFilmCommand == null)
                    usunFilmCommand = new RelayCommand(UsunFilm);
                return usunFilmCommand;
            }
        }

        public RelayCommand LoadedCommand
        {
            get
            {
                if (loadedCommand == null)
                    loadedCommand = new RelayCommand(OdswiezListeFilmow);
                return loadedCommand;
            }
        }

        public RelayCommand<string> DodajGraczaCommand
        {
            get
            {
                if (dodajGraczaCommand == null)
                    dodajGraczaCommand = new RelayCommand<string>(DodajGracza);
                return dodajGraczaCommand;
            }
        }
        public RelayCommand UstawJakoObejrzanyCommand
        {
            get
            {
                if (ustawJakoObejrzanyCommand == null)
                    ustawJakoObejrzanyCommand = new RelayCommand(UstawJakoObejrzany);
                return ustawJakoObejrzanyCommand;
            }
        }
        public RelayCommand<string> FilmyDlaGraczaCommand
        {
            get
            {
                if (filmyDlaGraczaCommand == null)
                    filmyDlaGraczaCommand = new RelayCommand<string>(FilmyDlaGracza);
                return filmyDlaGraczaCommand;
            }
        }

        #endregion

        #region constructors
        public MainWindowVM()
        {
            try
            {
                ListaFilmow = new Filmy();
                IsTylkoZaznaczone = true;
                szukanaFrazaTytul = "";
                szukanaFrazaOsoba = "";
                szukanaFrazaGatunek = "";
                listaGraczy = new ObservableCollection<string>(MovieSelector2.Properties.Settings.Default.ListaGraczy.Cast<string>().ToList());
                RodzajeTurniejow = new ObservableCollection<string>(Properties.Settings.Default.RodzajeTurniejow.Cast<string>().ToList());                
                pulaFilmow = 60;
                iloscFilmow = 30;
                IdRodzajuTurnieju = 0;
                selectedItems = new ObservableCollection<object>();
                WybranyGracz = "";
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        #region command methods
        private void UsunFilm()
        {
            try
            {
                if (FilmZaznaczony != null)
                {
                    dialogService = new DialogService();
                    bool usun = dialogService.ShowQuestion(string.Format("Usunąć film {0}", FilmZaznaczony.Tytul), "Ostrzeżenie");
                    if (usun)
                    {
                        DataServerFacade.UsunFilm(FilmZaznaczony);
                        OdswiezListeFilmow();
                    }
                }

            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void DodajGracza(string gracz)
        {
            listaGraczy.Add(gracz);
        }
        public void OdswiezListeFilmow()
        {
            ListaFilmow = new Filmy();
        }
        private void UstawJakoObejrzany()
        {
            if (FilmZaznaczony != null)
                FilmZaznaczony.UstawJakoObejrzany();
            OdswiezListeFilmow();
        }
        public void StartTurnieju()
        {
            try
            {
                FilmyTurniejowe = new List<Film>();
                int ile = IloscFilmow; //(int)numericUpDown1.Value;
                int pula = PulaFilmow; //(int)numericUpDownPula.Value;
                List<Film> lista = new List<Film>();
                if (IdRodzajuTurnieju == 0)
                {
                    int dodatkowaPula = listaFilmow.Take(pula).Where(f => f.Nieaktywny).Count();
                    pula += dodatkowaPula;
                    lista = ListaFilmow.Where(f => !f.IsObejrzany && !f.Nieaktywny).Take(pula).ToList();
                }
                else if (IdRodzajuTurnieju == 1)
                {
                    int dodatkowaPula = listaFilmow.OrderBy(f => f.Dlugosc).Take(pula).Where(f => f.Nieaktywny).Count();
                    pula += dodatkowaPula;
                    lista = ListaFilmow.OrderBy(f => f.Dlugosc).Where(f => !f.IsObejrzany && !f.Nieaktywny).Take(pula).ToList();
                }
                else if (IdRodzajuTurnieju == 2)
                {
                    lista = ListaFilmowView.Where(f => !f.Nieaktywny).ToList();                    
                }
                Random random = new Random();
                if (lista.Count < ile)
                    ile = lista.Count;
                while (ile > 0)
                {
                    int los = random.Next(lista.Count());
                    Film film = lista.ElementAt(los);
                    if (!FilmyTurniejowe.Contains(film))
                    {
                        ile--;
                        FilmyTurniejowe.Add(film);
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void FilmyDlaGracza(string gracz)
        {
            try
            {
                WybranyGracz = gracz;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion

        #region methods

        #endregion

        #region events

        #endregion

    }

}
