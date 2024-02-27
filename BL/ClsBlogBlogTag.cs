using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface BlogBlogTagService
    {
        List<TbBlogBlogTag> getAll();
        bool Add(TbBlogBlogTag client);
        bool Edit(TbBlogBlogTag client);
        bool Delete(TbBlogBlogTag client);


    }
    public class ClsBlogBlogTag : BlogBlogTagService
    {
        AlAl3abDbContext ctx;

        public ClsBlogBlogTag(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbBlogBlogTag> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbBlogBlogTag> lstBlogBlogTag = ctx.TbBlogBlogTags.ToList();

            return lstBlogBlogTag;
        }

        public bool Add(TbBlogBlogTag item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbBlogBlogTags.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbBlogBlogTag item)
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

        public bool Delete(TbBlogBlogTag item)
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
