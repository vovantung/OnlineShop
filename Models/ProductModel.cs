using Models.Framework;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Models
{
    public class ProductModel
    {

        private OnlineShopDbContext context = null;
        public ProductModel()
        {
            context = new OnlineShopDbContext();

        }
        public IEnumerable<Procduct> ListProdctPagiing(string ProductTypeID, string searchString, int page, int pagesize)
        {
            IQueryable<Procduct> model = context.Procducts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Description.Contains(searchString));
            }
            if(!string.IsNullOrEmpty(ProductTypeID))
            {
                model = model.Where(x => x.ProductTypeID == ProductTypeID);

            }    
            return model.OrderBy(x => x.ID).ToPagedList(page, pagesize);

        }

        public Procduct getProductbyID(int id)
        {
            return context.Procducts.Find(id);
          
        }

        public Procduct getProductbyMetaTitle(string title)
        {
            IQueryable<Procduct> model = context.Procducts;
            Procduct pr = model.Where(x => x.MetaTitle == title).SingleOrDefault();
            return pr;
        }
    }
}
