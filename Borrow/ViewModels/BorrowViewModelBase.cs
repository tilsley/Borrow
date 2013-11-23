﻿using System.ComponentModel;
using System.Diagnostics;

namespace Borrow.ViewModels
{
  /// <summary>
  /// Abstract base class for all pages shown in the wizard.
  /// </summary>
  public abstract class BorrowViewModelBase : INotifyPropertyChanged
  {
    #region Fields

    bool _isCurrentPage;
    private bool _hasBeenCompleted;
    private bool _isChecked;

    #endregion Fields

    #region Constructor

    public BorrowViewModelBase() { }

    #endregion Constructor

    #region Properties

    public virtual bool HasBeenCompleted
    { 
      get { return _hasBeenCompleted; } 
      set
      {
        if(value != _hasBeenCompleted)
        {
          _hasBeenCompleted = value;
          OnPropertyChanged("HasBeenCompleted");
        }
      }
    }

    public abstract string DisplayName { get; }

    public bool isChecked
    {
      get { return _isChecked; }
      set
      {
        if (value != _isChecked)
        {
          Debug.WriteLine(_isChecked);
          _isChecked = value;
          OnPropertyChanged("isChecked");
        }
        App.Current.logViewer.generateLogEntry("the user has clicked the box", "isChecked");
      }
    }

    public bool IsCurrentPage
    {
      get { return _isCurrentPage; }
      set
      {
        if (value == _isCurrentPage)
          return;

        _isCurrentPage = value;
        this.OnPropertyChanged("IsCurrentPage");
      }
    }

    #endregion Properties

    #region Methods

    /// <summary>
    /// Returns true if the user has filled in this page properly
    /// and the wizard should allow the user to progress to the 
    /// next page in the workflow.
    /// </summary>
    internal abstract bool IsValid();

    #endregion // Methods

    #region INotifyPropertyChanged Members

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
      PropertyChangedEventHandler handler = this.PropertyChanged;
      if (handler != null)
        handler(this, new PropertyChangedEventArgs(propertyName));
    }

    #endregion INotifyPropertyChanged Members
  }
}