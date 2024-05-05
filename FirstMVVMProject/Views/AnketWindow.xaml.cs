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


namespace FirstMVVMProject.Views;
    public partial class AnketWindow : Window
    {

       


        public AnketWindow()
        {
            InitializeComponent();
            DataContext=new AnketViewModel();
        }

    }

