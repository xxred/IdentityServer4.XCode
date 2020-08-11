using IdentityServer4.Models;
using NewLife;
using NewLife.Log;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using XCode;

namespace IdentityServer4.XCode.Entities
{
    /// <summary>
    /// 设备类型
    /// </summary>
    public enum ClientType
    {
        /// <summary>
        /// 空，默认
        /// </summary>
        Empty = 0,
        /// <summary>
        /// Web 应用程序 - 服务器端 混合流
        /// </summary>
        WebHybrid = 1,
        /// <summary>
        /// 单页应用程序 - Javascript Authorization Code Flow with PKCE
        /// </summary>
        Spa = 2,
        /// <summary>
        /// 原生应用程序 - 移动/桌面 混合流
        /// </summary>
        Native = 3,
        /// <summary>
        /// 机械/机器人 资源所有者密码和客户端凭据流
        /// </summary>
        Machine = 4,
        /// <summary>
        /// 电视和限制输入设备应用程序 设备流程
        /// </summary>
        Device = 5
    }

    /// <summary></summary>
    [ModelCheckMode(ModelCheckModes.CheckTableWhenFirstUse)]
    public partial class Clients : Entity<Clients>
    {
        #region 对象操作
        static Clients()
        {
            // 累加字段
            //var df = Meta.Factory.AdditionalFields;
            //df.Add(__.Enabled);

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (ClientId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ClientId), "ClientId不能为空！");
            if (ProtocolType.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ProtocolType), "ProtocolType不能为空！");
            if (ClientName.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ClientName), "ClientName不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正

