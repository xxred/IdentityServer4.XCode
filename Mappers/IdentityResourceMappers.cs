using IdentityServer4.Models;
using NewLife.Reflection;

namespace IdentityServer4.XCode.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for identity resources.
    /// </summary>
    public static class IdentityResourceMappers
    {
        static IdentityResourceMappers()
        {
            Mapper = new DefaultReflect();
        }

        internal static IReflect Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static IdentityResource ToModel(this XCode.Entities.IdentityResources entity)
        {
            if (entity == null)
            {
                return null;
            }

            var model = new IdentityResource();
            Mapper.Copy(model, entity);

            return model;
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static XCode.Entities.IdentityResources ToEntity(this IdentityResource model)
        {
            if (model == null)
            {
                return null;
            }

            var entity = new XCode.Entities.IdentityResources();
            Mapper.Copy(entity, model);

            return entity;
        }
    }
}