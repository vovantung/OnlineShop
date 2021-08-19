using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
     public class MenuModel
    {

        private OnlineShopDbContext context = null;
        public MenuModel()
        {
            context = new OnlineShopDbContext();

        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return context.Menus.Where(x => x.TypeID == groupId).ToList();

        }
    }



}
