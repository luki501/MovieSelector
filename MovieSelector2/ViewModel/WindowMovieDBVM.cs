using GalaSoft.MvvmLight.Command;
using MovieSelector2.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSelector2.ViewModel
{
    public class WindowMovieDBVM : ObservedObject
    {
        #region fields
        private JObject elements;
        private JObject elementDetails;
        private JObject elementCrew;
        private Film film;
        private int indeks;
        public FilmDane filmDane;
        public string DaneFilmu
        {
            get
            {
                string dane = "";
                foreach (var properties in typeof(FilmDane).GetProperties())
                {
                    dane += string.Format("{0} - {1}\n", properties.Name, properties.GetValue(filmDane, null));
                }
                return dane;
            }
        }

        public string PosterLink
        {
            get
            {
                if (elements["results"].Count() == 0)
                    return "";
                else
                    return string.Format("http://image.tmdb.org/t/p/w185//{0}", elements["results"][indeks]["poster_path"]);
            }
        }
        #endregion

        #region commands
        private RelayCommand poprzedniWpisCommand;
        private RelayCommand pobierzDaneCommand;
        private RelayCommand nastepnyWpisCommand;

        public RelayCommand PoprzedniWpisCommand
        {
            get
            {
                if (poprzedniWpisCommand == null)
                    poprzedniWpisCommand = new RelayCommand(PoprzedniWpis, () => { return indeks != 0; });
                return poprzedniWpisCommand;
            }
        }

        public RelayCommand NastepnyWpisCommand
        {
            get
            {
                if (nastepnyWpisCommand == null)
                    nastepnyWpisCommand = new RelayCommand(NastepnyWpis, () => { return indeks < elements["results"].Count() - 1; });
                return nastepnyWpisCommand;
            }
        }
        public RelayCommand PobierzDaneCommand
        {
            get
            {
                if (pobierzDaneCommand == null)
                    pobierzDaneCommand = new RelayCommand(ZapiszDane);
                return pobierzDaneCommand;
            }
        }

        #endregion

        #region constructors
        public WindowMovieDBVM(Film film, JObject elements)
        {
            this.film = film;
            this.elements = elements;
            PobierzDane();
        }
        #endregion

        #region methods
        private void PoprzedniWpis()
        {
            if (indeks > 0)
            {
                indeks--;
                PobierzDane();
            }
            OnPropertyChanged("DaneFilmu", "PosterLink", "DaneSzczegoloweFilmu");
        }
        private void NastepnyWpis()
        {
            if (indeks + 1 < elements["results"].Count())
            {
                indeks++;
                PobierzDane();
            }
            OnPropertyChanged("DaneFilmu", "PosterLink", "DaneSzczegoloweFilmu");
        }
        private void PobierzDane()
        {
            try
            {
                if (elements["results"].Count() == 0)
                    return;
                elementDetails = film.LoadDetailsDataFromMovieDB(Convert.ToInt32(elements["results"][indeks]["id"]));
                elementCrew = film.LoadCrewDataFromMovieDB(Convert.ToInt32(elements["results"][indeks]["id"]));
                filmDane.Opis = elements["results"][indeks]["overview"].ToString();
                filmDane.Opis = filmDane.Opis.Substring(0, Math.Min(1500, filmDane.Opis.Length));
                filmDane.PosterLink = string.Format("http://image.tmdb.org/t/p/w185//{0}", elements["results"][indeks]["poster_path"]);
                DateTime rok;
                if (DateTime.TryParse(elements["results"][indeks]["release_date"].ToString(), out rok))
                    filmDane.Rok = rok.Year;
                filmDane.TytulOrg = elements["results"][indeks]["original_title"].ToString();
                filmDane.Link = string.Format("http://www.imdb.com/title/{0}", elementDetails["imdb_id"]);
                filmDane.ImdbRating = Convert.ToDecimal(elements["results"][indeks]["vote_average"]);
                int dlugosc = 0;
                if (Int32.TryParse(elementDetails["runtime"].ToString(), out dlugosc))
                    filmDane.Dlugosc = dlugosc;
                filmDane.Kategoria = string.Join(", ", elementDetails["genres"].Select(e => e["name"].ToString()).ToArray());
                filmDane.Kraj = string.Join(", ", elementDetails["production_countries"].Select(e => e["name"].ToString()).ToArray());
                filmDane.Kraj = filmDane.Kraj.Replace("United States of America", "USA");
                filmDane.Kraj = filmDane.Kraj.Replace("United Kingdom", "UK");
                filmDane.Kraj = filmDane.Kraj.Substring(0, Math.Min(50, filmDane.Kraj.Length));
                filmDane.Opis = filmDane.Opis.Substring(0, Math.Min(50, filmDane.Opis.Length));
                filmDane.Obsada = string.Join(", ", elementCrew["credits"]["cast"].Select(e => e["name"].ToString()).ToArray());
                filmDane.Obsada = filmDane.Obsada.Substring(0, Math.Min(500, filmDane.Obsada.Length));
                filmDane.Rezyseria = elementCrew["credits"]["crew"].Where(e => e["job"].ToString().Equals("Director")).Select(e => e["name"].ToString()).FirstOrDefault(); // brak - poszukać w dokumentacji https://www.themoviedb.org/documentation/api                
                OnPropertyChanged("DaneFilmu");
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        private void ZapiszDane()
        {
            try
            {
                film.Dlugosc = filmDane.Dlugosc;                
                film.Kategoria = filmDane.Kategoria;
                film.Kraj = filmDane.Kraj;
                film.Link = filmDane.Link;
                film.Obsada = filmDane.Obsada;
                film.Opis = filmDane.Opis;
                film.PosterLink = filmDane.PosterLink;
                film.Rezyseria = filmDane.Rezyseria;
                film.Rok = filmDane.Rok;
                film.TytulOrg = filmDane.TytulOrg;
                film.ImdbRating = filmDane.ImdbRating;
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        #endregion
    }

    public struct FilmDane
    {
        public string TytulOrg { get; set; }
        public string Rezyseria { get; set; }
        public string Kraj { get; set; }
        public string PosterLink { get; set; }
        public int Rok { get; set; }
        public string Link { get; set; }
        public string Kategoria { get; set; }        
        public string Obsada { get; set; }               
        public int Dlugosc { get; set; }        
        public string Opis { get; set; }
        public decimal ImdbRating { get; set; }
    }
}
