from django.db import models

class LabRequest(models.Model):
    address = models.CharField(max_length=255, null=True, blank=True)
    date_request_received = models.DateTimeField()
    diagnosis = models.CharField(max_length=255, null=True, blank=True)
    is_urgent = models.BooleanField(default=False)
    lab_request_id = models.CharField(max_length=50, null=True, blank=True)
    location = models.CharField(max_length=100, null=True, blank=True)
    patient_age = models.IntegerField()
    patient_bed_number = models.CharField(max_length=50, null=True, blank=True)
    patient_birth_date = models.DateField()
    patient_first_name = models.CharField(max_length=50, null=True, blank=True)
    patient_gender = models.CharField(max_length=20, null=True, blank=True)
    patient_id = models.CharField(max_length=50, null=True, blank=True)
    patient_other_name = models.CharField(max_length=50, null=True, blank=True)
    ppatient_phone = models.CharField(max_length=50, null=True, blank=True)
    patient_stage = models.CharField(max_length=100, null=True, blank=True)
    patient_surname = models.CharField(max_length=50, null=True, blank=True)
    patient_ward = models.CharField(max_length=50, null=True, blank=True)
    receipt_number = models.CharField(max_length=50, null=True, blank=True)
    receipt_type = models.CharField(max_length=50, null=True, blank=True)
    requested_by_name = models.CharField(max_length=100, null=True, blank=True)
    open_mrs_id = models.CharField(max_length=50, null=True, blank=True)

    def __str__(self):
        return f"LabRequest {self.id}"


class LabTest(models.Model):
    lab_request = models.ForeignKey(LabRequest, on_delete=models.CASCADE, related_name="lab_tests")
    test_name = models.CharField(max_length=100)
    result = models.CharField(max_length=100, null=True, blank=True)
    units = models.CharField(max_length=30, null=True, blank=True)
    reference_range = models.CharField(max_length=100, null=True, blank=True)
    comment = models.TextField(null=True, blank=True)

    def __str__(self):
        return f"{self.test_name} - {self.result}"
