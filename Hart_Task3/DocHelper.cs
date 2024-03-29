using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Hart_Task3
{
    public class DocHelper
    {

        public static void ShowInfo(object obj)
        {
            if (obj == null) return;

            Type t = obj.GetType();
            TypeInfo typeinfo = t.GetTypeInfo();
            IEnumerable<PropertyInfo> props = t.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            IEnumerable<MethodInfo> methods = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(m => !m.IsSpecialName);
            IEnumerable<FieldInfo> fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic |  BindingFlags.Instance | BindingFlags.DeclaredOnly).Where(m => !m.Name.Contains("BackingField"));

            /// PROPERTIES
            Console.WriteLine($"{typeinfo.Name} \r\n{{");
            foreach (var prop in props)
            {
                string acces = string.Empty, getname = string.Empty, setname=string.Empty;


                if((prop.CanRead && prop.GetGetMethod().IsPublic) || (prop.CanWrite && prop.GetSetMethod().IsPublic))
                {
                    acces = "public";
                }
                else if ((prop.CanRead && prop.GetGetMethod().IsPrivate) || (prop.CanWrite && prop.GetSetMethod().IsPrivate))
                {
                    acces = "private";
                }else if ((prop.CanRead && prop.GetGetMethod().IsFamily) || (prop.CanWrite && prop.GetSetMethod().IsFamily))
                {
                    acces = "protected";
                }
                if ((prop.CanRead && prop.GetGetMethod().IsVirtual)|| (prop.CanWrite && prop.GetSetMethod().IsVirtual))
                    acces += " virtual";
                if (prop.CanRead == true)
                {
                    getname = "get;";
                }
                if (prop.CanWrite == true)
                {
                    setname = "set;";
                }

                var fullName = $"\t{acces} {prop.PropertyType.Name} {prop.Name} {{ {getname} {setname} }}";

                Console.WriteLine(fullName);
            }
            if (props.Any())
                Console.WriteLine("\t...");

            /// FIELDS
            foreach (var field in fields)
            {
                string acces = string.Empty;
                if (field.IsPublic)
                {
                    acces = "public";
                }
                else if (field.IsPrivate)
                {
                    acces = "private";
                }
                else if (field.IsFamily)
                {
                    acces = "protected";
                }
                if (field.IsStatic)
                {
                    acces += " static";
                }

                var fullName = $"\t{acces} {GetTypeName(field.FieldType)} {field.Name} ;";

                Console.WriteLine(fullName);
            }
            if(fields.Any())
            {
                Console.WriteLine("\t...");
            }
            /// METHODS
            foreach (var method in methods)
            {
                string acces = string.Empty;
                if (method.IsPublic)
                {
                    acces = "public";
                }
                else if (method.IsPrivate)
                {
                    acces = "public";
                }
                else if (method.IsFamily)
                {
                    acces = "protected";
                }
                if (method.IsStatic)
                {
                    acces += " static";
                }

                var fullName = $"\t{acces} {method.ReturnType.Name}  {method.Name} ({string.Join(", ", method.GetParameters().Select(o => string.Format("{0} {1}", o.ParameterType, o.Name)).ToArray())}) {{ }}";

                Console.WriteLine(fullName);
            }
            Console.WriteLine("}");

        }

        public static string GetTypeName(Type type)
        {
            var nullableType = Nullable.GetUnderlyingType(type);

            bool isNullableType = nullableType != null;

            if (isNullableType)
                return nullableType.Name + "?";
            else
                return type.Name;
        }

    }
}
