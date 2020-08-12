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
    public partial class PersistedGrants : Entity<PersistedGrants>
    {
        #region 对象操作
        static PersistedGrants()
        {

            // 过滤器 UserModule、TimeModule、IPModule
        }

        /// <summary>验证数据，通过抛出异常的方式提示验证失败。</summary>
        /// <param name="isNew">是否插入</param>
        public override void Valid(Boolean isNew)
        {
            // 如果没有脏数据，则不需要进行任何处理
            if (!HasDirty) return;

            // 这里验证参数范围，建议抛出参数异常，指定参数名，前端用户界面可以捕获参数异常并聚焦到对应的参数输入框
            if (Key.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Key), "Key不能为空！");
            if (Type.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Type), "Type不能为空！");
            if (SubjectId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(SubjectId), "SubjectId不能为空！");
            if (ClientId.IsNullOrEmpty()) throw new ArgumentNullException(nameof(ClientId), "ClientId不能为空！");
            if (Data.IsNullOrEmpty()) throw new ArgumentNullException(nameof(Data), "Data不能为空！");

            // 在新插入数据或者修改了指定字段时进行修正
        }

        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    if (Meta.Session.Count > 0) return;

        //    if (XTrace.Debug) XTrace.WriteLine("开始初始化PersistedGrants[PersistedGrants]数据……");

        //    var entity = new PersistedGrants();
        //    entity.Key = "abc";
        //    entity.Type = "abc";
        //    entity.SubjectId = "abc";
        //    entity.ClientId = "abc";
        //    entity.CreationTime = "abc";
        //    entity.Expiration = "abc";
        //    entity.Data = "abc";
        //    entity.Insert();

        //    if (XTrace.Debug) XTrace.WriteLine("完成初始化PersistedGrants[PersistedGrants]数据！");
        //}

        /// <summary>已重载。基类先调用Valid(true)验证数据，然后在事务保护内调用OnInsert</summary>
        /// <returns></returns>
        public override Int32 Insert()
        {
            CreationTime = CreationTime.ToLocalTime();
            Expiration = Expiration.ToLocalTime();

            return base.Insert();
        }

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

        /// <summary>根据Type、SubjectId、ClientId查找</summary>
        /// <param name="type">Type</param>
        /// <param name="subjectid">SubjectId</param>
        /// <param name="clientid">ClientId</param>
        /// <returns>实体列表</returns>
        public static IList<PersistedGrants> FindAllByTypeAndSubjectIdAndClientId(String type, String subjectid, String clientid)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Type == type && e.SubjectId == subjectid && e.ClientId == clientid);

            return FindAll(_.Type == type & _.SubjectId == subjectid & _.ClientId == clientid);
        }

        /// <summary>根据SubjectId、ClientId查找</summary>
        /// <param name="subjectid">SubjectId</param>
        /// <param name="clientid">ClientId</param>
        /// <returns>实体列表</returns>
        public static IList<PersistedGrants> FindAllBySubjectIdAndClientId(String subjectid, String clientid)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SubjectId == subjectid && e.ClientId == clientid);

            return FindAll(_.SubjectId == subjectid & _.ClientId == clientid);
        }

        /// <summary>根据SubjectId查找</summary>
        /// <param name="subjectid">SubjectId</param>
        /// <returns>实体列表</returns>
        public static IList<PersistedGrants> FindAllBySubjectId(String subjectid)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.SubjectId == subjectid);

            return FindAll(_.SubjectId == subjectid);
        }

        /// <summary>根据Expiration查找</summary>
        /// <param name="batchSize">批大小，每次取的数量</param>
        /// <returns>实体列表</returns>
        public static IList<PersistedGrants> FindAllByExpirationAndBatchSize(int batchSize)
        {
            // 实体缓存
            if (Meta.Session.Count < 1000) return Meta.Cache.FindAll(e => e.Expiration < DateTime.Now)
                .OrderBy(o => o.Key).Take(batchSize).ToList();

            return FindAll(_.Expiration < DateTime.Now & _.Key.Asc(), new PageParameter() { PageSize = batchSize });
        }


        #endregion

        #region 高级查询
        #endregion

        #region 业务操作
        #endregion
    }
}