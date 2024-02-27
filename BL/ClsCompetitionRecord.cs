using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface CompeitionRecordService
    {
        List<TbCompetitionRecord> getAll();
        bool Add(TbCompetitionRecord client);
        bool Edit(TbCompetitionRecord client);
        bool Delete(TbCompetitionRecord client);


    }
    public class ClsCompetitionRecord : CompeitionRecordService
    {
        AlAl3abDbContext ctx;

        public ClsCompetitionRecord(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbCompetitionRecord> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbCompetitionRecord> lstCompetitionRecords = ctx.TbCompetitionRecords.ToList();

            return lstCompetitionRecords;
        }

        public bool Add(TbCompetitionRecord item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbCompetitionRecords.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbCompetitionRecord item)
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

        public bool Delete(TbCompetitionRecord item)
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
