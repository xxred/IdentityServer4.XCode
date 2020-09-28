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
    [BindIndex("IX_IdentityResources_Name", true, "Name")]
    [BindTable("IdentityResources", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class IdentityResources : IIdentityResources
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private Boolean _Enabled;
        /// <summary></summary>
        [DisplayName("Enabled")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Enabled", "", "")]
        public Boolean Enabled { get => _Enabled; set { if (OnPropertyChanging("Enabled", value)) { _Enabled = value; OnPropertyChanged("Enabled"); } } }

        private String _Name;
        /// <summary></summary>
        [DisplayName("Name")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Name", "", "TEXT", Master = true)]
        public String Name { get => _Name; set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } } }

        private String _DisplayName;
        /// <summary></summary>
        [DisplayName("DisplayName")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("DisplayName", "", "TEXT")]
        public String DisplayName { get => _DisplayName; set { if (OnPropertyChanging("DisplayName", value)) { _DisplayName = value; OnPropertyChanged("DisplayName"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private Int64 _Required;
        /// <summary></summary>
        [DisplayName("Required")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Required", "", "INTEGER")]
        public Int64 Required { get => _Required; set { if (OnPropertyChanging("Required", value)) { _Required = value; OnPropertyChanged("Required"); } } }

        private Int64 _Emphasize;
        /// <summary></summary>
        [DisplayName("Emphasize")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Emphasize", "", "INTEGER")]
        public Int64 Emphasize { get => _Emphasize; set { if (OnPropertyChanging("Emphasize", value)) { _Emphasize = value; OnPropertyChanged("Emphasize"); } } }

        private Int64 _ShowInDiscoveryDocument;
        /// <summary></summary>
        [DisplayName("ShowInDiscoveryDocument")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ShowInDiscoveryDocument", "", "INTEGER")]
        public Int64 ShowInDiscoveryDocument { get => _ShowInDiscoveryDocument; set { if (OnPropertyChanging("ShowInDiscoveryDocument", value)) { _ShowInDiscoveryDocument = value; OnPropertyChanged("ShowInDiscoveryDocument"); } } }

        private String _Created;
        /// <summary></summary>
        [DisplayName("Created")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Created", "", "TEXT")]
        public String Created { get => _Created; set { if (OnPropertyChanging("Created", value)) { _Created = value; OnPropertyChanged("Created"); } } }

        private String _Updated;
        /// <summary></summary>
        [DisplayName("Updated")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Updated", "", "TEXT")]
        public String Updated { get => _Updated; set { if (OnPropertyChanging("Updated", value)) { _Updated = value; OnPropertyChanged("Updated"); } } }

        private Int64 _NonEditable;
        /// <summary></summary>
        [DisplayName("NonEditable")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NonEditable", "", "INTEGER")]
        public Int64 NonEditable { get => _NonEditable; set { if (OnPropertyChanging("NonEditable", value)) { _NonEditable = value; OnPropertyChanged("NonEditable"); } } }
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
                    case "Enabled": return _Enabled;
                    case "Name": return _Name;
                    case "DisplayName": return _DisplayName;
                    case "Description": return _Description;
                    case "Required": return _Required;
                    case "Emphasize": return _Emphasize;
                    case "ShowInDiscoveryDocument": return _ShowInDiscoveryDocument;
                    case "Created": return _Created;
                    case "Updated": return _Updated;
                    case "NonEditable": return _NonEditable;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Enabled": _Enabled = value.ToBoolean(); break;
                    case "Name": _Name = Convert.ToString(value); break;
                    case "DisplayName": _DisplayName = Convert.ToString(value); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "Required": _Required = value.ToLong(); break;
                    case "Emphasize": _Emphasize = value.ToLong(); break;
                    case "ShowInDiscoveryDocument": _ShowInDiscoveryDocument = value.ToLong(); break;
                    case "Created": _Created = Convert.ToString(value); break;
                    case "Updated": _Updated = Convert.ToString(value); break;
                    case "NonEditable": _NonEditable = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityResources字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Enabled = FindByName("Enabled");

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
            public static readonly Field Created = FindByName("Created");

            /// <summary></summary>
            public static readonly Field Updated = FindByName("Updated");

            /// <summary></summary>
            public static readonly Field NonEditable = FindByName("NonEditable");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得IdentityResources字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Enabled = "Enabled";

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
            public const String Created = "Created";

            /// <summary></summary>
            public const String Updated = "Updated";

            /// <summary></summary>
            public const String NonEditable = "NonEditable";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IIdentityResources
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        Boolean Enabled { get; set; }

        /// <summary></summary>
        String Name { get; set; }

        /// <summary></summary>
        String DisplayName { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        Int64 Required { get; set; }

        /// <summary></summary>
        Int64 Emphasize { get; set; }

        /// <summary></summary>
        Int64 ShowInDiscoveryDocument { get; set; }

        /// <summary></summary>
        String Created { get; set; }

        /// <summary></summary>
        String Updated { get; set; }

        /// <summary></summary>
        Int64 NonEditable { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}