using StokTakipProgDemo.Entitiy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipProgDemo
{
    public class ProductDal
    {
        public List<Product> GetAll()
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
                return entitiy.Products.ToList();
            }
        }

        public List<Product> GetbyName(string key)
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
                return entitiy.Products.Where(p => p.ProductName.Contains(key)).ToList();
            }
        }
        public List<Product> GetbyId(int id)
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
               return entitiy.Products.Where(p => p.Id == id).ToList();  
            }
        }

        public void Add(Product product)
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
               entitiy.Products.Add(product);
                entitiy.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
                var varlik = entitiy.Entry(product);
                varlik.State = System.Data.EntityState.Modified;
                entitiy.SaveChanges();
            }          
        }

        public void Delete(Product product)
        {
            using (StokTakipEntitiy entitiy = new StokTakipEntitiy())
            {
                var varlik = entitiy.Entry(product);
                varlik.State = System.Data.EntityState.Deleted;
                entitiy.SaveChanges();
            }
        }
        //public int stock;
        //public void Sell(int amount)
        //{ 


           
        //}
    }
}
