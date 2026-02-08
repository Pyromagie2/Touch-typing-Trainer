using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Win32;


namespace Touch_typing_Trainer
{
    public partial class Training : UserControl
    {
        private List<char> textList = new List<char>();
        int posisiton = 0;
        private char inputKey;
        
        public Training()
        {
            InitializeComponent();
            this.Loaded += Training_Loaded;
            this.TextInput += TrainingInput;
            this.PreviewKeyDown += Training_PreviewKeyDown;
            textToList();
        }
        
        private void Training_Loaded(object sender, RoutedEventArgs e)
        {
            this.Focus();
        }

        private void Training_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back && posisiton > 0)
            {
                posisiton--;
                e.Handled = true;
            }
            
        }

        
  
        
        public void textToList()
        {
            
            string path = string.Empty;
            
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "(*.txt)|*.txt";
            ofd.FilterIndex = 1;
            ofd.Title = "Choose a txt File";

            if (ofd.ShowDialog() == true)
            {
                path = ofd.FileName;
            }

            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Please select a file");
                textToList();
                return;
            }
            
            string text = File.ReadAllText(path);
            
            trainingText.Text = text;
            
            for (int i = 0; i < text.Length; i++)
            {
                textList.Add(text[i]);
            }
            foreach (char c in textList)
            {
                Console.Write(c);
            }
        }

        
        private void TrainingInput(object sender, TextCompositionEventArgs e)
        {
            string input  = e.Text;

            if (!string.IsNullOrEmpty(input))
            {
                inputKey = input[0];
            }

            TypingExercise();
            
            
            
            e.Handled = true;
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            textToList();
        }

     

        public void TypingExercise()
        {
            
                char currentCharacter = textList[posisiton];
                if (currentCharacter == inputKey)
                { 
                  Console.Write("GAAAAAAA");
                }
                
            
        }
    }
}