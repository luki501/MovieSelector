using GalaSoft.MvvmLight.Command;
using MovieSelector2.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Windows.Media;

namespace MovieSelector2.ViewModel
{
    public class TurniejWindowVM : ObservedObject
    {
        #region fields
        private TrulyObservableCollection<FilmTurniej> _lista;
        private bool _alfabetycznie;
        private int indeksAktualnegoGracza;
        private IDialogService dialogService;
        private Random random = new Random();
        public List<string> ListaGraczy;
        public TrulyObservableCollection<FilmTurniej> ListaFilmow { get { return _alfabetycznie? new TrulyObservableCollection<FilmTurniej>(_lista.OrderBy(f => f.Tytul)) : _lista; } set { _lista = value; OnPropertyChanged("ListaFilmow"); } }
        public bool Alfabetycznie { get { return _alfabetycznie; } set { _alfabetycznie = value; OnPropertyChanged("Alfabetycznie", "ListaFilmow"); } }
        public string GraczAktualny
        {
            get
            {
                return ListaGraczy[indeksAktualnegoGracza].ToString();
            }
        }
        public string OstatniSkreslony
        {
            get
            {
                if (_lista.Any(f => f.LokataTurniej > 0))
                    return _lista.Where(f => f.LokataTurniej > 0).OrderBy(f => f.LokataTurniej).Take(1).Select(f => f.Tytul).FirstOrDefault().ToString();
                else
                    return "<BRAK>";
            }
        }
        
        #endregion

        #region constructors
        public TurniejWindowVM(List<string> listaGraczy, List<Film> listaFilmow)
        {
            _lista = new TrulyObservableCollection<FilmTurniej>();
            foreach (Film film in listaFilmow)
            {
                _lista.Add(new FilmTurniej(film));
            }
            ListaGraczy = listaGraczy;
            indeksAktualnegoGracza = random.Next(listaGraczy.Count);
                 
        }
        #endregion

        #region commands
        private RelayCommand<FilmTurniej> skreslFilmCommand;
        private RelayCommand cofnijWyborCommand;
        private RelayCommand losowyWyborCommand;
        private RelayCommand<string> webBrowserCommand;
        private RelayCommand pokazLinkCommand;

        public RelayCommand<FilmTurniej> SkreslFilmCommand
        {
            get
            {
                if (skreslFilmCommand == null)
                    skreslFilmCommand = new RelayCommand<FilmTurniej>(SkreslFilm);
                return skreslFilmCommand;
            }
        }
        public RelayCommand CofnijWyborCommand
        {
            get
            {
                if (cofnijWyborCommand == null)
                    cofnijWyborCommand = new RelayCommand(CofnijWybor);
                return cofnijWyborCommand;
            }
        }       
        public RelayCommand LosowyWyborCommand
        {
            get
            {
                if (losowyWyborCommand == null)
                    losowyWyborCommand = new RelayCommand(LosowyWybor);
                return losowyWyborCommand;
            }
        }

        public RelayCommand<string> WebBrowserCommand
        {
            get
            {
                if (webBrowserCommand == null)
                    webBrowserCommand = new RelayCommand<string>(WebBrowserStart);
                return webBrowserCommand;
            }            
        }
        public RelayCommand PokazLinkCommand
        {
            get
            {
                if (pokazLinkCommand == null)
                    pokazLinkCommand = new RelayCommand(PokazLink);
                return pokazLinkCommand;
            }
        }

        #endregion

        #region command methods
        private void WebBrowserStart(string link)
        {
            System.Diagnostics.Process.Start(link);
        }
        private void SkreslFilm(FilmTurniej film)
        {
            try
            {
                int lokata = _lista.Count;
                lokata = _lista.Where(f => f.LokataTurniej == 0).Count();
                film.LokataTurniej = lokata;
                film.Skreslajacy = GraczAktualny;
                if (film.Hit && _lista.Any(f => f.LokataTurniej == 0))
                {
                    MediaPlayer mp = new MediaPlayer();
                    string path = System.IO.Directory.GetCurrentDirectory() + "\\MSszkoda.mp3";
                    mp.Open(new Uri(path));
                    mp.Play();
                }
                if (_lista.Any(f => f.LokataTurniej == 0))
                    NastepnyGracz();
                else
                    KoniecTurnieju();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        private void CofnijWybor()
        {
            try
            {
                if (ListaFilmow.Any(f => f.LokataTurniej > 0))
                {
                    FilmTurniej film = _lista.Where(f => f.LokataTurniej > 0).OrderBy(f => f.LokataTurniej).Take(1).FirstOrDefault();
                    if (film != null)
                        film.LokataTurniej = 0;
                    PoprzedniGracz();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void LosowyWybor()
        {
            try
            {
                if (ListaFilmow.Any(f => f.LokataTurniej == 0))
                {
                    List<FilmTurniej> listaDoLosowania = _lista.Where(f => f.LokataTurniej == 0).ToList();                    
                    int los = random.Next(listaDoLosowania.Count);
                    SkreslFilm(listaDoLosowania[los]);
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion
        #region methods
        private void NastepnyGracz()
        {
            indeksAktualnegoGracza++;
            if (indeksAktualnegoGracza >= ListaGraczy.Count)
                indeksAktualnegoGracza = 0;
            OnPropertyChanged("GraczAktualny", "OstatniSkreslony");
        }
        private void PoprzedniGracz()
        {
            indeksAktualnegoGracza--;
            if (indeksAktualnegoGracza < 0)
                indeksAktualnegoGracza = ListaGraczy.Count - 1;
            OnPropertyChanged("GraczAktualny", "OstatniSkreslony");
        }
        private void KoniecTurnieju()
        {
            try
            {
                FilmTurniej film = _lista.Where(f => f.LokataTurniej == 1).FirstOrDefault();
                IDialogService dialog = new DialogService();
                bool ok = dialog.ShowQuestion(string.Format("WYGRANA: {0}\nźródło: {1}\nZapisać wyniki", OstatniSkreslony, film.Zrodlo), "Uwaga");
                if (ok)
                {
                    DataServerFacade.SetTurniej(_lista.ToList());
                }
                ok = dialog.ShowQuestion(string.Format("Ustawić {0} jako obejrzany", OstatniSkreslony), "Uwaga");
                if (ok)
                {                    
                    film.UstawJakoObejrzany();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void PokazLink()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
