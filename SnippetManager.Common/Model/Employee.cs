using System;

namespace EmployeeManager.Common.Model
{
  public class Employee
  {
    public int Id { get; set; }

    public string FirstName { get; set; }

    public DateTimeOffset EntryDate { get; set; }

    public int JobRoleId { get; set; }

    public bool IsCoffeeDrinker { get; set; }
  }
}
