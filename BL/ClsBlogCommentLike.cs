using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface BlogCommentLikeService
    {
        List<TbBlogCommentLike> getAll();
        bool Add(TbBlogCommentLike client);
        bool Edit(TbBlogCommentLike client);
        bool Delete(TbBlogCommentLike client);


    }
    public class ClsBlogCommentLike : BlogCommentLikeService
    {
        AlAl3abDbContext ctx;

        public ClsBlogCommentLike(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbBlogCommentLike> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbBlogCommentLike> lstBlogCommentLikes = ctx.TbBlogCommentLikes.ToList();

            return lstBlogCommentLikes;
        }

        public bool Add(TbBlogCommentLike item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbBlogCommentLikes.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbBlogCommentLike item)
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

        public bool Delete(TbBlogCommentLike item)
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
