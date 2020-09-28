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
    [BindIndex("IX_ClientPostLogoutRedirectUris_ClientId", false, "ClientId")]
    [BindTable("ClientPostLogoutRedirectUris", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ClientPostLogoutRedirectUris : IClientPostLogoutRedirectUris
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _PostLogoutRedirectUri;
        /// <summary></summary>
        [DisplayName("PostLogoutRedirectUri")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("PostLogoutRedirectUri", "", "TEXT")]
        public String PostLogoutRedirectUri { get => _PostLogoutRedirectUri; set { if (OnPropertyChanging("PostLogoutRedirectUri", value)) { _PostLogoutRedirectUri = value; OnPropertyChanged("PostLogoutRedirectUri"); } } }

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
                    case "PostLogoutRedirectUri": return _PostLogoutRedirectUri;
                    case "ClientId": return _ClientId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "PostLogoutRedirectUri": _PostLogoutRedirectUri = Convert.ToString(value); break;
                    case "ClientId": _ClientId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ClientPostLogoutRedirectUris字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field PostLogoutRedirectUri = FindByName("PostLogoutRedirectUri");

            /// <summary></summary>
            public static readonly Field ClientId = FindByName("ClientId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ClientPostLogoutRedirectUris字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String PostLogoutRedirectUri = "PostLogoutRedirectUri";

            /// <summary></summary>
            public const String ClientId = "ClientId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IClientPostLogoutRedirectUris
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String PostLogoutRedirectUri { get; set; }

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