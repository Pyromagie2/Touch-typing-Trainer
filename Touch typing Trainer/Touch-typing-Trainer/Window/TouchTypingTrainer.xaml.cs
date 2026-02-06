using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Touch_typing_Trainer;

public partial class TouchTypingTrainer : Window
{
    public TouchTypingTrainer()
    {
        InitializeComponent();
        Navigate(new StartPage());
    }

    public void Navigate(UserControl page)
    {
        MainContent.Content = page;
    }
}