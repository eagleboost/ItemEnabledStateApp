namespace ItemEnabledStateApp
{
  using System.Collections.Generic;

  /// <summary>
  /// IItemEnabledStateStore
  /// </summary>
  public interface IItemEnabledStateStore
  {
    #region Properties
    IReadOnlyCollection<ItemEnabledState> Items { get; }
    
    ItemEnabledState this[string name] { get; }
    #endregion Properties

    #region Methods
    void Update(string name, bool isEnabled, string reason = null);
    #endregion Methods
  }
}