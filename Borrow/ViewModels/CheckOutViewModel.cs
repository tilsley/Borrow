using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borrow.Models;
using System.Diagnostics;
using System.Windows.Input;
using Borrow.HelperClasses;

namespace Borrow.ViewModels
{
  public class CheckOutViewModel : BorrowViewModelBase
  {
    #region Fields

    #endregion Fields

    #region Properties

    public override string DisplayName
    {
      get { return "CheckOut"; }
    }

    #endregion Properties

    #region Constructors

    public CheckOutViewModel(BookModel bookToBorrow) : base(bookToBorrow)
    {
    }

    #endregion Constructors

    #region Methods

    internal override bool IsValid()
    {
      return true;
    }

    #endregion Methods
  }
}
