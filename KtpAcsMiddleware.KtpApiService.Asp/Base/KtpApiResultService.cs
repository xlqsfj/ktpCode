namespace KtpAcsMiddleware.KtpApiService.Asp.Base
{
    internal class KtpApiResultService
    {
        public static bool IsSuccess(KtpApiResultBase ktpApiResult)
        {
            if (ktpApiResult.Status == null)
            {
                return false;
            }
            if (ktpApiResult.Status.Code != 10)
            {
                return false;
            }
            if (ktpApiResult.BusStatus == null)
            {
                return false;
            }
            if (ktpApiResult.BusStatus.Code != 100)
            {
                return false;
            }
            return true;
        }
    }
}