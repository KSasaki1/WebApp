using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Validation
{
    public class UniqueIDAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            trdbEntities db = new trdbEntities();
            GOODSTBLsController controller = new GOODSTBLsController();

            var inputID = value;
            var check = db.GOODSTBL.Find(inputID);
            string url = HttpContext.Current.Request.Url.AbsoluteUri;

            if (url.Contains("Edit"))
            {
                return ValidationResult.Success;
            }

            if (check != null)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
}
        public string GetErrorMessage()
        {
            return $"このIDはすでに登録されているため使用できません";
        }
    }
}