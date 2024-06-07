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

        [Fact]
        public void MikorIndul_HelyesIdopontotAdVissza()
        {
            var jaratKezelo = new JaratKezelo();
            var indulas = DateTime.Now;
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", indulas);
            jaratKezelo.Keses("ABC123", 30);

            var varhatoIndulas = indulas.AddMinutes(30);
            Assert.Equal(varhatoIndulas, jaratKezelo.MikorIndul("ABC123"));
        }

        [Fact]
        public void JaratokRepuloterrol_HelyesJaratokatAdVissza()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);
            jaratKezelo.UjJarat("DEF456", "BUD", "LAX", DateTime.Now);
            jaratKezelo.UjJarat("GHI789", "JFK", "BUD", DateTime.Now);

            var jaratok = jaratKezelo.JaratokRepuloterrol("BUD");

            Assert.Contains("ABC123", jaratok);
            Assert.Contains("DEF456", jaratok);
            Assert.DoesNotContain("GHI789", jaratok);
        }
    }
}
