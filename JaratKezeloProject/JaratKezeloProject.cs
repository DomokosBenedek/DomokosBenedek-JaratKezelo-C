using System;
using System.Collections.Generic;

namespace JaratKezeloProject
{
    public class JaratKezelo
    {
        private Dictionary<string, Jarat> jaratok = new Dictionary<string, Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (jaratok.ContainsKey(jaratSzam))
                throw new ArgumentException("A járatszám már létezik.");

            jaratok[jaratSzam] = new Jarat
            {
                JaratSzam = jaratSzam,
                RepterHonnan = repterHonnan,
                RepterHova = repterHova,
                Indulas = indulas,
                Keses = 0
            };
        }

        public void Keses(string jaratSzam, int keses)
        {
            if (!jaratok.ContainsKey(jaratSzam))
                throw new ArgumentException("Nem létező járat.");

            jaratok[jaratSzam].Keses += keses;

            if (jaratok[jaratSzam].Keses < 0)
                throw new ArgumentException("A késés nem lehet negatív.");
        }

        private class Jarat
        {
            public string JaratSzam { get; set; }
            public string RepterHonnan { get; set; }
            public string RepterHova { get; set; }
            public DateTime Indulas { get; set; }
            public int Keses { get; set; }
        }
    }
}
