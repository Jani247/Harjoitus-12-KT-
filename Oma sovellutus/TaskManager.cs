// TaskManager.cs tarkoitus on hallinnoida ja käsittellä kaikkia tehtäviä sovelluksessa jossa on List<Task> kokoelma, joka sit tallentaa kaikki tehtävät. Sitten löytyy metodit tehtävien lisäämiselle, poistamiselle, tallentamiselle tiedostoon ja lataamiselle tiedostosta. eli basically vastaa tehtävien pysyvyydestä tallentamalla ja lataamalla ne tiedostosta.

using System;
using System.Collections.Generic;
using System.IO;

//elikkäs käytännössä se pitää kirjaa kaikista sovelluksen tehtävistä ja huolehtii siitä, että ne säilyvät oikein
namespace TaskApp
{
    // Tehtävien hallinnointi
    public class TaskManager
    {
    private List<Task> tasks;

        public TaskManager()
        {
            tasks = new List<Task>();
        }

        // lisää uusi tehtävä listaansi
        public void AddTask(Task task)
        {
            tasks.Add(task);
        }

        // poista laitettu tehtävä listasta
        public void RemoveTask(Task task)
        {
            tasks.Remove(task);
        }

        // Palauttaa kaikki tehtävät niin että  että kutsuva koodi ei voisi muokata alkuperäistä listaa
        public List<Task> GetTasks()
        {
            return new List<Task>(tasks);
        }

        // Tallentaa tehtävät tiedostoon
        public void SaveTasksToFile(string filePath)
        {
            //Tiedoston Avaaminen Kirjoitusta Varten
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var task in tasks)
                {
                    //Tehtävän Tyyppi tarkistus ja tietojen Kirjoitus
                    if (task is UrgentTask urgentTask)
                    {
                        //Tietojen kirjoitus kirjoittaa tehtävän tiedot tiedostoon jossa erottimena käytän |-merkkiä..
                        writer.WriteLine($"UrgentTask|{urgentTask.Title}{urgentTask.Description}|{urgentTask.DueDate:O}|{urgentTask.Prioriteetti}");

                    }
                    else
                    {
                     writer.WriteLine($"Task|{task.Title}|{task.Description}|{task.DueDate:O}");
                    }
                }
            }
        }

        // Ladataan sit tehtävät tiedostosta
        public void LoadTasksFromFile(string filePath)
        {
            tasks.Clear(); // Tyhjennetään lista ennen uusien lataamista

            if (!File.Exists(filePath))
            {
                // Jos tiedostoa ei ole olemassa, lopetetaan tällöin lukeminen
                return;
            }
            //StreamReader luokan avulla avataan tiedosto, jonka polku on filePath, tän lukemista varten.
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts[0] == "UrgentTask")
                    {
                        tasks.Add(new UrgentTask(parts[1], parts[2], DateTime.Parse(parts[3]), parts[4]));
                    }
                    else
                    {
                        tasks.Add(new Task(parts[1], parts[2], DateTime.Parse(parts[3])));
                        //tää on hyvä osa sovelluksen kykyä tallentaa ja ladata tehtäviä niin että käyttäjän ei tarvitse syöttää tehtäviä uudelleen joka kerta sovelluksen avattaessaan.
                    }
                }
            }
        }
    }
}
