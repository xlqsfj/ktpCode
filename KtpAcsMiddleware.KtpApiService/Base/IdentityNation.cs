using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.Base
{
    public enum IdentityNation
    {
        /// <summary>
        ///     未知
        /// </summary>
        [Description("未知")] Wu,

        /// <summary>
        ///     汉族
        /// </summary>
        [Description("汉族")] Han,

        /// <summary>
        ///     蒙古族
        /// </summary>
        [Description("蒙古族")] Mongol,

        /// <summary>
        ///     回族
        /// </summary>
        [Description("回族 ")] Hui,

        /// <summary>
        ///     藏族
        /// </summary>
        [Description("藏族")] Tibetan,

        /// <summary>
        ///     维吾尔族
        /// </summary>
        [Description("维吾尔族")] Uighur,

        /// <summary>
        ///     苗族
        /// </summary>
        [Description("苗族")] Miao,

        /// <summary>
        ///     彝族
        /// </summary>
        [Description("彝族")] Yi,

        /// <summary>
        ///     壮族
        /// </summary>
        [Description("壮族")] Zhuang,

        /// <summary>
        ///     布依族
        /// </summary>
        [Description("布依族")] Buyi,

        /// <summary>
        ///     朝鲜族
        /// </summary>
        [Description("朝鲜族")] Korean,

        /// <summary>
        ///     满族
        /// </summary>
        [Description("满族")] Manchu,

        /// <summary>
        ///     侗族
        /// </summary>
        [Description("侗族")] Dong,

        /// <summary>
        ///     瑶族
        /// </summary>
        [Description("瑶族")] Yao,

        /// <summary>
        ///     白族
        /// </summary>
        [Description("白族")] Bai,

        /// <summary>
        ///     土家族
        /// </summary>
        [Description("土家族")] Tujia,

        /// <summary>
        ///     哈尼族
        /// </summary>
        [Description("哈尼族")] Hani,

        /// <summary>
        ///     哈萨克族
        /// </summary>
        [Description("哈萨克族")] Kazakh,

        /// <summary>
        ///     傣族
        /// </summary>
        [Description("傣族")] Dai,

        /// <summary>
        ///     黎族
        /// </summary>
        [Description("黎族")] Li,

        /// <summary>
        ///     僳僳族
        /// </summary>
        [Description("僳僳族")] Lisu,

        /// <summary>
        ///     佤族
        /// </summary>
        [Description("佤族")] Wa,

        /// <summary>
        ///     畲族
        /// </summary>
        [Description("畲族")] She,

        /// <summary>
        ///     高山族
        /// </summary>
        [Description("高山族")] Gaoshan,

        /// <summary>
        ///     拉祜族
        /// </summary>
        [Description("拉祜族")] Lahu,

        /// <summary>
        ///     水族
        /// </summary>
        [Description("水族")] Shui,

        /// <summary>
        ///     东乡族
        /// </summary>
        [Description("东乡族")] Dongxiang,

        /// <summary>
        ///     纳西族
        /// </summary>
        [Description("纳西族")] Naxi,

        /// <summary>
        ///     景颇族
        /// </summary>
        [Description("景颇族")] Jingpo,

        /// <summary>
        ///     柯尔克孜族
        /// </summary>
        [Description("柯尔克孜族")] Kirghiz,

        /// <summary>
        ///     土族
        /// </summary>
        [Description("土族")] Du,

        /// <summary>
        ///     达斡尔族
        /// </summary>
        [Description("达斡尔族")] Daur,

        /// <summary>
        ///     仫佬族
        /// </summary>
        [Description("仫佬族")] Mulam,

        /// <summary>
        ///     羌族
        /// </summary>
        [Description("羌族")] Qiang,

        /// <summary>
        ///     布朗族
        /// </summary>
        [Description("布朗族")] Blang,

        /// <summary>
        ///     撒拉族
        /// </summary>
        [Description("撒拉族")] Salar,

        /// <summary>
        ///     毛南族
        /// </summary>
        [Description("毛南族")] Maonan,

        /// <summary>
        ///     仡佬族
        /// </summary>
        [Description("仡佬族")] Gelao,

        /// <summary>
        ///     锡伯族
        /// </summary>
        [Description("锡伯族")] Xibe,

        /// <summary>
        ///     阿昌族
        /// </summary>
        [Description("阿昌族")] Achang,

        /// <summary>
        ///     普米族
        /// </summary>
        [Description("普米族")] Pumi,

        /// <summary>
        ///     塔吉克族
        /// </summary>
        [Description("塔吉克族")] Tajik,

        /// <summary>
        ///     怒族
        /// </summary>
        [Description("怒族")] Nu,

        /// <summary>
        ///     乌孜别克族
        /// </summary>
        [Description("乌孜别克族")] Uzbek,

        /// <summary>
        ///     俄罗斯族
        /// </summary>
        [Description("俄罗斯族")] Russian,

        /// <summary>
        ///     鄂温克族
        /// </summary>
        [Description("鄂温克族")] Evenki,

        /// <summary>
        ///     德昂族(崩龙族)
        /// </summary>
        [Description("德昂族(崩龙族)")] Deang,

        /// <summary>
        ///     保安族
        /// </summary>
        [Description("保安族")] Bonan,

        /// <summary>
        ///     保安族
        /// </summary>
        [Description("裕固族")] Yugur,

        /// <summary>
        ///     京族
        /// </summary>
        [Description("京族")] Gin,

        /// <summary>
        ///     塔塔尔族
        /// </summary>
        [Description("塔塔尔族")] Tatar,

        /// <summary>
        ///     独龙族
        /// </summary>
        [Description("独龙族")] Drung,

        /// <summary>
        ///     鄂伦春族
        /// </summary>
        [Description("鄂伦春族")] Oroqin,

        /// <summary>
        ///     赫哲族
        /// </summary>
        [Description("赫哲族")] Hezhen,

        /// <summary>
        ///     门巴族
        /// </summary>
        [Description("门巴族")] Menba,

        /// <summary>
        ///     珞巴族
        /// </summary>
        [Description("珞巴族")] Lhoba,

        /// <summary>
        ///     基诺族
        /// </summary>
        [Description("基诺族")] Jino,
        /// <summary>
        ///穿青人
        /// </summary>
        [Description("穿青人")] Chuanqingren,
        /// <summary>
        ///革家人
        /// </summary>
        [Description("革家人 ")] Jinogejiaren,

        //Han (汉族) //Zhuang (壮族) //Manchu (满族) //Hui (回族) //Miao (苗族) (Hmong) //Uighur (维吾尔族) //Yi (彝族) //Tujia (土家族) 
        //Mongol (蒙古族) //Tibetan (藏族) //Buyi (布依族) //Dong (侗族) //Yao (瑶族) //Korean (朝鲜族) //Bai (白族) //Hani (哈尼族) 
        //Li (黎族) //Kazakh (哈萨克族) //Dai (傣族, also called Dai Lue, one of the Thai ethnic groups) //She (畲族) //Lisu (僳僳族) 
        //Gelao (仡佬族) //Lahu (拉祜族) //Dongxiang (东乡族) //Wa (佤族) (Va) //Shui (水族) //Naxi (纳西族) (includes the Mosuo (摩梭)) 
        //Qiang (羌族) //Du (土族) //Xibe (锡伯族) //Mulam (仫佬族) //Kirghiz (柯尔克孜族) //Daur (达斡尔族) //Jingpo (景颇族) //Salar (撒拉族) 
        //Blang (布朗族 Bulang) //Maonan (毛南族) //Tajik (塔吉克族) //Pumi (普米族) //Achang (阿昌族) //Nu (怒族) //Evenki (鄂温克族) 
        //Gin (京族 Jing1) //Jino (基诺族) //De'ang (德昂族) //Uzbek (乌孜别克族) //Russian (俄罗斯族) //Yugur (裕固族) //Bonan (保安族) 
        //Menba (门巴族) //Oroqin (鄂伦春族) //Drung (独龙族) //Tatar (塔塔尔族) //Hezhen (赫哲族) //Lhoba (珞巴族) //Gaoshan (高山族) (Taiwanese aborigine)
    }
}

