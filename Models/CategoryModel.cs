using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Framework;
using PagedList;

namespace Models
{
    public class CategoryModel
    {
        private OnlineShopDbContext context = null;
        public CategoryModel()
        {
            context = new OnlineShopDbContext();

        }
        public IEnumerable<Category> ListAllPagiing(int page,  int pagesize)
        {
            return context.Categories.OrderBy(x => x.ID).ToPagedList(page, pagesize);

        }
        public List<Category> ListAll(bool status)
        {
            object[] sqlParams =
            {
                new SqlParameter("@Status", status)

            };
            var res = context.Database.SqlQuery<Category>("Sp_Category_ListAll @Status",  sqlParams).ToList();
            return res;


        }
        public int Insert(string Name, string Alias, DateTime CreatedDate, int ParentID, bool Status, int Order)
        {
            
            object[] sqlParams =
            {
              
                new SqlParameter("@Name", Name),
                new SqlParameter("@Alias", Alias),
                new SqlParameter("@CreatedDate", CreatedDate),
                new SqlParameter("@ParentID", ParentID),
                new SqlParameter("@Status", Status),
                new SqlParameter("@Order", Order)
            };
             int res = context.Database.ExecuteSqlCommand("Sp_Category_Insert @Name, @Alias, @CreatedDate, @ParentID, @Status, @Order",  sqlParams);
            return res; 

        }

    }
}
