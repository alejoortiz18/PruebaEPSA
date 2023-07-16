using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpsaEntities.ModelDto
{
    public class FechasDto : IValidatableObject
    {
        [Required]
        public DateTime FechaInicial { get; set; }
        
        [Required]
        public DateTime FechaFinal { get; set;}

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (FechaInicial > FechaFinal)
            {
                yield return new ValidationResult("La fecha 1 no puede ser mayor a la fecha 2");
            }
            else
            {
                yield return ValidationResult.Success;

            }
        }
    }
}
