using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Borrow.Models;
using Borrow.HelperClasses;
using System.Diagnostics;

namespace Borrow.ViewModels
{
  public class LookUpInCatalogViewModel : BorrowViewModelBase
  {

    #region Fields

    private BookModel _bookModel;
    private int _bookID;
    private bool _isChecked;
    private ICommand _checkCommand;

    #endregion Fields

    #region Properties / Commands

    public new bool isChecked
    {
      get { return _isChecked; }
      set
      {
        if (value != _isChecked)
        {
          Debug.WriteLine(_isChecked);
          _isChecked = value;
          OnPropertyChanged("isChecked");
          if (_isChecked)
            base.isChecked = true;
          else
            base.isChecked = false;
        }
      }
    }

    public override string DisplayName
    {
      get { return "LookUpInCatalog"; }
    }

    public BookModel bookModel
    {
      get { return _bookModel; }
      set
      {
        if (value != _bookModel)
        {
          _bookModel = value;
          OnPropertyChanged("bookModel");
        }
      }
    }

    #endregion Properties / Commands
    #region Helpers

    private void getBook()
    {
      BookModel b = new BookModel(1, "tim", "title");
      bookModel = b;
    }

    #endregion Helpers

    public LookUpInCatalogViewModel()
    { }

    #region Methods

    internal override bool IsValid()
    {
      return true;
    }

    #endregion Methods
  }
}
