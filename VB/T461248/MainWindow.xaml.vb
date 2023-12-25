Imports DevExpress.XtraReports.UI
Imports System.Windows
Imports System.Windows.Input
Imports DevExpress.Mvvm

Namespace T461248

    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Public Partial Class MainWindow
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            AddHandler Loaded, AddressOf Me.MainWindow_Loaded
        End Sub

        Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim viewModel = New MainWindowViewModel(New SampleReport())
            DataContext = viewModel
            Me.designer.RegisterHotKey(Key.OemTilde, ModifierKeys.Control, Function() viewModel.TestCommand, Nothing)
        End Sub
    End Class

    Public Class MainWindowViewModel
        Inherits ViewModelBase

        Private _Report As XtraReport, _TestCommand As ICommand

        Public Property Report As XtraReport
            Get
                Return _Report
            End Get

            Private Set(ByVal value As XtraReport)
                _Report = value
            End Set
        End Property

        Public Property TestCommand As ICommand
            Get
                Return _TestCommand
            End Get

            Private Set(ByVal value As ICommand)
                _TestCommand = value
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
