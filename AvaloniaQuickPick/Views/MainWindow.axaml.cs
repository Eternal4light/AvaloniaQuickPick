using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;

namespace AvaloniaQuickPick.Views
{
    public partial class MainWindow : Window
    {
        private double startPos = 0;
        private bool isCaptured = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ScrollViewerPointerPressed(object sender, PointerPressedEventArgs e)
        {
            startPos = e.GetPosition(MainScrollViewer).X;
            isCaptured = true;
        }

        private void ScrollViewerPointerReleased(object sender, PointerReleasedEventArgs e)
        {
            startPos = e.GetPosition(MainScrollViewer).X;
            isCaptured = false;
        }

        private void ScrollViewerPointerMoved(object sender, PointerEventArgs e)
        {
            if (!isCaptured)
                return;

            var offset = (e.GetPosition(MainScrollViewer).X - startPos);
            if (offset < 10 && offset > -10)
                return;

            var res = (MainScrollViewer.Offset.X - offset);

            MainScrollViewer.Offset = new Vector(res, MainScrollViewer.Offset.Y);
            startPos = e.GetPosition(MainScrollViewer).X;
        }
    }
}
