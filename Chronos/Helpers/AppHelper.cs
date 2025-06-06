
using ApplicationCore.DTOs;
using Chronos.Core.Enums;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Web;

public static class AppHelper
{
    public static void SetNotificationAlert(this ITempDataDictionary tempData, OperationStatus operationStatus, string message)
    {
        tempData["AlertType"] = operationStatus;
        tempData["AlertMessage"] = message;
    }

    public static void SetNotificationAlert<T>(this ITempDataDictionary tempData, OperationResult<T> operationResult)
    {
        tempData["AlertType"] = operationResult.Status;
        tempData["AlertMessage"] = operationResult.Message;
    }

    public static string GetActiveClass(CurrentView currentView, CurrentView currentViewToCheck)
    {
        return (currentView == currentViewToCheck)? "active" : string.Empty;
    }
}
