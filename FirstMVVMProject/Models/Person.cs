using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FirstMVVMProject.Models
{
    public class Person : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string email;
        private string phone;
        private DateTime birthday;

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public string Name { get => name; set { name=value; OnPropertyChanged(); } }
        public string Surname { get => surname; set { surname=value; OnPropertyChanged(); } }

        public string Email { get => email; set { email=value; OnPropertyChanged(); } }

        public string Phone { get => phone; set { phone=value; OnPropertyChanged(); } }

        public DateTime Birthday { get => birthday; set { birthday=value; OnPropertyChanged(); } }

        public override string ToString() => $"{Name}";

       
    }
}
