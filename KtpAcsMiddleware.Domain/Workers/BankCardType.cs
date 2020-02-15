using System.ComponentModel;

namespace KtpAcsMiddleware.Domain.Workers
{
    public enum BankCardType
    {
        [Description("工商银行")] Gongshang = 1,
        [Description("农业银行")] Nongye = 2,
        [Description("中国银行")] Zhongguo = 3,
        [Description("建设银行")] Jianshe = 4,
        [Description("交通银行")] Jiaotong = 5,
        [Description("中信银行")] Zhongxin = 6,
        [Description("光大银行")] Guangda = 7,
        [Description("华夏银行")] Huaxia = 8,
        [Description("民生银行")] Minsheng = 9,
        [Description("广发银行")] Guangfa = 10,
        [Description("平安银行")] Pingan = 11,
        [Description("招商银行")] Zhaoshang = 12,
        [Description("兴业银行")] Xingye = 13,
        [Description("浦发银行")] Pufa = 14,
        [Description("邮政储蓄银行")] Youchu = 15,
        [Description("恒丰银行")] Hengfeng = 16,
        [Description("齐鲁银行")] Jilu = 17,
        [Description("浙商银行")] Zheshang = 18,
        [Description("渤海银行")] Bohai = 19
    }
}