using System;
using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Base;
using KtpAcsMiddleware.Domain.Data;
using KtpAcsMiddleware.Infrastructure.Exceptions;
using KtpAcsMiddleware.Infrastructure.Utilities;

namespace KtpAcsMiddleware.AppService.FileMaps
{
    internal class FileMapService : IFileMapService
    {
        private readonly IFileMapRepository _repository;

        public FileMapService(IFileMapRepository repository)
        {
            _repository = repository;
        }

        public FileMap Get(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(id)));
            }
            return _repository.Find(id);
        }

        public IList<FileMap> Get(string[] ids)
        {
            if (ids == null || ids.Length == 0)
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(ids)));
            }
            return _repository.Find(ids).ToList();
        }

        public FileMap Add(FileMap fileMap)
        {
            if (string.IsNullOrEmpty(fileMap.FileName))
            {
                throw new ArgumentNullException(ExMessage.MustNotBeNullOrEmpty(nameof(fileMap.FileName)));
            }
            if (fileMap.Length <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    ExMessage.MustBeGreaterThanZero(nameof(fileMap.Length), fileMap.Length));
            }
            fileMap.Id = ConfigHelper.NewGuid;
            _repository.Add(fileMap);
            return fileMap;
        }
    }
}