using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.FaceRecognition;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Models.JsonJqGrids;

namespace KtpAcsMiddleware.Models
{
    internal class FaceRecognitionDeviceWorkerJsonService
    {
        public string GetJqGridJson(PagedResult<FaceDeviceWorkerPagedDto> pagedResult, int pageIndex, int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    GetSelectItem(item.WorkerId, item.WorkerName),
                    item.IdentityCode,
                    item.Mobile,
                    item.SexText,
                    item.NationText,
                    item.AddressNow,
                    GetStatusText(item),
                    item.ErrorCodeText
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        public string GetJqGridJson(PagedResult<FaceDeviceWorkerDeletedPagedDto> pagedResult, int pageIndex,
            int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    GetSelectItem(item.WorkerId, item.WorkerName),
                    item.IdentityCode,
                    item.Mobile,
                    item.SexText,
                    item.NationText,
                    item.AddressNow,
                    GetStatusText(item)
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        private string GetSelectItem(string workerId, string workerName)
        {
            var selectItem = "<a name='selectItem' wokerId='{wokerId}' style='cursor: pointer'>{itemName}</a>";
            return selectItem.Replace("{wokerId}", workerId).Replace("{itemName}", workerName);
        }

        private string GetStatusText(FaceDeviceWorkerPagedDto item)
        {
            if (string.IsNullOrEmpty(item.FacePicId))
            {
                return $"{((FaceWorkerState) item.Status).ToEnumText()}<span style='color: red'>(待认证)</span>";
            }
            var selectText = item.StatusText;
            var state = (FaceWorkerState) item.Status;
            if (!string.IsNullOrEmpty(item.FacePicId))
            {
                if (state == FaceWorkerState.PrepareAdd
                    || state == FaceWorkerState.FailAdd
                    || state == FaceWorkerState.RepeatAdd)
                {
                    selectText = selectText +
                                 " | <a name='initNewStatusBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>设为新添加</a>";
                }
                else if (state == FaceWorkerState.PrepareDel || state == FaceWorkerState.FailDel)
                {
                    selectText = selectText +
                                 " | <a name='initNewDelStatusBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>设为新删除</a>";
                }
            }
            return selectText.Replace("{itemId}", item.Id).Replace("{itemName}", item.WorkerName);
        }

        private string GetStatusText(FaceDeviceWorkerDeletedPagedDto item)
        {
            var selectText = item.StatusText;
            var state = (FaceWorkerState) item.Status;
            if (state != FaceWorkerState.HasDel && state != FaceWorkerState.NewDel)
            {
                selectText = selectText +
                             " | <a name='initNewDelStatusBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>设为新删除</a>";
            }
            return selectText.Replace("{itemId}", item.Id).Replace("{itemName}", item.WorkerName);
        }
    }
}