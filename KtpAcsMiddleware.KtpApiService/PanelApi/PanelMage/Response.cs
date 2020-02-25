using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsMiddleware.KtpApiService.PanelApi.PanelMage
{
    public class Response : Ipanel
    {
        /// <summary>
        /// 请求的URL
        /// </summary>
        public string ResponseURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreatedID { get; set; }
        /// <summary>
        /// 公共错误编号
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// 公共错误提示
        /// 0: 成功 Succeed
        ///1: 通用错误 Common Error
        ///2: 参数非法 Invalid Arguments
        ///3: 用户无权限 Not Authorized
        ///4: 设备不支持 Not Supported
        ///5： 用户状态异常
        /// </summary>
        public string ResponseString { get; set; }
        /// <summary>
        /// 宇视自己定义的错误编号
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        ///  宇视自己定义的错误
        /// </summary>
        public string StatusString { get; set; }
        /// <summary>
        /// 返回结果数据
        /// </summary>
        public Data Data { get; set; }
        string Ipanel.Data { get; set; }
    }

    public class ResponseDelete
    {
        /// <summary>
        /// 请求的URL
        /// </summary>
        public string ResponseURL { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CreatedID { get; set; }
        /// <summary>
        /// 公共错误编号
        /// </summary>
        public int ResponseCode { get; set; }
        /// <summary>
        /// 公共错误提示
        /// 0: 成功 Succeed
        ///1: 通用错误 Common Error
        ///2: 参数非法 Invalid Arguments
        ///3: 用户无权限 Not Authorized
        ///4: 设备不支持 Not Supported
        ///5： 用户状态异常
        /// </summary>
        public string ResponseString { get; set; }


        /// <summary>
        /// 宇视自己定义的错误编号
        /// </summary>
        public int StatusCode
        {
            get; set;
        }
        /// <summary>
        ///  宇视自己定义的错误
        /// </summary>
        public string StatusString { get; set; }
        /// <summary>
        /// 返回结果数据
        /// </summary>
        public string Data { get; set; }

    }

    public interface Ipanel
    {

        string Data { get; set; }
    }
    public class Data
    {
        /// <summary>
        /// 人员个数/设备中已创建的库数量范围：[0, 16]
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 插入成功返回的id
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 设备型号
        /// </summary>
        public string DeviceModel { get; set; }
        /// <summary>
        /// 序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 软件版本
        /// </summary>
        public string FirmwareVersion { get; set; }
        /// <summary>
        /// 查询库列表信息
        /// </summary>
        public Liblist[] LibList { get; set; }
        /// <summary>
        /// 人脸信息结果列表
        /// </summary>
        public List<Personlist> PersonList { get; set; }
    }

    public class Liblist
    {
        /// <summary>
        /// 库 ID，
        ///   Post 方法不用带，
        ///Get/Put 方法必带。
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// 人员库类型
        /// 0: 默认无效值;
        ///1：黑名单
        ///2:  灰名单/陌生人
        ///3：员工	4: 访客Put 方法不用带Get/Post 方法必带
        /// </summary>
        public int Type { get; set; }
        /// <summary>
        /// 库中人脸照片总数，即有多少张人脸照片/特征;
        /// Get 方法时必带。库 名 称 
        /// </summary>
        public int FaceNum { get; set; }
        /// <summary>
        /// 库中人员成员的总数,即有多少个不同的 FaceID
        /// 注：如果一个人有多个底图， 此处为底图个数的总和。无底图人员，占用一个成员名额。
        ///Get 方法时必带。
        /// </summary>
        public int MemberNum { get; set; }
        /// <summary>
        /// 库信息的最后修改时间(Unix 时间戳)
        /// </summary>
        public int LastChange { get; set; }
        /// <summary>
        /// 库 名 称 
        /// </summary>
        public string Name { get; set; }
    }
    public class Personlist
    {
        /// <summary>
        /// 人员 ID
        /// </summary>
        public int PersonID { get; set; }
        /// <summary>
        /// 人脸个数
        /// </summary>
        public int FaceNum { get; set; }
        /// <summary>
        /// 人脸信息结果列表
        /// </summary>
        public Facelist[] FaceList { get; set; }
    }
    /// <summary>
    /// 人脸信息结果列表
    /// </summary>
    public class Facelist
    {
        /// <summary>
        /// 人脸 ID
        ///FaceNum 为0时，此字段可选。
        /// </summary>
        public int FaceID { get; set; }
        /// <summary>
        /// 处理结果状态码
        ////0：成功;
        ////1：通用执行失败;
        ////2：初始化检测失败;
        ////3：人脸检测失败;
        ////4：图片未检测到人脸;
        /// 5：jpeg 照片解码失败;
        ////6：人脸图片质量分数不满足;
        ////7：图片缩放失败;
        ////8：未启用智能;
        ////9：图片不存在或过大/过小; FaceNum 为0时，此字段可选
        /// </summary>
        /// 
        private string _ResultCode;
        public string ResultCode
        {
            get { return _ResultCode; }

            set
            {
                switch (value)
                {
                    case "1":
                        _ResultCode = "通用执行失败";
                        break;

                    case "2":
                        _ResultCode = "初始化检测失败";
                        break;
                    case "3":
                        _ResultCode = "人脸检测失败";
                        break;
                    case "4":
                        _ResultCode = "图片未检测到人脸,请重新拍照";
                        break;
                    case "5":
                        _ResultCode = "jpeg 照片解码失败";
                        break;
                    case "6":
                        _ResultCode = "人脸图片质量分数不满足";
                        break;
                    case "7":
                        _ResultCode = "图片缩放失败";
                        break;
                    case "8":
                        _ResultCode = "未启用智能";
                        break;
                    case "9":
                        _ResultCode = "图片不存在或过大/过小; FaceNum 为0时，此字段可选";
                        break;
                    case "10":
                        _ResultCode = "未创建库";
                        break;
                    default: _ResultCode = "0"; break;
                }
            }
        }
    }
}
