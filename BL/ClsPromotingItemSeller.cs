using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface PromotingItemSellerService
    {
        List<TbPromotingItemSeller> getAll();
        bool Add(TbPromotingItemSeller client);
        bool Edit(TbPromotingItemSeller client);
        bool Delete(TbPromotingItemSeller client);


    }
    public class ClsPromotingItemSeller : PromotingItemSellerService
    {
        AlAl3abDbContext ctx;

        public ClsPromotingItemSeller(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbPromotingItemSeller> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbPromotingItemSeller> lstPromotingItemSellers = ctx.TbPromotingItemSellers.ToList();

            return lstPromotingItemSellers;
        }

        public bool Add(TbPromotingItemSeller item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbPromotingItemSellers.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbPromotingItemSeller item)
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

        public bool Delete(TbPromotingItemSeller item)
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
