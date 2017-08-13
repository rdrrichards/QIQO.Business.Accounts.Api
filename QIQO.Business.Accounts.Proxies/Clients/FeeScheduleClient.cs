using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using QIQO.Business.Accounts.Proxies.Models;
using QIQO.Business.Accounts.Data.Interfaces;
using QIQO.Business.Accounts.Proxies.Services;

namespace QIQO.Business.Accounts.Proxies.Clients
{
    public class FeeScheduleClient : ClientBase, IFeeScheduleService
    {
        private readonly IFeeScheduleRepository _feeScheduleRepository;
        private readonly IFeeScheduleEntityService _feeScheduleEntityService;
        private readonly IAccountEntityService _accountEntityService;
        private readonly ICompanyEntityService _companyEntityService;

        public FeeScheduleClient(IFeeScheduleRepository feeScheduleRepository, IFeeScheduleEntityService feeScheduleEntityService,
            IAccountEntityService accountEntityService, ICompanyEntityService companyEntityService)
        {
            _feeScheduleRepository = feeScheduleRepository;
            _feeScheduleEntityService = feeScheduleEntityService;
            _accountEntityService = accountEntityService;
            _companyEntityService = companyEntityService;
        }
        public int SaveFeeSchedule(FeeSchedule fee_schedule)
        {
            return ExecuteHandledOperation(() => { return _feeScheduleRepository.Save(_feeScheduleEntityService.Map(fee_schedule)); });
        }

        public Task<int> SaveFeeScheduleAsync(FeeSchedule fee_schedule)
        {
            return Task.Run(() => SaveFeeSchedule(fee_schedule));
        }

        public bool DeleteFeeSchedule(FeeSchedule fee_schedule)
        {
            return ExecuteHandledOperation(() =>
            {
                _feeScheduleRepository.Delete(_feeScheduleEntityService.Map(fee_schedule));
                return true;
            });
        }

        public Task<bool> DeleteFeeScheduleAsync(FeeSchedule fee_schedule)
        {
            return Task.Run(() => DeleteFeeSchedule(fee_schedule));
        }

        public FeeSchedule GetFeeSchedule(int fee_schedule)
        {
            return ExecuteHandledOperation(() => { return _feeScheduleEntityService.Map(_feeScheduleRepository.GetByID(fee_schedule)); });
        }

        public Task<FeeSchedule> GetFeeScheduleAsync(int fee_schedule)
        {
            return Task.Run(() => GetFeeSchedule(fee_schedule));
        }

        public List<FeeSchedule> GetFeeSchedulesByAccount(Account account)
        {
            return ExecuteHandledOperation(() => { return _feeScheduleEntityService.Map(_feeScheduleRepository.GetAll(_accountEntityService.Map(account))); });
        }

        public Task<List<FeeSchedule>> GetFeeSchedulesByAccountAsync(Account account)
        {
            return Task.Run(() => GetFeeSchedulesByAccount(account));
        }

        public List<FeeSchedule> GetFeeSchedulesByCompany(Company company)
        {
            return ExecuteHandledOperation(() => { return _feeScheduleEntityService.Map(_feeScheduleRepository.GetAll(_companyEntityService.Map(company))); });
        }

        public Task<List<FeeSchedule>> GetFeeSchedulesByCompanyAsync(Company company)
        {
            return Task.Run(() => GetFeeSchedulesByCompany(company));
        }
    }
}
