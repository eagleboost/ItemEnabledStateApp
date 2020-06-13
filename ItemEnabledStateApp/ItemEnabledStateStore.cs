namespace ItemEnabledStateApp
{
  using System.Collections.Generic;
  using System.Diagnostics;

  /// <summary>
  /// ItemEnabledStateStore
  /// </summary>
  [DebuggerDisplay("{Items.Count}")]
  public class ItemEnabledStateStore : NotifyPropertyChangedBase, IItemEnabledStateStore
  {
    private readonly Dictionary<string, ItemEnabledState> _items = new Dictionary<string, ItemEnabledState>();

    #region IItemEnabledStateProvider
    public IReadOnlyCollection<ItemEnabledState> Items => _items.Values;

    public ItemEnabledState this[string name] => GetOrDefault(name);

    public void Update(string name, bool isEnabled, string reason = null)
    {
      var state = GetOrCreate(name);
      state.IsEnabled = isEnabled;
      state.Reason = reason;
      RaisePropertyChanged("Item[]");
    }
    #endregion IItemEnabledStateProvider

    #region Private Methods
    private ItemEnabledState GetOrDefault(string name)
    {
      return _items.TryGetValue(name, out var state) ? state : ItemEnabledState.DefaultState;
    }
    
    private ItemEnabledState GetOrCreate(string name)
    {
      if (_items.TryGetValue(name, out var state))
      {
        return state;
      }

      return _items[name] = new ItemEnabledState(name);
    }
    #endregion Private Methods
  }
}