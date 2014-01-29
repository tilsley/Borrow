using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Borrow.HelperClasses;
using System.Windows;
using Borrow.Models;

namespace Borrow.ViewModels
{
  /// <summary>
  /// The main ViewModel class for the wizard.
  /// This class contains the various pages shown
  /// in the workflow and provides navigation
  /// between the pages.
  /// </summary>
  public class BorrowViewModel : INotifyPropertyChanged
  {
    #region Fields

    RelayCommand _cancelCommand;
    BorrowViewModelBase _currentPage;
    RelayCommand _moveNextCommand;
    RelayCommand _movePreviousCommand;
    ReadOnlyCollection<BorrowViewModelBase> _pages;
    private BookModel _bookToBorrow;

    #endregion // Fields

    #region Constructor

    public BorrowViewModel()
    {
      _bookToBorrow = new BookModel();
      this.CurrentPage = this.Pages[0];
      this.Pages[0].IsCurrentPage = true;
      App.Current.logViewer.generateLogEntry("create view model for whole screen", "BorrowViewModel");     
    }

    #endregion // Constructor

    #region Commands

    public ICommand CancelCommand
    {
      get
      {
        if (_cancelCommand == null)
          _cancelCommand = new RelayCommand(() => this.CancelOrder());

        return _cancelCommand;
      }
    }

    void CancelOrder()
    {
      this.OnRequestClose();
    }

    #region MovePreviousCommand

    /// <summary>
    /// Returns the command which, when executed, causes the CurrentPage 
    /// property to reference the previous page in the workflow.
    /// </summary>
    public ICommand MovePreviousCommand
    {
      get
      {
        if (_movePreviousCommand == null)
          _movePreviousCommand = new RelayCommand(
              () => this.MoveToPreviousPage(),
              () => this.CanMoveToPreviousPage);

        return _movePreviousCommand;
      }
    }

    bool CanMoveToPreviousPage
    {
      get { return 0 < this.CurrentPageIndex; }
    }

    void MoveToPreviousPage()
    {
      if (this.CanMoveToPreviousPage)
      {
        this.CurrentPage = this.Pages[this.CurrentPageIndex - 1];
        if(this.CurrentPageIndex > 0)
          this.Pages[this.CurrentPageIndex].HasBeenCompleted = false;
        App.Current.logViewer.generateLogEntry("user has moved back a page", "CanMoveToPreviousPage");
      }
    }

    #endregion // MovePreviousCommand

    #region MoveNextCommand

    /// <summary>
    /// Returns the command which, when executed, causes the CurrentPage 
    /// property to reference the next page in the workflow.  If the user
    /// is viewing the last page in the workflow, this causes the Wizard
    /// to finish and be removed from the user interface.
    /// </summary>
    public ICommand MoveNextCommand
    {
      get
      {
        if (_moveNextCommand == null)
          _moveNextCommand = new RelayCommand(
              () => this.MoveToNextPage(),
              () => this.CanMoveToNextPage);

        return _moveNextCommand;
      }
    }

    bool CanMoveToNextPage
    {
      get { return this.CurrentPage != null && this.CurrentPage.IsValid(); }
    }


    /// <summary>
    /// When moving to next page checks if there is tick box, which means 
    /// a user needs to perform a task. Then a new task is added to the system.
    /// </summary>
    void MoveToNextPage()
    {
      if (this.CanMoveToNextPage)
      {
        if (this.CurrentPage.isChecked)
        {
          List<BorrowViewModelBase> temp = new List<BorrowViewModelBase>(Pages);
          temp.Insert(3, new UseSearchEngineViewModel(this.BookToBorrow));
          Pages = new ReadOnlyCollection<BorrowViewModelBase>(temp);
          this.CurrentPage.isChecked = false;
          App.Current.logViewer.generateLogEntry("User moves to next page and another task has been added", "MoveToNextPage");
        }
        if (this.CurrentPageIndex < this.Pages.Count - 1)
        {
          this.Pages[this.CurrentPageIndex].HasBeenCompleted = true;

          for(int i = 0; i <= this.CurrentPageIndex; i++)
            Debug.WriteLine(this.Pages[this.CurrentPageIndex].HasBeenCompleted);
          this.CurrentPage = this.Pages[this.CurrentPageIndex + 1];
          App.Current.logViewer.generateLogEntry("User moves to next page", "MoveToNextPage");
        }
        else
        {
          this.OnRequestClose();
          App.Current.logViewer.generateLogEntry("User has finished", "MoveToNextPage");
        }
      }
    }

    #endregion // MoveNextCommand

    #endregion // Commands

    #region Properties

    public BookModel BookToBorrow
    {
      get { return _bookToBorrow; }
    }

    /// <summary>
    /// Returns the page ViewModel that the user is currently viewing.
    /// </summary>
    public BorrowViewModelBase CurrentPage
    {
      get { return _currentPage; }
      private set
      {
        if (value == _currentPage)
          return;

        if (_currentPage != null)
          _currentPage.IsCurrentPage = false;

        _currentPage = value;

        if (_currentPage != null)
          _currentPage.IsCurrentPage = true;

        this.OnPropertyChanged("CurrentPage");
        this.OnPropertyChanged("IsOnLastPage");
      }
    }

    /// <summary>
    /// Returns true if the user is currently viewing the last page 
    /// in the workflow.  This property is used by CoffeeWizardView
    /// to switch the Next button's text to "Finish" when the user
    /// has reached the final page.
    /// </summary>
    public bool IsOnLastPage
    {
      get { return this.CurrentPageIndex == this.Pages.Count - 1; }
    }

    /// <summary>
    /// Returns a read-only collection of all page ViewModels.
    /// </summary>
    public ReadOnlyCollection<BorrowViewModelBase> Pages
    {
      get
      {
        if (_pages == null)
        {
          this.CreatePages();
          OnPropertyChanged("Pages");
        }
        return _pages;
      }
      set
      {
        if (value != _pages)
        {
          _pages = value;
          OnPropertyChanged("Pages");
        }
      }
    }

    #endregion // Properties

    #region Events

    /// <summary>
    /// Raised when the wizard should be removed from the UI.
    /// </summary>
    public event EventHandler RequestClose;

    #endregion // Events
   
    #region Private Helpers

    void CreatePages()
    {
      var pages = new List<BorrowViewModelBase>();

      pages.Add(new GoToLibraryViewModel());
      pages.Add(new LookUpInCatalogViewModel(this.BookToBorrow));
      pages.Add(new TakeFromShelfViewModel());
      pages.Add(new CheckOutViewModel(this.BookToBorrow));

      _currentPage = pages[0];

      _pages = new ReadOnlyCollection<BorrowViewModelBase>(pages);
    }

    int CurrentPageIndex
    {
      get
      {

        if (this.CurrentPage == null)
        {
          Debug.Fail("Why is the current page null?");
          return -1;
        }

        return this.Pages.IndexOf(this.CurrentPage);
      }
    }

    void OnRequestClose()
    {
      Debug.WriteLine("made2");
      EventHandler handler = this.RequestClose;
      if (handler != null)
      {
        Debug.WriteLine("made");
        handler(this, EventArgs.Empty);
      }
    }

    #endregion // Private Helpers

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = this.PropertyChanged;
      if (handler != null)
        handler(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion // INotifyPropertyChanged Members
  }
}
