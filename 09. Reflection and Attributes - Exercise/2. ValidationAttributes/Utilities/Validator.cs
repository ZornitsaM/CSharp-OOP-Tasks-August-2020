using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        //Create a static class Validator. It should contain a method 
        //- public static bool IsValid(object obj), which must validate the properties of a given object.
        public static bool IsValid(object obj)
        {
            var objType = obj.GetType();
            var propertyInfos = objType.GetProperties();

            foreach (PropertyInfo property in propertyInfos)
            {
                var allAttributes = property.GetCustomAttributes<MyValidationAttribute>();

                object propertyObj = property.GetValue(obj);

                foreach (MyValidationAttribute attribute in allAttributes)
                {
                    if (!attribute.IsValid(propertyObj))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
