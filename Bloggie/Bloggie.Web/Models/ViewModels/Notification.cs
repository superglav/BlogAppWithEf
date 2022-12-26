using Bloggie.Web.enums;

namespace Bloggie.Web.Models.ViewModels
{
    public class Notification
    {
        public List<string> Messages { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
    }
}
