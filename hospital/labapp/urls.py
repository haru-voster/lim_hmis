from django.urls import path
from .views import (
    LabRequestCreateView,
    LabRequestListView,
    LabRequestDetailView,
    LabTestCreateView,
    LabTestListView
)

urlpatterns = [
    path('create-request/', LabRequestCreateView.as_view(), name='create_request'),
    path('requests/', LabRequestListView.as_view(), name='requests'),
    path('request/<int:pk>/', LabRequestDetailView.as_view(), name='request_detail'),
    path('add-test/', LabTestCreateView.as_view(), name='add_test'),
    path('tests/', LabTestListView.as_view(), name='tests'),
]
