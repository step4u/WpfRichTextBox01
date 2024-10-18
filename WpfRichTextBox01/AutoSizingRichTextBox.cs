using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfRichTextBox01
{
    public class AutoSizingRichTextBox : RichTextBox
    {
        public AutoSizingRichTextBox()
        {
            TextChanged += OnTextChanged;
            SizeChanged += OnSizeChanged;
            PreviewKeyDown += AutoSizingRichTextBox_PreviewKeyDown;
        }

        private void AutoSizingRichTextBox_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && Keyboard.Modifiers == ModifierKeys.Shift)
            {
                e.Handled = true;

                TextPointer caretPos = CaretPosition;

                caretPos.InsertTextInRun("\n");

                CaretPosition = caretPos.GetPositionAtOffset(1, LogicalDirection.Forward);

                UpdateLayout();

                double totalHeight = ExtentHeight;

                double viewportHeight = ViewportHeight;

                if (totalHeight > viewportHeight)
                {
                    ScrollToEnd();
                }

                CaretPosition.GetCharacterRect(LogicalDirection.Forward);
            }
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateSize();
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateSize();
        }

        private void UpdateSize()
        {
            var textRange = new TextRange(Document.ContentStart, Document.ContentEnd);

            var source = PresentationSource.FromVisual(this);
            if (source == null) return;

            var dpiScale = source.CompositionTarget.TransformToDevice.M11;
            var pixelsPerDip = 1 / dpiScale;

            var formattedText = new FormattedText(
                textRange.Text,
                System.Globalization.CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight,
                new Typeface(FontFamily, FontStyle, FontWeight, FontStretch),
                FontSize,
                Foreground,
                pixelsPerDip);

            Width = formattedText.Width + 15;
            Height = formattedText.Height + 15;
        }

        public DependencyObject FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }
    }
}
