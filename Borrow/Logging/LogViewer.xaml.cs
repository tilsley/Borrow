using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading;
using System.Diagnostics;

namespace Borrow.Logging
{
  /// <summary>
  /// Interaction logic for LogViewer.xaml
  /// </summary>
  public partial class LogViewer : Window
  {
    #region Fields

    public ObservableCollection<LogEntry> LogEntries { get; set; }
    private int index = 1;

    #endregion Fields

    #region constructors

    public LogViewer()
    {
      InitializeComponent();
      DataContext = LogEntries = new ObservableCollection<LogEntry>();
    }

    #endregion constructors

    #region Generate/Display LogEntry Methods

    /// <summary>
    /// This method is called by the app, whenever a log entry needs to be added
    /// </summary>
    /// <param name="message"></param>
    /// <param name="method"></param>
    public void generateLogEntry(string message, string method)
    {
      LogEntry newLogEntry = new LogEntry()
      {
        Index = index++,
        DateTime = DateTime.Now,
        Message = "Message: " + message,
        Method = "Method: " + method,
      };
      displayLogEntry(newLogEntry);
    }

    /// <summary>
    /// Displays the new log entry on the screen, 
    /// </summary>
    /// <param name="logEntry"></param>
    private void displayLogEntry(LogEntry logEntry)
    {
      LogEntries.Add(logEntry);
    }

    #endregion Generate/Display LogEntry Methods
  }
}
