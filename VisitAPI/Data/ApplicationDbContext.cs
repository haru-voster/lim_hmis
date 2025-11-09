using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using VisitAPI.Models;
using System.Data;


namespace VisitAPI.Data
{
    public class ApplicationDbContext
    {
        private readonly string _connectionString;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Insert new LabRequest record into SQL Server
        public async Task<bool> AddLabRequestAsync(LabRequest visit)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = @"
                    INSERT INTO patient_table 
                    (Address, DateRequestReceived, Diagnosis, IsUrgent, LabRequestId, LabTests, Location, 
                     PatientAge, PatientBedNumber, PatientBirthDate, PatientFirstName, PatientGender, 
                     PatientId, PatientOtherName, PPatientPhone, PatientStage, PatientSurname, 
                     PatientWard, ReceiptNumber, ReceiptType, RequestedByName, OpenMrsId)
                    VALUES
                    (@Address, @DateRequestReceived, @Diagnosis, @IsUrgent, @LabRequestId, @LabTests, @Location, 
                     @PatientAge, @PatientBedNumber, @PatientBirthDate, @PatientFirstName, @PatientGender, 
                     @PatientId, @PatientOtherName, @PPatientPhone, @PatientStage, @PatientSurname, 
                     @PatientWard, @ReceiptNumber, @ReceiptType, @RequestedByName, @OpenMrsId)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Address", visit.Address ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateRequestReceived", visit.DateRequestReceived);
                    cmd.Parameters.AddWithValue("@Diagnosis", visit.Diagnosis ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@IsUrgent", visit.IsUrgent);
                    cmd.Parameters.AddWithValue("@LabRequestId", visit.LabRequestId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LabTests", visit.LabTests != null
                        ? string.Join(",", visit.LabTests.Select(t => $"{t.LabTestId}:{t.LabTestName}"))
                        : (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Location", visit.Location ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PatientAge", visit.PatientAge);
                    cmd.Parameters.AddWithValue("@PatientBedNumber", visit.PatientBedNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PatientBirthDate", visit.PatientBirthDate);
                    cmd.Parameters.AddWithValue("@PatientFirstName", visit.PatientFirstName);
                    cmd.Parameters.AddWithValue("@PatientGender", visit.PatientGender);
                    cmd.Parameters.AddWithValue("@PatientId", visit.PatientId ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PatientOtherName", visit.PatientOtherName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PPatientPhone", visit.PPatientPhone ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PatientStage", visit.PatientStage ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@PatientSurname", visit.PatientSurname);
                    cmd.Parameters.AddWithValue("@PatientWard", visit.PatientWard ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReceiptNumber", visit.ReceiptNumber ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ReceiptType", visit.ReceiptType ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@RequestedByName", visit.RequestedByName ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@OpenMrsId", visit.OpenMrsId ?? (object)DBNull.Value);

                    await conn.OpenAsync();
                    int rows = await cmd.ExecuteNonQueryAsync();
                    return rows > 0;
                }
            }
        }
    }
}
