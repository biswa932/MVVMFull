using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MVVMAssignment1.Models
{
    [Table("ParameterA")]
    public class ParameterA
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
