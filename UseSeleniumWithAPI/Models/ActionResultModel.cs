using System;
using System.Collections.Generic;
using System.Reflection;

namespace UseSeleniumWithAPI.Models
{
    public class ActionResultModel : ActionModel
    {
        public bool Success { get; set; }
        public object Data { get; set; } = new();
        public string? Error { get; set; }


        public Dictionary<string, object> GetNotNullProperties()
        {
            var result = new Dictionary<string, object>();
            var properties = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach ( var property in properties)
            {
                var value = property.GetValue(this);
                if (value is not null)
                {
                    if (!result.ContainsKey(property.Name))
                    {
                        result.Add(property.Name.ToLower(), value);
                    }
                }
            }

            return result;
        }

        
    }
}
