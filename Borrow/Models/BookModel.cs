using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borrow.HelperClasses;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace Borrow.Models
{
  [XmlRoot("Database")]
  public class Database
  {
    [XmlArray("books")]
    public ObservableCollection<BookModel> allBooks = new ObservableCollection<BookModel>();
  }

  [XmlRoot("BookModel")]
  public class BookModel : ObservableObject
  {
    #region Fields;

    [XmlElement(ElementName = "ID")]
    private int _id;
    [XmlElement(ElementName = "Author")]
    private string _author;
    [XmlElement(ElementName = "Title")]
    private string _title;
    [XmlElement(ElementName = "Location")]
    private string _location;

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

    public string Author
    {
      get { return _author; }
      set
      {
        if (value != _author)
        {
          _author = value;
          OnPropertyChanged("Author");
        }
      }
    }

    public string Location
    {
      get { return _location; }
      set
      {
        if (value != _location)
        {
          _location = value;
          OnPropertyChanged("Location");
        }
      }
    }

    public string Title
    {
      get { return _title; }
      set
      {
        if (value != _title)
        {
          _title = value;
          OnPropertyChanged("Title");
        }
      }
    }

    #endregion Properties

    #region Constructors

    public BookModel()
    { }

    public BookModel(int reqId, string reqAuthor, string reqTitle, string reqLocation)
    {
      id = reqId;
      Author = reqAuthor;
      Title = reqTitle;
    }

    #endregion Constructors
  }
}
