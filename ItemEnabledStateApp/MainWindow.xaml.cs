using System.Windows;

namespace ItemEnabledStateApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      var vm = new ViewModel {Name = "eagleboost"};
      vm.ItemEnabledStateStore.Update("Name", false, "Name is not allowed to change");
      DataContext = vm;
    }
  }
}