using System;
using System.Collections.Generic;
using System.Text;
using MVVMAssignment1.Models;
namespace MVVMAssignment1.Services
{
    public interface IParameterARepository
    {
        List<ParameterA> GetAllParameterData();

        //Get Specific Parameter data  
        ParameterA GetParameterData(int id);

        // Delete all Parameter Data  
        void DeleteAllParameters();


        // Delete Specific Parameter  
        void DeleteParameter(int id);

        // Insert new Parameter to DB   
        void InsertParameter(ParameterA parameter);


        // Update Parameter Data  
        void UpdateParameter(ParameterA parameter);
        
    }
}
