namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Linq;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            string input = string.Empty;
            ConstructorInfo blackBoxIntConstructor = (typeof(BlackBoxInteger).GetConstructor(BindingFlags.NonPublic|BindingFlags.Instance, null, new Type[] { typeof(int) }, null));

            BlackBoxInteger blackBoxInteger = blackBoxIntConstructor.Invoke(new object[] {0}) as BlackBoxInteger;
            MethodInfo[] blackBoxIntMethods = blackBoxInteger.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inputs = input.Split(new char[] { '_' });
                FieldInfo[] blackBoxFields = blackBoxInteger.GetType().GetFields();
                string methodName = inputs[0];
                int parameter = int.Parse(inputs[1]);

                MethodInfo methodToInvoke = blackBoxIntMethods.Where(m => m.Name == methodName).First();
                methodToInvoke.Invoke(blackBoxInteger, new object[] { parameter });

                FieldInfo innerIntField = blackBoxInteger.GetType().GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
                int result = (int)(innerIntField.GetValue(blackBoxInteger));
                Console.WriteLine(result);
            }
        }
    }
}