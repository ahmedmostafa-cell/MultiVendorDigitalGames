using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface OrderDetailsService
    {
        List<TbOrderDetails> getAll();
        bool Add(TbOrderDetails client);
        bool Edit(TbOrderDetails client);
        bool Delete(TbOrderDetails client);


    }
    public class ClsOrderDetails : OrderDetailsService
    {
        AlAl3abDbContext ctx;

        public ClsOrderDetails(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbOrderDetails> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbOrderDetails> lstOrderDetails = ctx.TbOrderDetailss.ToList();

            return lstOrderDetails;
        }

        public bool Add(TbOrderDetails item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                item.CreatedDate = DateTime.Now;
                ctx.TbOrderDetailss.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbOrderDetails item)
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

        public bool Delete(TbOrderDetails item)
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
