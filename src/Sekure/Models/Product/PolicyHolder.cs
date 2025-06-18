using Sekure.Security;
using System;

namespace Sekure.Models;

public class PolicyHolder
{
    [Encrypted]
    public string FirstName { get; set; }

    [Encrypted]
    public string SecondName { get; set; }

    [Encrypted]
    public string LastName { get; set; }

    [Encrypted]
    public string SecondLastName { get; set; }

    [Encrypted]
    public string Gender { get; set; }

    [Encrypted]
    public string Address { get; set; }

    [Encrypted]
    public string IdentificationType { get; set; }

    [Encrypted]
    public string IdentificationNumber { get; set; }

    [Encrypted]
    public DateTime? Birthdate { get; set; }

    [Encrypted]
    public DateTime? ExpeditionDate { get; set; }

    [Encrypted]
    public string MaritalStatus { get; set; }

    [Encrypted]
    public string Email { get; set; }

    [Encrypted]
    public string PhoneNumber { get; set; }

    [Encrypted]
    public string CityCode { get; set; }

    [Encrypted]
    public string City { get; set; }

    [Encrypted]
    public string CompanyName { get; set; }

    [Encrypted]
    public string CompanyIdentificationNumber { get; set; }

    [Encrypted]
    public string CompanyEmail { get; set; }

    [Encrypted]
    public string CompanyPhone { get; set; }

    [Encrypted]
    public DateTime? CompanyDate { get; set; }

    [Encrypted]
    public string CompanyPostalCode { get; set; }

    [Encrypted]
    public string CompanyStreetNumber { get; set; }

    [Encrypted]
    public string CompanyAddress { get; set; }

    [Encrypted]
    public string CompanyCity { get; set; }

    [Encrypted]
    public string AddressTypeId { get; set; }

    [Encrypted]
    public string Nationality { get; set; }

    [Encrypted]
    public string PersonType { get; set; }

    [Encrypted]
    public string StreetNumber { get; set; }

    [Encrypted]
    public string CellNumber { get; set; }

    [Encrypted]
    public string Department { get; set; }

    [Encrypted]
    public string DepartmentCode { get; set; }

    [Encrypted]
    public string Birthplace { get; set; }

    [Encrypted]
    public string Neighborhood { get; set; }

    [Encrypted]
    public string CountryPlace { get; set; }

    [Encrypted]
    public string DepartmentPlace { get; set; }

    [Encrypted]
    public string CityPlace { get; set; }

    public PolicyHolder(
        string firstName
        , string secondName
        , string lastName
        , string secondLastName
        , string gender
        , string address
        , string identificationType
        , string identificationNumber
        , DateTime? birthdate
        , string maritalStatus
        , string email
        , string phoneNumber
    )
    {
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
        Gender = gender;
        Address = address;
        IdentificationType = identificationType;
        IdentificationNumber = identificationNumber;
        Birthdate = birthdate;
        MaritalStatus = maritalStatus;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public PolicyHolder(
        string firstName
        , string secondName
        , string lastName
        , string secondLastName
        , string gender
        , string address
        , string identificationType
        , string identificationNumber
        , DateTime? birthdate
        , DateTime? expeditionDate
        , string maritalStatus
        , string email
        , string phoneNumber
        , string cityCode
        , string city
        , string companyName
        , string companyIdentificationNumber
        , string companyEmail
        , string companyPhone
        , DateTime? companyDate
        , string companyPostalCode
        , string companyStreetNumber
        , string companyAddress
    )
    {
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
        Gender = gender;
        Address = address;
        IdentificationType = identificationType;
        IdentificationNumber = identificationNumber;
        Birthdate = birthdate;
        ExpeditionDate = expeditionDate;
        MaritalStatus = maritalStatus;
        Email = email;
        PhoneNumber = phoneNumber;
        CityCode = cityCode;
        City = city;
        CompanyName = companyName;
        CompanyIdentificationNumber = companyIdentificationNumber;
        CompanyEmail = companyEmail;
        CompanyPhone = companyPhone;
        CompanyDate = companyDate;
        CompanyPostalCode = companyPostalCode;
        CompanyStreetNumber = companyStreetNumber;
        CompanyAddress = companyAddress;
    }

    public PolicyHolder()
    {

    }
}