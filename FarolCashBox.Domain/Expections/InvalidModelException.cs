using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarolCashBox.Domain.Expections
{
    public class InvalidModelException : Exception
    {
        public List<Notification> Notifications { get; set; }

        public InvalidModelException(List<Notification> notifications) : base("Invalid Model")
            => Notifications = notifications;
    }
}
