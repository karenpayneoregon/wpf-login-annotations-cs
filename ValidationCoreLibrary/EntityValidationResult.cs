using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationCoreLibrary
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; set; }
        /// <summary>
        /// Indicates if validation was successful or failed
        /// </summary>
        public bool HasError => Errors.Count > 0;
        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }
}