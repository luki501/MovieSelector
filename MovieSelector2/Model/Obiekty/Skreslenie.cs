using MovieSelector2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieSelector2.Model
{
    public class Skreslenie   
    {
        #region fields   
        private SkresleniaEF skreslenia;
        public int IdFilmu { get { return skreslenia.id; } }
        public string Nick { get { return skreslenia.nick; } }
        public int Ilosc { get { return (int)skreslenia.ilosc; } }
        public int Lokata { get { return (int)skreslenia.lokata; } }
        #endregion

        #region constructors
        public Skreslenie(SkresleniaEF skreslenia)
        {
            this.skreslenia = skreslenia;
        }
        
        #endregion
    }
}
