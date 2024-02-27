using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface FavouriteCartService
    {
        List<TbFavouriteCart> getAll();
        bool Add(TbFavouriteCart client);
        bool Edit(TbFavouriteCart client);
        bool Delete(TbFavouriteCart client);


    }
    public class ClsFavouriteCart : FavouriteCartService
    {
        AlAl3abDbContext ctx;

        public ClsFavouriteCart(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbFavouriteCart> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbFavouriteCart> lstFavouriteCarts = ctx.TbFavouriteCarts.ToList();

            return lstFavouriteCarts;
        }

        public bool Add(TbFavouriteCart item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbFavouriteCarts.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbFavouriteCart item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }

        public bool Delete(TbFavouriteCart item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();

                ctx.Entry(item).State = EntityState.Deleted;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
