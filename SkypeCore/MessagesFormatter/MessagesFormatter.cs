using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkypeCore.MessagesFormatter
{
    public interface IMessagesFormatter
    {
        string FormatMessages(List<SkypeMessage> messages);
    }
}
