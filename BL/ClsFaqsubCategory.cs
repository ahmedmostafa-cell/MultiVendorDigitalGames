using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface FaqsubCategoryService
    {
        List<TbFaqsubCategory> getAll();
        bool Add(TbFaqsubCategory client);
        bool Edit(TbFaqsubCategory client);
        bool Delete(TbFaqsubCategory client);


    }
    public class ClsFaqsubCategory : FaqsubCategoryService
    {
        AlAl3abDbContext ctx;

        public ClsFaqsubCategory(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbFaqsubCategory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbFaqsubCategory> lstFaqsubCategories = ctx.TbFaqsubCategories.ToList();

            return lstFaqsubCategories;
        }

        public bool Add(TbFaqsubCategory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbFaqsubCategories.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbFaqsubCategory item)
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

        public bool Delete(TbFaqsubCategory item)
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
