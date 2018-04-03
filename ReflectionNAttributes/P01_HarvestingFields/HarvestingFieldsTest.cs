namespace P01_HarvestingFields
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            Type harvestingFieldsType = new HarvestingFields().GetType();
            List<FieldInfo> harvestingFieldsFields = harvestingFieldsType.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance).ToList();

            string input = string.Empty;
            List<string> requestedAccessModifiers = new List<string>();

            while ((input = Console.ReadLine()) != "HARVEST")
            {
                requestedAccessModifiers.Add(input);
            }

            StringBuilder sb = new StringBuilder();


            foreach (string requestedField in requestedAccessModifiers)
            {
                foreach (FieldInfo field in harvestingFieldsFields)
                {
                    if (requestedField == "all")
                    {
                        if (field.IsPrivate)
                        {
                            sb.Append("private ");
                        }
                        else if (field.IsPublic)
                        {
                            sb.Append("public ");
                        }
                        else if (field.IsFamily)
                        {
                            sb.Append("protected ");
                        }

                    }
                    else
                    {
                        if (field.IsPrivate && requestedField == "private")
                        {
                            sb.Append("private ");
                        }
                        else if (field.IsPublic && requestedField == "public")
                        {
                            sb.Append("public ");
                        }
                        else if (field.IsFamily && requestedField == "protected")
                        {
                            sb.Append("protected ");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    string fieldType = field.FieldType.ToString().Split(new char[] { '.' }).Last();
                    sb.Append(fieldType + " ");
                    sb.AppendLine(field.Name);

                }
            }

            Console.WriteLine(sb.ToString().Trim());
        }
    }
}