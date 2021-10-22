using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace ContactsRegistration.Domain.Models.Entities
{
    /// <summary>
    /// Base Entity
    /// </summary>
    public class Entity
    {
        public int? Id { get; set; }
        
        protected Entity()
        {
        }

        /// <summary>
        /// Verifies if object is Valid
        /// </summary>
        /// <returns>operation status</returns>
        public virtual Task<ValidationResult> IsValidAsync() =>
            throw new NotSupportedException();
    }
}
