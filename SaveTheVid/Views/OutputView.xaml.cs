using System.Windows.Controls;

namespace SaveTheVid.Views
{
    /// <summary>
    /// Interaction logic for OutputView.xaml
    /// </summary>
    public partial class OutputView : UserControl
    {
        public OutputView()
        {
            InitializeComponent();
        }

        private bool isAutoScrollEnabled = true;

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            ScrollViewer sv = sender as ScrollViewer;
            if (e.ExtentHeightChange == 0)
            {
                if (sv.VerticalOffset == sv.ScrollableHeight)
                    isAutoScrollEnabled = true;
                else
                    isAutoScrollEnabled = false;
            }
            if (isAutoScrollEnabled && e.ExtentHeightChange != 0)
                sv.ScrollToVerticalOffset(sv.ExtentHeight);
        }
    }
}
