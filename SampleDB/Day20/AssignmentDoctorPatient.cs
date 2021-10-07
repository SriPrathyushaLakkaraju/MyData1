using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDB.Day20
{
    class AssignmentDoctorPatient
    {
        static DataClasses1DataContext context = new DataClasses1DataContext();
        static void Main(string[] args)
        {
            insertPatient();
         // getBill();
        }

        private static void getBill(int id)
        {
            var result = from pat in context.Patients
                          where pat.DoctorID == id
                          select new
                          {
                              Name = pat.PatientName,
                              DocName = pat.Doctor.DoctorName,
                              fee = pat.Doctor.Fee
                          };
            /*var result = from pat in context.Patients
                         select new
                         {
                             Name = pat.PatientName,
                             DocName=pat.Doctor.DoctorName,
                             fee = pat.Doctor.Fee
                         };*/
            // foreach(var res in result) Console.WriteLine($"Patient Name : {res.Name} Doctor name : {res.DocName} and Bill for the Patient {res.fee} ");
            //Console.WriteLine(result);
            foreach(var res in result) Console.WriteLine($"Patient Name : {res.Name} Doctor name : {res.DocName} and Bill for the Patient {res.fee} ");
        }

        private static void insertPatient()
        {
            Console.WriteLine("Enter doctor id \nEnter 1 For Gynacologist\nEnter 2 for Orthopedician\nEnter 3 for Oncologist\nEnter 4 for Gastroentrologist\n");
            var id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Patient Name");
            var name = Console.ReadLine();
            Console.WriteLine("Enter Mobile Number");
            var num =long.Parse( Console.ReadLine());
            Console.WriteLine("Enter Visit date");
            var date =DateTime.Parse(Console.ReadLine());
            var patient = new Patient { DoctorID = id, PatientName = name, ContactNo = num, VisitDate = date };
            context.Patients.InsertOnSubmit(patient);
            context.SubmitChanges();
            getBill(id);
        }
    }
}
