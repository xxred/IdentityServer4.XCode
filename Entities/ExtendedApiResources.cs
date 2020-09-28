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
    [BindIndex("ApiNameIndex", true, "ApiResourceName")]
    [BindIndex("ApiResourceNameIndex", true, "NormalizedName")]
    [BindTable("ExtendedApiResources", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ExtendedApiResources : IExtendedApiResources
    {
        #region 属性
        private String _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Id", "", "TEXT")]
        public String Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _ApiResourceName;
        /// <summary></summary>
        [DisplayName("ApiResourceName")]
        [DataObjectField(true, false, false, 0)]
        [BindColumn("ApiResourceName", "", "TEXT")]
        public String ApiResourceName { get => _ApiResourceName; set { if (OnPropertyChanging("ApiResourceName", value)) { _ApiResourceName = value; OnPropertyChanged("ApiResourceName"); } } }

        private String _NormalizedName;
        /// <summary></summary>
        [DisplayName("NormalizedName")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalizedName", "", "TEXT")]
        public String NormalizedName { get => _NormalizedName; set { if (OnPropertyChanging("NormalizedName", value)) { _NormalizedName = value; OnPropertyChanged("NormalizedName"); } } }

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
                    case "ApiResourceName": return _ApiResourceName;
                    case "NormalizedName": return _NormalizedName;
                    case "Reserved": return _Reserved;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = Convert.ToString(value); break;
                    case "ApiResourceName": _ApiResourceName = Convert.ToString(value); break;
                    case "NormalizedName": _NormalizedName = Convert.ToString(value); break;
                    case "Reserved": _Reserved = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ExtendedApiResources字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field ApiResourceName = FindByName("ApiResourceName");

            /// <summary></summary>
            public static readonly Field NormalizedName = FindByName("NormalizedName");

            /// <summary></summary>
            public static readonly Field Reserved = FindByName("Reserved");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ExtendedApiResources字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String ApiResourceName = "ApiResourceName";

            /// <summary></summary>
            public const String NormalizedName = "NormalizedName";

            /// <summary></summary>
            public const String Reserved = "Reserved";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IExtendedApiResources
    {
        #region 属性
        /// <summary></summary>
        String Id { get; set; }

        /// <summary></summary>
        String ApiResourceName { get; set; }

        /// <summary></summary>
        String NormalizedName { get; set; }

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