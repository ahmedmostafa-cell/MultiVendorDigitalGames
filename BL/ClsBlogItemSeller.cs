using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface BlogItemSellerService
    {
        List<TbBlogItemSeller> getAll();
        bool Add(TbBlogItemSeller client);
        bool Edit(TbBlogItemSeller client);
        bool Delete(TbBlogItemSeller client);


    }
    public class ClsBlogItemSeller : BlogItemSellerService
    {
        AlAl3abDbContext ctx;

        public ClsBlogItemSeller(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbBlogItemSeller> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbBlogItemSeller> lstBlogItemSellers = ctx.TbBlogItemSellers.ToList();

            return lstBlogItemSellers;
        }

        public bool Add(TbBlogItemSeller item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbBlogItemSellers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbBlogItemSeller item)
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

        public bool Delete(TbBlogItemSeller item)
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
