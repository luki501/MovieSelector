using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MovieSelector2.Model
{
    public class Filmy : IEnumerable<Film>
    {
        #region fields
        public BindingList<Film> ListaFilmow;
        public Film WybranyFilm { get; internal set; }
        #endregion

        #region constructors
        public Filmy()
        {
            ListaFilmow = new BindingList<Film>(DataServerFacade.GetListaFilmow());            
        }       
        #endregion

        #region interface methods
        public IEnumerator<Film> GetEnumerator()
        {
            return ListaFilmow.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }

        internal void Odswiez()
        {
            ListaFilmow = new BindingList<Film>(DataServerFacade.GetListaFilmow());            
        }
        #endregion
    }
}
