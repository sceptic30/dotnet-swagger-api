// Models/Person.cs
public class Person : PersonData
{
    public Guid Uuid { get; set; }
}

// Models/PersonData.cs
public class PersonData
{
    public bool Survived { get; set; }
    public int PassengerClass { get; set; }
    public string? Name { get; set; } // Allow null values
    public string? Sex { get; set; } // Allow null values
    public int Age { get; set; }
    public int SiblingsOrSpousesAboard { get; set; }
    public int ParentsOrChildrenAboard { get; set; }
    public double Fare { get; set; }
}