using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSelector2.Model
{
    public class FilmTurniej : Film
    {
        #region fields
        private int lokataTurniej;

        public int LokataTurniej { get { return lokataTurniej; }set { lokataTurniej = value; OnPropertyChanged("LokataTurniej"); } }
        public string Skreslajacy { get; set; }
        #endregion
        public FilmTurniej(Film f) : base(f)
        {            
            lokataTurniej = 0;
            Skreslajacy = "";
        }
    }
}
