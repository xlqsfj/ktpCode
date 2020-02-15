using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;

namespace KtpAcsMiddleware.Domain.Base
{
    public interface IFileMapRepository
    {
        FileMap Find(string id);
        FileMap FirstOrDefault(string id);
        FileMap FindByUrl(string qiniuUrl);
        IList<FileMap> FindWorkerNewPics();
        IEnumerable<FileMap> Find(SearchCriteria<FileMap> searchCriteria);
        IEnumerable<FileMap> Find(string[] ids);
        string Add(FileMap fileMap);
        void ModifyQiniu(string id, string key, string url);
    }
}