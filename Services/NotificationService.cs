using Modak.NotificationServiceTest.Helpers;
using Modak.NotificationServiceTest.Interfaces;
using Modak.NotificationServiceTest.Models;
using System.Reflection.Metadata.Ecma335;

namespace Modak.NotificationServiceTest.Services
{
    public class NotificationService
    {
        List<Notification> NotifiedUsers = new List<Notification>();
        IGatewayService _GatewayService;

        public NotificationService(IGatewayService p_Gateway)
        {
            _GatewayService = p_Gateway;
        }

        public void Send(Notification p_Notification)
        {
            try
            {
                // Checks if Notification fits the rules.
                if (CheckRules(p_Notification))
                {
                    // Add Notification to "database".
                    NotifiedUsers.Add(p_Notification);
                    // Calls Send function from gateway service.
                    _GatewayService.Send(p_Notification);
                }
                else
                {
                    // If notification rules have been exceeded.
                    throw new Exception("Too many notifications sent.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private bool CheckRules(Notification p_Notification)
        {
            // Calls the corresponding method of notification type.
            switch (p_Notification.Type)
            {
                case NotificationType.News:
                    return RulesHelper.NewsRule(p_Notification, NotifiedUsers);
                case NotificationType.Status:
                    return RulesHelper.StatusRule(p_Notification, NotifiedUsers);
                case NotificationType.Marketing:
                    return RulesHelper.MarketingRule(p_Notification, NotifiedUsers);
                default:
                    return false;
            }
        }
    }
}
