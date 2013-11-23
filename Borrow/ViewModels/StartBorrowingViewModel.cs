using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borrow.HelperClasses;
using System.Windows.Input;

namespace Borrow.ViewModels
{
  public class StartBorrowingViewModel : BorrowViewModelBase
  {
    #region Fields

    //private BookModel _bookModel;
    private int _bookID;
    private ICommand _getBook;

    #endregion Fields

    #region Properties / Commands

    public override string DisplayName
    {
      get { return "Books"; }
    }

    public int bookID
    {
      get { return _bookID; }
      set
      {
        if (value != _bookID)
        {
          _bookID = value;
          OnPropertyChanged("bookID");
        }
      }
    }

    #endregion Properties / Commands
    #region Helpers

    /*private void getBook()
    {
      BookModel b = new BookModel(1, "tim", "title");
      bookModel = b;
    }*/

    #endregion Helpers

    public StartBorrowingViewModel()
    { }

    #region Methods

    internal override bool IsValid()
    {
      return true;
    }

    #endregion Methods
  }
}
