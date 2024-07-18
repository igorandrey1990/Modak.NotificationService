using Modak.NotificationServiceTest.Models;
using Modak.NotificationServiceTest.Services;

namespace Modak.NotificationServiceTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Creates instance of NotificationService injecting Gateway service into the constructor.
            NotificationService notificationService = new NotificationService(new GatewayService());

            // Creates users that will be receiving notifications.
            User userOne = new User(1, "Igor");
            User userTwo = new User(2, "Chris");
            User userThree = new User(3, "Kelly");

            DateTime testDate = DateTime.Now;

            #region Test Case 1 - Same User News Notifications

            // Fisrt News Notification - Should Work
            Notification notificationOne = new Notification(1, userOne, NotificationType.News, "News 1", testDate);
            notificationService.Send(notificationOne);

            // Second News Notification Same User - 1 Hour Should Not Work
            Notification notificationTwo = new Notification(2, userOne, NotificationType.News, "News 2", testDate.AddHours(1));
            notificationService.Send(notificationTwo);

            // Third News Notification Same User - 1 Day Should Work
            Notification notificationThree = new Notification(3, userOne, NotificationType.News, "News 3", testDate.AddDays(1));
            notificationService.Send(notificationThree);
            #endregion

            #region Test Case 2 - Same User Status Notications

            // Fisrt Status Notification - Should Work
            Notification notificationFour = new Notification(4, userOne, NotificationType.Status, "Status 1", testDate);
            notificationService.Send(notificationFour);

            // Second Status Notification Same User - 30 Seconds Should Work
            Notification notificationFive = new Notification(5, userOne, NotificationType.Status, "Status 2", testDate.AddSeconds(30));
            notificationService.Send(notificationFive);


            // Third Status Notification Same User Inside 1 Minute Mark - Should Not Work
            Notification notificationSix = new Notification(6, userOne, NotificationType.Status, "Status 3", testDate.AddSeconds(30));
            notificationService.Send(notificationSix);

            // Fourth Status Notification Same User After 1 Minute Mark - Should Work
            Notification notificationSeven = new Notification(7, userOne, NotificationType.Status, "Status 4", testDate.AddMinutes(2));
            notificationService.Send(notificationSeven);
            #endregion

            #region Test Case 3 - Same User Marketing Notifications

            // Fisrt Marketing Notification - Should Work
            Notification notificationEight = new Notification(8, userOne, NotificationType.Marketing, "Marketing 1", testDate);
            notificationService.Send(notificationEight);

            // Second Marketing Notification Same User - 15 Minutes Should Work
            Notification notificationNine = new Notification(9, userOne, NotificationType.Marketing, "Marketing 2", testDate.AddMinutes(15));
            notificationService.Send(notificationNine);

            // Third Marketing Notification Same User - 15 Minutes Later Should Work
            Notification notificationTen = new Notification(10, userOne, NotificationType.Marketing, "Marketing 3", testDate.AddMinutes(15));
            notificationService.Send(notificationTen);

            // Fourth Marketing Notification Same User - 2 Minutes Later Should Not Work
            Notification notificationEleven = new Notification(11, userOne, NotificationType.Marketing, "Marketing 4", testDate.AddMinutes(2));
            notificationService.Send(notificationEleven);

            // Fifth Marketing Notification Same User - 2 Hours Later Should Not Work
            Notification notificationTwelve = new Notification(12, userOne, NotificationType.Marketing, "Marketing 5", testDate.AddHours(2));
            notificationService.Send(notificationTwelve);
            #endregion
        }
    }
}
