namespace Api.BussinesLogical.Interfaces
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public interface IBookValidationRules
    {
        List<ValidationResult> ValidateId(object value);
    }
}
