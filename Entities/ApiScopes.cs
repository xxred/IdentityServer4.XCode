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
    [BindIndex("IX_ApiScopes_ApiResourceId", false, "ApiResourceId")]
    [BindIndex("IX_ApiScopes_Name", true, "Name")]
    [BindTable("ApiScopes", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ApiScopes : IApiScopes
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _Name;
        /// <summary></summary>
        [DisplayName("Name")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Name", "", "TEXT", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _DisplayName;
        /// <summary></summary>
        [DisplayName("DisplayName")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("DisplayName", "", "TEXT")]
        public String DisplayName { get => _DisplayName; set { if (OnPropertyChanging("DisplayName", value)) { _DisplayName = value; OnPropertyChanged("DisplayName"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private Boolean _Required;
        /// <summary></summary>
        [DisplayName("Required")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Required", "", "")]
        public Boolean Required { get => _Required; set { if (OnPropertyChanging("Required", value)) { _Required = value; OnPropertyChanged("Required"); } } }

        private Boolean _Emphasize;
        /// <summary></summary>
        [DisplayName("Emphasize")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Emphasize", "", "")]
        public Boolean Emphasize { get => _Emphasize; set { if (OnPropertyChanging("Emphasize", value)) { _Emphasize = value; OnPropertyChanged("Emphasize"); } } }

        private Boolean _ShowInDiscoveryDocument;
        /// <summary></summary>
        [DisplayName("ShowInDiscoveryDocument")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ShowInDiscoveryDocument", "", "")]
        public Boolean ShowInDiscoveryDocument { get => _ShowInDiscoveryDocument; set { if (OnPropertyChanging("ShowInDiscoveryDocument", value)) { _ShowInDiscoveryDocument = value; OnPropertyChanged("ShowInDiscoveryDocument"); } } }

        private Int64 _ApiResourceId;
        /// <summary></summary>
        [DisplayName("ApiResourceId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ApiResourceId", "", "INTEGER")]
        public Int64 ApiResourceId { get => _ApiResourceId; set { if (OnPropertyChanging("ApiResourceId", value)) { _ApiResourceId = value; OnPropertyChanged("ApiResourceId"); } } }
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
                    case "Name": return _Name;
                    case "DisplayName": return _DisplayName;
                    case "Description": return _Description;
                    case "Required": return _Required;
                    case "Emphasize": return _Emphasize;
                    case "ShowInDiscoveryDocument": return _ShowInDiscoveryDocument;
                    case "ApiResourceId": return _ApiResourceId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "DisplayName": _DisplayName = Convert.ToString(value); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "Required": _Required = value.ToBoolean(); break;
                    case "Emphasize": _Emphasize = value.ToBoolean(); break;
                    case "ShowInDiscoveryDocument": _ShowInDiscoveryDocument = value.ToBoolean(); break;
                    case "ApiResourceId": _ApiResourceId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ApiScopes字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Name = FindByName("Name");

            /// <summary></summary>
            public static readonly Field DisplayName = FindByName("DisplayName");

            /// <summary></summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary></summary>
            public static readonly Field Required = FindByName("Required");

            /// <summary></summary>
            public static readonly Field Emphasize = FindByName("Emphasize");

            /// <summary></summary>
            public static readonly Field ShowInDiscoveryDocument = FindByName("ShowInDiscoveryDocument");

            /// <summary></summary>
            public static readonly Field ApiResourceId = FindByName("ApiResourceId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ApiScopes字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Name = "Name";

            /// <summary></summary>
            public const String DisplayName = "DisplayName";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary></summary>
            public const String Required = "Required";

            /// <summary></summary>
            public const String Emphasize = "Emphasize";

            /// <summary></summary>
            public const String ShowInDiscoveryDocument = "ShowInDiscoveryDocument";

            /// <summary></summary>
            public const String ApiResourceId = "ApiResourceId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IApiScopes
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Name { get; set; }

        /// <summary></summary>
        String DisplayName { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Boolean Required { get; set; }

        /// <summary></summary>
        Boolean Emphasize { get; set; }

        /// <summary></summary>
        Boolean ShowInDiscoveryDocument { get; set; }

        /// <summary></summary>
        Int64 ApiResourceId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}