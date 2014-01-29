using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Borrow.Models;
using Borrow.HelperClasses;
using System.Diagnostics;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows;
using Borrow.XMLDeserialization;

namespace Borrow.ViewModels
{
  public class LookUpInCatalogViewModel : BorrowViewModelBase
  {
    #region Fields

    private BookModel _selectedBook;
    private bool _isChecked;
    private ObservableCollection<BookModel> _catalog;

    #endregion Fields

    #region Properties

    /// <summary>
    /// Is bound to the checkbox on UI.
    /// Updates everytime the user clicks the UI button.
    /// </summary>
    public new bool isChecked
    {
      get { return _isChecked; }
      set
      {
        if (value != _isChecked)
        {
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

    /// <summary>
    /// Property that holds the current book the user has selected
    /// </summary>
    public BookModel SelectedBook
    {
      get { return _selectedBook; }
      set
      {
        if (value != _selectedBook)
        {
          _selectedBook = value;
          BookToBorrow.Author = _selectedBook.Author;
          BookToBorrow.Title = _selectedBook.Title;
          BookToBorrow.Location = _selectedBook.Location;
          OnPropertyChanged("SelectedBook");
        }
      }
    }

    #endregion Properties

    #region Data

    /// <summary>
    /// Collection
    /// </summary>
    public ObservableCollection<BookModel> Catalog
    {
      get { return _catalog; }
      set
      {
        if (_catalog != value)
        {
          _catalog = value;
          OnPropertyChanged("Catalog");
        }
      }
    }

    #endregion Data

    #region Methods

    internal override bool IsValid()
    {
      return true;
    }

    #endregion Methods

    #region Constructors

    public LookUpInCatalogViewModel(BookModel bookToBorrow) : base(bookToBorrow)
    {
      initialiseCollections();
    }

    public void initialiseCollections()
    {
      Catalog = new ObservableCollection<BookModel>();
      Catalog.Add(new BookModel() { Title = "title", Author = "author", Location = "shelf1" });
      Catalog.Add(new BookModel() { Title = "cheese", Author = "Terry", Location = "shelf2" });
      DeserializeXML xmlObj = new DeserializeXML();
      Catalog = xmlObj.DeserializeObject("LookUpInCatalog");
    }

    #endregion Constructors
  }
}
