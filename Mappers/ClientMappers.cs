using IdentityServer4.Models;
using IdentityServer4.XCode.Entities;
using NewLife.Reflection;

namespace IdentityServer4.XCode.Mappers
{
    /// <summary>
    /// Extension methods to map to/from entity/model for clients.
    /// </summary>
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new DefaultReflect();
        }

        internal static IReflect Mapper { get; }

        /// <summary>
        /// Maps an entity to a model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public static Client ToModel(this Clients entity)
        {
            if (entity == null)
            {
                return null;
            }

            var model = new Client();
            Mapper.Copy(model, entity);

            return model;
        }

        /// <summary>
        /// Maps a model to an entity.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        public static Clients ToEntity(this Client model)
        {
            if (model == null)
            {
                return null;
            }

            var entity = new Clients();
            Mapper.Copy(entity, model);

            return entity;
        }
    }
}