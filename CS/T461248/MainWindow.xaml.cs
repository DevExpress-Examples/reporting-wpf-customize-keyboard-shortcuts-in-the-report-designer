using DevExpress.XtraReports.UI;
using System.Windows;
using System.Windows.Input;
using DevExpress.Mvvm;

namespace T461248 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            var viewModel = new MainWindowViewModel(new SampleReport());
            DataContext = viewModel;

            designer.RegisterHotKey(Key.OemTilde, ModifierKeys.Control, () => viewModel.TestCommand, null);
        }
    }

    public class MainWindowViewModel : ViewModelBase {
        public XtraReport Report { get; private set; }
        public ICommand TestCommand { get; private set; }

        public MainWindowViewModel(XtraReport report) {
            Report = report;
            TestCommand = new DelegateCommand(RunTestCommand);
        }

        void RunTestCommand() {
            GetService<IMessageBoxService>().ShowMessage("Test command.");
        }
    }
}
