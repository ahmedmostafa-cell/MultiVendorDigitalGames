using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface SellerSubscribeService
    {
        List<TbSellerSubscribe> getAll();
        bool Add(TbSellerSubscribe client);
        bool Edit(TbSellerSubscribe client);
        bool Delete(TbSellerSubscribe client);


    }
    public class ClsSellerSubscribe : SellerSubscribeService
    {
        AlAl3abDbContext ctx;

        public ClsSellerSubscribe(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbSellerSubscribe> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbSellerSubscribe> lstSellerSubscribes = ctx.TbSellerSubscribes.ToList();

            return lstSellerSubscribes;
        }

        public bool Add(TbSellerSubscribe item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbSellerSubscribes.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbSellerSubscribe item)
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

        public bool Delete(TbSellerSubscribe item)
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
