using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BabyShoping.Model;
using BabyShoping.ViewModel;
using BabyShoping.Data;

namespace BabyShoping.ViewModel
{
    public class MainWindowViewModel : BaseViewModel 
    {
        List<User> Users = new List<User>()
        {
            //Создание пользователя
            new User("mokraya", "julia", "Мокрая Юлия Александровна"),
            new User("grahov","ivan","Грахов Иван Азаматович")
         
        };

        private string _password;
        private string _login;

        public string Password
        {
            get => _password;
            set => SetPropertyChanged(ref _password, value, nameof(_password));
        }
        public string Login
        {
            get => _login;
            set => SetPropertyChanged(ref _login, value, nameof(_login));
        }
        public ICommand LoginButtonCommand { get; set; }
        public ICommand MinimizeWindowCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }

        public MainWindowViewModel()
        {
            User authorization = null;
            using (Data.DataContext context = new Data.DataContext())
            {
                foreach (User user in Users)
                {
                    string hashPass = user.Password;
                    authorization = context.Users.Where(x => x.Name == user.Name).FirstOrDefault();

                    if (authorization == null)
                    {
                        User imya = user;
                        context.Users.Add(imya);
                        context.SaveChanges();
                    }
                }
            }
            LoginButtonCommand = new RelayCommand(o => MainButtonClick());
            MinimizeWindowCommand = new RelayCommand(o => MinimizeWindowClick());
            CloseWindowCommand = new RelayCommand(o => CloseWindowClick());

        }
        //Авторизация при нажатии на кнопку
        private void MainButtonClick()
        {
            try
            {
                foreach (User user in Users)
                {
                    if (user.Name == _login && HashCode.GetHashCode(_password) == user.Password )
                    {

                        CurrentUser.Name = user.UserName;
                        View.BimBomWindow controlwindow = new View.BimBomWindow();
                        Application.Current.MainWindow.Hide();

                        controlwindow.ShowDialog();


                        return;
                    }
                }

                MessageBox.Show("Данные введены не верно!");
            }
            catch { MessageBox.Show("Произошла ошибка"); }
            }
            
        private void MinimizeWindowClick()
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }
        private void CloseWindowClick()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
