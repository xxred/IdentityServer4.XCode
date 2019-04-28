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
    [BindIndex("IX_Clients_ClientId", true, "ClientId")]
    [BindTable("Clients", Description = "", ConnName = "IdentityServer", DbType = DatabaseType.None)]
    public partial class Clients : IClients
    {
        #region 属性
        private Int32 _Id;
        /// <summary></summary>
        [DisplayName("Id")]
        [DataObjectField(true, true, false, 0)]
        [BindColumn("Id", "", "INTEGER")]
        public Int32 Id { get { return _Id; } set { if (OnPropertyChanging(__.Id, value)) { _Id = value; OnPropertyChanged(__.Id); } } }

        private Boolean _Enabled;
        /// <summary>启用(默认为true)</summary>
        [DisplayName("启用")]
        [Description("启用(默认为true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("Enabled", "启用(默认为true)", "")]
        public Boolean Enabled { get { return _Enabled; } set { if (OnPropertyChanging(__.Enabled, value)) { _Enabled = value; OnPropertyChanged(__.Enabled); } } }

        private String _ClientId;
        /// <summary>客户端ID(应用程序的唯一识别标识)</summary>
        [DisplayName("客户端ID")]
        [Description("客户端ID(应用程序的唯一识别标识)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ClientId", "客户端ID(应用程序的唯一识别标识)", "TEXT")]
        public String ClientId { get { return _ClientId; } set { if (OnPropertyChanging(__.ClientId, value)) { _ClientId = value; OnPropertyChanged(__.ClientId); } } }

        private String _ProtocolType;
        /// <summary>协议类型(默认oidc)</summary>
        [DisplayName("协议类型")]
        [Description("协议类型(默认oidc)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ProtocolType", "协议类型(默认oidc)", "TEXT")]
        public String ProtocolType { get { return _ProtocolType; } set { if (OnPropertyChanging(__.ProtocolType, value)) { _ProtocolType = value; OnPropertyChanged(__.ProtocolType); } } }

        private Boolean _RequireClientSecret;
        /// <summary>需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)</summary>
        [DisplayName("需要密钥")]
        [Description("需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RequireClientSecret", "需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)", "")]
        public Boolean RequireClientSecret { get { return _RequireClientSecret; } set { if (OnPropertyChanging(__.RequireClientSecret, value)) { _RequireClientSecret = value; OnPropertyChanged(__.RequireClientSecret); } } }

        private Boolean _RequirePkce;
        /// <summary>校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)</summary>
        [DisplayName("校验密钥")]
        [Description("校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RequirePkce", "校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)", "")]
        public Boolean RequirePkce { get { return _RequirePkce; } set { if (OnPropertyChanging(__.RequirePkce, value)) { _RequirePkce = value; OnPropertyChanged(__.RequirePkce); } } }

        private Boolean _AllowPlainTextPkce;
        /// <summary>允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)</summary>
        [DisplayName("允许纯文本密钥")]
        [Description("允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AllowPlainTextPkce", "允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)", "")]
        public Boolean AllowPlainTextPkce { get { return _AllowPlainTextPkce; } set { if (OnPropertyChanging(__.AllowPlainTextPkce, value)) { _AllowPlainTextPkce = value; OnPropertyChanged(__.AllowPlainTextPkce); } } }

        private Boolean _AllowOfflineAccess;
        /// <summary>允许刷新token(需要offline_access范围scope)</summary>
        [DisplayName("允许刷新token")]
        [Description("允许刷新token(需要offline_access范围scope)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AllowOfflineAccess", "允许刷新token(需要offline_access范围scope)", "")]
        public Boolean AllowOfflineAccess { get { return _AllowOfflineAccess; } set { if (OnPropertyChanging(__.AllowOfflineAccess, value)) { _AllowOfflineAccess = value; OnPropertyChanged(__.AllowOfflineAccess); } } }

        private Boolean _AllowAccessTokensViaBrowser;
        /// <summary>允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)</summary>
        [DisplayName("允许通过浏览器接收token")]
        [Description("允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AllowAccessTokensViaBrowser", "允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)", "")]
        public Boolean AllowAccessTokensViaBrowser { get { return _AllowAccessTokensViaBrowser; } set { if (OnPropertyChanging(__.AllowAccessTokensViaBrowser, value)) { _AllowAccessTokensViaBrowser = value; OnPropertyChanged(__.AllowAccessTokensViaBrowser); } } }

        private String _FrontChannelLogoutUri;
        /// <summary>客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)</summary>
        [DisplayName("客户端前端注销URI")]
        [Description("客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("FrontChannelLogoutUri", "客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)", "TEXT")]
        public String FrontChannelLogoutUri { get { return _FrontChannelLogoutUri; } set { if (OnPropertyChanging(__.FrontChannelLogoutUri, value)) { _FrontChannelLogoutUri = value; OnPropertyChanged(__.FrontChannelLogoutUri); } } }

        private Boolean _FrontChannelLogoutSessionRequired;
        /// <summary>发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)</summary>
        [DisplayName("发送会话id到前端注销URI")]
        [Description("发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("FrontChannelLogoutSessionRequired", "发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)", "")]
        public Boolean FrontChannelLogoutSessionRequired { get { return _FrontChannelLogoutSessionRequired; } set { if (OnPropertyChanging(__.FrontChannelLogoutSessionRequired, value)) { _FrontChannelLogoutSessionRequired = value; OnPropertyChanged(__.FrontChannelLogoutSessionRequired); } } }

        private String _BackChannelLogoutUri;
        /// <summary>客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)</summary>
        [DisplayName("客户端注销URI")]
        [Description("客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("BackChannelLogoutUri", "客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)", "TEXT")]
        public String BackChannelLogoutUri { get { return _BackChannelLogoutUri; } set { if (OnPropertyChanging(__.BackChannelLogoutUri, value)) { _BackChannelLogoutUri = value; OnPropertyChanged(__.BackChannelLogoutUri); } } }

        private Boolean _BackChannelLogoutSessionRequired;
        /// <summary>发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)</summary>
        [DisplayName("发送会话id到注销URI")]
        [Description("发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("BackChannelLogoutSessionRequired", "发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)", "")]
        public Boolean BackChannelLogoutSessionRequired { get { return _BackChannelLogoutSessionRequired; } set { if (OnPropertyChanging(__.BackChannelLogoutSessionRequired, value)) { _BackChannelLogoutSessionRequired = value; OnPropertyChanged(__.BackChannelLogoutSessionRequired); } } }

        private Boolean _EnableLocalLogin;
        /// <summary>仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)</summary>
        [DisplayName("仅用本地登录")]
        [Description("仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("EnableLocalLogin", "仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)", "")]
        public Boolean EnableLocalLogin { get { return _EnableLocalLogin; } set { if (OnPropertyChanging(__.EnableLocalLogin, value)) { _EnableLocalLogin = value; OnPropertyChanged(__.EnableLocalLogin); } } }

        private Int64 _UserSsoLifetime;
        /// <summary>用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)</summary>
        [DisplayName("用户身份持续时间")]
        [Description("用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UserSsoLifetime", "用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)", "INTEGER")]
        public Int64 UserSsoLifetime { get { return _UserSsoLifetime; } set { if (OnPropertyChanging(__.UserSsoLifetime, value)) { _UserSsoLifetime = value; OnPropertyChanged(__.UserSsoLifetime); } } }

        private Int64 _IdentityTokenLifetime;
        /// <summary>识别令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
        [DisplayName("识别令牌生命周期")]
        [Description("识别令牌生命周期(秒为单位，默认为300秒/5分钟)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IdentityTokenLifetime", "识别令牌生命周期(秒为单位，默认为300秒/5分钟)", "INTEGER")]
        public Int64 IdentityTokenLifetime { get { return _IdentityTokenLifetime; } set { if (OnPropertyChanging(__.IdentityTokenLifetime, value)) { _IdentityTokenLifetime = value; OnPropertyChanged(__.IdentityTokenLifetime); } } }

        private Int64 _AccessTokenLifetime;
        /// <summary>访问令牌生命周期(秒为单位，默认为3600秒/1小时)</summary>
        [DisplayName("访问令牌生命周期")]
        [Description("访问令牌生命周期(秒为单位，默认为3600秒/1小时)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AccessTokenLifetime", "访问令牌生命周期(秒为单位，默认为3600秒/1小时)", "INTEGER")]
        public Int64 AccessTokenLifetime { get { return _AccessTokenLifetime; } set { if (OnPropertyChanging(__.AccessTokenLifetime, value)) { _AccessTokenLifetime = value; OnPropertyChanged(__.AccessTokenLifetime); } } }

        private Int64 _AuthorizationCodeLifetime;
        /// <summary>访问令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
        [DisplayName("访问令牌生命周期")]
        [Description("访问令牌生命周期(秒为单位，默认为300秒/5分钟)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AuthorizationCodeLifetime", "访问令牌生命周期(秒为单位，默认为300秒/5分钟)", "INTEGER")]
        public Int64 AuthorizationCodeLifetime { get { return _AuthorizationCodeLifetime; } set { if (OnPropertyChanging(__.AuthorizationCodeLifetime, value)) { _AuthorizationCodeLifetime = value; OnPropertyChanged(__.AuthorizationCodeLifetime); } } }

        private Int64 _AbsoluteRefreshTokenLifetime;
        /// <summary>刷新令牌生命周期(秒为单位，默认为2592000秒/30天)</summary>
        [DisplayName("刷新令牌生命周期")]
        [Description("刷新令牌生命周期(秒为单位，默认为2592000秒/30天)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AbsoluteRefreshTokenLifetime", "刷新令牌生命周期(秒为单位，默认为2592000秒/30天)", "INTEGER")]
        public Int64 AbsoluteRefreshTokenLifetime { get { return _AbsoluteRefreshTokenLifetime; } set { if (OnPropertyChanging(__.AbsoluteRefreshTokenLifetime, value)) { _AbsoluteRefreshTokenLifetime = value; OnPropertyChanged(__.AbsoluteRefreshTokenLifetime); } } }

        private Int64 _SlidingRefreshTokenLifetime;
        /// <summary>滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)</summary>
        [DisplayName("滑动刷新令牌生命周期")]
        [Description("滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("SlidingRefreshTokenLifetime", "滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)", "INTEGER")]
        public Int64 SlidingRefreshTokenLifetime { get { return _SlidingRefreshTokenLifetime; } set { if (OnPropertyChanging(__.SlidingRefreshTokenLifetime, value)) { _SlidingRefreshTokenLifetime = value; OnPropertyChanged(__.SlidingRefreshTokenLifetime); } } }

        private IdentityServer4.Models.TokenUsage _RefreshTokenUsage;
        /// <summary>刷新令牌句柄是否保持不变(ReUse，OneTime)</summary>
        [DisplayName("刷新令牌句柄是否保持不变")]
        [Description("刷新令牌句柄是否保持不变(ReUse，OneTime)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RefreshTokenUsage", "刷新令牌句柄是否保持不变(ReUse，OneTime)", "INTEGER")]
        public IdentityServer4.Models.TokenUsage RefreshTokenUsage { get { return _RefreshTokenUsage; } set { if (OnPropertyChanging(__.RefreshTokenUsage, value)) { _RefreshTokenUsage = value; OnPropertyChanged(__.RefreshTokenUsage); } } }

        private IdentityServer4.Models.TokenExpiration _RefreshTokenExpiration;
        /// <summary>刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)</summary>
        [DisplayName("刷新令牌期限")]
        [Description("刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RefreshTokenExpiration", "刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)", "INTEGER")]
        public IdentityServer4.Models.TokenExpiration RefreshTokenExpiration { get { return _RefreshTokenExpiration; } set { if (OnPropertyChanging(__.RefreshTokenExpiration, value)) { _RefreshTokenExpiration = value; OnPropertyChanged(__.RefreshTokenExpiration); } } }

        private Boolean _UpdateAccessTokenClaimsOnRefresh;
        /// <summary>更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)</summary>
        [DisplayName("更新访问令牌")]
        [Description("更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("UpdateAccessTokenClaimsOnRefresh", "更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)", "")]
        public Boolean UpdateAccessTokenClaimsOnRefresh { get { return _UpdateAccessTokenClaimsOnRefresh; } set { if (OnPropertyChanging(__.UpdateAccessTokenClaimsOnRefresh, value)) { _UpdateAccessTokenClaimsOnRefresh = value; OnPropertyChanged(__.UpdateAccessTokenClaimsOnRefresh); } } }

        private IdentityServer4.Models.AccessTokenType _AccessTokenType;
        /// <summary>访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)</summary>
        [DisplayName("访问令牌类型")]
        [Description("访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AccessTokenType", "访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)", "INTEGER")]
        public IdentityServer4.Models.AccessTokenType AccessTokenType { get { return _AccessTokenType; } set { if (OnPropertyChanging(__.AccessTokenType, value)) { _AccessTokenType = value; OnPropertyChanged(__.AccessTokenType); } } }

        private Boolean _IncludeJwtId;
        /// <summary>是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)</summary>
        [DisplayName("是否嵌入JwtId")]
        [Description("是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("IncludeJwtId", "是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)", "")]
        public Boolean IncludeJwtId { get { return _IncludeJwtId; } set { if (OnPropertyChanging(__.IncludeJwtId, value)) { _IncludeJwtId = value; OnPropertyChanged(__.IncludeJwtId); } } }

        private Boolean _AlwaysSendClientClaims;
        /// <summary>发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)</summary>
        [DisplayName("发送客户端声明")]
        [Description("发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AlwaysSendClientClaims", "发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)", "")]
        public Boolean AlwaysSendClientClaims { get { return _AlwaysSendClientClaims; } set { if (OnPropertyChanging(__.AlwaysSendClientClaims, value)) { _AlwaysSendClientClaims = value; OnPropertyChanged(__.AlwaysSendClientClaims); } } }

        private Boolean _AlwaysIncludeUserClaimsInIdToken;
        /// <summary>用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)</summary>
        [DisplayName("用户声明添加到ID令牌")]
        [Description("用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AlwaysIncludeUserClaimsInIdToken", "用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)", "")]
        public Boolean AlwaysIncludeUserClaimsInIdToken { get { return _AlwaysIncludeUserClaimsInIdToken; } set { if (OnPropertyChanging(__.AlwaysIncludeUserClaimsInIdToken, value)) { _AlwaysIncludeUserClaimsInIdToken = value; OnPropertyChanged(__.AlwaysIncludeUserClaimsInIdToken); } } }

        private String _ClientClaimsPrefix;
        /// <summary>客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)</summary>
        [DisplayName("客户端声明前缀")]
        [Description("客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ClientClaimsPrefix", "客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)", "TEXT")]
        public String ClientClaimsPrefix { get { return _ClientClaimsPrefix; } set { if (OnPropertyChanging(__.ClientClaimsPrefix, value)) { _ClientClaimsPrefix = value; OnPropertyChanged(__.ClientClaimsPrefix); } } }

        private String _PairWiseSubjectSalt;
        /// <summary>生成成对subjectId使用的盐值</summary>
        [DisplayName("生成成对subjectId使用的盐值")]
        [Description("生成成对subjectId使用的盐值")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("PairWiseSubjectSalt", "生成成对subjectId使用的盐值", "TEXT")]
        public String PairWiseSubjectSalt { get { return _PairWiseSubjectSalt; } set { if (OnPropertyChanging(__.PairWiseSubjectSalt, value)) { _PairWiseSubjectSalt = value; OnPropertyChanged(__.PairWiseSubjectSalt); } } }

        private Boolean _RequireConsent;
        /// <summary>需要同意(默认为true)</summary>
        [DisplayName("需要同意")]
        [Description("需要同意(默认为true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("RequireConsent", "需要同意(默认为true)", "")]
        public Boolean RequireConsent { get { return _RequireConsent; } set { if (OnPropertyChanging(__.RequireConsent, value)) { _RequireConsent = value; OnPropertyChanged(__.RequireConsent); } } }

        private Boolean _AllowRememberConsent;
        /// <summary>存储同意决策(默认true)</summary>
        [DisplayName("存储同意决策")]
        [Description("存储同意决策(默认true)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("AllowRememberConsent", "存储同意决策(默认true)", "")]
        public Boolean AllowRememberConsent { get { return _AllowRememberConsent; } set { if (OnPropertyChanging(__.AllowRememberConsent, value)) { _AllowRememberConsent = value; OnPropertyChanged(__.AllowRememberConsent); } } }

        private Int64 _ConsentLifetime;
        /// <summary>用户同意的生命周期(默认null，无到期)</summary>
        [DisplayName("用户同意的生命周期")]
        [Description("用户同意的生命周期(默认null，无到期)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ConsentLifetime", "用户同意的生命周期(默认null，无到期)", "INTEGER")]
        public Int64 ConsentLifetime { get { return _ConsentLifetime; } set { if (OnPropertyChanging(__.ConsentLifetime, value)) { _ConsentLifetime = value; OnPropertyChanged(__.ConsentLifetime); } } }

        private String _ClientName;
        /// <summary>显示名称</summary>
        [DisplayName("显示名称")]
        [Description("显示名称")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("ClientName", "显示名称", "TEXT")]
        public String ClientName { get { return _ClientName; } set { if (OnPropertyChanging(__.ClientName, value)) { _ClientName = value; OnPropertyChanged(__.ClientName); } } }

        private String _Description;
        /// <summary>说明</summary>
        [DisplayName("说明")]
        [Description("说明")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Description", "说明", "TEXT")]
        public String Description { get { return _Description; } set { if (OnPropertyChanging(__.Description, value)) { _Description = value; OnPropertyChanged(__.Description); } } }

        private String _ClientUri;
        /// <summary>客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)</summary>
        [DisplayName("客户端信息url")]
        [Description("客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("ClientUri", "客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)", "TEXT")]
        public String ClientUri { get { return _ClientUri; } set { if (OnPropertyChanging(__.ClientUri, value)) { _ClientUri = value; OnPropertyChanged(__.ClientUri); } } }

        private String _LogoUri;
        /// <summary>客户端logo地址(在同意页面上使用)</summary>
        [DisplayName("客户端logo地址")]
        [Description("客户端logo地址(在同意页面上使用)")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LogoUri", "客户端logo地址(在同意页面上使用)", "TEXT")]
        public String LogoUri { get { return _LogoUri; } set { if (OnPropertyChanging(__.LogoUri, value)) { _LogoUri = value; OnPropertyChanged(__.LogoUri); } } }

        private String _UserCodeType;
        /// <summary>设备流用户代码的类型</summary>
        [DisplayName("设备流用户代码的类型")]
        [Description("设备流用户代码的类型")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("UserCodeType", "设备流用户代码的类型", "TEXT")]
        public String UserCodeType { get { return _UserCodeType; } set { if (OnPropertyChanging(__.UserCodeType, value)) { _UserCodeType = value; OnPropertyChanged(__.UserCodeType); } } }

        private Int64 _DeviceCodeLifetime;
        /// <summary>设备代码的生命周期(秒为单位，默认为300秒/5分钟)</summary>
        [DisplayName("设备代码的生命周期")]
        [Description("设备代码的生命周期(秒为单位，默认为300秒/5分钟)")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("DeviceCodeLifetime", "设备代码的生命周期(秒为单位，默认为300秒/5分钟)", "INTEGER")]
        public Int64 DeviceCodeLifetime { get { return _DeviceCodeLifetime; } set { if (OnPropertyChanging(__.DeviceCodeLifetime, value)) { _DeviceCodeLifetime = value; OnPropertyChanged(__.DeviceCodeLifetime); } } }

        private String _Created;
        /// <summary>创建</summary>
        [DisplayName("创建")]
        [Description("创建")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Created", "创建", "TEXT")]
        public String Created { get { return _Created; } set { if (OnPropertyChanging(__.Created, value)) { _Created = value; OnPropertyChanged(__.Created); } } }

        private String _Updated;
        /// <summary>更新</summary>
        [DisplayName("更新")]
        [Description("更新")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("Updated", "更新", "TEXT")]
        public String Updated { get { return _Updated; } set { if (OnPropertyChanging(__.Updated, value)) { _Updated = value; OnPropertyChanged(__.Updated); } } }

        private DateTime _LastAccessed;
        /// <summary>上次授权时间</summary>
        [DisplayName("上次授权时间")]
        [Description("上次授权时间")]
        [DataObjectField(false, false, true, 0)]
        [BindColumn("LastAccessed", "上次授权时间", "")]
        public DateTime LastAccessed { get { return _LastAccessed; } set { if (OnPropertyChanging(__.LastAccessed, value)) { _LastAccessed = value; OnPropertyChanged(__.LastAccessed); } } }

        private Boolean _NonEditable;
        /// <summary>不可编辑</summary>
        [DisplayName("不可编辑")]
        [Description("不可编辑")]
        [DataObjectField(false, false, false, 0)]
        [BindColumn("NonEditable", "不可编辑", "")]
        public Boolean NonEditable { get { return _NonEditable; } set { if (OnPropertyChanging(__.NonEditable, value)) { _NonEditable = value; OnPropertyChanged(__.NonEditable); } } }
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
                    case __.Id : return _Id;
                    case __.Enabled : return _Enabled;
                    case __.ClientId : return _ClientId;
                    case __.ProtocolType : return _ProtocolType;
                    case __.RequireClientSecret : return _RequireClientSecret;
                    case __.RequirePkce : return _RequirePkce;
                    case __.AllowPlainTextPkce : return _AllowPlainTextPkce;
                    case __.AllowOfflineAccess : return _AllowOfflineAccess;
                    case __.AllowAccessTokensViaBrowser : return _AllowAccessTokensViaBrowser;
                    case __.FrontChannelLogoutUri : return _FrontChannelLogoutUri;
                    case __.FrontChannelLogoutSessionRequired : return _FrontChannelLogoutSessionRequired;
                    case __.BackChannelLogoutUri : return _BackChannelLogoutUri;
                    case __.BackChannelLogoutSessionRequired : return _BackChannelLogoutSessionRequired;
                    case __.EnableLocalLogin : return _EnableLocalLogin;
                    case __.UserSsoLifetime : return _UserSsoLifetime;
                    case __.IdentityTokenLifetime : return _IdentityTokenLifetime;
                    case __.AccessTokenLifetime : return _AccessTokenLifetime;
                    case __.AuthorizationCodeLifetime : return _AuthorizationCodeLifetime;
                    case __.AbsoluteRefreshTokenLifetime : return _AbsoluteRefreshTokenLifetime;
                    case __.SlidingRefreshTokenLifetime : return _SlidingRefreshTokenLifetime;
                    case __.RefreshTokenUsage : return _RefreshTokenUsage;
                    case __.RefreshTokenExpiration : return _RefreshTokenExpiration;
                    case __.UpdateAccessTokenClaimsOnRefresh : return _UpdateAccessTokenClaimsOnRefresh;
                    case __.AccessTokenType : return _AccessTokenType;
                    case __.IncludeJwtId : return _IncludeJwtId;
                    case __.AlwaysSendClientClaims : return _AlwaysSendClientClaims;
                    case __.AlwaysIncludeUserClaimsInIdToken : return _AlwaysIncludeUserClaimsInIdToken;
                    case __.ClientClaimsPrefix : return _ClientClaimsPrefix;
                    case __.PairWiseSubjectSalt : return _PairWiseSubjectSalt;
                    case __.RequireConsent : return _RequireConsent;
                    case __.AllowRememberConsent : return _AllowRememberConsent;
                    case __.ConsentLifetime : return _ConsentLifetime;
                    case __.ClientName : return _ClientName;
                    case __.Description : return _Description;
                    case __.ClientUri : return _ClientUri;
                    case __.LogoUri : return _LogoUri;
                    case __.UserCodeType : return _UserCodeType;
                    case __.DeviceCodeLifetime : return _DeviceCodeLifetime;
                    case __.Created : return _Created;
                    case __.Updated : return _Updated;
                    case __.LastAccessed : return _LastAccessed;
                    case __.NonEditable : return _NonEditable;
                    default: return base[name];
                }
            }
            set
            {
                switch (name)
                {
                    case __.Id : _Id = value.ToInt(); break;
                    case __.Enabled : _Enabled = value.ToBoolean(); break;
                    case __.ClientId : _ClientId = Convert.ToString(value); break;
                    case __.ProtocolType : _ProtocolType = Convert.ToString(value); break;
                    case __.RequireClientSecret : _RequireClientSecret = value.ToBoolean(); break;
                    case __.RequirePkce : _RequirePkce = value.ToBoolean(); break;
                    case __.AllowPlainTextPkce : _AllowPlainTextPkce = value.ToBoolean(); break;
                    case __.AllowOfflineAccess : _AllowOfflineAccess = value.ToBoolean(); break;
                    case __.AllowAccessTokensViaBrowser : _AllowAccessTokensViaBrowser = value.ToBoolean(); break;
                    case __.FrontChannelLogoutUri : _FrontChannelLogoutUri = Convert.ToString(value); break;
                    case __.FrontChannelLogoutSessionRequired : _FrontChannelLogoutSessionRequired = value.ToBoolean(); break;
                    case __.BackChannelLogoutUri : _BackChannelLogoutUri = Convert.ToString(value); break;
                    case __.BackChannelLogoutSessionRequired : _BackChannelLogoutSessionRequired = value.ToBoolean(); break;
                    case __.EnableLocalLogin : _EnableLocalLogin = value.ToBoolean(); break;
                    case __.UserSsoLifetime : _UserSsoLifetime = value.ToLong(); break;
                    case __.IdentityTokenLifetime : _IdentityTokenLifetime = value.ToLong(); break;
                    case __.AccessTokenLifetime : _AccessTokenLifetime = value.ToLong(); break;
                    case __.AuthorizationCodeLifetime : _AuthorizationCodeLifetime = value.ToLong(); break;
                    case __.AbsoluteRefreshTokenLifetime : _AbsoluteRefreshTokenLifetime = value.ToLong(); break;
                    case __.SlidingRefreshTokenLifetime : _SlidingRefreshTokenLifetime = value.ToLong(); break;
                    case __.RefreshTokenUsage : _RefreshTokenUsage = (IdentityServer4.Models.TokenUsage)value.ToInt(); break;
                    case __.RefreshTokenExpiration : _RefreshTokenExpiration = (IdentityServer4.Models.TokenExpiration)value.ToInt(); break;
                    case __.UpdateAccessTokenClaimsOnRefresh : _UpdateAccessTokenClaimsOnRefresh = value.ToBoolean(); break;
                    case __.AccessTokenType : _AccessTokenType = (IdentityServer4.Models.AccessTokenType)value.ToInt(); break;
                    case __.IncludeJwtId : _IncludeJwtId = value.ToBoolean(); break;
                    case __.AlwaysSendClientClaims : _AlwaysSendClientClaims = value.ToBoolean(); break;
                    case __.AlwaysIncludeUserClaimsInIdToken : _AlwaysIncludeUserClaimsInIdToken = value.ToBoolean(); break;
                    case __.ClientClaimsPrefix : _ClientClaimsPrefix = Convert.ToString(value); break;
                    case __.PairWiseSubjectSalt : _PairWiseSubjectSalt = Convert.ToString(value); break;
                    case __.RequireConsent : _RequireConsent = value.ToBoolean(); break;
                    case __.AllowRememberConsent : _AllowRememberConsent = value.ToBoolean(); break;
                    case __.ConsentLifetime : _ConsentLifetime = value.ToLong(); break;
                    case __.ClientName : _ClientName = Convert.ToString(value); break;
                    case __.Description : _Description = Convert.ToString(value); break;
                    case __.ClientUri : _ClientUri = Convert.ToString(value); break;
                    case __.LogoUri : _LogoUri = Convert.ToString(value); break;
                    case __.UserCodeType : _UserCodeType = Convert.ToString(value); break;
                    case __.DeviceCodeLifetime : _DeviceCodeLifetime = value.ToLong(); break;
                    case __.Created : _Created = Convert.ToString(value); break;
                    case __.Updated : _Updated = Convert.ToString(value); break;
                    case __.LastAccessed : _LastAccessed = value.ToDateTime(); break;
                    case __.NonEditable : _NonEditable = value.ToBoolean(); break;
                    default: base[name] = value; break;
                }
            }
        }
        #endregion

        #region 字段名
        /// <summary>取得Clients字段信息的快捷方式</summary>
        public partial class _
        {
            /// <summary></summary>
            public static readonly Field Id = FindByName(__.Id);

            /// <summary>启用(默认为true)</summary>
            public static readonly Field Enabled = FindByName(__.Enabled);

            /// <summary>客户端ID(应用程序的唯一识别标识)</summary>
            public static readonly Field ClientId = FindByName(__.ClientId);

            /// <summary>协议类型(默认oidc)</summary>
            public static readonly Field ProtocolType = FindByName(__.ProtocolType);

            /// <summary>需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)</summary>
            public static readonly Field RequireClientSecret = FindByName(__.RequireClientSecret);

            /// <summary>校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)</summary>
            public static readonly Field RequirePkce = FindByName(__.RequirePkce);

            /// <summary>允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)</summary>
            public static readonly Field AllowPlainTextPkce = FindByName(__.AllowPlainTextPkce);

            /// <summary>允许刷新token(需要offline_access范围scope)</summary>
            public static readonly Field AllowOfflineAccess = FindByName(__.AllowOfflineAccess);

            /// <summary>允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)</summary>
            public static readonly Field AllowAccessTokensViaBrowser = FindByName(__.AllowAccessTokensViaBrowser);

            /// <summary>客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)</summary>
            public static readonly Field FrontChannelLogoutUri = FindByName(__.FrontChannelLogoutUri);

            /// <summary>发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)</summary>
            public static readonly Field FrontChannelLogoutSessionRequired = FindByName(__.FrontChannelLogoutSessionRequired);

            /// <summary>客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)</summary>
            public static readonly Field BackChannelLogoutUri = FindByName(__.BackChannelLogoutUri);

            /// <summary>发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)</summary>
            public static readonly Field BackChannelLogoutSessionRequired = FindByName(__.BackChannelLogoutSessionRequired);

            /// <summary>仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)</summary>
            public static readonly Field EnableLocalLogin = FindByName(__.EnableLocalLogin);

            /// <summary>用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)</summary>
            public static readonly Field UserSsoLifetime = FindByName(__.UserSsoLifetime);

            /// <summary>识别令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public static readonly Field IdentityTokenLifetime = FindByName(__.IdentityTokenLifetime);

            /// <summary>访问令牌生命周期(秒为单位，默认为3600秒/1小时)</summary>
            public static readonly Field AccessTokenLifetime = FindByName(__.AccessTokenLifetime);

            /// <summary>访问令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public static readonly Field AuthorizationCodeLifetime = FindByName(__.AuthorizationCodeLifetime);

            /// <summary>刷新令牌生命周期(秒为单位，默认为2592000秒/30天)</summary>
            public static readonly Field AbsoluteRefreshTokenLifetime = FindByName(__.AbsoluteRefreshTokenLifetime);

            /// <summary>滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)</summary>
            public static readonly Field SlidingRefreshTokenLifetime = FindByName(__.SlidingRefreshTokenLifetime);

            /// <summary>刷新令牌句柄是否保持不变(ReUse，OneTime)</summary>
            public static readonly Field RefreshTokenUsage = FindByName(__.RefreshTokenUsage);

            /// <summary>刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)</summary>
            public static readonly Field RefreshTokenExpiration = FindByName(__.RefreshTokenExpiration);

            /// <summary>更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)</summary>
            public static readonly Field UpdateAccessTokenClaimsOnRefresh = FindByName(__.UpdateAccessTokenClaimsOnRefresh);

            /// <summary>访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)</summary>
            public static readonly Field AccessTokenType = FindByName(__.AccessTokenType);

            /// <summary>是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)</summary>
            public static readonly Field IncludeJwtId = FindByName(__.IncludeJwtId);

            /// <summary>发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)</summary>
            public static readonly Field AlwaysSendClientClaims = FindByName(__.AlwaysSendClientClaims);

            /// <summary>用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)</summary>
            public static readonly Field AlwaysIncludeUserClaimsInIdToken = FindByName(__.AlwaysIncludeUserClaimsInIdToken);

            /// <summary>客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)</summary>
            public static readonly Field ClientClaimsPrefix = FindByName(__.ClientClaimsPrefix);

            /// <summary>生成成对subjectId使用的盐值</summary>
            public static readonly Field PairWiseSubjectSalt = FindByName(__.PairWiseSubjectSalt);

            /// <summary>需要同意(默认为true)</summary>
            public static readonly Field RequireConsent = FindByName(__.RequireConsent);

            /// <summary>存储同意决策(默认true)</summary>
            public static readonly Field AllowRememberConsent = FindByName(__.AllowRememberConsent);

            /// <summary>用户同意的生命周期(默认null，无到期)</summary>
            public static readonly Field ConsentLifetime = FindByName(__.ConsentLifetime);

            /// <summary>显示名称</summary>
            public static readonly Field ClientName = FindByName(__.ClientName);

            /// <summary>说明</summary>
            public static readonly Field Description = FindByName(__.Description);

            /// <summary>客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)</summary>
            public static readonly Field ClientUri = FindByName(__.ClientUri);

            /// <summary>客户端logo地址(在同意页面上使用)</summary>
            public static readonly Field LogoUri = FindByName(__.LogoUri);

            /// <summary>设备流用户代码的类型</summary>
            public static readonly Field UserCodeType = FindByName(__.UserCodeType);

            /// <summary>设备代码的生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public static readonly Field DeviceCodeLifetime = FindByName(__.DeviceCodeLifetime);

            /// <summary>创建</summary>
            public static readonly Field Created = FindByName(__.Created);

            /// <summary>更新</summary>
            public static readonly Field Updated = FindByName(__.Updated);

            /// <summary>上次授权时间</summary>
            public static readonly Field LastAccessed = FindByName(__.LastAccessed);

            /// <summary>不可编辑</summary>
            public static readonly Field NonEditable = FindByName(__.NonEditable);

            static Field FindByName(String name) { return Meta.Table.FindByName(name); }
        }

        /// <summary>取得Clients字段名称的快捷方式</summary>
        public partial class __
        {
            /// <summary></summary>
            public const String Id = "Id";

            /// <summary>启用(默认为true)</summary>
            public const String Enabled = "Enabled";

            /// <summary>客户端ID(应用程序的唯一识别标识)</summary>
            public const String ClientId = "ClientId";

            /// <summary>协议类型(默认oidc)</summary>
            public const String ProtocolType = "ProtocolType";

            /// <summary>需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)</summary>
            public const String RequireClientSecret = "RequireClientSecret";

            /// <summary>校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)</summary>
            public const String RequirePkce = "RequirePkce";

            /// <summary>允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)</summary>
            public const String AllowPlainTextPkce = "AllowPlainTextPkce";

            /// <summary>允许刷新token(需要offline_access范围scope)</summary>
            public const String AllowOfflineAccess = "AllowOfflineAccess";

            /// <summary>允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)</summary>
            public const String AllowAccessTokensViaBrowser = "AllowAccessTokensViaBrowser";

            /// <summary>客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)</summary>
            public const String FrontChannelLogoutUri = "FrontChannelLogoutUri";

            /// <summary>发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)</summary>
            public const String FrontChannelLogoutSessionRequired = "FrontChannelLogoutSessionRequired";

            /// <summary>客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)</summary>
            public const String BackChannelLogoutUri = "BackChannelLogoutUri";

            /// <summary>发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)</summary>
            public const String BackChannelLogoutSessionRequired = "BackChannelLogoutSessionRequired";

            /// <summary>仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)</summary>
            public const String EnableLocalLogin = "EnableLocalLogin";

            /// <summary>用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)</summary>
            public const String UserSsoLifetime = "UserSsoLifetime";

            /// <summary>识别令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public const String IdentityTokenLifetime = "IdentityTokenLifetime";

            /// <summary>访问令牌生命周期(秒为单位，默认为3600秒/1小时)</summary>
            public const String AccessTokenLifetime = "AccessTokenLifetime";

            /// <summary>访问令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public const String AuthorizationCodeLifetime = "AuthorizationCodeLifetime";

            /// <summary>刷新令牌生命周期(秒为单位，默认为2592000秒/30天)</summary>
            public const String AbsoluteRefreshTokenLifetime = "AbsoluteRefreshTokenLifetime";

            /// <summary>滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)</summary>
            public const String SlidingRefreshTokenLifetime = "SlidingRefreshTokenLifetime";

            /// <summary>刷新令牌句柄是否保持不变(ReUse，OneTime)</summary>
            public const String RefreshTokenUsage = "RefreshTokenUsage";

            /// <summary>刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)</summary>
            public const String RefreshTokenExpiration = "RefreshTokenExpiration";

            /// <summary>更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)</summary>
            public const String UpdateAccessTokenClaimsOnRefresh = "UpdateAccessTokenClaimsOnRefresh";

            /// <summary>访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)</summary>
            public const String AccessTokenType = "AccessTokenType";

            /// <summary>是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)</summary>
            public const String IncludeJwtId = "IncludeJwtId";

            /// <summary>发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)</summary>
            public const String AlwaysSendClientClaims = "AlwaysSendClientClaims";

            /// <summary>用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)</summary>
            public const String AlwaysIncludeUserClaimsInIdToken = "AlwaysIncludeUserClaimsInIdToken";

            /// <summary>客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)</summary>
            public const String ClientClaimsPrefix = "ClientClaimsPrefix";

            /// <summary>生成成对subjectId使用的盐值</summary>
            public const String PairWiseSubjectSalt = "PairWiseSubjectSalt";

            /// <summary>需要同意(默认为true)</summary>
            public const String RequireConsent = "RequireConsent";

            /// <summary>存储同意决策(默认true)</summary>
            public const String AllowRememberConsent = "AllowRememberConsent";

            /// <summary>用户同意的生命周期(默认null，无到期)</summary>
            public const String ConsentLifetime = "ConsentLifetime";

            /// <summary>显示名称</summary>
            public const String ClientName = "ClientName";

            /// <summary>说明</summary>
            public const String Description = "Description";

            /// <summary>客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)</summary>
            public const String ClientUri = "ClientUri";

            /// <summary>客户端logo地址(在同意页面上使用)</summary>
            public const String LogoUri = "LogoUri";

            /// <summary>设备流用户代码的类型</summary>
            public const String UserCodeType = "UserCodeType";

            /// <summary>设备代码的生命周期(秒为单位，默认为300秒/5分钟)</summary>
            public const String DeviceCodeLifetime = "DeviceCodeLifetime";

            /// <summary>创建</summary>
            public const String Created = "Created";

            /// <summary>更新</summary>
            public const String Updated = "Updated";

            /// <summary>上次授权时间</summary>
            public const String LastAccessed = "LastAccessed";

            /// <summary>不可编辑</summary>
            public const String NonEditable = "NonEditable";
        }
        #endregion
    }

    /// <summary>接口</summary>
    public partial interface IClients
    {
        #region 属性
        /// <summary></summary>
        Int32 Id { get; set; }

        /// <summary>启用(默认为true)</summary>
        Boolean Enabled { get; set; }

        /// <summary>客户端ID(应用程序的唯一识别标识)</summary>
        String ClientId { get; set; }

        /// <summary>协议类型(默认oidc)</summary>
        String ProtocolType { get; set; }

        /// <summary>需要密钥(指定此客户端是否需要密钥才能从令牌端点请求令牌（默认为true）)</summary>
        Boolean RequireClientSecret { get; set; }

        /// <summary>校验密钥(使用基于授权代码authorization_code的授权类型的客户端是否必须发送校验密钥)</summary>
        Boolean RequirePkce { get; set; }

        /// <summary>允许纯文本密钥(指定是否可以使用文本方法发送证明密钥（不推荐，默认false）)</summary>
        Boolean AllowPlainTextPkce { get; set; }

        /// <summary>允许刷新token(需要offline_access范围scope)</summary>
        Boolean AllowOfflineAccess { get; set; }

        /// <summary>允许通过浏览器接收token(这对于强化允许多种响应类型的流很有用（例如，不允许使用代码id_token添加令牌响应类型的混合流客户端，从而将令牌泄漏到浏览器中）)</summary>
        Boolean AllowAccessTokensViaBrowser { get; set; }

        /// <summary>客户端前端注销URI(用于基于HTTP的前端通道注销。有关详细信息，请参阅 https://openid.net/specs/openid-connect-frontchannel-1_0.html)</summary>
        String FrontChannelLogoutUri { get; set; }

        /// <summary>发送会话id到前端注销URI(是否应将用户的会话ID发送到FrontChannelLogoutUri。默认为true)</summary>
        Boolean FrontChannelLogoutSessionRequired { get; set; }

        /// <summary>客户端注销URI(用于基于HTTP的反向通道注销。有关更多详细信息，请参阅 https://openid.net/specs/openid-connect-backchannel-1_0.html)</summary>
        String BackChannelLogoutUri { get; set; }

        /// <summary>发送会话id到注销URI(是否应在请求中将用户的会话ID发送到BackChannelLogoutUri。默认为true)</summary>
        Boolean BackChannelLogoutSessionRequired { get; set; }

        /// <summary>仅用本地登录(此客户端是否可以仅使用本地帐户或外部IdP。默认为true)</summary>
        Boolean EnableLocalLogin { get; set; }

        /// <summary>用户身份持续时间(自上次用户进行身份验证以来的最长持续时间（以秒为单位）。默认为0。您可以调整会话令牌的生命周期，以控制在使用Web应用程序时，用户需要重新输入凭据的时间和频率，而不是进行静默身份验证)</summary>
        Int64 UserSsoLifetime { get; set; }

        /// <summary>识别令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
        Int64 IdentityTokenLifetime { get; set; }

        /// <summary>访问令牌生命周期(秒为单位，默认为3600秒/1小时)</summary>
        Int64 AccessTokenLifetime { get; set; }

        /// <summary>访问令牌生命周期(秒为单位，默认为300秒/5分钟)</summary>
        Int64 AuthorizationCodeLifetime { get; set; }

        /// <summary>刷新令牌生命周期(秒为单位，默认为2592000秒/30天)</summary>
        Int64 AbsoluteRefreshTokenLifetime { get; set; }

        /// <summary>滑动刷新令牌生命周期(秒为单位，默认为1296000秒/15天)</summary>
        Int64 SlidingRefreshTokenLifetime { get; set; }

        /// <summary>刷新令牌句柄是否保持不变(ReUse，OneTime)</summary>
        IdentityServer4.Models.TokenUsage RefreshTokenUsage { get; set; }

        /// <summary>刷新令牌期限(Absolute 刷新令牌将在固定时间点到期（由AbsoluteRefreshTokenLifetime指定），Sliding刷新令牌时，将刷新刷新令牌的生命周期（按SlidingRefreshTokenLifetime中指定的数量）。生命周期不会超过AbsoluteRefreshTokenLifetime)</summary>
        IdentityServer4.Models.TokenExpiration RefreshTokenExpiration { get; set; }

        /// <summary>更新访问令牌(是否应在刷新令牌请求上更新访问令牌（及其声明）)</summary>
        Boolean UpdateAccessTokenClaimsOnRefresh { get; set; }

        /// <summary>访问令牌类型(指定访问令牌是引用令牌还是自包含JWT令牌（默认为Jwt）)</summary>
        IdentityServer4.Models.AccessTokenType AccessTokenType { get; set; }

        /// <summary>是否嵌入JwtId(指定JWT访问令牌是否应具有嵌入的唯一ID（通过jti声明）)</summary>
        Boolean IncludeJwtId { get; set; }

        /// <summary>发送客户端声明(如果设置，将为每个流发送客户端声明。如果不是，仅用于客户端凭证流（默认为false）)</summary>
        Boolean AlwaysSendClientClaims { get; set; }

        /// <summary>用户声明添加到ID令牌(当同时请求ID令牌和访问令牌时，是否应始终将用户声明添加到ID令牌，而不是重新请求客户端使用userinfo端点。默认值为false)</summary>
        Boolean AlwaysIncludeUserClaimsInIdToken { get; set; }

        /// <summary>客户端声明前缀(如果设置，客户端声明将以此为前缀。默认为client_。目的是确保它们不会意外地与用户声明冲突)</summary>
        String ClientClaimsPrefix { get; set; }

        /// <summary>生成成对subjectId使用的盐值</summary>
        String PairWiseSubjectSalt { get; set; }

        /// <summary>需要同意(默认为true)</summary>
        Boolean RequireConsent { get; set; }

        /// <summary>存储同意决策(默认true)</summary>
        Boolean AllowRememberConsent { get; set; }

        /// <summary>用户同意的生命周期(默认null，无到期)</summary>
        Int64 ConsentLifetime { get; set; }

        /// <summary>显示名称</summary>
        String ClientName { get; set; }

        /// <summary>说明</summary>
        String Description { get; set; }

        /// <summary>客户端信息url(有关客户端的更多信息的URI（在同意页面上使用）)</summary>
        String ClientUri { get; set; }

        /// <summary>客户端logo地址(在同意页面上使用)</summary>
        String LogoUri { get; set; }

        /// <summary>设备流用户代码的类型</summary>
        String UserCodeType { get; set; }

        /// <summary>设备代码的生命周期(秒为单位，默认为300秒/5分钟)</summary>
        Int64 DeviceCodeLifetime { get; set; }

        /// <summary>创建</summary>
        String Created { get; set; }

        /// <summary>更新</summary>
        String Updated { get; set; }

        /// <summary>上次授权时间</summary>
        DateTime LastAccessed { get; set; }

        /// <summary>不可编辑</summary>
        Boolean NonEditable { get; set; }
        #endregion

        #region 获取/设置 字段值
        /// <summary>获取/设置 字段值</summary>
        /// <param name="name">字段名</param>
        /// <returns></returns>
        Object this[String name] { get; set; }
        #endregion
    }
}