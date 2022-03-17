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
                var input = this.FindControl<TextBox>("RegexInput");
                try
                {
                    Regex rg = new(input.Text);
                    this.Close(input.Text);
                }
                catch (Exception)
                {
                    input.Text = "INVALID REGEX";
                }
            };
            this.FindControl<Button>("Cancel").Click += delegate
            {
                this.Close();
            };
        }
        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
