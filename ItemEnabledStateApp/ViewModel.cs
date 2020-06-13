namespace ItemEnabledStateApp
{
  public class ViewModel
  {
    public IItemEnabledStateStore ItemEnabledStateStore { get; } = new ItemEnabledStateStore();

    public string Name { get; set; }
    
    public string Address { get; set; }
  }
}