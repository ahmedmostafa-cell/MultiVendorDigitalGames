using Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BL
{
    public interface PolicyAndPrivacyService
    {
        List<TbPolicyAndPrivacy> getAll();
        bool Add(TbPolicyAndPrivacy client);
        bool Edit(TbPolicyAndPrivacy client);
        bool Delete(TbPolicyAndPrivacy client);


    }
    public class ClsPolicyAndPrivacy : PolicyAndPrivacyService
    {
        AlAl3abDbContext ctx;

        public ClsPolicyAndPrivacy(AlAl3abDbContext context)
        {
            ctx = context;
        }
        public List<TbPolicyAndPrivacy> getAll()
        {
            //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
            List<TbPolicyAndPrivacy> lstPolicyAndPrivacies = ctx.TbPolicyAndPrivacies.ToList();

            return lstPolicyAndPrivacies;
        }

        public bool Add(TbPolicyAndPrivacy item)
        {
            try
            {
                //_4ZsoftwareCompanyTestTaskContext o_4ZsoftwareCompanyTestTaskContext = new _4ZsoftwareCompanyTestTaskContext();
                item.CurrentState = 1;
                ctx.TbPolicyAndPrivacies.Add(item);
                ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
        public bool Edit(TbPolicyAndPrivacy item)
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

        public bool Delete(TbPolicyAndPrivacy item)
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
