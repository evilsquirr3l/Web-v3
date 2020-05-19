using System;
using System.Collections.Generic;
using Business.Models;

namespace Business.Abstraction
{
    public interface IResidentService
    {
        IEnumerable<ResidentModel> FindByName(string name);
        
        IEnumerable<ResidentModel> FindByBirthdate(DateTime birthdate);
        
        IEnumerable<ResidentModel> FindByNumberOfApartments(int numberOfApartments);
    }
}