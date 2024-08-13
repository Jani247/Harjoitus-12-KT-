// lyhyesti Task.cs edustaa yksittäistä tehtävää jonka ominaisuudet ovat Title, Description ja DueDate.
//ToString - metodi, joka sit esittää tehtävän merkkijonona.
using System;

namespace TaskApp
{
    // Tehtävä luokka joka sisältää perustiedot tehtävästä
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }

        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
        }

        // tää sit palauttaa tehtävän tiedot merkkijonona
        public override string ToString()
        {
            return $"{Title} - {Description} - {DueDate:dd/MM/yyyy}";
       }
    }
}
