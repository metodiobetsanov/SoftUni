using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Organization : IOrganization
{
    private List<Person> persons;

    public Organization()
    {
        this.persons = new List<Person>();
    }

    public IEnumerator<Person> GetEnumerator()
    {
        foreach (var person in persons)
        {
            yield return person;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public int Count
    {
        get { return persons.Count; }
    }
    public bool Contains(Person person)
    {
        return persons.Contains(person);
    }

    public bool ContainsByName(string name)
    {
        return !(persons.FirstOrDefault(p => p.Name == name) == null);
    }

    public void Add(Person person)
    {
        persons.Add(person);
    }

    public Person GetAtIndex(int index)
    {
        if (index < 0 || index > persons.Count)
        {
            throw new IndexOutOfRangeException();    
        }

        return  persons[index];
    }

    public IEnumerable<Person> GetByName(string name)
    {
        return persons.Where(p => p.Name == name);
    }

    public IEnumerable<Person> FirstByInsertOrder(int count = 1)
    {
        return persons.Take(count);
    }

    public IEnumerable<Person> SearchWithNameSize(int minLength, int maxLength)
    {
        return persons.Where(p => p.Name.Length >= minLength && p.Name.Length <= maxLength);
    }

    public IEnumerable<Person> GetWithNameSize(int length)
    {
        var result = persons.Where(p => p.Name.Length == length);
        if (result.Count() == 0)
        {
            throw new ArgumentException();
        }

        return result;
    }

    public IEnumerable<Person> PeopleByInsertOrder()
    {
        return persons;
    }
}