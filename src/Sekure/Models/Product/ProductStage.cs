using System;

namespace Sekure.Models;

public class ProductStage
{
    public string FirstName { get; set; }
    public string SecondName { get; set; }
    public string LastName { get; set; }
    public string SecondLastName { get; set; }
    public string Gender { get; set; }
    public DateTime Birthdate { get; set; }
    public string Email { get; set; }
    public string PolicyTypeName { get; set; }
    public string Stage { get; set; }
    public DateTime DateCreate { get; set; }
    public string Value { get; set; }
    public DateTime? BeginDate { get; set; }
    public string CompanyTitle { get; set; }

    public ProductStage() { }

    public ProductStage(
        string firstName
        , string secondName
        , string lastName
        , string secondLastName
        , string gender
        , DateTime birthdate
        , string email
        , string policyTypeName
        , string stage
        , DateTime dateCreate
        , string value
        , DateTime? beginDate
        , string companyTitle
    )
    {
        FirstName = firstName;
        SecondName = secondName;
        LastName = lastName;
        SecondLastName = secondLastName;
        Gender = gender;
        Birthdate = birthdate;
        Email = email;
        PolicyTypeName = policyTypeName;
        Stage = stage;
        DateCreate = dateCreate;
        Value = value;
        BeginDate = beginDate;
        CompanyTitle = companyTitle;
    }
}