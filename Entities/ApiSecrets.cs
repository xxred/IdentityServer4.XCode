using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.Configuration;
using XCode.DataAccessLayer;

namespace IdentityServer4.XCode.Entities
{
    /// <summary></summary>
    [Serializable]
    [DataObject]
    [BindIndex("IX_ApiSecrets_ApiResourceId", false, "ApiResourceId")]
    [BindTable("ApiSecrets", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class ApiSecrets : IApiSecrets
    {
        #region 属性
        private String _Created;
        /// <summary></summary>
        [DisplayName("Created")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Created", "", "TEXT")]
        public String Created { get { return _Created; } set { if (OnPropertyChanging(__.Created, value)) { _Created = value; OnPropertyChanged(__.Created); } } }

        private DateTime _Expiration;
        /// <summary></summary>
        [DisplayName("Expiration")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Expiration", "", "")]
        public DateTime Expiration { get { return _Expiration; } set { if (OnPropertyChanging(__.Expiration, value)) { _Expiration = value; OnPropertyChanged(__.Expiration); } } }

        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get { return _Description; } set { if (OnPropertyChanging(__.Description, value)) { _Description = value; OnPropertyChanged(__.Description); } } }

        private String _Value;
        /// <summary></summary>
        [DisplayName("Value")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Value", "", "TEXT")]
        public String Value { get { return _Value; } set { if (OnPropertyChanging(__.Value, value)) { _Value = value; OnPropertyChanged(__.Value); } } }

        private String _Type;
        /// <summary></summary>
        [DisplayName("Type")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Type", "", "TEXT")]
        public String Type { get { return _Type; } set { if (OnPropertyChanging(__.Type, value)) { _Type = value; OnPropertyChanged(__.Type); } } }

        private Int64 _ApiResourceId;
        /// <summary></summary>
        [DisplayName("ApiResourceId")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ApiResourceId", "", "INTEGER")]
        public Int64 ApiResourceId { get { return _ApiResourceId; } set { if (OnPropertyChanging(__.ApiResourceId, value)) { _ApiResourceId = value; OnPropertyChanged(__.ApiResourceId); } } }
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
                    case __.Created : return _Created;
                    case __.Expiration : return _Expiration;
                    case __.Id : return _Id;
                    case __.Description : return _Description;
                    case __.Value : return _Value;
                    case __.Type : return _Type;
                    case __.ApiResourceId : return _ApiResourceId;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Created : _Created = Convert.ToString(value); break;
                    case __.Expiration : _Expiration = value.ToDateTime(); break;
                    case __.Id : _Id = value.ToInt(); break;
                    case __.Description : _Description = Convert.ToString(value); break;
                    case __.Value : _Value = Convert.ToString(value); break;
                    case __.Type : _Type = Convert.ToString(value); break;
                    case __.ApiResourceId : _ApiResourceId = value.ToLong(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得ApiSecrets字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Created = FindByName(__.Created);

            /// <summary></summary>
            public static readonly Field Expiration = FindByName(__.Expiration);

            /// <summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary></summary>
            public static readonly Field Description = FindByName(__.Description);

            /// <summary></summary>
            public static readonly Field Value = FindByName(__.Value);

            /// <summary></summary>
            public static readonly Field Type = FindByName(__.Type);

            /// <summary></summary>
            public static readonly Field ApiResourceId = FindByName(__.ApiResourceId);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得ApiSecrets字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Created = "Created";

            /// <summary></summary>
            public const String Expiration = "Expiration";

            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary></summary>
            public const String Value = "Value";

            /// <summary></summary>
            public const String Type = "Type";

            /// <summary></summary>
            public const String ApiResourceId = "ApiResourceId";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IApiSecrets
    {
        #region 属性
        /// <summary></summary>
        String Created { get; set; }

        /// <summary></summary>
        DateTime Expiration { get; set; }

        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        String Value { get; set; }

        /// <summary></summary>
        String Type { get; set; }

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