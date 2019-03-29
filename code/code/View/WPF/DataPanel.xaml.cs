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

        public RecordViewModel RecordViewModel { get; set; }

        public DataPanel()
        {
            InitializeComponent();
            DataTempletViewModel = new DataTempletViewModel();
            DocumentViewModel = new DocumentViewModel();
            RecordViewModel = new RecordViewModel(DocumentViewModel.DocumentModel.APIVersion, @"E:\\user\\code\\ReportGenerator\\code\\Input\\tape.xml");

            this.DataTempletTree.ItemsSource = DataTempletViewModel.Root;
            this.BookmarkHeader.Text = "书签组";
            this.DataHeader.Text = "数据组";
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
            int? cellrow = null, cellcolumn = null;
            DocumentViewModel.InsertBookMark(item.Name, ref cellrow, ref cellcolumn);

            GeneratorBase.MethodParams mp
                = new GeneratorBase.MethodParams(item.Name, item.Path, ((cellrow == null && cellcolumn == null) ? false : true), cellrow - 1, cellcolumn - 1);
            // DocumentViewModel.CallMethod(MethodName, mp);

            RecordViewModel.AddRecord(GeneratorBase.MethodName.DynamicInsert, mp);
        }

        private void SaveTemplateButton_Click(object sender, RoutedEventArgs e)
        {
            RecordViewModel.Recorder.Save();
            DocumentViewModel.SaveAs(@"E:\\user\\code\\ReportGenerator\\code\\Input\\Template.docx");
        }

        private void InsertBookmark_Click(object sender, RoutedEventArgs e)
        {
            DocumentViewModel.InsertBookMarks(this.BookmarkHeader.Text);            
        }

        private void StaticInsert_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
