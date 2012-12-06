using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Site.Helpers
{
    public class MinAgeAttribute : ValidationAttribute, IClientValidatable
    {
        public int MinAge { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var minAge = DateTime.Now.AddYears(-MinAge);
            var date = DateTime.Parse(value.ToString());

            return DateTime.Today.AddDays(-date.Subtract(minAge).TotalDays) >= minAge;
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = ErrorMessage,
                ValidationType = "mvcminage"
            };

            rule.ValidationParameters.Add("mindate", DateTime.Now.AddYears(-MinAge).ToString("dd/MM/yyyy"));
            rule.ValidationParameters.Add("minage", MinAge);
            rule.ValidationParameters.Add("today", DateTime.Today.ToString("dd/MM/yyyy"));

            yield return rule;
        }
    }
}