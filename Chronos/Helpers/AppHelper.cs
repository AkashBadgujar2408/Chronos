
using ApplicationCore.DTOs;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

public static class AppHelper
{
    public static void SetNotificationAlert(this ITempDataDictionary tempData, OperationStatus operationStatus, string message)
    {
        tempData["AlertType"] = operationStatus;
        tempData["AlertMessage"] = message;
    }
}
