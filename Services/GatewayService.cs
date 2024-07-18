using Modak.NotificationServiceTest.Interfaces;
using Modak.NotificationServiceTest.Models;
using System.Text;

namespace Modak.NotificationServiceTest.Services
{
    public class GatewayService : IGatewayService
    {
        public void Send(Notification p_Notification)
        {
            // Builds string with the corresponding parameters.
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendFormat("Sending {0} to {1} message {2}", p_Notification.Type, p_Notification.User.Name, p_Notification.Message);
            Console.WriteLine(formattedMessage.ToString());
        }
    }
}
