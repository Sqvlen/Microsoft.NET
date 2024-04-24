// using System.Reflection;
// using System.Xml;
// using System.Xml.Serialization;
//
// namespace Routes.Xml.Core.Reader;
//
// public static class XmlCustomReader
// {
//     public static T Read<T>(XmlReaderParams xmlReaderParams)
//     {
//         var xmlDocument = new XmlDocument();
//         xmlDocument.Load(xmlReaderParams.FileName);
//
//         return ReadNode<T>(xmlDocument.DocumentElement!, xmlReaderParams.ElementName);
//     }
//
//     public static T ReadNode<T>(XmlNode node, string name)
//     {
//         var type = typeof(T);
//
//         if (type.IsPrimitive || type.IsEnum || type == typeof(string))
//             return ((T?)Convert.ChangeType(node.InnerText, type))!;
//         
//         if (typeof(IEnumerable<object>).IsAssignableFrom(type))
//         {
//             var innerType = type.GetGenericArguments()[0];
//             Type listType = typeof(List<>).MakeGenericType(innerType);
//             var enumerable = Activator.CreateInstance(listType);
//             foreach (XmlNode item in node)
//             {
//                 var method = typeof(XmlContext).GetMethod(nameof(XmlContext.Read),
//                     BindingFlags.NonPublic | BindingFlags.Instance);
//                 var generic = method!.MakeGenericMethod(innerType);
//                 object[] parameters = new object[] { item, innerType.Name, true };
//                 var itemConverted = generic.Invoke(this, parameters);
//                 enumerable!.GetType().GetMethod("Add")!.Invoke(enumerable, new[] { itemConverted });
//             }
//
//             return (T?)enumerable;
//         }
//         else
//         {
//             if (node[typeName] != null)
//                 type = Type.GetType(node[typeName]!.InnerText)!;
//             if (type.IsAbstract)
//             {
//                 throw new InvalidOperationException("Unable to create an object from the node.\n" +
//                                                     "More likely, your type is an interface or an abstract class" +
//                                                     " and no <type> child node was specified");
//             }
//
//             object obj = (T)Activator.CreateInstance(type)!;
//             foreach (var prop in type.GetProperties())
//             {
//                 if (!prop.CustomAttributes.Any(a => a.AttributeType == typeof(XmlIgnoreAttribute)))
//                 {
//                     var method = typeof(XmlContext).GetMethod(nameof(XmlContext.Read),
//                         BindingFlags.NonPublic | BindingFlags.Instance);
//                     var generic = method!.MakeGenericMethod(prop.PropertyType);
//                     object?[] parameters = new object?[]
//                         { node[prop.Name.FirstToLower()], prop.PropertyType.ToString(), true };
//                     var itemConverted = generic.Invoke(this, parameters);
//                     if (itemConverted != default)
//                         prop.SetValue(obj, itemConverted, null);
//                 }
//             }
//
//             return (T?)obj;
//         }
//     }