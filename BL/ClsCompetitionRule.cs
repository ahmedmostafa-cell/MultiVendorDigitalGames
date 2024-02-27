using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface CompeitionRuleService
    {
        List<TbCompetitionRule> getAll();
        bool Add(TbCompetitionRule client);
        bool Edit(TbCompetitionRule client);
        bool Delete(TbCompetitionRule client);


    }

    public class ClsCompetitionRule : CompeitionRuleService
    {
        AlAl3abDbContext ctx;

        public ClsCompetitionRule(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbCompetitionRule> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbCompetitionRule> lstCompetitionRules = ctx.TbCompetitionRules.ToList();

            return lstCompetitionRules;
        }

        public bool Add(TbCompetitionRule item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbCompetitionRules.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbCompetitionRule item)
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

        public bool Delete(TbCompetitionRule item)
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
