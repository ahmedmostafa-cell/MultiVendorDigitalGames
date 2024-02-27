using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface ItemSellerImageService
    {
        List<TbItemSellerImages> getAll();
        bool Add(TbItemSellerImages client);
        bool Edit(TbItemSellerImages client);
        bool Delete(TbItemSellerImages client);


    }
    public class ClsItemSellerImage : ItemSellerImageService
    {
        AlAl3abDbContext ctx;

        public ClsItemSellerImage(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbItemSellerImages> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbItemSellerImages> lstItemSellerImages = ctx.TbItemSellerImagess.ToList();

            return lstItemSellerImages;
        }

        public bool Add(TbItemSellerImages item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbItemSellerImagess.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbItemSellerImages item)
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

        public bool Delete(TbItemSellerImages item)
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
