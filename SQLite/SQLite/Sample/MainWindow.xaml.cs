using Sample.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        private async void PostalSearchButton_Click(object sender, RoutedEventArgs e) {
            string postalCode = PostalCodeTextBox.Text?.Trim().Replace("-", "");
            if (string.IsNullOrEmpty(postalCode)) {
                MessageBox.Show("郵便番号を入力してください。");
                return;
            }

            try {
                using var http = new HttpClient();
                string url = $"https://jp-postal-code-api.ttskch.com/api/v1/{postalCode}.json";

                HttpResponseMessage response = await http.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;

                if (root.TryGetProperty("addresses", out JsonElement addressesElem) && addressesElem.GetArrayLength() > 0) {
                    var addr0 = addressesElem[0];
                    string prefecture = addr0.GetProperty("ja").GetProperty("prefecture").GetString();
                    string address1 = addr0.GetProperty("ja").GetProperty("address1").GetString();
                    string address2 = addr0.GetProperty("ja").GetProperty("address2").GetString();
                    string address3 = addr0.GetProperty("ja").GetProperty("address3").GetString();

                    string fullAddress = $"{prefecture}{address1}{address2}{address3}";
                    addressTextBox.Text = fullAddress;
                } else {
                    MessageBox.Show("住所が見つかりませんでした。");
                }
            }
            catch (Exception ex) {
                MessageBox.Show($"住所検索中にエラーが発生しました: {ex.Message}");
            }
        }
    }
}



        