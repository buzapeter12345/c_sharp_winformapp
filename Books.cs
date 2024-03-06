using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvek
{
    internal class Books
    {
        public int sorszam;
        public string kategoria;
        public string konyv;
        public int ar;
        public int db;

        public Books(string sorszam, string kategoria, string konyv, string ar, string db)
        {
            this.sorszam = int.Parse(sorszam) ;
            this.kategoria = kategoria;
            this.konyv = konyv;
            this.ar = int.Parse(ar);
            this.db = int.Parse(db);
        }
    }

}
