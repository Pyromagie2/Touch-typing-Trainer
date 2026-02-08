using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
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
            setTextPointer();
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
                var runTemp = trainingText.Inlines.ElementAt(posisiton) as Run;
                runTemp.Background = Brushes.White;
                runTemp.Foreground = Brushes.Black;
                e.Handled = true;
            }
            
        }

        public void setTextPointer()
        {
            var run = trainingText.Inlines.ElementAt(posisiton) as Run;
            run.Background = Brushes.BurlyWood;
        }
        
  
        
        public void textToList()
        {
            
            textList.Clear();
            trainingText.Inlines.Clear();
            posisiton = 0;
            
           

            
            string path = string.Empty;

            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "(*.txt)|*.txt",
                FilterIndex = 1,
                Title = "Choose a txt File"
            };

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

            for (int i = 0; i < text.Length; i++)
            {
                char c = text[i];
                textList.Add(c);
                Console.Write(c);
                var run = new Run(c.ToString())
                {
                    Foreground = Brushes.Black 
                };
                trainingText.Inlines.Add(run);
                
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
            setTextPointer();
            
            
            e.Handled = true;
            
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            textToList();
        }

     

        public void TypingExercise()
        {
       

            char currentCharacter = textList[posisiton];
            
            var run = trainingText.Inlines.ElementAt(posisiton) as Run;

            if (run == null)
                return;

            if (currentCharacter == inputKey)
            {
                run.Foreground = Brushes.Green;  
            }
            else
            {
                run.Foreground = Brushes.Red;    
            }

            posisiton++;
        }

    }
}