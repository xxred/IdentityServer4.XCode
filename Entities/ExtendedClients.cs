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
    [BindIndex("IdIndex", true, "ClientId")]
    [BindIndex("ClientIdIndex", true, "NormalizedClientId")]
    [BindIndex("ClientNameIndex", true, "NormalizedClientName")]
    [BindTable("ExtendedClients", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ExtendedClients : IExtendedClients
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Id", "", "TEXT")]
        public String Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _ClientId;
        /// <summary></summary>
        [DisplayName("ClientId")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("ClientId", "", "TEXT")]
        public String ClientId { get => _ClientId; set { if (OnPropertyChanging("ClientId", value)) { _ClientId = value; OnPropertyChanged("ClientId"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private String _NormalizedClientId;
        /// <summary></summary>
        [DisplayName("NormalizedClientId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalizedClientId", "", "TEXT")]
        public String NormalizedClientId { get => _NormalizedClientId; set { if (OnPropertyChanging("NormalizedClientId", value)) { _NormalizedClientId = value; OnPropertyChanged("NormalizedClientId"); } } }

        private String _NormalizedClientName;
        /// <summary></summary>
        [DisplayName("NormalizedClientName")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalizedClientName", "", "TEXT")]
        public String NormalizedClientName { get => _NormalizedClientName; set { if (OnPropertyChanging("NormalizedClientName", value)) { _NormalizedClientName = value; OnPropertyChanged("NormalizedClientName"); } } }

        private Int64 _Reserved;
        /// <summary></summary>
        [DisplayName("Reserved")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Reserved", "", "INTEGER")]
        public Int64 Reserved { get => _Reserved; set { if (OnPropertyChanging("Reserved", value)) { _Reserved = value; OnPropertyChanged("Reserved"); } } }
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
                    case "Id": return _Id;
                    case "ClientId": return _ClientId;
                    case "Description": return _Description;
                    case "NormalizedClientId": return _NormalizedClientId;
                    case "NormalizedClientName": return _NormalizedClientName;
                    case "Reserved": return _Reserved;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = Convert.ToString(value); break;
                    case "ClientId": _ClientId = Convert.ToString(value); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "NormalizedClientId": _NormalizedClientId = Convert.ToString(value); break;
                    case "NormalizedClientName": _NormalizedClientName = Convert.ToString(value); break;
                    case "Reserved": _Reserved = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ExtendedClients字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field ClientId = FindByName("ClientId");

            /// <summary></summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary></summary>
            public static readonly Field NormalizedClientId = FindByName("NormalizedClientId");

            /// <summary></summary>
            public static readonly Field NormalizedClientName = FindByName("NormalizedClientName");

            /// <summary></summary>
            public static readonly Field Reserved = FindByName("Reserved");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ExtendedClients字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String ClientId = "ClientId";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary></summary>
            public const String NormalizedClientId = "NormalizedClientId";

            /// <summary></summary>
            public const String NormalizedClientName = "NormalizedClientName";

            /// <summary></summary>
            public const String Reserved = "Reserved";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IExtendedClients
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String ClientId { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        String NormalizedClientId { get; set; }

        /// <summary></summary>
        String NormalizedClientName { get; set; }

        /// <summary></summary>
        Int64 Reserved { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}