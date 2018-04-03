using System;
using System.Reflection;
using System.Linq;

public class Tracker
{
    public Tracker()
    {
    }

    public void PrintMethodsByAuthor()
    {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(System.Reflection.BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (MethodInfo methodInfo in methods)
        {
            if (methodInfo.CustomAttributes.Any(a => a.AttributeType == typeof(SoftUniAttribute)))
            {
                object[] attrs = methodInfo.GetCustomAttributes(false);
                foreach (SoftUniAttribute attr in attrs)
                {
                    Console.WriteLine($"{methodInfo.Name} is writte by {attr.Name}");
                }
            }
        }
    }
}