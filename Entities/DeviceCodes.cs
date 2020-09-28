using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace IdentityServer4.XCode.Entities
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindIndex("IX_DeviceCodes_DeviceCode", true, "DeviceCode")]
    [BindIndex("IX_DeviceCodes_UserCode", true, "UserCode")]
    [BindTable("DeviceCodes", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class DeviceCodes : IDeviceCodes
    {
        #region 属性
        private String _DeviceCode;
        /// <summary></summary>
        [DisplayName("DeviceCode")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("DeviceCode", "", "TEXT")]
        public String DeviceCode { get => _DeviceCode; set { if (OnPropertyChanging("DeviceCode", value)) { _DeviceCode = value; OnPropertyChanged("DeviceCode"); } } }

        private String _UserCode;
        /// <summary></summary>
        [DisplayName("UserCode")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserCode", "", "TEXT")]
        public String UserCode { get => _UserCode; set { if (OnPropertyChanging("UserCode", value)) { _UserCode = value; OnPropertyChanged("UserCode"); } } }

        private String _SubjectId;
        /// <summary></summary>
        [DisplayName("SubjectId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("SubjectId", "", "TEXT")]
        public String SubjectId { get => _SubjectId; set { if (OnPropertyChanging("SubjectId", value)) { _SubjectId = value; OnPropertyChanged("SubjectId"); } } }

        private String _ClientId;
        /// <summary></summary>
        [DisplayName("ClientId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ClientId", "", "TEXT")]
        public String ClientId { get => _ClientId; set { if (OnPropertyChanging("ClientId", value)) { _ClientId = value; OnPropertyChanged("ClientId"); } } }

        private DateTime _CreationTime;
        /// <summary></summary>
        [DisplayName("CreationTime")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("CreationTime", "", "")]
        public DateTime CreationTime { get => _CreationTime; set { if (OnPropertyChanging("CreationTime", value)) { _CreationTime = value; OnPropertyChanged("CreationTime"); } } }

        private DateTime _Expiration;
        /// <summary></summary>
        [DisplayName("Expiration")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Expiration", "", "")]
        public DateTime Expiration { get => _Expiration; set { if (OnPropertyChanging("Expiration", value)) { _Expiration = value; OnPropertyChanged("Expiration"); } } }

        private String _Data;
        /// <summary></summary>
        [DisplayName("Data")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Data", "", "TEXT")]
        public String Data { get => _Data; set { if (OnPropertyChanging("Data", value)) { _Data = value; OnPropertyChanged("Data"); } } }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        public override Object this[String name]
        {
            get
            {
                switch (name)
                {
                    case "DeviceCode": return _DeviceCode;
                    case "UserCode": return _UserCode;
                    case "SubjectId": return _SubjectId;
                    case "ClientId": return _ClientId;
                    case "CreationTime": return _CreationTime;
                    case "Expiration": return _Expiration;
                    case "Data": return _Data;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "DeviceCode": _DeviceCode = Convert.ToString(value); break;
                    case "UserCode": _UserCode = Convert.ToString(value); break;
                    case "SubjectId": _SubjectId = Convert.ToString(value); break;
                    case "ClientId": _ClientId = Convert.ToString(value); break;
                    case "CreationTime": _CreationTime = value.ToDateTime(); break;
                    case "Expiration": _Expiration = value.ToDateTime(); break;
                    case "Data": _Data = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得DeviceCodes字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field DeviceCode = FindByName("DeviceCode");

            /// <summary></summary>
            public static readonly Field UserCode = FindByName("UserCode");

            /// <summary></summary>
            public static readonly Field SubjectId = FindByName("SubjectId");

            /// <summary></summary>
            public static readonly Field ClientId = FindByName("ClientId");

            /// <summary></summary>
            public static readonly Field CreationTime = FindByName("CreationTime");

            /// <summary></summary>
            public static readonly Field Expiration = FindByName("Expiration");

            /// <summary></summary>
            public static readonly Field Data = FindByName("Data");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得DeviceCodes字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String DeviceCode = "DeviceCode";

            /// <summary></summary>
            public const String UserCode = "UserCode";

            /// <summary></summary>
            public const String SubjectId = "SubjectId";

            /// <summary></summary>
            public const String ClientId = "ClientId";

            /// <summary></summary>
            public const String CreationTime = "CreationTime";

            /// <summary></summary>
            public const String Expiration = "Expiration";

            /// <summary></summary>
            public const String Data = "Data";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IDeviceCodes
    {
        #region 属性
        /// <summary></summary>
        String DeviceCode { get; set; }

        /// <summary></summary>
        String UserCode { get; set; }

        /// <summary></summary>
        String SubjectId { get; set; }

        /// <summary></summary>
        String ClientId { get; set; }

        /// <summary></summary>
        DateTime CreationTime { get; set; }

        /// <summary></summary>
        DateTime Expiration { get; set; }

        /// <summary></summary>
        String Data { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}