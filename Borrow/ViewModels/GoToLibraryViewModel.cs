using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Borrow.ViewModels
{
  public class GoToLibraryViewModel : BorrowViewModelBase
  {
    #region Fields

    private string _goToLibraryString;
    private ICommand _goToLibraryCommand;

    #endregion Fields

    #region Properties / Commands

    public override string DisplayName
    {
      get { return "GoToLibrary"; }
    }

    public string goToLibraryString
    {
      get { return _goToLibraryString; }
      set
      {
        if (value != _goToLibraryString)
        {
          _goToLibraryString = value;
          OnPropertyChanged("goToLibraryString");
        }
      }
    }

    public ICommand goneToLibraryCommand
    {
      get { return _goToLibraryCommand; }
      set
      {
        if (value != _goToLibraryCommand)
        {
          _goToLibraryCommand = value;
          OnPropertyChanged("goToLibraryCommand");
        }
      }
    }

    #endregion Properties / Commands

    public GoToLibraryViewModel() { }

    #region Methods

    internal override bool IsValid()
    {
      return true;
    }

    #endregion Methods
  }
}
