from rest_framework import serializers
from .models import LabRequest, LabTest

class LabTestSerializer(serializers.ModelSerializer):
    class Meta:
        model = LabTest
        fields = '__all__'


class LabRequestSerializer(serializers.ModelSerializer):
    lab_tests = LabTestSerializer(many=True, read_only=True)

    class Meta:
        model = LabRequest
        fields = '__all__'
