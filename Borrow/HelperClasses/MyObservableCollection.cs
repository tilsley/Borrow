using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Borrow.HelperClasses
{
  public class MyObservableCollection : ObservableCollection<object>
  {
    #region Fields

    private bool m_suppressNotifications;
    public delegate void MyObservableCollectionItemEventHandler(object senderIn, MyObservableCollectionItemEventArgs eventArgs);
    public event EventHandler CollectionCleared;
    public event EventHandler ItemsAdded;
    public event MyObservableCollectionItemEventHandler ItemAdded;
    public event MyObservableCollectionItemEventHandler ItemRemoved;
    public event MyObservableCollectionItemEventHandler ItemChanged;

    #endregion Fields

    #region Constructors

    public MyObservableCollection()
    {
    }

    #endregion Constructors

    #region Methods

    protected override void ClearItems()
    {
      base.ClearItems();
      if (!m_suppressNotifications && null != CollectionCleared)
        CollectionCleared(this, new EventArgs());
    }

    protected override void InsertItem(int index, object item)
    {
      base.InsertItem(index, item);
      if (!m_suppressNotifications && null != ItemAdded)
        ItemAdded(this, new MyObservableCollectionItemEventArgs(index, item));
    }

    protected override void RemoveItem(int index)
    {
      base.RemoveItem(index);
      if (!m_suppressNotifications && null != ItemRemoved)
        ItemRemoved(this, new MyObservableCollectionItemEventArgs(index));
    }

    protected override void SetItem(int index, object item)
    {
      base.SetItem(index, item);
      if (!m_suppressNotifications && null != ItemChanged)
        ItemChanged(this, new MyObservableCollectionItemEventArgs(index, item));
    }

    public void AddRange(ICollection<object> items)
    {
      m_suppressNotifications = true;
      foreach (object item in items)
        Add(item);
      m_suppressNotifications = false;

      if (null != ItemsAdded)
        ItemsAdded(this, new EventArgs());
    }

    #endregion Constructors
  }

  public class MyObservableCollectionItemEventArgs : EventArgs
  {
    private int m_index = -1;
    private object m_item;

    public MyObservableCollectionItemEventArgs(int index)
      : this(index, null)
    {

    }

    public MyObservableCollectionItemEventArgs(int index, object item)
    {
      m_index = index;
      m_item = item;
    }

    public int ItemIndex
    {
      get { return m_index; }
    }

    public object Item
    {
      get { return m_item; }
    }
  }
}
