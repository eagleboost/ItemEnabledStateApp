namespace ItemEnabledStateApp
{
  public class ItemEnabledState : NotifyPropertyChangedBase
  {
    public static readonly ItemEnabledState DefaultState = new ItemEnabledState {IsEnabled = true};
    
    private bool _isEnabled;
    private string _reason;
    public readonly string Name;

    private ItemEnabledState()
    {
    }
    
    public ItemEnabledState(string name, bool isEnabled = false, string reason = null)
    {
      Name = name;
      IsEnabled = isEnabled;
      Reason = reason;
    }
    
    public bool IsEnabled
    {
      get => _isEnabled;
      set => SetValue(ref _isEnabled, value);
    }
    
    public string Reason
    {
      get => _reason;
      set => SetValue(ref _reason, value);
    }

    public override string ToString()
    {
      return Name + " " + (_isEnabled ? "is enabled" : "is disabled") + (_reason != null ? ", " + _reason : null);
    }
  }
}