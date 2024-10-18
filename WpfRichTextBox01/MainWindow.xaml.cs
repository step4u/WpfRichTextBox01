using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfRichTextBox01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void richTextBox_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift)
        //    {
        //        e.Handled = true;

        //        // 현재 캐럿 위치를 가져옵니다
        //        TextPointer caretPos = richTextBox.CaretPosition;

        //        // Soft line break (LineFeed)를 삽입합니다
        //        caretPos.InsertTextInRun("\n");

        //        // 캐럿을 새로 삽입된 줄바꿈 다음으로 이동합니다
        //        richTextBox.CaretPosition = caretPos.GetPositionAtOffset(1, LogicalDirection.Forward);

        //        // 레이아웃 업데이트를 강제로 실행합니다
        //        richTextBox.UpdateLayout();

        //        // 문서의 전체 높이를 계산합니다
        //        double totalHeight = richTextBox.ExtentHeight;

        //        // 현재 보이는 영역의 높이를 가져옵니다
        //        double viewportHeight = richTextBox.ViewportHeight;

        //        // 문서의 전체 높이가 뷰포트 높이보다 크면 맨 아래로 스크롤합니다
        //        if (totalHeight > viewportHeight)
        //        {
        //            richTextBox.ScrollToEnd();
        //        }

        //        // 캐럿을 보이게 만듭니다
        //        richTextBox.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
        //    }
        //}
    }
}