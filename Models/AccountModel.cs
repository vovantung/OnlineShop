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
    public class AccountModel
    {
        private OnlineShopDbContext context = null;
        public AccountModel()
        {
            context = new OnlineShopDbContext();

        }
        public Account getUserbyID(int id)
        {
            return context.Accounts.Find(id);
        }

        public  bool ChangStatus(int id)
        {
            var user = context.Accounts.Find(id);
            user.Status = !user.Status;
            context.SaveChanges();
            return !user.Status;

        }

        public  IEnumerable<Account> ListAccountPagiing(string searchString, int page, int pagesize)
        {
            IQueryable<Account> model = context.Accounts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Username.Contains(searchString) || x.FullName.Contains(searchString));
            }
            return model.OrderBy(x => x.UserID).ToPagedList(page, pagesize);
        }
        public int InsertUser(Account user)
        {
            context.Accounts.Add(user);
            context.SaveChanges();
            return user.UserID;
        }
        public bool DeleteUser(int id){
            try {
                var user = context.Accounts.Find(id);
                context.Accounts.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }  
        }
      
        public bool EditAccount(Account entrity)
        {

            try
            {
                var user = context.Accounts.Find(entrity.UserID);
                if(user == null)
                {
                    return false;
                }
                else
                {

                    user.Password = new md5().Encrypt(entrity.Password, "TX") ;
                    user.Status = entrity.Status;
                    user.FullName = entrity.FullName;
                    user.ModifiedDate = DateTime.Now;
                    context.SaveChanges();
                    return true;

                }
                
                

            }
            catch(Exception exx)
            {
                return false;
            }


            

        }


        public int Login(string username, string password)
        {
            //object[] sqlParams =
            //{
            //    new SqlParameter("@Username", username),
            //    new SqlParameter("@Password", password)
            //};
            //var res = context.Database.SqlQuery<bool>("Sp_Account_Login @Username, @Password", sqlParams).SingleOrDefault();

            //return res;
            var result = context.Accounts.SingleOrDefault(x => x.Username == username);
            if(result == null)
            {
                return  0;

            }
            else
            {
                if(result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if(result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }

            }


        }
        public Account GetUserIDbyUsername(string userName)
        {
            return context.Accounts.SingleOrDefault(x => x.Username == userName);
        }
      
    }
}
