using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modak.NotificationServiceTest.Models
{
    public class Notification
    {
        public Notification(int p_Id, User p_User, NotificationType p_NotificationType, string p_Message, DateTime p_TimeStamp) {
            Id = p_Id; 
            User = p_User; 
            Type = p_NotificationType; 
            Message = p_Message; 
            TimeStamp = p_TimeStamp;
        }
        public int Id { get; set; }
        public User User { get; set; }
        public NotificationType Type { get; set; }
        public string Message { get; set; }
        public DateTime TimeStamp { get; set; }
        public int Count { get; set; }
    }

    public enum NotificationType
    {
        News,
        Status,
        Marketing
    }
}
