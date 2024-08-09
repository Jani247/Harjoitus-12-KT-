// Tiedosto: Program.cs

using System;
using System.Collections.Generic;

namespace Korttipeli
{
    class Korttipakka
    {
        // Ominaisuus korttien tallentamista varten
        private List<string> kortit;

        // Konstruktorit
        public Korttipakka()
        {
            kortit = new List<string>();
            AlustaKortit();
        }

        // Metodi korttipakan alustamiseen
        private void AlustaKortit()
        {
            string[] maat = { "Hertta", "Pata", "Risti", "Ruutu" };
            string[] arvot = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13" };

            foreach (var maa in maat)
            {
                foreach (var arvo in arvot)
                {
                    kortit.Add($"{maa} - {arvo}");
                }
            }
        }

        // Metodi korttien tulostamiseen
        public void TulostaKortit()
        {
            for (int i = 0; i < kortit.Count; i++)
            {
                Console.WriteLine($"{i + 1}. kortti on {kortit[i]}");
            }
        }

        // Metodi korttien sekoittamist varten
        public void SekoitaKortit()
        {
            Random rng = new Random();
            int n = kortit.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                string value = kortit[k];
                kortit[k] = kortit[n];
                kortit[n] = value;
            }
            Console.WriteLine("Korttipakka on sekoitettu");
        }
    }
        //tulostus
    class Program
    {
        static void Main(string[] args)
        {
            Korttipakka pakka = new Korttipakka();

            Console.WriteLine("Korttipakka ennen sekoittamista:");
            pakka.TulostaKortit();

            pakka.SekoitaKortit();

            Console.WriteLine("\nKorttipakka sekoittamisen jälkeen:");
            pakka.TulostaKortit();

            Console.WriteLine("\nPaina mitä tahansa näppäintä poistuaksesi.");
            Console.ReadKey();
        }
    }
}
