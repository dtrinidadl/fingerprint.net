using DPFP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsistenciaSys.Models
{
    // internal class ApiResponse

    public class ApiResponse
    {
        public int statusCode { get; set; }
        public bool result { get; set; }
        public string message { get; set; }
        public int total { get; set; }

        public List<Student> records { get; set; }
    }

    public class PaginatedData<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
    }

    public class Student
    {
        public int studentCode { get; set; }
        public int studentStatus { get; set; }
        public string studentName { get; set; }
        public string studentPhone { get; set; }
        public int studentFingerprint { get; set; }
        public string studentStatusShow { get; set; }
        public string studentFingerprintShow { get; set; }

        public byte[] studentFingerprintByte { get; set; }

        //public int studentCompany { get; set; }
        //public int studentStore { get; set; }
    }

    public class StudentDB
    {
        public int studentCode { get; set; }
        public string studentName { get; set; }
        public byte[] studentFingerprint { get; set; }
    }

    public class ApiResponseVerify
    {
        public bool result { get; set; }
        public int statusCode { get; set; }
        public Records records { get; set; }
        public int exitFlag { get; set; }
        public string errorType { get; set; }
        public string errorMessage { get; set; }
        public string[] stack { get; set; }
    }

    public class Records
    {
        public string studentName { get; set; }
        public int packageCode { get; set; }
        public string packageName { get; set; }
        public int packageHourClass { get; set; }
        public string paymentDetailEndDate { get; set; }
        public int packageHour { get; set; }
        public string assistAvailableHours { get; set; }
        public string message { get; set; }
        public int messageOption { get; set; }
    }
}
