//MainWindow.xaml.cs sisältää C#-koodin, joka sit liittyy MainWindow.xaml-tiedoston käyttöliittymän toiminnallisuuteen, eli kaikki tapahtumat ja logiikka ja määrittely mitä
//tapahtuu kun käyttäjä paineskelee esim. nappeja. täältä löytyy esim. tehtävien lisääminen, poistaminen ja tallentaminen ja käyttöliittymän päivittäminen, kuten tehtävälistan päivittäminen ja sit yötekenttien tyhjentäminen. ja muuta.

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace TaskApp
{
    public partial class MainWindow : Window
    {
        private TaskManager taskManager;
        private const string TaskFilePath = "tasks.txt";

        public MainWindow()
        {
            InitializeComponent();
            taskManager = new TaskManager();
            LoadTasks();
        }
        //Tämä keroo että prioriteetti nappi kertoo että se on prioriteetti nappi
        private void PriorityComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (PriorityComboBox.SelectedIndex == 0)
        {
                // jos ei oo valittu mitää nii ei tehdä mitää
                PriorityComboBox.SelectedIndex = -1;
        }
        }

        // Tapahtumankäsittelijä tehtävän lisäämiselle
        private void AddTaskButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = TitleTextBox.Text;
                string description = DescriptionTextBox.Text;
                DateTime dueDate = DueDatePicker.SelectedDate ?? DateTime.Now;
                string priority = (PriorityComboBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Normaali";

             if (string.IsNullOrWhiteSpace(title))
             throw new Exception("Tehtävän otsikko ei voi olla tyhjää täynnä.");

                Task newTask = new UrgentTask(title, description, dueDate, priority);
                taskManager.AddTask(newTask);
                RefreshTaskList();
                ClearInputs();
            }
            catch (Exception ex)
                 {
                MessageBox.Show(ex.Message, "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Tapahtumankäsittelijä tehtävän poistamiselle
        private void RemoveTaskButton_Click(object sender, RoutedEventArgs e)
        {
        if (TaskListBox.SelectedItem is Task selectedTask)
            {
                taskManager.RemoveTask(selectedTask);
                RefreshTaskList();
            }
            else
            //ilmoittaa jos et valitse tehtävää minkä haluat poistaa
            {
                MessageBox.Show("Valitse ensin poistettava tehtävä.", "Virhe", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Tapahtumankäsittelijä tehtävien lataamiselle tiedostosta
        private void LoadTasksButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                taskManager.LoadTasksFromFile(TaskFilePath);
                RefreshTaskList();
            }
            catch (Exception ex)
            {
            MessageBox.Show(ex.Message, "Virhe", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Tapahtumankäsittelijä tehtävien tallentamiselle tiedostoon
        private void SaveTasksButton_Click(object sender, RoutedEventArgs e)
        {
          try
        {
             taskManager.SaveTasksToFile(TaskFilePath);
                MessageBox.Show("Tehtävät tallennettu onnistuneesti. Wau!.", "Tallennus", MessageBoxButton.OK, MessageBoxImage.Information);
        }
            catch (Exception ex)
            //Jos tallennus menis pieleen kerrotaan error viesti
            {
           MessageBox.Show(ex.Message, "Tehtävän tallentaminen ei mennyt sujuvasti :(", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

  // Päivittää tehtävälistan käyttö liittymässä
        private void RefreshTaskList()
        {
            TaskListBox.Items.Clear();
            foreach (var task in taskManager.GetTasks())
            {
                TaskListBox.Items.Add(task);
            }
        }

        // Tyhjentää syötekentät
        private void ClearInputs()
        {
            TitleTextBox.Clear();
            DescriptionTextBox.Clear();
            DueDatePicker.SelectedDate = null;
            PriorityComboBox.SelectedIndex = -1;
      }

        // Sitten ladataan tehtävät kun käynnistetään sovellutus uudestaan
        private void LoadTasks()
        {
            try
            {
                taskManager.LoadTasksFromFile(TaskFilePath);
                RefreshTaskList();
            }
            catch (FileNotFoundException)
            {
                // Jos tulee virhe eikä tiedostoa ei löydy, annetaan virhe viesti 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Jotain meni pieleen", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
