using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using titanic_api.Models;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private static readonly List<Person> People = new List<Person>();

    [HttpGet]
    public IEnumerable<Person> GetPeople()
    {
        return People;
    }

    [HttpPost]
    public ActionResult<Person> AddPerson(PersonData personData)
    {
        var person = new Person
        {
            Uuid = Guid.NewGuid(),
            Survived = personData.Survived,
            PassengerClass = personData.PassengerClass,
            Name = personData.Name,
            Sex = personData.Sex,
            Age = personData.Age,
            SiblingsOrSpousesAboard = personData.SiblingsOrSpousesAboard,
            ParentsOrChildrenAboard = personData.ParentsOrChildrenAboard,
            Fare = personData.Fare
        };

        People.Add(person);

        return person;
    }

    [HttpGet("{uuid}")]
    public ActionResult<Person> GetPerson(Guid uuid)
    {
        var person = People.FirstOrDefault(p => p.Uuid == uuid);

        if (person == null)
        {
            return NotFound();
        }

        return person;
    }

    [HttpPut("{uuid}")]
    public ActionResult<Person> UpdatePerson(Guid uuid, PersonData personData)
    {
        var person = People.FirstOrDefault(p => p.Uuid == uuid);

        if (person == null)
        {
            return NotFound();
        }

        person.Survived = personData.Survived;
        person.PassengerClass = personData.PassengerClass;
        person.Name = personData.Name;
        person.Sex = personData.Sex;
        person.Age = personData.Age;
        person.SiblingsOrSpousesAboard = personData.SiblingsOrSpousesAboard;
        person.ParentsOrChildrenAboard = personData.ParentsOrChildrenAboard;
        person.Fare = personData.Fare;

        return person;
    }

    [HttpDelete("{uuid}")]
    public IActionResult DeletePerson(Guid uuid)
    {
        var person = People.FirstOrDefault(p => p.Uuid == uuid);

        if (person == null)
        {
            return NotFound();
        }

        People.Remove(person);

        return Ok();
    }
}