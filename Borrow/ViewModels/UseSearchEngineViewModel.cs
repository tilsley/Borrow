using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borrow.ViewModels
{
  public class UseSearchEngineViewModel : BorrowViewModelBase
  {
    public override string DisplayName
    {
      get { return "UseSearchEngine"; }
    }

    internal override bool IsValid()
    {
      return true;
    }
  }
}
