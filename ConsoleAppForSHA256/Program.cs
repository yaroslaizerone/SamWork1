using ClassLibraryForSamWork1;
using ConsoleAppForSHA256.Models;
using System;
using System.Globalization;

namespace ConsoleAppForSHA256
{
    class Program
    {
        static void Main(string[] args)
        {
            librarySHA lib = new librarySHA();
            ShoesFactoryEntities db = Helper.getContext();
            Helper helperCreate = new Helper();
            //сбор данных 

            Console.WriteLine("Cоздание новой учетной записи для пользователя\n");

            Console.Write("Введите логин: ");
            string loginn = CheckInput(Convert.ToString(Console.ReadLine()),"логин");

            Console.Write("Введите пароль: ");
            string pass = CheckInput(Convert.ToString(Console.ReadLine()), "пароль");
            pass = lib.Sha(pass);
            Console.WriteLine($"Пароль SHA256: {lib.Sha(pass)}");

            Console.Write("Введите E-mail: ");
            string eMailUser = CheckInput(Convert.ToString(Console.ReadLine()), "E-mail");

            Console.Write("Введите Имя: ");
            string nameUser = CheckInput(Convert.ToString(Console.ReadLine()), "Имя");

            Console.Write("Введите Фамилию: ");
            string surnameUser = CheckInput(Convert.ToString(Console.ReadLine()), "Фамилия");

            Console.Write("Введите Отчетсво: ");
            string patrUser = Convert.ToString(Console.ReadLine());

            Console.Write("Введите Телефонный номер: ");
            string phoneUser = Convert.ToString(Console.ReadLine());

            //ввод даты рождения
            DateTime bzdUser = inputDoB();
            
            int id = helperCreate.GetLastID(); //Поиск поледнего Id
            try
            {
                User u1 = new User { ID_User = id, Login = loginn, Password = pass, E_mail = eMailUser, Name = nameUser, Surname = surnameUser, Patronymic = patrUser, PhoneNumber = phoneUser, DateOfBirth = bzdUser, Сonfirmed = "False", ID_Group = 1 };
                helperCreate.CreateUser(u1);
                Console.WriteLine("Данные успешно записанны...");
            }
            catch
            {
                Console.WriteLine("Не удалось записать данные в базу");
            }

            // метод проверки ввода данных 

            string CheckInput(string str, string name)
            {
               while(str == "")
               {
                  Console.WriteLine($"Введите {name}!!");
                  Console.Write($"Введите занова {name}:");
                  str = Convert.ToString(Console.ReadLine());
               }
                return str;
            }
            DateTime inputDoB()
            {
                DateTime dob; // date of birth
                string input;

                do
                {
                    Console.WriteLine("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                    input = Console.ReadLine();
                }
                while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));

                return dob;
            }
        }
    }
}
