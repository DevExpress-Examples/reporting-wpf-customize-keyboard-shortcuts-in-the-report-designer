Imports DevExpress.XtraReports.UI
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Mvvm

Namespace T461248
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitializeComponent()
            AddHandler Loaded, AddressOf MainWindow_Loaded
        End Sub

        Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim viewModel = New MainWindowViewModel(New SampleReport())
            DataContext = viewModel

            designer.RegisterHotKey(Key.OemTilde, ModifierKeys.Control, Function() viewModel.TestCommand, Nothing)
        End Sub
    End Class

    Public Class MainWindowViewModel
        Inherits ViewModelBase

        Private privateReport As XtraReport
        Public Property Report() As XtraReport
            Get
                Return privateReport
            End Get
            Private Set(ByVal value As XtraReport)
                privateReport = value
            End Set
        End Property
        Private privateTestCommand As ICommand
        Public Property TestCommand() As ICommand
            Get
                Return privateTestCommand
            End Get
            Private Set(ByVal value As ICommand)
                privateTestCommand = value
            End Set
        End Property

        Public Sub New(ByVal report As XtraReport)
            Me.Report = report
            TestCommand = New DelegateCommand(AddressOf RunTestCommand)
        End Sub

        Private Sub RunTestCommand()
            GetService(Of IMessageBoxService)().ShowMessage("Test command.")
        End Sub
    End Class
End Namespace
