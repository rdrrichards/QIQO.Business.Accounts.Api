using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class FeeScheduleClient : IFeeScheduleService
    {
        public int CreateFeeSchedule(FeeSchedule fee_schedule)
        {
            throw new NotImplementedException();
        }

        public Task<int> CreateFeeScheduleAsync(FeeSchedule fee_schedule)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFeeSchedule(FeeSchedule fee_schedule)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteFeeScheduleAsync(FeeSchedule fee_schedule)
        {
            throw new NotImplementedException();
        }

        public FeeSchedule GetFeeSchedule(int fee_schedule)
        {
            throw new NotImplementedException();
        }

        public Task<FeeSchedule> GetFeeScheduleAsync(int fee_schedule)
        {
            throw new NotImplementedException();
        }

        public List<FeeSchedule> GetFeeSchedulesByAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeeSchedule>> GetFeeSchedulesByAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }

        public List<FeeSchedule> GetFeeSchedulesByCompany(Company company)
        {
            throw new NotImplementedException();
        }

        public Task<List<FeeSchedule>> GetFeeSchedulesByCompanyAsync(Company company)
        {
            throw new NotImplementedException();
        }
    }
}
