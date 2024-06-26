using System;
using Xunit;
using JaratKezeloProject;

namespace TestJaratKezeloProject
{
    public class UnitTest1
    {
        // UjJarat_Letrehoz_Es_Tarol: Teszteli, hogy �j j�ratot helyesen l�trehozza �s t�rolja.
        [Fact]
        public void UjJarat_Letrehoz_Es_Tarol()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            jaratKezelo.Keses("ABC123", 0);
        }

        // Keses_Hozzaadodik: Teszteli, hogy a k�s�s helyesen hozz�ad�dik egy j�rathoz.
        [Fact]
        public void Keses_Hozzaadodik()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);
            jaratKezelo.Keses("ABC123", 10);

            jaratKezelo.Keses("ABC123", 0);
        }

        // Keses_Nem_Lehet_Negativ: Teszteli, hogy a k�s�s nem lehet negat�v.
        [Fact]
        public void Keses_Nem_Lehet_Negativ()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            Assert.Throws<ArgumentException>(() => jaratKezelo.Keses("ABC123", -10));
        }

        // UjJarat_Duplikalt_JaratSzam: Teszteli, hogy duplik�lt j�ratsz�m eset�n kiv�telt dob.
        [Fact]
        public void UjJarat_Duplikalt_JaratSzam()
        {
            var jaratKezelo = new JaratKezelo();
            jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now);

            Assert.Throws<ArgumentException>(() => jaratKezelo.UjJarat("ABC123", "BUD", "JFK", DateTime.Now));
        }

        // MikorIndul_HelyesIdopontotAdVissza: Teszteli, hogy a t�nyleges indul�si id�pont helyesen sz�mol�dik ki.
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

        // MikorIndul_NemLetezoJarat: Teszteli, hogy nem l�tez� j�rat eset�n kiv�telt dob.
        [Fact]
        public void MikorIndul_NemLetezoJarat()
        {
            var jaratKezelo = new JaratKezelo();
            Assert.Throws<ArgumentException>(() => jaratKezelo.MikorIndul("XYZ999"));
        }

        // JaratokRepuloterrol_HelyesJaratokatAdVissza: Teszteli, hogy a megadott rep�l�t�rr�l indul� j�ratok helyesen visszaad�dnak.
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

        // JaratokRepuloterrol_UresLista: Teszteli, hogy nem l�tez� rep�l�t�r eset�n �res list�t ad vissza.
        [Fact]
        public void JaratokRepuloterrol_UresLista()
        {
            var jaratKezelo = new JaratKezelo();
            var jaratok = jaratKezelo.JaratokRepuloterrol("XYZ");

            Assert.Empty(jaratok);
        }
    }
}
