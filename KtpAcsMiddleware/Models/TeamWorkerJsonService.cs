using System.Collections.Generic;
using System.Linq;
using KtpAcsMiddleware.AppService.Dto;
using KtpAcsMiddleware.Domain.Workers;
using KtpAcsMiddleware.Infrastructure.Search.Paging;
using KtpAcsMiddleware.Infrastructure.Serialization;
using KtpAcsMiddleware.Models.JsonJqGrids;

namespace KtpAcsMiddleware.Models
{
    internal class TeamWorkerJsonService
    {
        public string GetJqGridJson(PagedResult<TeamWorkerPagedDto> pagedResult, int pageIndex, int pageSize)
        {
            IList<JqGridRowObject> rows =
                pagedResult.Entities.Select(item => new JqGridRowObject(item.Id, new[]
                {
                    GetSelectItem(item.Id, item.WorkerName),
                    item.IdentityCode,
                    item.Mobile,
                    item.SexText,
                    item.Nation,
                    item.AddressNow,
                    GetAuthenticationStateText(item),
                    GetSelectBtn(item)
                })).ToList();
            var jsonJqGridObject = new JqGridObject(rows, pagedResult.Count, pageIndex, pageSize);
            return jsonJqGridObject.ToJson(true);
        }

        private string GetAuthenticationStateText(TeamWorkerPagedDto item)
        {
            if (item.AuthenticationState == WorkerAuthenticationState.WaitFor)
            {
                return $"<span style='color: red'>{item.AuthenticationStateText}</span>";
            }
            return item.AuthenticationStateText;
        }

        private string GetSelectItem(string itemId, string itemName)
        {
            const string selectItem =
                "<a name='selectItem' itemId='{itemId}' style='cursor: pointer'>{itemName}</a>";
            return selectItem.Replace("{itemId}", itemId).Replace("{itemName}", itemName);
        }

        private string GetSelectBtn(TeamWorkerPagedDto item)
        {
            var selectItem =
                "<a name='selectBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>编辑</a>" +
                "&nbsp;|&nbsp;<a name='delBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>删除</a>";
            if (item.AuthenticationState == WorkerAuthenticationState.WaitFor)
            {
                selectItem = selectItem +
                             "&nbsp;|&nbsp;<a name='identityAuthenticationBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>认证</a>";
            }
            else
            {
                selectItem = selectItem +
                             "&nbsp;|&nbsp;<a name='identityAuthenticationBtn' itemId='{itemId}' itemName='{itemName}' style='cursor: pointer'>更新认证</a>";
            }
            return selectItem.Replace("{itemId}", item.Id).Replace("{itemName}", item.WorkerName);
        }
    }
}