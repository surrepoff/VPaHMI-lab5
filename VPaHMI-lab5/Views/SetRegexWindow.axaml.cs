using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using VPaHMI_lab5.ViewModels;
using System;
using System.Text.RegularExpressions;

namespace VPaHMI_lab5.Views
{
    public partial class SetRegexWindow : Window
    {
        public SetRegexWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif

            this.FindControl<Button>("OK").Click += delegate
                {
                    var context = this.Owner.DataContext as MainWindowViewModel;
                    var inputField = this.FindControl<TextBox>("RegexInput");
                    try
                    {
                        Regex rg = new Regex(inputField.Text);
                        context.Regex = inputField.Text;
                        this.CloseWindow();
                    }
                    catch (Exception)
                    {
                        inputField.Text = "INVALID REGEX";
                    }

                };
            this.FindControl<Button>("Cancel").Click += delegate
            {
                CloseWindow();
            };
        }
        private void CloseWindow()
        {
            this.Close();
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
