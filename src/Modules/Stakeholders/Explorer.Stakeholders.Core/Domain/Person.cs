using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Globalization;
using System.Numerics;
using Explorer.BuildingBlocks.Core.Domain;

namespace Explorer.Stakeholders.Core.Domain;

public class Person : Entity
{
    public long UserId { get; init; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string? Picture { get; init; }
    public string? Bio {  get; init; }
    public string? Quote { get; init; }
    public string City { get; init; }
    public string Country { get; init; }
    public string Phone { get; init; }
    public string Profession { get; init; }
    public string FirmName { get; init; }
    public int Xp { get; private set; }
    public int Level { get; private set; } = 1;
    [NotMapped] 
    public bool CanMakeEncounter => Level >= 10;

    public Person() {}
    public Person(long userId, string name, string surname, string picture, string bio, string quote,string city,string country,string phone,string profession,string firmName)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Picture = picture;
        Bio = bio;
        Quote = quote;
        City = city;
        Country = country;
        Phone = phone;
        Profession = profession;
        FirmName = firmName;
        Validate();

    }
    public Person(long userId, string name, string surname, string? picture, string? bio, string? quote,string city,string country,string phone,string profession,string firmName, int xp, int level)
    {
        UserId = userId;
        Name = name;
        Surname = surname;
        Picture = picture;
        Bio = bio;
        Quote = quote;
        City = city;
        Country = country;
        Phone = phone;
        Profession = profession;
        FirmName = firmName;
        Xp = xp;
        Level = level;
    }

    public void GainXP(int xp)
    {
        if(xp < 0) throw new ArgumentOutOfRangeException("Exception! XP must be greater than zero!");
        Xp += xp;
        Level = (int)Math.Ceiling(Math.Pow(2, (double) Xp / 100));
    }
    private void Validate()
    {
        if (UserId == 0) throw new ArgumentException("Invalid UserId");
        if (string.IsNullOrWhiteSpace(Name)) throw new ArgumentException("Invalid Name");
        if (string.IsNullOrWhiteSpace(Surname)) throw new ArgumentException("Invalid Surname");
        if (string.IsNullOrWhiteSpace(City)) throw new ArgumentException("Invalid city");
        if (string.IsNullOrWhiteSpace(Country)) throw new ArgumentException("Invalid country");
        if (string.IsNullOrWhiteSpace(Phone)) throw new ArgumentException("Invalid phone");
        if (string.IsNullOrWhiteSpace(Profession)) throw new ArgumentException("Invalid profession");
        if (string.IsNullOrWhiteSpace(FirmName)) throw new ArgumentException("Invalid firmName");
    }
}