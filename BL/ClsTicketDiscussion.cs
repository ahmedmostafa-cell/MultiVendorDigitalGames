using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface TicketDiscussionService
    {
        List<TbTicketDiscussion> getAll();
        bool Add(TbTicketDiscussion client);
        bool Edit(TbTicketDiscussion client);
        bool Delete(TbTicketDiscussion client);


    }
    public class ClsTicketDiscussion : TicketDiscussionService
    {
        AlAl3abDbContext ctx;

        public ClsTicketDiscussion(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbTicketDiscussion> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbTicketDiscussion> lstTicketDiscussions = ctx.TbTicketDiscussions.ToList();

            return lstTicketDiscussions;
        }

        public bool Add(TbTicketDiscussion item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbTicketDiscussions.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbTicketDiscussion item)
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

        public bool Delete(TbTicketDiscussion item)
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
