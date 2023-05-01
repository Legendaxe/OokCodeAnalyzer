using System;
using System.Linq;
using System.Windows;
using Analyzer;


namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AnalyzeButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.AnalyzerOutput.Text = string.Join(Environment.NewLine,
                Analyzer.Analyzer.ScrapTextForLexemes(this.InputCode.Text));
        }

        private void SynthesizerButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.InputCode.Text = Synthesizer.Synthesizer.SynthesizeOokCodeByStateMachine(50);
        }
    }
}