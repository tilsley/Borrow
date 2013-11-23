using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Borrow.ViewModels;
using Borrow.Views;
using Borrow.Logging;

namespace Borrow
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    public LogViewer logViewer { get; set; }

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
      logViewer = new LogViewer(); BorrowWindow app = new BorrowWindow();
      logViewer.generateLogEntry("LogViewer Has been instantiated", "OnStartup");
      BorrowViewModel context = new BorrowViewModel();
      app.DataContext = context;
      app.Show();
      logViewer.Show();
    }

    public static new App Current
    {
      get { return Application.Current as App; }
    }
  }
}
