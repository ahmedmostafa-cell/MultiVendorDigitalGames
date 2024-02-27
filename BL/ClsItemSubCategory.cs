using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ItemSubCategoryService
    {
        List<TbItemSubCategory> getAll();
        bool Add(TbItemSubCategory client);
        bool Edit(TbItemSubCategory client);
        bool Delete(TbItemSubCategory client);


    }
    public class ClsItemSubCategory : ItemSubCategoryService
    {
        AlAl3abDbContext ctx;

        public ClsItemSubCategory(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbItemSubCategory> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbItemSubCategory> lstItemSubCategories = ctx.TbItemSubCategories.ToList();

            return lstItemSubCategories;
        }

        public bool Add(TbItemSubCategory item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbItemSubCategories.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbItemSubCategory item)
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

        public bool Delete(TbItemSubCategory item)
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
