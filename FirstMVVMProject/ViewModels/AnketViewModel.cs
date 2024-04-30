using FirstMVVMProject.Commands;
using FirstMVVMProject.DataBase;
using FirstMVVMProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace FirstMVVMProject.ViewModels
{
    public class AnketViewModel :INotifyPropertyChanged  
    {
       

        public ObservableCollection<Person> People { get; set; } = new();

        private string filePath { get; set; } = string.Empty;
        public string FilePath { get => filePath; set { filePath=value; OnPropertyChanged(); } }
        private Person person { get; set; } = new();
        public Person Person
        {
            get=> person;
            set {
                person = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand AddCommand { get; set; }    
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public AnketViewModel() {

            AddCommand = new RelayCommand(param => People.Add(Person) );
            SaveCommand= new RelayCommand(param => Save(param), param =>
            {
                return FilePath!=string.Empty;
            });
            LoadCommand= new RelayCommand(param => Load(param), param =>
            {
                return FilePath!=string.Empty;
            });


        }

      void Save(object param)
       {
            JsonHandler<Person> saveData = new(FilePath);
            foreach (var person in People)
            {
                bool isDublicate = false;
                foreach (var person1 in saveData.Items)
                {
                    if (person.Equals(person1))
                        isDublicate=true;
                }
                if (!isDublicate)
                {
                    saveData.Items.Add(person);
                }

            }
            saveData.SaveData();
            MessageBox.Show("All Data Saved!");
       }
        void Load(object param)
        {
            if (File.Exists(FilePath))
            {
                JsonHandler<Person> AllData = new(FilePath);

                foreach (var person in AllData.Items)
                {

                    People.Add(person);
                }
                MessageBox.Show("All Data Loaded!");
            }
            else
            {
                MessageBox.Show("Don't Found File");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
