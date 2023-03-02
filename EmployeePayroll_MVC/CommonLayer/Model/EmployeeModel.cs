using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile_Image { get; set; }
        public string Gender  { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
