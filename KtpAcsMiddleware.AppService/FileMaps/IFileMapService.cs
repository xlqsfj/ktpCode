using System.Collections.Generic;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.AppService.FileMaps
{
    public interface IFileMapService
    {
        FileMap Get(string id);
        IList<FileMap> Get(string[] ids);
        FileMap Add(FileMap fileMap);
    }
}