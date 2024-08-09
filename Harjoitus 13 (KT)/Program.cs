// Tiedosto: Program.cs

using System;
using System.Collections.Generic;

namespace SMLiiga
{
    // Määritellään Pelaajaluokka
    class Pelaaja
    {
        // Public Ominaisuudet
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public int PelaajaNumero { get; set; }

        // Konstruktorit
        public Pelaaja(string etunimi, string sukunimi, int pelaajaNumero)
        {
            Etunimi = etunimi;
            Sukunimi = sukunimi;
            PelaajaNumero = pelaajaNumero;
        }

        // ToStringmetodi pelaajan tietojen tulostamisee
        public override string ToString()
        {
            return $"{PelaajaNumero}: {Etunimi} {Sukunimi}";
        }
    }

    // Määritellään class nimieltä joukkue. ie. joukkue luokka
    class Joukkue
    {
        // tän ominaisuudet
        public string Nimi { get; set; }
        public string Kotikaupunki { get; set; }
        private Dictionary<int, Pelaaja> Pelaajat { get; set; }

        // Konstrukorit
        public Joukkue(string nimi, string kotikaupunki)
        {
            Nimi = nimi;
            Kotikaupunki = kotikaupunki;
            Pelaajat = new Dictionary<int, Pelaaja>();
        }

        // Metodi pelaajan hakemiseen
        public Pelaaja HaePelaaja(int numero)
        {
            try
            {
                if (Pelaajat.ContainsKey(numero))
                {
                    return Pelaajat[numero];
                }
                else
                {
                    throw new Exception("Pelaajaa ei löydy annetulla numerolla.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Virhe: {e.Message}");
                return null;
            }
        }

        // Metodi pelaajan lisäämiseen
        public void LisääPelaaja(Pelaaja pelaaja)
        {
            try
            {
                if (!Pelaajat.ContainsKey(pelaaja.PelaajaNumero))
                {
                    Pelaajat.Add(pelaaja.PelaajaNumero, pelaaja);
                    Console.WriteLine($"Pelaaja {pelaaja} lisätty.");
                }
                else
                {
                    throw new Exception("Pelaajanumero on jo käytössä.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Virhe: {e.Message}");
            }
        }

        // Metodi pelaajan poistamiseen
        public void PoistaPelaaja(int numero)
        {
            try
            {
                if (Pelaajat.Remove(numero))
                {
                    Console.WriteLine($"Pelaaja numerolla {numero} poistettu.");
                }
                else
                {
                    throw new Exception("Pelaajaa ei löydy annetulla numerolla.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Virhe: {e.Message}");
            }
        }

        // Metodi kaikkien pelaajien hakemiseen
        public List<Pelaaja> HaePelaajat()
        {
            return new List<Pelaaja>(Pelaajat.Values);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Joukkue joukkue = new Joukkue("JYP", "Jyväskylä");

            // Lisää pelaajia joukkueeseen
            joukkue.LisääPelaaja(new Pelaaja("Mikko", "Koivu", 9));
            joukkue.LisääPelaaja(new Pelaaja("Teemu", "Selänne", 8));
            joukkue.LisääPelaaja(new Pelaaja("Jari", "Kurri", 17));

            // Yritetään lisätä pelaaja, jonka numero on jo käytössä
            joukkue.LisääPelaaja(new Pelaaja("Ville", "Peltonen", 9));

            // Haetaan pelaaja
            Pelaaja pelaaja = joukkue.HaePelaaja(9);
            Console.WriteLine(pelaaja != null ? pelaaja.ToString() : "Pelaajaa ei löydy.");

            // Poistetaan pelaaja
            joukkue.PoistaPelaaja(8);

            // Yritetään poistaa pelaaja, jota ei ole
            joukkue.PoistaPelaaja(99);

            // Tulostetaan kaikki pelaajat
            Console.WriteLine("\nJoukkueen pelaajat:");
            foreach (var p in joukkue.HaePelaajat())
            {
                Console.WriteLine(p);
            }

            Console.WriteLine("\nPaina mitä näippäintä vaan poistuaksesi.");
            Console.ReadKey();
        }
    }
}
