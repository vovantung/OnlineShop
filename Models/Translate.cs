using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Models.Framework;

namespace Models
{
    public class Translate
    {
        private OnlineShopDbContext context = null;
        public Translate()
        {
            context = new OnlineShopDbContext();

        }
        public string Trans(string word)
        {
            try {
                bool launge = false;

                IQueryable<Word> model = context.Words;
                Word res1 = model.Where(x => x.Word1.Contains(word) || x.Word1.Contains(word)).SingleOrDefault();
                IQueryable<Translation> model2 = context.Translations;
                if(res1 == null){
                    return null; 
                }
                    
                Translation res2 = model2.Where(x => x.WordID == res1.ID).Take(1).SingleOrDefault();
                if (res2 == null)
                {
                    res2 = model2.Where(x => x.ToWordID == res1.ID).SingleOrDefault();
                    launge = true;
                }

                long id;
                if (launge)
                {
                    id = long.Parse(res2.WordID.ToString());
                }
                else
                {
                    id = long.Parse(res2.ToWordID.ToString());
                }


                return model.Where(x => x.ID == id).SingleOrDefault().Word1.ToString();
            }
            catch(Exception ex)
            {
                return null;
            }
            

        }
    }
}
