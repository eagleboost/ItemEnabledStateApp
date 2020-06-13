namespace ItemEnabledStateApp
{
  using System.Collections.Generic;
  using System.ComponentModel;
  using System.Runtime.CompilerServices;

  public class NotifyPropertyChangedBase : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetValue<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
      if (EqualityComparer<T>.Default.Equals(field, value))
      {
        return false;
      }

      field = value;
      RaisePropertyChanged(propertyName);
      return true;
    }
  }
}