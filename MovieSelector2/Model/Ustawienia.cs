using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelector2.Model
{
    static class Ustawienia
    {
        #region basically
        public static string GetConfValue(string nazwa)
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            return ustawienia[nazwa].ToString();
        }

        internal static void SetConfValue(string nazwa, object value)
        {
            Properties.Settings ustawienia = Properties.Settings.Default;
            ustawienia[nazwa] = value;
            ustawienia.Save();
            Refresh();
        }

        private static void Refresh()
        {

        }
        #endregion



    }
}
