using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface EvaluationCommentLikeService
    {
        List<TbEvaluationCommentLike> getAll();
        bool Add(TbEvaluationCommentLike client);
        bool Edit(TbEvaluationCommentLike client);
        bool Delete(TbEvaluationCommentLike client);


    }
    public class ClsEvaluationCommentLike : EvaluationCommentLikeService
    {
        AlAl3abDbContext ctx;

        public ClsEvaluationCommentLike(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbEvaluationCommentLike> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbEvaluationCommentLike> lstEvaluationCommentLikes = ctx.TbEvaluationCommentLikes.ToList();

            return lstEvaluationCommentLikes;
        }

        public bool Add(TbEvaluationCommentLike item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbEvaluationCommentLikes.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbEvaluationCommentLike item)
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

        public bool Delete(TbEvaluationCommentLike item)
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
