using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using IdentityServer4.Models;
using NewLife;
using NewLife.Data;
using NewLife.Log;
using NewLife.Model;
using NewLife.Reflection;
using NewLife.Threading;
using NewLife.Web;
using XCode;
using XCode.Cache;
using XCode.Configuration;
using XCode.DataAccessLayer;
using XCode.Membership;

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

        /// <summary>
        /// Client secrets - only relevant for flows that require a secret
        /// </summary>
        public ICollection<Secret> ClientSecrets =>
            Entities.ClientSecrets.FindAllByClientId(Id)
            .Select(s => new Secret(s.Value, s.Description, s.Expiration)
            {
                Type = s.Type
            }).ToList();


        /// <summary>
        /// Specifies the allowed grant types (legal combinations of AuthorizationCode, Implicit, Hybrid, ResourceOwner, ClientCredentials).
        /// </summary>
        public ICollection<string> AllowedGrantTypes =>
            ClientGrantTypes.FindAllByClientId(Id)
                .Select(s => s.GrantType)
                .ToList();

        /// <summary>
        /// Specifies allowed URIs to return tokens or authorization codes to
        /// </summary>
        public ICollection<string> RedirectUris =>
            ClientRedirectUris.FindAllByClientId(Id)
                .Select(s => s.RedirectUri)
                .ToList();

        /// <summary>
        /// Specifies allowed URIs to redirect to after logout
        /// </summary>
        public ICollection<string> PostLogoutRedirectUris =>
            ClientPostLogoutRedirectUris.FindAllByClientId(Id)
                .Select(s => s.PostLogoutRedirectUri)
                .ToList();

        /// <summary>
        /// Specifies the api scopes that the client is allowed to request. If empty, the client can't access any scope
        /// </summary>
        public ICollection<string> AllowedScopes =>
            ClientScopes.FindAllByClientId(Id)
                .Select(s => s.Scope)
                .ToList();

        /// <summary>
        /// Specifies which external IdPs can be used with this client (if list is empty all IdPs are allowed). Defaults to empty.
        /// </summary>
        public ICollection<string> IdentityProviderRestrictions =>
            ClientIdPRestrictions.FindAllByClientId(Id)
                .Select(s => s.Provider)
                .ToList();

        /// <summary>
        /// Allows settings claims for the client (will be included in the access token).
        /// </summary>
        /// <value>
        /// The claims.
        /// </value>
        public ICollection<Claim> Claims =>
            ClientClaims.FindAllByClientId(Id)
                .Select(s => new Claim(s.Type, s.Value))
                .ToList();

        /// <summary>
        /// Gets or sets the allowed CORS origins for JavaScript clients.
        /// </summary>
        /// <value>
        /// The allowed CORS origins.
        /// </value>
        public ICollection<string> AllowedCorsOrigins =>
            ClientCorsOrigins.FindAllByClientId(Id)
                .Select(s => s.Origin)
                .ToList();

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

        protected override int OnInsert()
        {

            return base.OnInsert();
        }

        #endregion
    }
}