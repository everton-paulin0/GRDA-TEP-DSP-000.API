using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GRDA_TEP_DSP_000.Domain.Entities.Enum
{
    public enum SessionTimes
    {
        [Description("Matutino")]
        Morning = 1,
        [Description("Vespertino")]
        Evening = 2,
        [Description("Almoço")]
        LunchBreak = 3,        
        [Description("Evento de Networking")]
        NetworkingEvent = 4


    }
}
