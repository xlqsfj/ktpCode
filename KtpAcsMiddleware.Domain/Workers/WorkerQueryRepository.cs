using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Domain.Dto;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Search.Paging;

namespace KtpAcsMiddleware.Domain.Workers
{
    internal class WorkerQueryRepository : AbstractRepository, IWorkerQueryRepository
    {
        public Worker First(string id)
        {
            return FactoryContext.Workers.First(t => t.Id == id);
        }

        public Worker Find(string id)
        {
            return DataContext.Workers.First(t => t.Id == id);
        }

        public IList<WorkerDto> FindAll(bool isContainDel = false)
        {
            if (isContainDel)
            {
                return DataContext.Workers.Select(t => MapDto(t)).ToList();
            }
            return DataContext.Workers.Where(t => t.IsDelete == false).Select(t => MapDto(t)).ToList();
        }

        public IList<WorkerDto> Find(SearchCriteria<Worker> searchCriteria, bool isContainDel = false)
        {
            if (!isContainDel)
            {
                searchCriteria.AddFilterCriteria(t => t.IsDelete == false);
            }
            return DataContext.Workers.SearchBy(searchCriteria).Select(t => MapDto(t)).ToList();
        }

        public bool FindAnyIdentityCode(string identityCode, string excludedId)
        {
            using (var dataContext = DataContext)
            {
                if (string.IsNullOrEmpty(excludedId))
                {
                    return dataContext.Workers.Any(t => t.WorkerIdentity.Code == identityCode && t.IsDelete == false);
                }
                return dataContext.Workers.Any(
                    t => t.WorkerIdentity.Code == identityCode && t.Id != excludedId && t.IsDelete == false);
            }
        }

        public bool FindAnyMobile(string mobile, string excludedId)
        {
            using (var dataContext = DataContext)
            {
                if (string.IsNullOrEmpty(excludedId))
                {
                    return dataContext.Workers.Any(t => t.Mobile == mobile && t.IsDelete == false);
                }
                return dataContext.Workers.Any(
                    t => t.Mobile == mobile && t.Id != excludedId && t.IsDelete == false);
            }
        }

        public PagedResult<Worker> FindPaged(SearchCriteria<Worker> searchCriteria)
        {
            searchCriteria.AddFilterCriteria(t => t.IsDelete == false);
            //var count = DataContext.Workers.FilterBy(searchCriteria.FilterCriterias).Count();
            //var entities = DataContext.Workers.SearchBy(searchCriteria);
            //return new PagedResult<Worker>(count, entities);
            var count = DataContext.Workers.FilterBy(searchCriteria.FilterCriterias).Count();
            var entities = DataContext.Workers.SearchBy(searchCriteria);
            return new PagedResult<Worker>(count, entities);
        }

        private WorkerDto MapDto(Worker t)
        {
            return Mapper.Map<WorkerDto>(t);
        }
    }
}