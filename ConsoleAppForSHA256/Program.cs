using ClassLibraryForSamWork1;
using ConsoleAppForSHA256.Models;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

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

            Console.WriteLine("Cоздание нового сотрудника фабрики \n");

            Console.Write("Введите Имя: ");
            string nameStaff = CheckInput(Convert.ToString(Console.ReadLine()), "Имя");

            Console.Write("Введите Фамилию: ");
            string surnameStaff = CheckInput(Convert.ToString(Console.ReadLine()), "Фамилия");

            Console.Write("Введите Отчетсво: ");
            string patrStaff = Convert.ToString(Console.ReadLine());

            Console.Write("Введите Телефонный номер: ");
            string phoneStaff = RegPhone(Convert.ToString(Console.ReadLine()));
            
            //ввод даты рождения
            DateTime bzdStaff = inputDoB();

            Console.Write("Введите номер группы: ");
            string idGroup = CheckInput(Convert.ToString(Console.ReadLine()), "Номер группы");
            int id_group = helperCreate.GetLastIDGroup();
            while (1 > Convert.ToInt32(idGroup) || Convert.ToInt32(idGroup) > id_group)
            {
                Console.Write("Данной группы не существует, Введите данные заново:");
                idGroup = CheckInput(Convert.ToString(Console.ReadLine()), "Номер группы");
            }
            int id_staff = helperCreate.GetLastIDstaff(); //Поиск поледнего Id сотрудника

            try
            {
                Staff s1 = new Staff {ID_Staff = id_staff, Name = nameStaff, Surname =surnameStaff, Patronymic = patrStaff, PhoneNumber = phoneStaff, DateOfBirth = bzdStaff, ID_Group = Convert.ToInt32(idGroup)};
                helperCreate.CreateStaff(s1);
                Console.WriteLine("Данные успешно записанны...");
            }
            catch
            {
                Console.WriteLine("Не удалось записать данные в базу");
            }

            Console.Write("Желаете стать пользователем системы? y/n");
            string outStr = Console.ReadLine();
            if (outStr == "y")
            {
                Console.Write("Введите логин: ");
                string loginn = CheckInput(Convert.ToString(Console.ReadLine()), "логин");

                Console.Write("Введите пароль: ");
                string pass = CheckInput(Convert.ToString(Console.ReadLine()), "пароль");
                pass = lib.Sha(pass);
                Console.WriteLine($"Пароль SHA256: {pass}");

                Console.Write("Введите E-mail: ");
                string eMail = CheckInput(Convert.ToString(Console.ReadLine()), "E-mail");
                string emailUser = RegEmail(eMail);

                int id_user = helperCreate.GetLastIDUser(); //Поиск поледнего Id пользователя
                try
                {
                    User u1 = new User { ID_User = id_user, Login = loginn, Password = pass, E_mail = emailUser, Сonfirmed = "F", ID_Staff = id_staff};
                    helperCreate.CreateUser(u1);
                    Console.WriteLine("Данные успешно записанны...");
                }
                catch
                {
                    Console.WriteLine("Не удалось записать данные в базу");
                }
            }
            else { }


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
                    Console.Write("Введите дату рождения в формате дд.ММ.гггг (день.месяц.год):");
                    input = Console.ReadLine();
                }
                while (!DateTime.TryParseExact(input, "dd.MM.yyyy", null, DateTimeStyles.None, out dob));

                return dob;
            }
            string RegPhone(string phNumber)
            {
                string pattern = @"\D";
                string target = "";
                Regex regex = new Regex(pattern);
                phNumber = "+" + regex.Replace(phNumber, target);
                Console.WriteLine((phNumber.Length));
                while(phNumber.Length < 12 || phNumber.Length > 12)
                {
                    Console.Write("Неверный ввод телефонного номера, введите завново: ");
                    string phoneSf = RegPhone(Convert.ToString(Console.ReadLine()));
                }    
                return phNumber;
            }
            string RegEmail (string eMail)
            {
                string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
                if (Regex.IsMatch(eMail, pattern, RegexOptions.IgnoreCase))
                {
                    return eMail;
                }
                else
                {
                    while(!Regex.IsMatch(eMail, pattern, RegexOptions.IgnoreCase))
                    {
                        Console.Write("Введите E-mail: ");
                        eMail = CheckInput(Convert.ToString(Console.ReadLine()), "E-mail");
                    }
                    return eMail;
                }
            }
        }
    }
}
