using FirstMVVMProject.Models;
using FirstMVVMProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace FirstMVVMProject.Views
{
    /// <summary>
    /// Interaction logic for AnketWindow.xaml
    /// </summary>
    public partial class AnketWindow : Window
    {

       


        public AnketWindow()
        {
            InitializeComponent();
            DataContext=new AnketViewModel();
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
