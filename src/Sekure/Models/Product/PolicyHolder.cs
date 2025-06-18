using Sekure.Security;
using System;

namespace Sekure.Models
{
    public class PolicyHolder
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string IdentificationType { get; set; }
        public string IdentificationNumber { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? ExpeditionDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CityCode { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string CompanyIdentificationNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string CompanyPhone { get; set; }
        public DateTime? CompanyDate { get; set; }
        public string CompanyPostalCode { get; set; }
        public string CompanyStreetNumber { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyCity { get; set; }
        public string AddressTypeId { get; set; }
        public string Nationality { get; set; }
        public string PersonType { get; set; }
        public string StreetNumber { get; set; }
        public string CellNumber { get; set; }
        public string Department { get; set; }
        public string DepartmentCode { get; set; }
        public string Birthplace { get; set; }
        public string Neighborhood { get; set; }
        public string CountryPlace { get; set; }
        public string DepartmentPlace { get; set; }
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
