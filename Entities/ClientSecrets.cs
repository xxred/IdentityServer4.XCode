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
    [BindIndex("IX_ClientSecrets_ClientId", false, "ClientId")]
    [BindTable("ClientSecrets", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ClientSecrets : IClientSecrets
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _Created;
        /// <summary></summary>
        [DisplayName("Created")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Created", "", "TEXT")]
        public String Created { get => _Created; set { if (OnPropertyChanging("Created", value)) { _Created = value; OnPropertyChanged("Created"); } } }

        private DateTime _Expiration;
        /// <summary></summary>
        [DisplayName("Expiration")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Expiration", "", "TEXT")]
        public DateTime Expiration { get => _Expiration; set { if (OnPropertyChanging("Expiration", value)) { _Expiration = value; OnPropertyChanged("Expiration"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private String _Value;
        /// <summary></summary>
        [DisplayName("Value")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Value", "", "TEXT")]
        public String Value { get => _Value; set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } } }

        private String _Type;
        /// <summary></summary>
        [DisplayName("Type")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Type", "", "TEXT")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private Int64 _ClientId;
        /// <summary></summary>
        [DisplayName("ClientId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ClientId", "", "INTEGER")]
        public Int64 ClientId { get => _ClientId; set { if (OnPropertyChanging("ClientId", value)) { _ClientId = value; OnPropertyChanged("ClientId"); } } }
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
                    case "Created": return _Created;
                    case "Expiration": return _Expiration;
                    case "Description": return _Description;
                    case "Value": return _Value;
                    case "Type": return _Type;
                    case "ClientId": return _ClientId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Created": _Created = Convert.ToString(value); break;
                    case "Expiration": _Expiration = value.ToDateTime(); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "Value": _Value = Convert.ToString(value); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "ClientId": _ClientId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ClientSecrets字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Created = FindByName("Created");

            /// <summary></summary>
            public static readonly Field Expiration = FindByName("Expiration");

            /// <summary></summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary></summary>
            public static readonly Field Value = FindByName("Value");

            /// <summary></summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary></summary>
            public static readonly Field ClientId = FindByName("ClientId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ClientSecrets字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Created = "Created";

            /// <summary></summary>
            public const String Expiration = "Expiration";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary></summary>
            public const String Value = "Value";

            /// <summary></summary>
            public const String Type = "Type";

            /// <summary></summary>
            public const String ClientId = "ClientId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IClientSecrets
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Created { get; set; }

        /// <summary></summary>
        DateTime Expiration { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        String Value { get; set; }

        /// <summary></summary>
        String Type { get; set; }

        /// <summary></summary>
        Int64 ClientId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}