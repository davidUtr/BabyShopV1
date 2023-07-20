using BabyShoping.Model;
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

using BabyShoping.Data;
using System.ComponentModel;

namespace BabyShoping.View
{
  
    public partial class BimBomWindow : Window
    {
        public BimBomWindow()
        {
            InitializeComponent();
            nameText.Text = CurrentUser.Name;
       
            using (DataContext context = new DataContext())
            {
                toys = new ObservableCollection<Toy>(context.Toys.ToList());
            }
            ListView.ItemsSource = Toys;
        }
       

        private void Exit_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void MainGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
        public ObservableCollection<Toy> toys { get; set; } = new ObservableCollection<Toy>();
        public ObservableCollection<Toy> Toys { get { return toys; } }

        private void editBut_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as FrameworkElement).DataContext;
            int index = ListView.Items.IndexOf(item);

            EditWindow editWindow = new EditWindow(Toys[index]);
            
            this.Close();
            editWindow.Show();
            
        }

        private void addBut_Click(object sender, RoutedEventArgs e)
        {
            AddToysWindow addToysWindow = new AddToysWindow();
            
            this.Hide();
            addToysWindow.Show();
        }
    }
    }

