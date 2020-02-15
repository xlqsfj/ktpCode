using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KtpAcsAotoUpdate
{
  


        // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class updateInfo
        {

            private updateInfoFile[] updateFilesField;

            private string updateStateField;

            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("file", IsNullable = false)]
            public updateInfoFile[] updateFiles
            {
                get
                {
                    return this.updateFilesField;
                }
                set
                {
                    this.updateFilesField = value;
                }
            }

            /// <remarks/>
            public string updateState
            {
                get
                {
                    return this.updateStateField;
                }
                set
                {
                    this.updateStateField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class updateInfoFile
        {

            private string pathField;

            private string urlField;

            private string lastverField;

            private ushort sizeField;

            private bool needRestartField;

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string path
            {
                get
                {
                    return this.pathField;
                }
                set
                {
                    this.pathField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string url
            {
                get
                {
                    return this.urlField;
                }
                set
                {
                    this.urlField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string lastver
            {
                get
                {
                    return this.lastverField;
                }
                set
                {
                    this.lastverField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public ushort size
            {
                get
                {
                    return this.sizeField;
                }
                set
                {
                    this.sizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public bool needRestart
            {
                get
                {
                    return this.needRestartField;
                }
                set
                {
                    this.needRestartField = value;
                }
            }
        }




    }

