using System.Reflection;

namespace _14DemoReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\KDAC_Demos\\KDAC\\MathLib\\bin\\Debug\\MathLib.dll";
            Assembly assembly = Assembly.LoadFrom(path);

            Type[] allTypesInAssembly = assembly.GetTypes();

            foreach (Type type in allTypesInAssembly)
            {
                
                Console.WriteLine("FullName  : " + type.FullName);

                object dynamicObejct = 
                    assembly.CreateInstance(type.FullName);

                Console.WriteLine("Object created for type " + type.FullName);

                MethodInfo[] allMethods = type.GetMethods();

                foreach (MethodInfo method in allMethods)
                {
                    Console.WriteLine(" -- Calling : " + method.Name );

                    ParameterInfo[] allParams =
                        method.GetParameters();

                    object[] arguments = new object[allParams.Length];


                    for (int i = 0; i < allParams.Length; i++)
                    {
                        ParameterInfo para = allParams[i];

                        Console.WriteLine("Enter data of type " + 
                            para.ParameterType.ToString() + " for "
                            + para.Name + " ");

                        string data = Console.ReadLine();
                        arguments[i] = 
                                Convert.ChangeType(data, para.ParameterType);


                    }

                  object output = 
                        type.InvokeMember(method.Name,
                        BindingFlags.Public |
                        BindingFlags.Instance |
                        BindingFlags.InvokeMethod,
                        null, dynamicObejct, arguments);
                    Console.WriteLine(output);
                    Console.WriteLine("-------------------");

                }

            }

            Console.ReadLine();

        }
    }
}
