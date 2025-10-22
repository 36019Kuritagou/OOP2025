using Sample.Data;
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using static System.Net.Mime.MediaTypeNames;

namespace Sample {
    public partial class MainWindow : Window {
        private List<Person> _persons = new List<Person>();
        private byte[] _selectedImageBytes;

        public MainWindow() {
            InitializeComponent();
            RefreshPersonList();
        }

        private void RefreshPersonList() {
            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                _persons = connection.Table<Person>().ToList();
            }
            PersonListView.ItemsSource = _persons;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var person = new Person() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = addressTextBox.Text,
                Picture = _selectedImageBytes
            };

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                connection.Insert(person);
            }

            RefreshPersonList();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e) {
            var selectedPerson = PersonListView.SelectedItem as Person;
            if (selectedPerson == null) return;

            selectedPerson.Name = NameTextBox.Text;
            selectedPerson.Phone = PhoneTextBox.Text;
            selectedPerson.Address = addressTextBox.Text;
            selectedPerson.Picture = _selectedImageBytes;

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                connection.Update(selectedPerson);
            }

            RefreshPersonList();
        }

        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            RefreshPersonList();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            var item = PersonListView.SelectedItem as Person;
            if (item == null) {
                MessageBox.Show("行を選択してください");
                return;
            }

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                connection.Delete(item);
            }

            RefreshPersonList();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
            var filterList = _persons.Where(s => s.Name.Contains(SearchTextBox.Text, System.StringComparison.OrdinalIgnoreCase)).ToList();
            PersonListView.ItemsSource = filterList;
        }

        private void PictureButton_Click(object sender, RoutedEventArgs e) {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog {
                Filter = "画像ファイル (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|すべてのファイル (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true) {
                _selectedImageBytes = File.ReadAllBytes(openFileDialog.FileName);

                var bitmap = new BitmapImage();
                using (var stream = new MemoryStream(_selectedImageBytes)) {
                    bitmap.BeginInit();
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();
                }

                MyImage.Source = bitmap;
            }
        }

        private void PersonListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var selectedPerson = PersonListView.SelectedItem as Person;
            if (selectedPerson == null) return;

            NameTextBox.Text = selectedPerson.Name;
            PhoneTextBox.Text = selectedPerson.Phone;
            addressTextBox.Text = selectedPerson.Address;
            MyImage.Source = selectedPerson.PictureImage;
            _selectedImageBytes = selectedPerson.Picture;
        }
    }
}