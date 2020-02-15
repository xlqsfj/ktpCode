using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.Domain.Data;

namespace KtpAcsMiddleware.Domain.Base
{
    public class FileMapEntityService
    {
        public static string GetFileBase64String(IList<FileMap> fileMaps, string id)
        {
            var map = GetFile(fileMaps, id);
            if (map == null)
            {
                return string.Empty;
            }
            return GetFileSrc(map);
        }

        public static string GetFileSrc(IList<FileMap> fileMaps, string id)
        {
            var map = GetFile(fileMaps, id);
            if (map == null)
            {
                return string.Empty;
            }
            return GetFileSrc(map);
        }

        public static string GetFileSrc(FileMap map)
        {
            if (string.IsNullOrEmpty(map.PhysicalFileName))
            {
                return string.Empty;
            }
            return $"../../_Files/{map.PhysicalFileName}";
        }

        private static FileMap GetFile(IList<FileMap> fileMaps, string id)
        {
            if (fileMaps == null || fileMaps.Count == 0)
            {
                return null;
            }
            if (id == null)
            {
                return null;
            }
            if (id == string.Empty)
            {
                return null;
            }
            return fileMaps.FirstOrDefault(i => i.Id == id);
        }
    }
}