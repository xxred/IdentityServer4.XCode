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
    [BindIndex("IX_ApiScopeClaims_ApiScopeId", false, "ApiScopeId")]
    [BindTable("ApiScopeClaims", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ApiScopeClaims : IApiScopeClaims
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _Type;
        /// <summary></summary>
        [DisplayName("Type")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Type", "", "TEXT")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

        private Int64 _ApiScopeId;
        /// <summary></summary>
        [DisplayName("ApiScopeId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ApiScopeId", "", "INTEGER")]
        public Int64 ApiScopeId { get => _ApiScopeId; set { if (OnPropertyChanging("ApiScopeId", value)) { _ApiScopeId = value; OnPropertyChanged("ApiScopeId"); } } }
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
                    case "Type": return _Type;
                    case "ApiScopeId": return _ApiScopeId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "ApiScopeId": _ApiScopeId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ApiScopeClaims字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary></summary>
            public static readonly Field ApiScopeId = FindByName("ApiScopeId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ApiScopeClaims字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Type = "Type";

            /// <summary></summary>
            public const String ApiScopeId = "ApiScopeId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IApiScopeClaims
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Type { get; set; }

        /// <summary></summary>
        Int64 ApiScopeId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}