            // 检查唯一索引
            // CheckExist(isNew, __.ClientId);
        }

        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            if (Meta.Session.Count > 0) return;

            if (XTrace.Debug) XTrace.WriteLine("开始初始化Clients[Clients]数据……");

            var entity = new Clients();
            entity.Id = 1;
            entity.Enabled = true;
            entity.ClientId = "client";
            entity.ProtocolType = "oidc";
            entity.RequireClientSecret = true;
            entity.ClientName = "client";
            entity.Description = "client";
            entity.ClientUri = null;
            entity.LogoUri = null;
            entity.RequireConsent = false;
            entity.AllowRememberConsent = true;
            entity.AlwaysIncludeUserClaimsInIdToken = false;
            entity.RequirePkce = false;
            entity.AllowPlainTextPkce = false;
            entity.AllowAccessTokensViaBrowser = false;
            entity.FrontChannelLogoutUri = null;
            entity.FrontChannelLogoutSessionRequired = false;
            entity.BackChannelLogoutUri = null;
            entity.BackChannelLogoutSessionRequired = false;
            entity.AllowOfflineAccess = false;
            entity.IdentityTokenLifetime = 300;
            entity.AccessTokenLifetime = 3600;
            entity.AuthorizationCodeLifetime = 300;
            entity.ConsentLifetime = 300;
            entity.AbsoluteRefreshTokenLifetime = 2592000;
            entity.SlidingRefreshTokenLifetime = 1296000;
            entity.RefreshTokenUsage = TokenUsage.ReUse;
            entity.UpdateAccessTokenClaimsOnRefresh = false;
            entity.RefreshTokenExpiration = TokenExpiration.Sliding;
            entity.AccessTokenType = AccessTokenType.Jwt;
            entity.EnableLocalLogin = true;
            entity.IncludeJwtId = true;
            entity.AlwaysSendClientClaims = false;
            entity.ClientClaimsPrefix = "client_";
            entity.PairWiseSubjectSalt = null;
            entity.Created = "admin";
            entity.Updated = "admin";
            entity.LastAccessed = DateTime.MinValue;
            entity.UserSsoLifetime = 30000;
            entity.UserCodeType = null;
            entity.DeviceCodeLifetime = 300;
            entity.NonEditable = false;
            entity.Insert();

            if (XTrace.Debug) XTrace.WriteLine("完成初始化Clients[Clients]数据！");
        }

        ///// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        ///// <returns></returns>
        //public override Int32 Insert()
        //{
        //    return base.Insert();
        //}

        ///// <summary>已重载。在事务保护范围内处理业务，位于Valid之后</summary>
        ///// <returns></returns>
        //protected override Int32 OnDelete()
        //{
        //    return base.OnDelete();
        //}
        #endregion

        #region 扩展属性

        /// <summary>
        /// 设备类型，用于前端传值，根据类型进行设置
        /// </summary>
        public ClientType ClientType { get; set; }

        public ICollection<Secret> _ClientSecrets;
        /// <summary>
        /// Client secrets - only relevant for flows that require a secret
        /// </summary>
        public ICollection<Secret> ClientSecrets
        {
            get =>
                        Entities.ClientSecrets.FindAllByClientId(Id)
                        .Select(s => new Secret(s.Value, s.Description, s.Expiration)
                        {
                            Type = s.Type
                        }).ToList();
            set => _ClientSecrets = value;
        }

        /// <summary>
        /// Specifies the allowed grant types (legal combinations of AuthorizationCode, Implicit, Hybrid, ResourceOwner, ClientCredentials).
        /// </summary>
        public ICollection<string> AllowedGrantTypes =>
            ClientGrantTypes.FindAllByClientId(Id)
                .Select(s => s.GrantType)
                .ToList();

        public ICollection<string> _RedirectUris;
        /// <summary>
        /// Specifies allowed URIs to return tokens or authorization codes to
        /// </summary>
        public ICollection<string> RedirectUris
        {
            get
            {
                return ClientRedirectUris.FindAllByClientId(Id)
                    .Select(s => s.RedirectUri)
                    .ToList();
            }
            set => _RedirectUris = value;
        }


        /// <summary>
        /// Specifies allowed URIs to redirect to after logout
        /// </summary>
        private ICollection<string> _postLogoutRedirectUris;
        /// <summary>
        /// Specifies allowed URIs to redirect to after logout
        /// </summary>
        public ICollection<string> PostLogoutRedirectUris
        {
            get =>
                ClientPostLogoutRedirectUris.FindAllByClientId(Id)
                    .Select(s => s.PostLogoutRedirectUri)
                    .ToList();
            set => _postLogoutRedirectUris = value;
        }

        /// <summary>
        /// Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope
        /// </summary>
        private ICollection<string> _allowedScopes;
        /// <summary>
        /// Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope
        /// </summary>
        public ICollection<string> AllowedScopes
        {
            get =>
                ClientScopes.FindAllByClientId(Id)
                    .Select(s => s.Scope)
                    .ToList();
            set => _allowedScopes = value;
        }

        /// <summary>
        /// Specifies which external IdPs can be used with this client (if list is empty all IdPs are allowed). Defaults to empty.
        /// </summary>
        private ICollection<string> _identityProviderRestrictions;
        /// <summary>
        /// Specifies which external IdPs can be used with this client (if list is empty all IdPs are allowed). Defaults to empty.
        /// </summary>
        public ICollection<string> IdentityProviderRestrictions
        {
            get =>
                ClientIdPRestrictions.FindAllByClientId(Id)
                    .Select(s => s.Provider)
                    .ToList();
            set => _identityProviderRestrictions = value;
        }

        /// <summary>
        /// Allows settings claims for the client (will be included in the access token).
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        private ICollection<Claim> _claims;
        /// <summary>
        /// Allows settings claims for the client (will be included in the access token).
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public ICollection<Claim> Claims
        {
            get =>
                ClientClaims.FindAllByClientId(Id)
                    .Select(s => new Claim(s.Type, s.Value))
                    .ToList();
            set => _claims = value;
        }

        /// <summary>
        /// Gets or sets the allowed CORS origins for JavaScript clients.
        /// </summary>
        /// <value>
        /// The allowed CORS origins.
        /// </value>
        private ICollection<string> _allowedCorsOrigins;
        /// <summary>
        /// Gets or sets the allowed CORS origins for JavaScript clients.
        /// </summary>
        /// <value>
        /// The allowed CORS origins.
        /// </value>
        public ICollection<string> AllowedCorsOrigins
        {
            get =>
                ClientCorsOrigins.FindAllByClientId(Id)
                    .Select(s => s.Origin)
                    .ToList();
            set => _allowedCorsOrigins = value;
        }

        /// <summary>
        /// Gets or sets the custom properties for the client.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        private IDictionary<string, string> _properties;
        /// <summary>
        /// Gets or sets the custom properties for the client.
        /// </summary>
        /// <value>
        /// The properties.
        /// </value>
        public IDictionary<string, string> Properties
        {
            get
            {
                var dic = new Dictionary<string, string>();
                var list = ClientProperties.FindAllByClientId(Id);
                foreach (var item in list)
                {
                    dic[item.Key] = item.Value;
                }

                return dic;
            }
            set { _properties = value; }
        }
        #endregion

        #region 扩展查询
        /// <summary>根据Id查找</summary>
        /// <param name="id">Id</param>
        /// <returns>实体对象</returns>
        public static Clients FindById(Int32 id)
        {
            if (id <= 0) return null;

            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.Id == id);

            // 单对象缓存
            return Meta.SingleCache[id];

            //return Find(_.Id == id);
        }

        /// <summary>根据ClientId查找</summary>
        /// <param name="clientid">ClientId</param>
        /// <returns>实体对象</returns>
        public static Clients FindByClientId(String clientid)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.Find(e => e.ClientId == clientid);

            return Find(_.ClientId == clientid);
        }
        #endregion

        #region 高级查询
        #endregion

        #region 业务操作
        /// <summary>
        /// 重载插入，根据客户端类型处理
        /// </summary>
        /// <returns></returns>
        public override int Insert()
        {
            if (ClientId.IsNullOrWhiteSpace())
            {
                ClientId = Guid.NewGuid().ToString().Replace("-", "");
            }

            if (ProtocolType.IsNullOrWhiteSpace())
            {
                ProtocolType = "oidc";
            }

            {
                Enabled = true;
                RequireClientSecret = true;
                RequireConsent = true;
                AllowRememberConsent = true;
                AlwaysIncludeUserClaimsInIdToken = false;
                RequirePkce = false;
                AllowPlainTextPkce = false;
                AllowAccessTokensViaBrowser = false;
                FrontChannelLogoutUri = null;
                FrontChannelLogoutSessionRequired = true;
                BackChannelLogoutUri = null;
                BackChannelLogoutSessionRequired = true;
                AllowOfflineAccess = false;
                IdentityTokenLifetime = 300;
                AccessTokenLifetime = 3600;
                AuthorizationCodeLifetime = 300;
                ConsentLifetime = 300;
                AbsoluteRefreshTokenLifetime = 2592000;
                SlidingRefreshTokenLifetime = 1296000;
                RefreshTokenUsage = TokenUsage.ReUse;
                UpdateAccessTokenClaimsOnRefresh = false;
                RefreshTokenExpiration = TokenExpiration.Sliding;
                AccessTokenType = AccessTokenType.Jwt;
                EnableLocalLogin = true;
                IncludeJwtId = true;
                AlwaysSendClientClaims = false;
                ClientClaimsPrefix = "client_";
                PairWiseSubjectSalt = null;
                LastAccessed = DateTime.MinValue;
                UserSsoLifetime = 30000;
                UserCodeType = null;
                DeviceCodeLifetime = 300;
                NonEditable = false;
            }

            var client = this;

            switch (client.ClientType)
            {
                case ClientType.Empty:
                    break;
                case ClientType.WebHybrid:
                    break;
                case ClientType.Spa:
                    client.RequirePkce = true;
                    client.RequireClientSecret = false;
                    break;
                case ClientType.Native:
                    break;
                case ClientType.Machine:
                    break;
                case ClientType.Device:
                    client.RequireClientSecret = false;
                    client.AllowOfflineAccess = true;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            base.Insert();

            AllowedGrantType();

            return 1;
        }

        /// <summary>
        /// 根据客户端类型设置GrantType
        /// </summary>
        public void AllowedGrantType()
        {
            var client = this;

            switch (client.ClientType)
            {
                case ClientType.Empty:
                    break;
                case ClientType.WebHybrid:
                    SaveGrantType(GrantTypes.Hybrid);
                    break;
                case ClientType.Spa:
                    SaveGrantType(GrantTypes.Code);
                    break;
                case ClientType.Native:
                    SaveGrantType(GrantTypes.Hybrid);
                    break;
                case ClientType.Machine:
                    SaveGrantType(GrantTypes.ResourceOwnerPasswordAndClientCredentials);
                    break;
                case ClientType.Device:
                    SaveGrantType(GrantTypes.DeviceFlow);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void SaveGrantType(ICollection<string> grantTypes)
        {
            foreach (var item in grantTypes)
            {
                var grantType = new ClientGrantTypes();
                grantType.ClientId = Id;
                grantType.GrantType = item;
                grantType.Save();
            }
        }

        /// <summary>
        /// 重载更新，处理关联表数据
        /// </summary>
        /// <returns></returns>
        public override int Update()
        {
            base.Update();

            var old = FindById(Id);

            UpdateScopes(old);
            UpdateRedirectUris(old);
            UpdateGrantTypes(old);
            UpdatePostLogoutRedirectUris(old);
            UpdateIdentityProviderRestrictions(old);
            UpdateAllowedCorsOrigins(old);

            return 1;
        }

        public void UpdateScopes(Clients old)
        {
            var oldScopes = old.AllowedScopes;
            foreach (var scope in AllowedScopes)
            {
                if (oldScopes.Contains(scope))
                {
                    // 旧的移出列表
                    oldScopes.Remove(scope);
                }
                else
                {
                    // 新的添加
                    new ClientScopes()
                    {
                        ClientId = Id,
                        Scope = scope
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var oldScope in oldScopes)
            {
                ClientScopes.Find(
                    ClientScopes._.ClientId == Id & 
                    ClientScopes._.Scope == oldScope)
                    ?.Delete();
            }
        }

        public void UpdateRedirectUris(Clients client)
        {
            var olds = client.RedirectUris;
            foreach (var newItem in RedirectUris)
            {
                if (olds.Contains(newItem))
                {
                    // 旧的移出列表
                    olds.Remove(newItem);
                }
                else
                {
                    // 新的添加
                    new ClientRedirectUris()
                    {
                        ClientId = Id,
                        RedirectUri = newItem
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var old in olds)
            {
                ClientRedirectUris.Find(
                        ClientRedirectUris._.ClientId == Id &
                        ClientRedirectUris._.RedirectUri == old)
                    ?.Delete();
            }
        }

        public void UpdateGrantTypes(Clients client)
        {
            var olds = client.AllowedGrantTypes;
            foreach (var newItem in AllowedGrantTypes)
            {
                if (olds.Contains(newItem))
                {
                    // 旧的移出列表
                    olds.Remove(newItem);
                }
                else
                {
                    // 新的添加
                    new ClientGrantTypes()
                    {
                        ClientId = Id,
                        GrantType = newItem
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var old in olds)
            {
                ClientGrantTypes.Find(
                        ClientGrantTypes._.ClientId == Id &
                        ClientGrantTypes._.GrantType == old)
                    ?.Delete();
            }
        }

        public void UpdatePostLogoutRedirectUris(Clients client)
        {
            var olds = client.PostLogoutRedirectUris;
            foreach (var newItem in PostLogoutRedirectUris)
            {
                if (olds.Contains(newItem))
                {
                    // 旧的移出列表
                    olds.Remove(newItem);
                }
                else
                {
                    // 新的添加
                    new ClientPostLogoutRedirectUris()
                    {
                        ClientId = Id,
                        PostLogoutRedirectUri = newItem
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var old in olds)
            {
                ClientPostLogoutRedirectUris.Find(
                        ClientPostLogoutRedirectUris._.ClientId == Id &
                        ClientPostLogoutRedirectUris._.PostLogoutRedirectUri == old)
                    ?.Delete();
            }
        }

        public void UpdateIdentityProviderRestrictions(Clients client)
        {
            var olds = client.IdentityProviderRestrictions;
            foreach (var newItem in IdentityProviderRestrictions)
            {
                if (olds.Contains(newItem))
                {
                    // 旧的移出列表
                    olds.Remove(newItem);
                }
                else
                {
                    // 新的添加
                    new ClientIdPRestrictions()
                    {
                        ClientId = Id,
                        Provider = newItem
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var old in olds)
            {
                ClientIdPRestrictions.Find(
                        ClientIdPRestrictions._.ClientId == Id &
                        ClientIdPRestrictions._.Provider == old)
                    ?.Delete();
            }
        }

        public void UpdateAllowedCorsOrigins(Clients client)
        {
            var olds = client.AllowedCorsOrigins;
            foreach (var newItem in AllowedCorsOrigins)
            {
                if (olds.Contains(newItem))
                {
                    // 旧的移出列表
                    olds.Remove(newItem);
                }
                else
                {
                    // 新的添加
                    new ClientCorsOrigins()
                    {
                        ClientId = Id,
                        Origin = newItem
                    }.Save();
                }
            }

            // 剩下的移除
            foreach (var old in olds)
            {
                ClientCorsOrigins.Find(
                        ClientCorsOrigins._.ClientId == Id &
                        ClientCorsOrigins._.Origin == old)
                    ?.Delete();
            }
        }

        #endregion
    }
}