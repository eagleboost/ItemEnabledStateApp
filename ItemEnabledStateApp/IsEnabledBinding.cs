namespace ItemEnabledStateApp
{
  using System;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Data;

  /// <summary>
  /// IsEnabledBinding
  /// </summary>
  public class IsEnabledBinding : BindingDecoratorBase
  {
    public IsEnabledBinding(string id)
    {
      Id = id;
    }

    public string Id { get; set; }
    
    public override object ProvideValue(IServiceProvider provider)
    {
      var pathPrefix = "ItemEnabledStateStore[" + Id + "].";
      Binding.Path = new PropertyPath(pathPrefix + "IsEnabled");
      
      if (TryGetTargetItems(provider, out var obj, out var dp))
      {
        var element = (FrameworkElement)obj;
        var toolTipBinding = new Binding(pathPrefix + "Reason");
        element.SetBinding(FrameworkElement.ToolTipProperty, toolTipBinding);
        ToolTipService.SetShowOnDisabled(element, true);
      }
      
      return base.ProvideValue(provider);
    }
  }
}