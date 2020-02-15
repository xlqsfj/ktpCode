using System;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Base
{
    public class FileMapDataService
    {
        public static FileMap Get(string id)
        {
            using (var dataContext = UnitOfWork.DataContext)
            {
                return dataContext.FileMaps.First(t => t.Id == id);
            }
        }

        public static FileMap Add(FileMap fileMap)
        {
            if (string.IsNullOrEmpty(fileMap.Id))
            {
                fileMap.Id = ConfigHelper.NewGuid;
            }
            if (string.IsNullOrEmpty(fileMap.Code))
            {
                fileMap.Code = fileMap.Id;
            }
            fileMap.FileExtensionName =
                fileMap.FileName.Substring(fileMap.FileName.LastIndexOf(".", StringComparison.Ordinal));
            if (string.IsNullOrEmpty(fileMap.PhysicalFileName))
            {
                fileMap.PhysicalFileName = fileMap.FileName;
            }
            fileMap.PhysicalFullName = $"{ConfigHelper.CustomFilesDir}{fileMap.PhysicalFileName}";
            var now = DateTime.Now;
            fileMap.CreateTime = now;
            fileMap.ModifiedTime = now;
            using (var dataContext = UnitOfWork.DataContext)
            {
                dataContext.FileMaps.InsertOnSubmit(fileMap);
                dataContext.SubmitChanges();
                return fileMap;
            }
        }
    }
}