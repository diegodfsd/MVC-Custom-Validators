using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Site.Helpers
{
    public class DateRangeAttribute : ValidationAttribute, IClientValidatable
    {
        public enum ScaleRangeDate
        {
            Days,
            Months,
            Years
        }

        public ScaleRangeDate ScaleType { get; set; }
        public int? Min { get; set; }
        public int Max { get; set; }

        public DateRangeAttribute()
        {
            ScaleType = ScaleRangeDate.Days;
        }

        public override bool IsValid(object value)
        {
            var date = DateTime.Parse(value.ToString());
            return (date >= GetDate(Min) && date <= GetDate(Max));
        }

        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                           {
                               ErrorMessage = ErrorMessage,
                               ValidationType = "mvcdaterange"
                           };

            rule.ValidationParameters.Add("mindate", GetDate(Min).ToString("dd/MM/yyyy"));
            rule.ValidationParameters.Add("maxdate", GetDate(Max).ToString("dd/MM/yyyy"));

            yield return rule;
        }

        private DateTime GetDate(int? index)
        {
            if (ScaleType == ScaleRangeDate.Days)
                return index.HasValue ? DateTime.Today.AddDays(index.Value) : DateTime.MinValue;

            if (ScaleType == ScaleRangeDate.Months)
                return index.HasValue ? DateTime.Today.AddMonths(index.Value) : DateTime.MinValue;

            return index.HasValue ? DateTime.Today.AddMonths(index.Value) : DateTime.MinValue;
        }
    }
}