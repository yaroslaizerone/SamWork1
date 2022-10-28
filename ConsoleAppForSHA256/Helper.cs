using System.Linq;
using System.Data.Entity;

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
        public void CreateUser(Models.User user)
        {
            sFirstDBEntities.User.Add(user);
            sFirstDBEntities.SaveChanges();
        }
        public int GetLastID()
        {
            int id = 0;
            try
            {
                id = sFirstDBEntities.User.OrderByDescending(user => user.ID_User).First().ID_User;
                return id+1;
            }
            catch
            {
                return id+1;
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
            var user = sFirstDBEntities.User.Where(x => x.Name.StartsWith("M") || x.Name.StartsWith("A"));
        }
        public void SortUser()
        {
            var user = sFirstDBEntities.User.OrderBy(x => x.Name);
        }
    }
}
