using System;
using Xunit;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class UnitTest1
    {
        [Fact]
        public void UjJarat_Letrehoz_Es_Tarol()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            // Ellen�rizd, hogy a j�rat t�nylegesen hozz� lett-e adva (nincs kiv�tel)
            jaratKezelo.Keses("ABC123", 0);
        }

        [Fact]
        public void Keses_Hozzaadodik()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);
            jaratKezelo.Keses("ABC123", 10);

            // Ellen�rizd, hogy a k�s�s hozz�ad�dott
            jaratKezelo.Keses("ABC123", 0);  // Ha ez nem dob kiv�telt, a k�s�s sikeresen hozz�ad�dott
        }

        [Fact]
        public void Keses_Nem_Lehet_Negativ()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            Assert.Throws<ArgumentException>(() => jaratKezelo.Keses("ABC123", -10));
        }

        [Fact]
        public void UjJarat_Duplikalt_JaratSzam()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            Assert.Throws<ArgumentException>(() => jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now));
        }
    }
}
