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
    [BindIndex("IX_PersistedGrants_SubjectId_ClientId_Type", false, "SubjectId,ClientId,Type")]
    [BindTable("PersistedGrants", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class PersistedGrants : IPersistedGrants
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _Key;
        /// <summary></summary>
        [DisplayName("Key")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Key", "", "TEXT")]
        public String Key { get => _Key; set { if (OnPropertyChanging("Key", value)) { _Key = value; OnPropertyChanged("Key"); } } }

        private String _Type;
        /// <summary></summary>
        [DisplayName("Type")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Type", "", "TEXT")]
        public String Type { get => _Type; set { if (OnPropertyChanging("Type", value)) { _Type = value; OnPropertyChanged("Type"); } } }

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
                    case "Id": return _Id;
                    case "Key": return _Key;
                    case "Type": return _Type;
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
                    case "Id": _Id = value.ToInt(); break;
                    case "Key": _Key = Convert.ToString(value); break;
                    case "Type": _Type = Convert.ToString(value); break;
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
        /// <summary>取得PersistedGrants字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field Key = FindByName("Key");

            /// <summary></summary>
            public static readonly Field Type = FindByName("Type");

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

        /// <summary>取得PersistedGrants字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Key = "Key";

            /// <summary></summary>
            public const String Type = "Type";

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
    public partial interface IPersistedGrants
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Key { get; set; }

        /// <summary></summary>
        String Type { get; set; }

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