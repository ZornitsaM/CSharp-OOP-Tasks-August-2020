using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameClass,string[] nameFields)
        {
            StringBuilder sb = new StringBuilder();

            var type = Type.GetType(nameClass);
            var hacker = (Hacker)Activator.CreateInstance(type);
            sb.AppendLine($"Class under investigation: {type}");

            for (int i = 0; i < nameFields.Length; i++)
            {
                string currentName = nameFields[i];
                var currentField = type.GetField(currentName, BindingFlags.Instance
                | BindingFlags.NonPublic | BindingFlags.Public);

                var valueUser = currentField.GetValue(hacker);

                sb.AppendLine($"{currentField.Name} = {valueUser}");
            }

            return sb.ToString().TrimEnd();

        }

        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            var type = Type.GetType(className);
            var hacker = Activator.CreateInstance(type);

            var fields = type.GetFields(BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
            var publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var nonPublicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
               
            }

            foreach (var method in publicMethods.Where(x=>x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} have to be private!");
            }

            foreach (var nonMethod in nonPublicMethods.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonMethod.Name} have to be public!");
            }

            return sb.ToString().TrimEnd();
        }


        public string RevealPrivateMethods(string className)
        {
            StringBuilder sb = new StringBuilder();
            var type = Type.GetType(className);

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            var privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().TrimEnd();
        }
       
    }
}
