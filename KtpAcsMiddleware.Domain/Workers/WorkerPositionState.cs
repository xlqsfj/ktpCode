using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.Workers
{
    /// <summary>
    ///     工人职位状态Worker.Status
    ///     暂时没有“离场”的需求，开太平接口的离场状态直接对应到本地的删除
    /// </summary>
    public enum WorkerPositionState
    {
        [Description("在场")] Zaichang = 1,
        [Description("离场")] Lichang = 2
    }
}