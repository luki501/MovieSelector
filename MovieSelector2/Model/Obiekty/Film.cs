using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace MovieSelector2.Model
{
    public class Film : ObservedObject
    {
        #region fields
        private const string KeyMovieDB = "7a31b2b32f07bf48dcd2edab5fbc4e17";
        private bool isSelected;
        protected FilmEF film;
        public int Lokata { get { return (int)film.lokata; } }
        public int Id { get { return film.id; } }
        public int Srednia { get { return (int)film.srednia; } }
        public string Tytul { get { return film.tytul; } set { film.tytul = value; } }
        public string TytulOrg { get { return film.tytul_org; } set { film.tytul_org = value; } }
        public string Rezyseria { get { return film.rezyseria; } set { film.rezyseria = value; } }
        public int Udzial { get { return (int)film.udzial; } }
        public int MaxLokata { get { return film.max; } }
        public decimal ImdbRating { get { if (film.imdb == null) return 0; else return (decimal)film.imdb; } set { film.imdb = value; } }
        public string Kategoria { get { return film.kategoria; } set { film.kategoria = value; } }
        public int? Dlugosc { get { return film.dlugosc; } set { film.dlugosc = value; } }
        public string Obsada { get { return film.obsada; } set { film.obsada = value; } }
        public string Zrodlo { get { return film.zrodlo; } set { film.zrodlo = value; } }
        public bool Hit { get { if (film.hit == null) return false; else return (bool)film.hit; } set { film.hit = value; } }
        public DateTime? Obejrzany { get { return film.obejrzany; } set { film.obejrzany = value; } }
        public string PosterLink { get { return film.poster_link; } set { film.poster_link = value; } }
        public string Opis { get { return film.opis; } set { film.opis = value; } }
        public string Link { get { return film.link; } set { film.link = value; } }
        public string Kraj { get { return film.kraj; } set { film.kraj = value; } }
        public int? Rok { get { return film.rok; } set { film.rok = value; } }
        public bool Nieaktywny { get { if (film.nieaktywny == null) return false; else return (bool)film.nieaktywny; } set { film.nieaktywny = value; } }
        public bool IsObejrzany { get { return film.obejrzany != null; } }
        public bool IsSelected { get { return isSelected; } set { isSelected = value; OnPropertyChanged("IsSelected"); } } 
        public List<Skreslenie> ListaSkreslen
        {
            get
            {
                return DataServerFacade.GetSkresleniaFilmu(Id);
            }
        }

        #endregion

        #region constructors
        public Film(Film f)
        {
            this.film = f.film;
        }
        public Film(FilmEF film)
        {
            this.film = film;                        
        }
        #endregion

        #region interface methods

        internal bool Save()
        {
            DataServerFacade.ZapiszFilm(this);
            return true;
        }
        #endregion

        #region methods
        public JObject PobierzDaneZMovieDb()
        {
            if (Tytul == null && TytulOrg == null)
                return null;
            string tytul;
            if (TytulOrg != null && !TytulOrg.Equals(""))
                tytul = TytulOrg;
            else if (Tytul != null && !Tytul.Equals(""))
                tytul = Tytul;
            else
                return null;     
            return LoadDataFromMovieDB(tytul);

        }

        internal JObject LoadCrewDataFromMovieDB(int id)
        {
            try
            {
                string m_strFilePath = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}&append_to_response=credits", id, KeyMovieDB);
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(m_strFilePath);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    json = Encoding.UTF8.GetString(bytes);
                    JObject obj = JObject.Parse(json);
                    return obj;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private JObject LoadDataFromMovieDB(string tytul)
        {
            try
            {
                tytul = tytul.Replace(" ", "+");
                string m_strFilePath = string.Format("https://api.themoviedb.org/3/search/movie?api_key={0}&query={1}", KeyMovieDB, tytul);
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(m_strFilePath);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    json = Encoding.UTF8.GetString(bytes);
                    JObject obj = JObject.Parse(json);
                    return obj;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public JObject LoadDetailsDataFromMovieDB(int id)
        {
            try
            {
                string m_strFilePath = string.Format("https://api.themoviedb.org/3/movie/{0}?api_key={1}", id, KeyMovieDB);
                using (WebClient wc = new WebClient())
                {
                    string json = wc.DownloadString(m_strFilePath);
                    byte[] bytes = Encoding.Default.GetBytes(json);
                    json = Encoding.UTF8.GetString(bytes);
                    JObject obj = JObject.Parse(json);
                    return obj;

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal void UstawJakoObejrzany()
        {
            try
            {
                DataServerFacade.UstawObejrzany(this);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

    }
}
