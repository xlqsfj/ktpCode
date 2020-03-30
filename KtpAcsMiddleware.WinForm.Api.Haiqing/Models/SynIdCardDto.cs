using System.Runtime.InteropServices;

namespace KtpAcsMiddleware.WinForm.Api.Models
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SynIdCardDto
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string Name; //姓名   
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)] public string Sex; //性别
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)] public string Nation; //名族
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string Born; //出生日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 72)] public string Address; //住址
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)] public string IDCardNo; //身份证号
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)] public string GrantDept; //发证机关
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string UserLifeBegin; // 有效开始日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 18)] public string UserLifeEnd; // 有效截止日期
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 38)] public string reserved; // 保留
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 255)] public string PhotoFileName; // 照片路径
    }
}