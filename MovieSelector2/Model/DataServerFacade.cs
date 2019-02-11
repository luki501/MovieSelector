using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSelector2.Model
{
    public static class DataServerFacade
    {
        public static List<Film> GetListaFilmow()
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    List<Film> listaFilmow = new List<Film>();
                    List<FilmEF> lista = context.GetFilmyAll().ToList();
                    foreach (FilmEF filmEF in lista)
                    {
                        listaFilmow.Add(new Film(filmEF));
                    }
                    return listaFilmow;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal static bool ZapiszFilm(Film film)
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    tytuly tytul = context.tytuly.Where(t => t.id == film.Id).FirstOrDefault();
                    if (tytul == null)
                    {
                        tytul = new tytuly();
                        context.tytuly.Add(tytul);
                    }
                    tytul.data_dodania = DateTime.Now;
                    tytul.dlugosc = film.Dlugosc;
                    tytul.hit = film.Hit;
                    tytul.imdb = film.ImdbRating;
                    tytul.kategoria = film.Kategoria;
                    tytul.kraj = film.Kraj;
                    tytul.link = film.Link;
                    tytul.obejrzany = film.Obejrzany;
                    tytul.obsada = film.Obsada;
                    tytul.opis = film.Opis;
                    tytul.poster_link = film.PosterLink;
                    tytul.rezyseria = film.Rezyseria;
                    tytul.rok = film.Rok;
                    tytul.tytul = film.Tytul;
                    tytul.tytul_org = film.TytulOrg;
                    tytul.zrodlo = film.Zrodlo;
                    tytul.nieaktywny = film.Nieaktywny;
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal static void UsunFilm(Film film)
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    tytuly tytul = context.tytuly.Where(t => t.id == film.Id).FirstOrDefault();
                    if (tytul != null)
                        context.tytuly.Remove(tytul);
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal static List<Skreslenie> GetSkresleniaFilmu(int id)
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    List<Skreslenie> listaSkreslen = new List<Skreslenie>();
                    List<SkresleniaEF> lista = context.GetSkresleniaByIdFilmu(id).ToList();
                    foreach (SkresleniaEF s in lista)
                    {
                        Skreslenie skreslenie = new Skreslenie(s);
                        listaSkreslen.Add(skreslenie);
                    }
                    return listaSkreslen.OrderByDescending(f => f.Ilosc).ToList();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal static void SetTurniej(List<FilmTurniej> lista)
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    int idTurnieju = context.turnieje.Max(t => t.id_turnieju) + 1;
                    foreach (FilmTurniej film in lista)
                    {
                        turnieje skreslenie = new turnieje();
                        skreslenie.id_turnieju = idTurnieju;
                        skreslenie.id_filmu = film.Id;
                        skreslenie.lokata = film.LokataTurniej;
                        skreslenie.nick = film.Skreslajacy;
                        skreslenie.data_wstawienia = DateTime.Now;
                        context.turnieje.Add(skreslenie);                        
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }

        internal static void UstawObejrzany(Film film)
        {
            try
            {
                using (FilmyEntities context = new FilmyEntities())
                {
                    tytuly t = context.tytuly.Where(f => f.id == film.Id).FirstOrDefault();
                    if (t != null)
                    {
                        t.obejrzany = DateTime.Now;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
    }
}
