using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace ColorChecker {
    public partial class MainWindow : Window {
        private MyColor[] colorList;
        private ObservableCollection<MyColor> stockColors = new ObservableCollection<MyColor>();

        public MainWindow() {
            InitializeComponent();

            colorList = GetColorList();
            colorComboBox.ItemsSource = colorList;
            stockList.ItemsSource = stockColors;
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(p => new MyColor {
                    Color = (Color)p.GetValue(null),
                    Name = p.Name,
                    IsKnownColor = true 
                }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            Color currentColor = Color.FromRgb(r, g, b);
            colorArea.Background = new SolidColorBrush(currentColor);
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (colorComboBox.SelectedItem is MyColor selectedColor) {
                setSliderValue(selectedColor.Color);
                colorArea.Background = new SolidColorBrush(selectedColor.Color);
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            Color currentColor = Color.FromRgb(r, g, b);

            
            var knownColor = colorList.FirstOrDefault(c => c.Color == currentColor);
            string name;
            bool isKnown;

            if (knownColor != null) {
                name = knownColor.Name;
                isKnown = true;
            } else {
                name = $"#{currentColor.R:X2}{currentColor.G:X2}{currentColor.B:X2}";
                isKnown = false;
            }

            
            if (!stockColors.Any(c => c.Color == currentColor)) {
                stockColors.Add(new MyColor { Color = currentColor, Name = name, IsKnownColor = isKnown });
            }
        }

        private void stockList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockList.SelectedItem is MyColor selected) {
                setSliderValue(selected.Color);
                colorArea.Background = new SolidColorBrush(selected.Color);
            }
        }
    }
}
