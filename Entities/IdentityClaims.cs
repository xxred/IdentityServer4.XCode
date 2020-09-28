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
    [BindIndex("IX_IdentityClaims_IdentityResourceId", false, "IdentityResourceId")]
    [BindTable("IdentityClaims", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class IdentityClaims : IIdentityClaims
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

        private Int64 _IdentityResourceId;
        /// <summary></summary>
        [DisplayName("IdentityResourceId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IdentityResourceId", "", "INTEGER")]
        public Int64 IdentityResourceId { get => _IdentityResourceId; set { if (OnPropertyChanging("IdentityResourceId", value)) { _IdentityResourceId = value; OnPropertyChanged("IdentityResourceId"); } } }
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
                    case "IdentityResourceId": return _IdentityResourceId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "Type": _Type = Convert.ToString(value); break;
                    case "IdentityResourceId": _IdentityResourceId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得IdentityClaims字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Type = FindByName("Type");

            /// <summary></summary>
            public static readonly Field IdentityResourceId = FindByName("IdentityResourceId");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得IdentityClaims字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Type = "Type";

            /// <summary></summary>
            public const String IdentityResourceId = "IdentityResourceId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IIdentityClaims
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Type { get; set; }

        /// <summary></summary>
        Int64 IdentityResourceId { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}