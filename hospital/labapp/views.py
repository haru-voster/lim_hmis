from rest_framework import generics
from .models import LabRequest, LabTest
from .serializers import LabRequestSerializer, LabTestSerializer

# Create Lab Request
class LabRequestCreateView(generics.CreateAPIView):
    queryset = LabRequest.objects.all()
    serializer_class = LabRequestSerializer


# List all Lab Requests with tests
class LabRequestListView(generics.ListAPIView):
    queryset = LabRequest.objects.all()
    serializer_class = LabRequestSerializer


# Get Single Lab Request
class LabRequestDetailView(generics.RetrieveAPIView):
    queryset = LabRequest.objects.all()
    serializer_class = LabRequestSerializer


# Add Lab Test
class LabTestCreateView(generics.CreateAPIView):
    queryset = LabTest.objects.all()
    serializer_class = LabTestSerializer


# List Lab Tests Only
class LabTestListView(generics.ListAPIView):
    queryset = LabTest.objects.all()
    serializer_class = LabTestSerializer
