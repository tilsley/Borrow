using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrow.Logging
{
  public class LogEntry
  {
    public DateTime DateTime { get; set; }

    public int Index { get; set; }

    public string Message { get; set; }

    public string Method { get; set; }
  }

  public class CollapsibleLogEntry : LogEntry
  {
    public List<LogEntry> Contents { get; set; }
  }
}
