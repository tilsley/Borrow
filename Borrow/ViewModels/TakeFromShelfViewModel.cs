using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrow.ViewModels
{
  public class TakeFromShelfViewModel : BorrowViewModelBase
  {
    #region Properties / Commands

    public override string DisplayName
    {
      get { return "TakeFromShelf"; }
    }

    #endregion Properties / Commands

    internal override bool IsValid()
    {
      return true;
    }
  }
}
