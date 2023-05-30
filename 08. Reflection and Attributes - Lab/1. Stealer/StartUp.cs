using Microsoft.Win32.SafeHandles;
using Stealer;
using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            var type = typeof(Hacker);
            var hacker = new Hacker();
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            foreach (var getMethod in methods.Where(x=>x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{getMethod.Name} will return {getMethod.ReturnType}");
            }

            foreach (var setMethod in methods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{setMethod.Name} will return {setMethod.ReturnType}");
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
