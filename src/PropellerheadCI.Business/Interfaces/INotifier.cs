using PropellerheadCI.Business.Notifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace PropellerheadCI.Business.Interfaces
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
