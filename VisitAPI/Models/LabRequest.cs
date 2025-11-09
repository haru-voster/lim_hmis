using System;
using System.Collections.Generic;

namespace VisitAPI.Models
{public class LabTest
{
    public string? LabTestId { get; set; }
    public string? LabTestName { get; set; }
}

public class LabRequest
{
    public string? Address { get; set; }
    public DateTime DateRequestReceived { get; set; }
    public string? Diagnosis { get; set; }
    public bool IsUrgent { get; set; }
    public string? LabRequestId { get; set; }
    public List<LabTest>? LabTests { get; set; }
    public string? Location { get; set; }
    public int PatientAge { get; set; }
    public string? PatientBedNumber { get; set; }
    public DateTime PatientBirthDate { get; set; }
    public string? PatientFirstName { get; set; }
    public string? PatientGender { get; set; }
    public string? PatientId { get; set; }
    public string? PatientOtherName { get; set; }
    public string? PPatientPhone { get; set; }
    public string? PatientStage { get; set; }
    public string? PatientSurname { get; set; }
    public string? PatientWard { get; set; }
    public string? ReceiptNumber { get; set; }
    public string? ReceiptType { get; set; }
    public string? RequestedByName { get; set; }
    public string? OpenMrsId { get; set; }
}

}
