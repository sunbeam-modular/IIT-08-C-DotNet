using System.Reflection;

namespace _13DemoReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "D:\\KDAC_Demos\\KDAC\\MathLib\\bin\\Debug\\MathLib.dll";
            //string path = "D:\\KDAC_Demos\\KDAC\\02DemoOOP_Editor\\bin\\Debug\\net8.0\\02DemoOOP_Editor.dll";

            Assembly assembly = Assembly.LoadFrom(path);

            Type[] allTypesInAssembly = assembly.GetTypes();

            foreach (Type type in allTypesInAssembly)
            {
                Console.WriteLine("Is Public : " + type.IsPublic);
                Console.WriteLine("Is Class : " + type.IsClass);
                Console.WriteLine("FullName  : " + type.FullName);

                IEnumerable<Attribute> allAttributesOnType =
                     type.GetCustomAttributes();

                bool IsSerializable = false;
                foreach (Attribute attribute in allAttributesOnType)
                {
                    if (attribute is SerializableAttribute)
                    {
                        IsSerializable = true;
                        break;
                    }
                }

                if (IsSerializable)
                {
                    Console.WriteLine(type.Name  + " is Serializable!");
                }
                else
                {
                    //Console.WriteLine(type.Name + " is NOT Serializable!");

                    throw new Exception(type.Name + " is not marked as Serializable");
                }



                MethodInfo[] allMethods = type.GetMethods();

                Console.WriteLine("Methods : ");
                Console.WriteLine();
                foreach (MethodInfo method in allMethods)
                {
                    Console.Write(" -- " + 
                                       method.ReturnType.ToString() 
                                        + " " + method.Name + "( ");

                    ParameterInfo[] allParams =
                        method.GetParameters();

                    foreach (ParameterInfo para in allParams)
                    {
                        Console.Write(
                            para.ParameterType.ToString() + " "
                            +para.Name + " ");
                    }

                    Console.Write(" )");
                    Console.WriteLine();
                }

            }

            Console.ReadLine();

        }
    }
}
