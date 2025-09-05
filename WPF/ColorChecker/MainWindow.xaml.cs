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

namespace ColorChecker
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        //すべてのスライダーから呼ばれるイベントハンドラ
        private void rSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //colorAreaの色(背景色)は、スライダーで指定したRGBの色を表示する
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;

            // 色を作成して背景に設定
            colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
