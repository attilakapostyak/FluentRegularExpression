using System.Reflection;

namespace FluentRegularExpression.Tests.Utils
{
    public class ClassUtils
    {
        public List<MethodInfo> GetMethodList(Type type, BindingFlags bindingFlags)
        {
            MethodInfo[] methods = type.GetMethods(bindingFlags);

            var result = new List<MethodInfo>();
            result.AddRange(methods);

            return result;
        }
    }
}
