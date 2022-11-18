using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamWork1
{
    public class DataBaseFuncs
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
    }
}
