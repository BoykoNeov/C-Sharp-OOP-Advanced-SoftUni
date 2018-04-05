using System;

public class StartUp
{
    public static void Main()
    {
        string input = string.Empty;
        while ((input = Console.ReadLine()) != "END")
        {
            string result = input + ": ";

            switch (input)
            {
                case "Author":
                   result += GetCustomAttributeAuthor(typeof(Weapon));
                    break;

                case "Revision":
                   result += GetCustomAttributeRevision(typeof(Weapon)).ToString();
                    break;

                case "Description":
                    result = "Class description: ";
                   result += GetCustomAttributeDescritpion(typeof(Weapon));
                    break;

                case "Reviewers":
                   result += GetCustomAttributeReviewers(typeof(Weapon));
                    break;

                default:
                    result = string.Empty;
                    break;
            }

            Console.WriteLine(result);
        }
    }

    public static CustomClassAttribute GetCustomClassAttribute(Type type)
    {
        return (CustomClassAttribute)Attribute.GetCustomAttribute(type, typeof(CustomClassAttribute));
    }

    public static string GetCustomAttributeAuthor(Type type)
    {
        return GetCustomClassAttribute(type).Author;
    }

    public static string GetCustomAttributeDescritpion(Type type)
    {
        return GetCustomClassAttribute(type).Description;
    }

    public static int GetCustomAttributeRevision(Type type)
    {
        return GetCustomClassAttribute(type).Revision;
    }

    public static string GetCustomAttributeReviewers(Type type)
    {
        return string.Join(", ", GetCustomClassAttribute(type).Reviewers);
    }
}