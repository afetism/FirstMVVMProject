using FirstMVVMProject.Commands;
using FirstMVVMProject.DataBase;
using FirstMVVMProject.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;



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
      
        private Person _SelectedPerson { get; set; }
        public Person SelectedPerson
        {
            get { return _SelectedPerson; }
            set
            {
                _SelectedPerson = value;
                OnPropertyChanged();

                if (_SelectedPerson is not null)
                {
                   var result= MessageBox.Show($"{_SelectedPerson.ToString()}", "Do you want Edit?", MessageBoxButton.YesNo);
                    if(result==MessageBoxResult.Yes)
                    {
                        SelectCommand.Execute(this);
                        IsButtonEnabled=true;
                    }
                    
                }

            }
        }
        private bool _isButtonEnabled;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand AddCommand { get; set; }    
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand LoadCommand { get; set; }
        public RelayCommand SelectCommand { get; set; }
        public RelayCommand EditCommand { get; set; }


        public AnketViewModel() {

            SelectedPerson=null;
            IsButtonEnabled = false;
            AddCommand = new RelayCommand(param => { People.Add(Person); Person=new(); });
            SaveCommand= new RelayCommand(param => Save(param), param =>
            {
                return FilePath!=string.Empty;
            });
            LoadCommand= new RelayCommand(param => Load(param), param =>
            {
                return FilePath!=string.Empty;
            });
            SelectCommand = new RelayCommand(param => Person=SelectedPerson);
           
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
            FilePath=string.Empty;
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
            FilePath=string.Empty;
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
