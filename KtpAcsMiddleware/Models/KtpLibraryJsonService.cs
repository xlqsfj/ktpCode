using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.KtpLibrary;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Infrastructure.Utilities;
using KtpAcsMiddleware.Models.JsonJqGrids;

namespace KtpAcsMiddleware.Models
{
    public class KtpLibraryJsonService
    {
        public string GetTeamSyncJqGridJson(PagedResult<TeamSyncPagedDto> pagedResult, int pageIndex, int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    item.TeamName,
                    item.WorkTypeName,
                    item.TypeText,
                    GetTeamSyncStateText(item),
                    FormatHelper.GetIntString(item.FeedbackCode),
                    item.Feedback,
                    FormatHelper.GetIsoDateString(item.TeamModifiedTime)
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        public string GetWorkerSyncJqGridJson(PagedResult<WorkerSyncPagedDto> pagedResult, int pageIndex, int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    GetSelectItem(item.Id, item.WorkerName),
                    item.IdentityCode,
                    item.TypeText,
                    GetWorkerSyncStateText(item),
                    FormatHelper.GetIntString(item.FeedbackCode),
                    item.Feedback,
                    item.Mobile
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        public string GetAuthenticationSyncJqGridJson(
            PagedResult<AuthenticationSyncPagedDto> pagedResult, int pageIndex, int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    GetSelectItem(item.Id, item.WorkerName),
                    item.IdentityCode,
                    item.ClockTypeText,
                    item.ClockTimeText,
                    item.ClockStateText,
                    GetAuthSyncStateText(item),
                    FormatHelper.GetIntString(item.FeedbackCode),
                    item.Feedback
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        private string GetSelectItem(string itemId, string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                return "未知";
            }
            if (string.IsNullOrEmpty(itemId))
            {
                return itemName;
            }
            const string selectItem =
                "<a name='selectItem' itemId='{itemId}' style='cursor: pointer'>{itemName}</a>";
            return selectItem.Replace("{itemId}", itemId).Replace("{itemName}", itemName);
        }

        private string GetWorkerSyncStateText(WorkerSyncPagedDto item)
        {
            if (item.Status == (int) KtpSyncState.Fail)
            {
                var typeText = item.TypeText.Replace("推送", string.Empty);
                return
                    $"{item.StateText}&nbsp;|&nbsp;<a name='resetSyncStateBtn' itemId='{item.Id}' itemName='{item.WorkerName}' typeText='{typeText}' style='cursor: pointer'>复位</a>";
            }
            if ((KtpSyncState) item.Status == KtpSyncState.NewAdd && !item.IsAuthentication)
            {
                return item.StateText.Replace("(待认证)", "<span style='color: red'>(待认证)</span>");
            }
            return item.StateText;
        }

        private string GetTeamSyncStateText(TeamSyncPagedDto item)
        {
            if (item.Status == (int) KtpSyncState.Fail)
            {
                var typeText = item.TypeText.Replace("推送", string.Empty);
                return
                    $"{item.StateText}&nbsp;|&nbsp;<a name='resetSyncStateBtn' itemId='{item.Id}' itemName='{item.TeamName}' typeText='{typeText}' style='cursor: pointer'>复位</a>";
            }
            return item.StateText;
        }

        private string GetAuthSyncStateText(AuthenticationSyncPagedDto item)
        {
            if (item.State == (int) KtpSyncState.Fail)
            {
                var text = $"{((KtpSyncState) item.State).ToEnumText()}&nbsp;|&nbsp;";
                text =
                    $"{text}<a name='resetSyncStateBtn' itemId='{item.Id}' itemName='{item.WorkerName}' typeText='推送' style='cursor: pointer'>复位</a>";
                return text;
            }
            return item.StateText;
        }
    }
}