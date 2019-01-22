using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using code.ViewModel;

namespace code.View.WPF
{
    /// <summary>
    /// DataPanel.xaml 的交互逻辑
    /// </summary>
    public partial class DataPanel : UserControl
    {
        public DataTempletViewModel DataTempletViewModel { get; set; }

        public DocumentViewModel DocumentViewModel { get; set; }

        public DataPanel()
        {
            InitializeComponent();
            DataTempletViewModel = new DataTempletViewModel();
            DocumentViewModel = new DocumentViewModel();

            this.DataTempletTree.ItemsSource = DataTempletViewModel.Root;
        }

        private void DataTempletScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta)
            {
                RoutedEvent = UIElement.MouseWheelEvent,
                Source = sender
            };
            DataTempletScrollViewer.RaiseEvent(eventArg);
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            DataTempletItem item = DataTempletTree.SelectedItem as DataTempletItem;
            DocumentViewModel.InsertBookMark(item.Name);
        }
    }
}
