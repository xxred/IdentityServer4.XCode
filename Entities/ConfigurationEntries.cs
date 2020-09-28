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
    [BindTable("ConfigurationEntries", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ConfigurationEntries : IConfigurationEntries
    {
        #region 属性
        private String _Key;
        /// <summary></summary>
        [DisplayName("Key")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Key", "", "TEXT")]
        public String Key { get => _Key; set { if (OnPropertyChanging("Key", value)) { _Key = value; OnPropertyChanged("Key"); } } }

        private String _Value;
        /// <summary></summary>
        [DisplayName("Value")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Value", "", "TEXT")]
        public String Value { get => _Value; set { if (OnPropertyChanging("Value", value)) { _Value = value; OnPropertyChanged("Value"); } } }
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
                    case "Key": return _Key;
                    case "Value": return _Value;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Key": _Key = Convert.ToString(value); break;
                    case "Value": _Value = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ConfigurationEntries字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Key = FindByName("Key");

            /// <summary></summary>
            public static readonly Field Value = FindByName("Value");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得ConfigurationEntries字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Key = "Key";

            /// <summary></summary>
            public const String Value = "Value";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IConfigurationEntries
    {
        #region 属性
        /// <summary></summary>
        String Key { get; set; }

        /// <summary></summary>
        String Value { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}