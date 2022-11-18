using System.Linq;
using System.Data.Entity;
using System;

namespace ConsoleAppForSHA256
{
    public class Helper
    {
        private static Models.ShoesFactoryEntities sFirstDBEntities;

        public static Models.ShoesFactoryEntities getContext()
        {
            if (sFirstDBEntities == null)
            {
                sFirstDBEntities = new Models.ShoesFactoryEntities();
            }
            return sFirstDBEntities;
        }
        public void CreateStaff(Models.Staff staff)
        {
            sFirstDBEntities.Staff.Add(staff);
            sFirstDBEntities.SaveChanges();
        }
        public void CreateUser(Models.User user)
        {
            sFirstDBEntities.User.Add(user);
            sFirstDBEntities.SaveChanges();
        }
        public int GetLastIDstaff()
        {
            int id = 0;
            try
            {
                id = sFirstDBEntities.Staff.OrderByDescending(staff => staff.ID_Staff).First().ID_Staff;
                return id+1;
            }
            catch
            {
                return id+1;
            }
        }
        public int GetLastIDGroup()
        {
            int id = 0;
            try
            {
                id = sFirstDBEntities.Group.OrderByDescending(group => group.ID_Group).First().ID_Group;
                return id + 1;
            }
            catch
            {
                return id + 1;
            }
        }
        public int GetLastIDUser()
        {
            int id = 0;
            try
            {
                id = sFirstDBEntities.User.OrderByDescending(user => user.ID_User).First().ID_User;
                return id + 1;
            }
            catch
            {
                return id + 1;
            }
        }
        public void UpdateUser(Models.User user)
        {
            sFirstDBEntities.Entry(user).State = EntityState.Modified;
            sFirstDBEntities.SaveChanges();
        }
        public void Removeuser(int Id_User)
        {
            var user = sFirstDBEntities.User.Find(Id_User);
            sFirstDBEntities.User.Remove(user);
            sFirstDBEntities.SaveChanges();
        }
        public void FiltrUser()
        {
            var user = sFirstDBEntities.Staff.Where(x => x.Name.StartsWith("M") || x.Name.StartsWith("A"));
        }
        public void SortUser()
        {
            var user = sFirstDBEntities.Staff.OrderBy(x => x.Name);
        }
        public void CheckUserData(string login)
        {
            while(sFirstDBEntities.User.Any(x => x.Login == login))
            {
                Console.WriteLine("Данный пользователь уже существует, введите логин занова: ");
                login = Convert.ToString(Console.ReadLine());
            }
        }
    }
}
