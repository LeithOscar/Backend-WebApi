
namespace Api.BussinesLogical
{

    using Api.BussinesLogical.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;



    public class BookValidationRules: IBookValidationRules
    {
        public List<ValidationResult> ValidationResultItems { get; set; }
        public BookValidationRules()
        {
            this.ValidationResultItems= new List<ValidationResult>();
        }
        public List<ValidationResult> ValidateId(object value)
        {
            try
            {
                if ((long)value < 0)
                {
                     this.ValidationResultItems.Add( new ValidationResult($"The id cannot be less than zero"));
                }
            }
            catch (Exception ex)
            {
                this.ValidationResultItems.Add(new ValidationResult($"Error: {ex}"));
            }

            return this.ValidationResultItems;
        }
    }

}
