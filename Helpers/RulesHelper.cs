using Modak.NotificationServiceTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modak.NotificationServiceTest.Helpers
{
    public class RulesHelper
    {
        public static bool NewsRule(Notification p_Notification, List<Notification> p_NotifiedUsers)
        {
            // News Rule - 1 Notification per day.

            // Finds the latest notification sent if nothing is found it means this user has not been sent a news notification yet, automatic true.
            Notification? sentNotification = p_NotifiedUsers.Where(x => x.User == p_Notification.User && x.Type == NotificationType.News).OrderByDescending(x => x.TimeStamp).FirstOrDefault();

            if (sentNotification != null)
                // If there is a notification we compare timestamps to check if the difference is greater or equal to 1 day.
                return ((p_Notification.TimeStamp - sentNotification.TimeStamp).TotalDays >= 1) ? true : false;

            return true;
        }

        public static bool StatusRule(Notification p_Notification, List<Notification> p_NotifiedUsers)
        {
            // Status Rule - not more than 2 notifications per minute

            // Finds the list of sent status notifications if we have 0 or 1 automatic true.
            List<Notification> sentNotifications = p_NotifiedUsers.Where(x => x.User == p_Notification.User && x.Type == NotificationType.Status).OrderByDescending(x => x.TimeStamp).ToList();

            if (sentNotifications.Count > 1)
            {
                // If there is 2 or more we compare to check if they are in within 1 minute.
                Notification last = sentNotifications[0];
                Notification secondToLast = sentNotifications[1];

                // If they are not within a minute, true.
                if ((last.TimeStamp - secondToLast.TimeStamp).TotalMinutes > 1)
                    return true;
                // If the last 2 are within a minute we need to check if the new notification is greater than 1 minute to the last.
                else if ((p_Notification.TimeStamp - last.TimeStamp).TotalMinutes > 1)
                    return true;
                else
                    return false;
            }
            return true;
        }

        public static bool MarketingRule(Notification p_Notification, List<Notification> p_NotifiedUsers)
        {
            // Marketing Rule - not more than 3 notifications per hour

            // Finds the list of sent marketing notifications, less than 3 automatic true.
            List<Notification> sentNotifications = p_NotifiedUsers.Where(x => x.User == p_Notification.User && x.Type == NotificationType.Marketing).OrderByDescending(x => x.TimeStamp).ToList();

            if (sentNotifications.Count > 2)
            {
                // Since there are 3 we grab the last and the second to last.
                Notification last = sentNotifications[0];
                Notification thirdToLast = sentNotifications[2];

                // If the last and second to last are not within the hour we can send the notification.
                if ((last.TimeStamp - thirdToLast.TimeStamp).Hours > 1)
                    return true;
                // If they are we check to see if the new notification is greater than 1 hour to the last.
                else if ((p_Notification.TimeStamp - last.TimeStamp).TotalHours > 1)
                    return true;
                else
                    return false;
            }
            return true;
        }
    }
}
