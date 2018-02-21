using System;
using System.Dynamic;
using System.Runtime.Serialization;

public class Person : IComparable
{
    private int age;
    private string name;

    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Age
    {
        get { return this.age;}
        set { this.age = value; }
    }

    public Person()
    {
        this.name = "No name";
        this.age = 1;
    }

    public Person(int age)
    {
        this.name = "No name";
        this.age = age;
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    public int CompareTo(object obj)
    {
        var other = (Person) obj;
        return this.Age.CompareTo(other.Age);
    }
}

