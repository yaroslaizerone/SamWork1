using ClassLibraryForSamWork1;
using SamWork1.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Windows;

namespace SamWork1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            librarySHA lib = new librarySHA();
            string login = textBoxLogin.Text;
            string password = lib.Sha(textBoxPassword.Password);
            ShoesFactoryEntities m = new ShoesFactoryEntities();
            var dataBaseChekerUser = m.User;
            var dataBaseChekerPost = m.Post;
            
            var userSystem = dataBaseChekerUser.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
            if (userSystem != null)
            {
                int idStaff = userSystem.ID_Staff;
                var userPost = dataBaseChekerPost.First(y => y.ID_Staff == idStaff);
                if (userPost != null)
                {
                    string namePost = userPost.Name;
                    switch (namePost)
                    {
                        case "Администратор":
                            AdminPanel f = new AdminPanel();
                            f.Show();
                            break;
                        case "Работник Склада":
                            SkladWorkerPanel f2 = new SkladWorkerPanel();
                            f2.Show();
                            break;
                        case "Менеджер":
                            ManagerPanel f3 = new ManagerPanel();
                            f3.Show();
                            break;
                        case "Модельер-технолог":
                            ModelTechnologyPanel f4 = new ModelTechnologyPanel();
                            f4.Show();
                            break;
                        case "Закройщик":
                            ZakroishikPanel f5 = new ZakroishikPanel();
                            f5.Show();
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Такого пользователя не существует");
                }
            }
            else
            {
                MessageBox.Show("Неверныый логин или пароль!");
            }







        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
