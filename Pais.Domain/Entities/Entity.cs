using FluentValidation;
using FluentValidation.Results;

namespace Pais.Domain.Entities
{
    /// <summary>
    /// Entidade base
    /// </summary>
    /// <typeparam name="TipoId"></typeparam>
    public abstract class Entity<TipoId>
    {
        /// <summary>
        /// ID
        /// </summary>
        public TipoId Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Valid { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ValidationResult ValidationResult { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="model"></param>
        /// <param name="validator"></param>
        /// <returns></returns>
        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return Valid = ValidationResult.IsValid;
        }
    }
}
