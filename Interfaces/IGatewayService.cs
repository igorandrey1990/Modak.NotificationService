using Modak.NotificationServiceTest.Models;

namespace Modak.NotificationServiceTest.Interfaces
{
    public interface IGatewayService
    {
        public void Send(Notification p_Notification);
    }
}
