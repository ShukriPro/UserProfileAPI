using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace UserProfileAPI.Modal
{

    public class PatientData
    {
        public string datecalc { get; set; }
        public Description Description { get; set; }
        public int Patient_Id { get; set; }
        public double Qn { get; set; }
        public string Version { get; set; }
    }

    public class Description
    {
        public string Factors { get; set; }
    }



}
