using System.Windows;
using System.Windows.Controls;

namespace Touch_typing_Trainer;

public partial class StartPage : UserControl
{
    public StartPage()
    {
        InitializeComponent();
    }

    private void ZuStats_OnClick(object sender, RoutedEventArgs e)
    {
        var main = (TouchTypingTrainer)Application.Current.MainWindow;
        main.Navigate(new Stats());
    }

    private void DifficultyMedium_OnClick(object sender, RoutedEventArgs e)
    {
        var main = (TouchTypingTrainer)Application.Current.MainWindow;
        main.Navigate(new Training());
    }

    private void DifficultyLow_OnClick(object sender, RoutedEventArgs e)
    {
        var main = (TouchTypingTrainer)Application.Current.MainWindow;
        main.Navigate(new Training());
    }

    private void DifficultyHigh_OnClick(object sender, RoutedEventArgs e)
    {
        var main = (TouchTypingTrainer)Application.Current.MainWindow;
        main.Navigate(new Training());
    }

    private void ExitButton_OnClick(object sender, RoutedEventArgs e)
    {
        Window.GetWindow(this).Close();
    }
}