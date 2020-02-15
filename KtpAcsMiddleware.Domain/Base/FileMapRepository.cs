using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Search;
using KtpAcsMiddleware.Infrastructure.Search.Extensions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.Domain.Base
{
    internal class FileMapRepository : AbstractRepository, IFileMapRepository
    {
        public FileMap Find(string id)
        {
            return DataContext.FileMaps.First(t => t.Id == id);
        }

        public FileMap FirstOrDefault(string id)
        {
            return DataContext.FileMaps.FirstOrDefault(t => t.Id == id);
        }

        public FileMap FindByUrl(string qiniuUrl)
        {
            return DataContext.FileMaps.FirstOrDefault(t => t.QiniuUrl == qiniuUrl);
        }

        public IList<FileMap> FindWorkerNewPics()
        {
            using (var dataContext = DataContext)
            {
                return dataContext.FileMaps.Where(
                    t => (dataContext.Workers.Any(i => i.FacePicId == t.Id) ||
                          dataContext.WorkerIdentities.Any(i => i.PicId == t.Id) ||
                          dataContext.WorkerIdentities.Any(i => i.BackPicId == t.Id)) &&
                         (t.QiniuUrl == null || t.QiniuUrl == string.Empty
                          || t.QiniuKey == null || t.QiniuKey == string.Empty)).ToList();
            }
        }

        public IEnumerable<FileMap> Find(SearchCriteria<FileMap> searchCriteria)
        {
            return DataContext.FileMaps.SearchBy(searchCriteria);
        }

        public IEnumerable<FileMap> Find(string[] ids)
        {
            ids = ids.Where(i => i != null && i != string.Empty).ToArray();
            return DataContext.FileMaps.Where(t => ids.Contains(t.Id));
        }

        public string Add(FileMap fileMap)
        {
            if (string.IsNullOrEmpty(fileMap.Id))
            {
                fileMap.Id = ConfigHelper.NewGuid;
            }
            if (string.IsNullOrEmpty(fileMap.Code))
            {
                fileMap.Code = fileMap.Id;
            }
            if (string.IsNullOrEmpty(fileMap.PhysicalFileName))
            {
                fileMap.PhysicalFileName = fileMap.FileName;
            }
            if (string.IsNullOrEmpty(fileMap.PhysicalFullName))
            {
                fileMap.PhysicalFullName = $"{ConfigHelper.CustomFilesDir}{fileMap.PhysicalFileName}";
            }
            fileMap.FileExtensionName =
                fileMap.FileName.Substring(fileMap.FileName.LastIndexOf(".", StringComparison.Ordinal));
            var now = DateTime.Now;
            fileMap.CreateTime = now;
            fileMap.ModifiedTime = now;
            using (var dataContext = DataContext)
            {
                dataContext.FileMaps.InsertOnSubmit(fileMap);
                dataContext.SubmitChanges();
                return fileMap.Id;
            }
        }

        public void ModifyQiniu(string id, string key, string url)
        {
            using (var dataContext = DataContext)
            {
                var map = dataContext.FileMaps.First(t => t.Id == id);
                map.QiniuKey = key;
                map.QiniuUrl = url;
                dataContext.SubmitChanges();
            }
        }
    }
}