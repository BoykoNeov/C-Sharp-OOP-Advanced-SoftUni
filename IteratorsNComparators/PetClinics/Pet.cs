public class Pet
{
    private string name;
    private int age;
    private string kind;

    public Pet()
    {
    }

    public Pet(string name, int age, string kind)
    {
        this.Name = name;
        this.Age = age;
        this.Kind = kind;
    }

    public string Kind
    {
        get { return kind; }
        set { kind = value; }
    }


    public int Age
    {
        get { return age; }
        set { age = value; }
    }


    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age} {this.Kind}";
    }
}