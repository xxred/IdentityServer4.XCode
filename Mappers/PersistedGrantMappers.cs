using IdentityServer4.Models;
using IdentityServer4.XCode.Entities;
using NewLife.Reflection;

namespace IdentityServer4.XCode.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for persisted grants.
    /// </summary>
    public static class PersistedGrantMappers
    {
        static PersistedGrantMappers()
        {
            Mapper = new DefaultReflect();
        }

        internal static IReflect Mapper { get; }


        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static PersistedGrant ToModel(this PersistedGrants entity)
        {
            if (entity == null)
            {
                return null;
            }

            var model = new PersistedGrant();
            Mapper.Copy(model, entity);

            return model;
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static PersistedGrants ToEntity(this PersistedGrant model)
        {
            if (model == null)
            {
                return null;
            }


            var entity = new PersistedGrants();
            Mapper.Copy(entity, model);

            return entity;
        }

        /// <summary>
        /// Updates an entity from a model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="entity">The entity.</param>
        public static void UpdateEntity(this PersistedGrant model, PersistedGrants entity)
        {
            Mapper.Copy(entity, model);
        }
    }
}