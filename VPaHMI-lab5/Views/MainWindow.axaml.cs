using Avalonia.Controls;
using Avalonia.Interactivity;
using VPaHMI_lab5.ViewModels;

namespace VPaHMI_lab5.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.FindControl<Button>("OpenFile").Click += async delegate
            {
                var taskPath = new OpenFileDialog()
                .ShowAsync(this);

                string[]? path = await taskPath;
                var context = this.DataContext as MainWindowViewModel;
                if (path is not null)
                {
                    context.ReadFileToInput(string.Join("/", path));
                }

            };

            this.FindControl<Button>("SaveFile").Click += async delegate
            {
                var taskPath = new SaveFileDialog()
                .ShowAsync(this);

                string path = await taskPath;
                var context = this.DataContext as MainWindowViewModel;
                if (path is not null)
                {
                    context.SaveOutputInFile(path);
                }

            };

        }
        public async void ShowRegexSetWindow(object sender, RoutedEventArgs e)
        {
            var context = this.DataContext as MainWindowViewModel;
            string? str = await new SetRegexWindow().ShowDialog<string?>((Window)this.VisualRoot);
            context.Regex = str;
        }
    }
}
