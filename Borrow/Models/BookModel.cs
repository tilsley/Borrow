using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borrow.HelperClasses;

namespace Borrow.Models
{
  public class BookModel : ObservableObject
  {
    #region Fields;

    private int _id;
    private string _author;
    private string _title;

    #endregion Fields;

    #region Properties;

    public int id
    {
      get { return _id; }
      set
      {
        if (value != _id)
        {
          _id = value;
          OnPropertyChanged("id");
        }
      }
    }

    public string author
    {
      get { return _author; }
      set
      {
        if (value != _author)
        {
          _author = value;
          OnPropertyChanged("author");
        }
      }
    }

    public string title
    {
      get { return _title; }
      set
      {
        if (value != _title)
        {
          _title = value;
          OnPropertyChanged("title");
        }
      }
    }

    #endregion Properties

    #region Constructors

    public BookModel()
    { }

    public BookModel(int reqId, string reqAuthor, string reqTitle)
    {
      id = reqId;
      author = reqAuthor;
      title = reqTitle;
    }

    #endregion Constructors
  }
}
