using System;
using System.Collections.Generic;
using System.Text;
using MVVMAssignment1.Models;
using MVVMAssignment1.Helpers;

namespace MVVMAssignment1.Services
{
    public class ParameterARepository : IParameterARepository
    {
        DatabaseHelper _databaseHelper;
        public ParameterARepository()
        {
            _databaseHelper = new DatabaseHelper();
        }
        public void DeleteAllParameters()
        {
            _databaseHelper.DeleteAllParameters();
        }

        public void DeleteParameter(int id)
        {
            _databaseHelper.DeleteParameter(id);
        }

        public List<ParameterA> GetAllParameterData()
        {
           return _databaseHelper.GetAllParameterData();
        }

        public ParameterA GetParameterData(int id)
        {
            return _databaseHelper.GetParameterData(id);
        }

        public void InsertParameter(ParameterA parameter)
        {
             _databaseHelper.InsertParameter(parameter);
        }

        public void UpdateParameter(ParameterA parameter)
        {
            _databaseHelper.UpdateParameter(parameter);
        }
    }
}
