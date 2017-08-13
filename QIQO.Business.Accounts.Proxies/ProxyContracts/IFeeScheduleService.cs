using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Core.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QIQO.Business.Accounts.Proxies
{
    public interface IFeeScheduleService : IServiceContract
    {
        List<FeeSchedule> GetFeeSchedulesByAccount(Account account);
        List<FeeSchedule> GetFeeSchedulesByCompany(Company company);
        //List<FeeSchedule> GetFeeSchedulesByProduct(Product product);
        int CreateFeeSchedule(FeeSchedule fee_schedule);
        bool DeleteFeeSchedule(FeeSchedule fee_schedule);        
        FeeSchedule GetFeeSchedule(int fee_schedule);

        Task<List<FeeSchedule>> GetFeeSchedulesByAccountAsync(Account account);
        Task<List<FeeSchedule>> GetFeeSchedulesByCompanyAsync(Company company);
        //Task<List<FeeSchedule>> GetFeeSchedulesByProductAsync(Product product);
        Task<int> CreateFeeScheduleAsync(FeeSchedule fee_schedule);
        Task<bool> DeleteFeeScheduleAsync(FeeSchedule fee_schedule);
        Task<FeeSchedule> GetFeeScheduleAsync(int fee_schedule);
    }

}
