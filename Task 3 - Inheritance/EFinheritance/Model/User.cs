using System.ComponentModel.DataAnnotations;

namespace EFinheritance.Models;

public class User {
    
    [Key]
    public string? EmployeeID{get;set;}
    public string? Name{get;set;}

}

public class Employee:User{
    public string? UserLevel{get;set;}
}

public class Admin : User{
    public string? AdminRole{get;set;}
}
