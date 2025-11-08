using System;
using System.Collections.Generic;

namespace VisitAPI.Models
{
    public class LabTest
    {
        public string LabTestId { get; set; }
        public string LabTestName { get; set; }
    }

    public class LabRequest
    {
        public int Id { get; set; }
        public string LabRequestId { get; set; }
        public string Diagnosis { get; set; }
        public bool IsUrgent { get; set; }
        public DateTime DateRequestReceived { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientSurname { get; set; }
        public string PatientGender { get; set; }
        public int PatientAge { get; set; }
        public string PatientStage { get; set; }
        public string RequestedByName { get; set; }
        public ICollection<LabTest> LabTests { get; set; }
    }
}
