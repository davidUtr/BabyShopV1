using BabyShoping.Data;
using BabyShoping.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace BabyShoping.View
{
    /// <summary>
    /// Логика взаимодействия для AddToysWindow.xaml
    /// </summary>
    public partial class AddToysWindow : Window
    {
        public AddToysWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BimBomWindow bimBomWindow = new BimBomWindow();
            bimBomWindow.Show();
            this.Close();
        }

        private void saveBut_Click(object sender, RoutedEventArgs e)
        {
           

                if (string.IsNullOrEmpty(nameText.Text) || string.IsNullOrEmpty(priceText.Text) || string.IsNullOrEmpty(descText.Text) && Image.Source.ToString() == null)
                {
                    MessageBox.Show("Вы ввели некорректные данные, либо вообще ничего не ввели");
                }
                else
                {
                Toy save = null;
                using (DataContext context = new DataContext())
                {
                     save = new Toy(nameText.Text, priceText.Text, descText.Text, "ну да");
                    context.Toys.Add(save);
                    context.SaveChanges();
                }
                using (FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\Image\\" + save.id + ".png", FileMode.Create))
                    {
                        BitmapFrame frame = BitmapFrame.Create((BitmapSource)Image.Source);
                        BitmapEncoder encoder = new PngBitmapEncoder();
                        encoder.Frames.Add(frame);
                        encoder.Save(fileStream);
                    using (DataContext context = new DataContext())
                    {
                        Toy imya = context.Toys.Where(x => x.id == save.id).FirstOrDefault();
                        imya.ImagePath = "\\Image\\" + save.id + ".png";
                        context.SaveChanges();
                       
                    }
                    }
                    BimBomWindow bimBomWindow = new BimBomWindow();
                    bimBomWindow.Show();
                    this.Close();
                MessageBox.Show("Вы добавили новый товар!");
                }
                }
            

        

        private void imageBut_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog avatar = new OpenFileDialog();
            avatar.Title = "Выберете картинку";
            avatar.Filter = "Image Files (*.bmp;*.png;(.jpg)|*.bmp;*.png;*.jpg";
            if (avatar.ShowDialog() == true)
            {
                BitmapImage image = new BitmapImage(new Uri(avatar.FileName));
                Image.Source = image;
            }
        }

        private void priceText_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z))
            {
                e.Handled = true;
            }
        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
