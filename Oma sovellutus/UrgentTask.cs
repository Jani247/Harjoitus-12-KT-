// UrgentTask.cs tiedosto lisää tavalliseen tehtävään ominaisuuden joka kertoo kuinka kiireinen se on. tää tiedosto määrittää uuden UrgentTask-luokan joka sisältää samat tiedot kuin tavallinen tehtävä esim. kuten otsikko, kuvaus ja eräpäivä, mutta siihen on lisätty myös prioriteetti

using System;

namespace TaskApp
{
    // tehtävä, joka perii sit Task-luokan
    public class UrgentTask : Task
    {
        public string Prioriteetti { get; set; }

        public UrgentTask(string title, string description, DateTime dueDate, string priority)
            : base(title, description, dueDate)
        {
        Prioriteetti = priority;
        }

        // palauttaa sit tehtävän tiedot merkkijonona
        public override string ToString()
        {
            return $"{Title} - {Description} - {DueDate:dd/MM/yyyy} - Prioriteetti: {Prioriteetti}";
        }
    }
}