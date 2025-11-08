using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace GRDA_TEP_DSP_000.Application.Notification
{
    public class PalestraCreatedNotification : INotification
    {
        public PalestraCreatedNotification(int id, string subject)
        {
            Id = id;
            Subject = subject;
        }

        public int Id { get; set; }
        public string Subject { get; set; }
    }
}
