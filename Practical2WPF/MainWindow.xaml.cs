using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace Practical2WPF
{
    public class Note
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }

    public class DataManager
    {
        public void SerializeNotes(List<Note> notes, string filePath)
        {
            string json = JsonConvert.SerializeObject(notes);
            File.WriteAllText(filePath, json);
        }

        public List<Note> DeserializeNotes(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Note>>(json);
            }
            return new List<Note>();
        }
    }

    public partial class MainWindow : Window
    {
        private string dataFilePath = "notes.json";
        private List<Note> allNotes;
        private List<Note> displayedNotes;

        public MainWindow()
        {
            InitializeComponent();
            LoadNotes();
            datePicK.SelectedDate = DateTime.Today;
        }

        private void LoadNotes()
        {
            DataManager dataManager = new DataManager();
            allNotes = dataManager.DeserializeNotes(dataFilePath);
        }

        private void SaveNotes()
        {
            DataManager dataManager = new DataManager();
            dataManager.SerializeNotes(allNotes, dataFilePath);
        }

        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DateTime selectedDate = datePicK.SelectedDate ?? DateTime.Today;
            displayedNotes = allNotes.Where(note => note.Date.Date == selectedDate.Date).ToList();
            notesList.ItemsSource = displayedNotes;
        }

        private void notesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Note selectedNote = notesList.SelectedItem as Note;
            if (selectedNote != null)
            {
                title.Text = selectedNote.Title;
                description.Text = selectedNote.Description;
            }
        }

        private void addNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            string titl = title.Text.Trim();
            string desc = description.Text.Trim();
            DateTime selectedDate = datePicK.SelectedDate ?? DateTime.Today;

            if (!string.IsNullOrEmpty(titl) && selectedDate != null)
            {
                Note newNote = new Note
                {
                    Title = titl,
                    Description = desc,
                    Date = selectedDate
                };

                allNotes.Add(newNote);
                SaveNotes();

                displayedNotes.Add(newNote);
                notesList.ItemsSource = displayedNotes;
                notesList.SelectedItem = newNote;

                ClearFields();
            }
            else
            {
                MessageBox.Show("Введите описание заметки и выберите дату");
            }
        }

        private void updateNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note selectedNote = notesList.SelectedItem as Note;
            if (selectedNote != null)
            {
                selectedNote.Title = title.Text.Trim();
                selectedNote.Description = description.Text.Trim();
                SaveNotes();

                notesList.Items.Refresh();
                ClearFields();
            }
        }

        private void deleteNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            Note selectedNote = notesList.SelectedItem as Note;
            if (selectedNote != null)
            {
                allNotes.Remove(selectedNote);
                SaveNotes();

                displayedNotes.Remove(selectedNote);
                notesList.ItemsSource = displayedNotes;

                ClearFields();
            }
        }

        private void ClearFields()
        {
            title.Text = "";
            description.Text = "";
        }
    }
}
