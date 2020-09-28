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
    [BindIndex("IX_AuditEntries_When", false, "When")]
    [BindTable("AuditEntries", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class AuditEntries : IAuditEntries
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get => _Id; set { if (OnPropertyChanging("Id", value)) { _Id = value; OnPropertyChanged("Id"); } } }

        private String _When;
        /// <summary></summary>
        [DisplayName("When")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("When", "", "TEXT")]
        public String When { get => _When; set { if (OnPropertyChanging("When", value)) { _When = value; OnPropertyChanged("When"); } } }

        private String _Source;
        /// <summary></summary>
        [DisplayName("Source")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Source", "", "TEXT")]
        public String Source { get => _Source; set { if (OnPropertyChanging("Source", value)) { _Source = value; OnPropertyChanged("Source"); } } }

        private String _SubjectType;
        /// <summary></summary>
        [DisplayName("SubjectType")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("SubjectType", "", "TEXT")]
        public String SubjectType { get => _SubjectType; set { if (OnPropertyChanging("SubjectType", value)) { _SubjectType = value; OnPropertyChanged("SubjectType"); } } }

        private String _SubjectIdentifier;
        /// <summary></summary>
        [DisplayName("SubjectIdentifier")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("SubjectIdentifier", "", "TEXT")]
        public String SubjectIdentifier { get => _SubjectIdentifier; set { if (OnPropertyChanging("SubjectIdentifier", value)) { _SubjectIdentifier = value; OnPropertyChanged("SubjectIdentifier"); } } }

        private String _Subject;
        /// <summary></summary>
        [DisplayName("Subject")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Subject", "", "TEXT")]
        public String Subject { get => _Subject; set { if (OnPropertyChanging("Subject", value)) { _Subject = value; OnPropertyChanged("Subject"); } } }

        private String _Action;
        /// <summary></summary>
        [DisplayName("Action")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Action", "", "TEXT")]
        public String Action { get => _Action; set { if (OnPropertyChanging("Action", value)) { _Action = value; OnPropertyChanged("Action"); } } }

        private String _ResourceType;
        /// <summary></summary>
        [DisplayName("ResourceType")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ResourceType", "", "TEXT")]
        public String ResourceType { get => _ResourceType; set { if (OnPropertyChanging("ResourceType", value)) { _ResourceType = value; OnPropertyChanged("ResourceType"); } } }

        private String _Resource;
        /// <summary></summary>
        [DisplayName("Resource")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Resource", "", "TEXT")]
        public String Resource { get => _Resource; set { if (OnPropertyChanging("Resource", value)) { _Resource = value; OnPropertyChanged("Resource"); } } }

        private String _ResourceIdentifier;
        /// <summary></summary>
        [DisplayName("ResourceIdentifier")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ResourceIdentifier", "", "TEXT")]
        public String ResourceIdentifier { get => _ResourceIdentifier; set { if (OnPropertyChanging("ResourceIdentifier", value)) { _ResourceIdentifier = value; OnPropertyChanged("ResourceIdentifier"); } } }

        private Int64 _Succeeded;
        /// <summary></summary>
        [DisplayName("Succeeded")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Succeeded", "", "INTEGER")]
        public Int64 Succeeded { get => _Succeeded; set { if (OnPropertyChanging("Succeeded", value)) { _Succeeded = value; OnPropertyChanged("Succeeded"); } } }

        private String _Description;
        /// <summary></summary>
        [DisplayName("Description")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Description", "", "TEXT")]
        public String Description { get => _Description; set { if (OnPropertyChanging("Description", value)) { _Description = value; OnPropertyChanged("Description"); } } }

        private String _NormalisedSubject;
        /// <summary></summary>
        [DisplayName("NormalisedSubject")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalisedSubject", "", "TEXT")]
        public String NormalisedSubject { get => _NormalisedSubject; set { if (OnPropertyChanging("NormalisedSubject", value)) { _NormalisedSubject = value; OnPropertyChanged("NormalisedSubject"); } } }

        private String _NormalisedAction;
        /// <summary></summary>
        [DisplayName("NormalisedAction")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalisedAction", "", "TEXT")]
        public String NormalisedAction { get => _NormalisedAction; set { if (OnPropertyChanging("NormalisedAction", value)) { _NormalisedAction = value; OnPropertyChanged("NormalisedAction"); } } }

        private String _NormalisedResource;
        /// <summary></summary>
        [DisplayName("NormalisedResource")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalisedResource", "", "TEXT")]
        public String NormalisedResource { get => _NormalisedResource; set { if (OnPropertyChanging("NormalisedResource", value)) { _NormalisedResource = value; OnPropertyChanged("NormalisedResource"); } } }

        private String _NormalisedSource;
        /// <summary></summary>
        [DisplayName("NormalisedSource")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NormalisedSource", "", "TEXT")]
        public String NormalisedSource { get => _NormalisedSource; set { if (OnPropertyChanging("NormalisedSource", value)) { _NormalisedSource = value; OnPropertyChanged("NormalisedSource"); } } }
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
                    case "When": return _When;
                    case "Source": return _Source;
                    case "SubjectType": return _SubjectType;
                    case "SubjectIdentifier": return _SubjectIdentifier;
                    case "Subject": return _Subject;
                    case "Action": return _Action;
                    case "ResourceType": return _ResourceType;
                    case "Resource": return _Resource;
                    case "ResourceIdentifier": return _ResourceIdentifier;
                    case "Succeeded": return _Succeeded;
                    case "Description": return _Description;
                    case "NormalisedSubject": return _NormalisedSubject;
                    case "NormalisedAction": return _NormalisedAction;
                    case "NormalisedResource": return _NormalisedResource;
                    case "NormalisedSource": return _NormalisedSource;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case "Id": _Id = value.ToInt(); break;
                    case "When": _When = Convert.ToString(value); break;
                    case "Source": _Source = Convert.ToString(value); break;
                    case "SubjectType": _SubjectType = Convert.ToString(value); break;
                    case "SubjectIdentifier": _SubjectIdentifier = Convert.ToString(value); break;
                    case "Subject": _Subject = Convert.ToString(value); break;
                    case "Action": _Action = Convert.ToString(value); break;
                    case "ResourceType": _ResourceType = Convert.ToString(value); break;
                    case "Resource": _Resource = Convert.ToString(value); break;
                    case "ResourceIdentifier": _ResourceIdentifier = Convert.ToString(value); break;
                    case "Succeeded": _Succeeded = value.ToLong(); break;
                    case "Description": _Description = Convert.ToString(value); break;
                    case "NormalisedSubject": _NormalisedSubject = Convert.ToString(value); break;
                    case "NormalisedAction": _NormalisedAction = Convert.ToString(value); break;
                    case "NormalisedResource": _NormalisedResource = Convert.ToString(value); break;
                    case "NormalisedSource": _NormalisedSource = Convert.ToString(value); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得AuditEntries字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName("Id");

            /// <summary></summary>
            public static readonly Field When = FindByName("When");

            /// <summary></summary>
            public static readonly Field Source = FindByName("Source");

            /// <summary></summary>
            public static readonly Field SubjectType = FindByName("SubjectType");

            /// <summary></summary>
            public static readonly Field SubjectIdentifier = FindByName("SubjectIdentifier");

            /// <summary></summary>
            public static readonly Field Subject = FindByName("Subject");

            /// <summary></summary>
            public static readonly Field Action = FindByName("Action");

            /// <summary></summary>
            public static readonly Field ResourceType = FindByName("ResourceType");

            /// <summary></summary>
            public static readonly Field Resource = FindByName("Resource");

            /// <summary></summary>
            public static readonly Field ResourceIdentifier = FindByName("ResourceIdentifier");

            /// <summary></summary>
            public static readonly Field Succeeded = FindByName("Succeeded");

            /// <summary></summary>
            public static readonly Field Description = FindByName("Description");

            /// <summary></summary>
            public static readonly Field NormalisedSubject = FindByName("NormalisedSubject");

            /// <summary></summary>
            public static readonly Field NormalisedAction = FindByName("NormalisedAction");

            /// <summary></summary>
            public static readonly Field NormalisedResource = FindByName("NormalisedResource");

            /// <summary></summary>
            public static readonly Field NormalisedSource = FindByName("NormalisedSource");

            static Field FindByName(String name) => Meta.Table.FindByName(name);
        }

        /// <summary>取得AuditEntries字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary></summary>
            public const String When = "When";

            /// <summary></summary>
            public const String Source = "Source";

            /// <summary></summary>
            public const String SubjectType = "SubjectType";

            /// <summary></summary>
            public const String SubjectIdentifier = "SubjectIdentifier";

            /// <summary></summary>
            public const String Subject = "Subject";

            /// <summary></summary>
            public const String Action = "Action";

            /// <summary></summary>
            public const String ResourceType = "ResourceType";

            /// <summary></summary>
            public const String Resource = "Resource";

            /// <summary></summary>
            public const String ResourceIdentifier = "ResourceIdentifier";

            /// <summary></summary>
            public const String Succeeded = "Succeeded";

            /// <summary></summary>
            public const String Description = "Description";

            /// <summary></summary>
            public const String NormalisedSubject = "NormalisedSubject";

            /// <summary></summary>
            public const String NormalisedAction = "NormalisedAction";

            /// <summary></summary>
            public const String NormalisedResource = "NormalisedResource";

            /// <summary></summary>
            public const String NormalisedSource = "NormalisedSource";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IAuditEntries
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary></summary>
        String When { get; set; }

        /// <summary></summary>
        String Source { get; set; }

        /// <summary></summary>
        String SubjectType { get; set; }

        /// <summary></summary>
        String SubjectIdentifier { get; set; }

        /// <summary></summary>
        String Subject { get; set; }

        /// <summary></summary>
        String Action { get; set; }

        /// <summary></summary>
        String ResourceType { get; set; }

        /// <summary></summary>
        String Resource { get; set; }

        /// <summary></summary>
        String ResourceIdentifier { get; set; }

        /// <summary></summary>
        Int64 Succeeded { get; set; }

        /// <summary></summary>
        String Description { get; set; }

        /// <summary></summary>
        String NormalisedSubject { get; set; }

        /// <summary></summary>
        String NormalisedAction { get; set; }

        /// <summary></summary>
        String NormalisedResource { get; set; }

        /// <summary></summary>
        String NormalisedSource { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}