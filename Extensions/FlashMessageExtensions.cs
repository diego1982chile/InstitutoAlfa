using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

internal static class FlashMessageExtensions
{
    public static ActionResult Danger(this ActionResult result, string message)
    {
        CreateCookieWithFlashMessage(Notification.Danger, message);
        return result;
    }

    public static ActionResult Warning(this ActionResult result, string message)
    {
        CreateCookieWithFlashMessage(Notification.Warning, message);
        return result;
    }

    public static ActionResult Success(this ActionResult result, string message)
    {
        CreateCookieWithFlashMessage(Notification.Success, message);
        return result;
    }

    public static ActionResult Information(this ActionResult result, string message)
    {
        CreateCookieWithFlashMessage(Notification.Info, message);
        return result;
    }

    private static void CreateCookieWithFlashMessage(Notification notification, string message)
    {
        HttpContext.Current.Response.Cookies.Add(new HttpCookie(string.Format("Flash.{0}", notification), message) { Path = "/" });
    }

    private enum Notification
    {
        Danger,
        Warning,
        Success,
        Info
    }
}