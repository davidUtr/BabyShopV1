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
    /// Логика взаимодействия для EditWindow.xaml
    /// </summary>
    public partial class EditWindow : Window
    {
        Toy toy = null;
        public EditWindow(Toy toy)
        {
            InitializeComponent();
            this.toy = toy;
            nameText.Text = toy.Name;
            priceText.Text = toy.Price;
            descText.Text = toy.Description;
            Image.Source = new BitmapImage(new Uri(toy.ImagePathD));
        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            using (DataContext context = new DataContext())
            {
                try { 
                if (toy != null)
                {
                    Toy game = context.Toys.Where(x => x.id == toy.id).FirstOrDefault();
                    context.Toys.Remove(game);
                    context.SaveChanges();
                    this.Close();
                    BimBomWindow bimBomWindow = new BimBomWindow();
                    bimBomWindow.Show();
                    MessageBox.Show("Данные успешно удалены!");

                }
                }
                catch { MessageBox.Show("Произошла ошибка, пипец"); }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BimBomWindow bimBomWindow = new BimBomWindow();
            bimBomWindow.Show();
            this.Hide();

        }

      

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z))
            {
                e.Handled = true;
            }
        }

        private void saveBut_Click(object sender, RoutedEventArgs e)
        {
            Toy save = null;
            using (DataContext context = new DataContext())
            {
                save = context.Toys.Where(x => x.id == toy.id).FirstOrDefault();
                if (save == null || string.IsNullOrEmpty(nameText.Text) || string.IsNullOrEmpty(priceText.Text) || string.IsNullOrEmpty(descText.Text))
                {
                    MessageBox.Show("Вы ввели некорректные данные, либо вообще ничего не ввели");
                }
                else { 
                    save.Name = nameText.Text;
                save.Price = priceText.Text;

                save.Description = descText.Text;
                    try
                    {
                        using (FileStream fileStream = new FileStream(Directory.GetCurrentDirectory() + "\\Image\\" + save.id + ".png", FileMode.Create))
                        {
                            BitmapFrame frame = BitmapFrame.Create((BitmapSource)Image.Source);
                            BitmapEncoder encoder = new PngBitmapEncoder();
                            encoder.Frames.Add(frame);
                            encoder.Save(fileStream);
                        }
                    }
                    catch { Exception n; }
                   save.ImagePath = "\\Image\\" + save.id + ".png";
                context.SaveChanges();
                BimBomWindow bimBomWindow = new BimBomWindow();
                bimBomWindow.Show();
                this.Close();
            }
            }

        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
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
    }
}


