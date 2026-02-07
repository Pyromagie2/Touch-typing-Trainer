using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace Touch_typing_Trainer
{
    public partial class Training : UserControl
    {
        private string zielText = "Hallo Welt";
        private int position = 0;
        
        public Training()
        {
            InitializeComponent();
            this.Loaded += Training_Loaded;
            this.MouseDown += (s, e) => HiddenInput.Focus();
        }
        
        private void Training_Loaded(object sender, RoutedEventArgs e)
        {
            HiddenInput.Focus();
        }
        
        private void HiddenInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = HiddenInput.Text;

           
                if (!string.IsNullOrEmpty(text))
                {

                   
                    Console.WriteLine(text);
                  
                }
            
            
        }
    }
}