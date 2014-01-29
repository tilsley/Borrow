using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Borrow.Models;
using System.Windows.Input;
using Borrow.HelperClasses;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Borrow.ViewModels
{
  public class UseSearchEngineViewModel : BorrowViewModelBase
  {
    #region Fields

    private BookModel _currentBook;
    private int _bookID;
    private ICommand _getBook;
    private ObservableCollection<BookModel> _database;

    #endregion Fields

    #region Properties

    public override string DisplayName
    {
      get { return "UseSearchEngine"; }
    }

    /// <summary>
    /// This holds the current book the user has searched for, and is displayed on the UI
    /// </summary>
    public BookModel CurrentBook
    {
      get { return _currentBook; }
      set
      {
        if (value != _currentBook)
        {
          _currentBook = value;
          OnPropertyChanged("CurrentBook");
        }
      }
    }

    /// <summary>
    /// Holds the book ID we are looking for
    /// </summary>
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

    #endregion Properties

    #region Commands

    /// <summary>
    /// A command for getting a book from some place.
    /// </summary>
    public ICommand getBookCommand
    {
      get
      {
        if (_getBook == null)
        {
          _getBook = new RelayCommand(
              () => getBook(),
              () => bookID > 0
          );
        }
        return _getBook;
      }
    }

    #endregion Commands

    #region Data

    public ObservableCollection<BookModel> Database
    {
      get { return _database; }
      set
      {
        if (value != _database)
        {
          _database = value;
          OnPropertyChanged("Database");
        }
      }
    }

    #endregion Data

    #region Constructors

    public UseSearchEngineViewModel(BookModel bookToBorrow) :base(bookToBorrow)
    {
      Database = new ObservableCollection<BookModel>();
      Database.Add(new BookModel() { Title = "hello", Author = "tim", Location = "Shelf1", id = 1 });
    }

    #endregion Constructors

    internal override bool IsValid()
    {
      return true;
    }
    
    #region Helpers

    public bool bookIDIsValid()
    {
      if (bookID < Database.Count() && bookID > 0)
        return true;
      else
        return false;
    }

    public void getBook()
    {
    }

    #endregion Helpers
  }
}
