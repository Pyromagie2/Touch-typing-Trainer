using System.Windows;
using System.Windows.Controls;

namespace Touch_typing_Trainer;

public partial class Stats : UserControl
{
    public Stats()
    {
        InitializeComponent();
    }

    private void ZuStart_OnClick(object sender, RoutedEventArgs e)
    {
        var main = (TouchTypingTrainer)Application.Current.MainWindow;
        main.Navigate(new StartPage());
    }
}