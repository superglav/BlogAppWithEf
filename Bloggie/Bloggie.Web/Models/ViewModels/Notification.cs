using Bloggie.Web.enums;

namespace Bloggie.Web.Models.ViewModels
{
    public class Notification
    {
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
