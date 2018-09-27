using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using MVVMAssignment1.Models;
using Xamarin.Forms;

namespace MVVMAssignment1.Helpers
{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteConnection;
        public DatabaseHelper()
        {
            sqliteConnection = DependencyService.Get<ISQLite>().GetConnection();
            sqliteConnection.CreateTable<ParameterA>();
        }

        // Get All Parameter data      
        public List<ParameterA> GetAllParameterData()
        {
            return sqliteConnection.Table<ParameterA>().ToList();
        }

        //Get Specific Parameter data  
        public ParameterA GetParameterData(int id)
        {
            return sqliteConnection.Table<ParameterA>().FirstOrDefault(t => t.Id == id);
        }

        // Delete all Parameter Data  
        public void DeleteAllParameters()
        {
            sqliteConnection.DeleteAll<ParameterA>();
        }

        // Delete Specific Parameter  
        public void DeleteParameter(int id)
        {
            sqliteConnection.Delete<ParameterA>(id);
        }

        // Insert new Parameter to DB   
        public void InsertParameter(ParameterA parameter)
        {
            sqliteConnection.Insert(parameter);
        }

        // Update Parameter Data  
        public void UpdateParameter(ParameterA parameter)
        {
            sqliteConnection.Update(parameter);
        }
    }
}
