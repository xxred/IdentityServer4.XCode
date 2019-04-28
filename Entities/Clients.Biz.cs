using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
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
        #endregion
    }
}