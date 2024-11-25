using MassCultureLibrary.Animes;
using System.Windows;
using System.Windows.Controls;

namespace MassCultureLibrary.Desktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для AnimeListPage.xaml
    /// </summary>
    public partial class AnimeListPage : Page
    {
        public AnimeListPage()
        {
            InitializeComponent();
            RenewList();
        }
        async void RenewList()
        {
            IAnimeService animeService = new AnimeService(new JsonAnimeStorage());
            AnimeDataGrid.Items.Clear();
            var items = await animeService.GetAnimeAsync();
            foreach (var item in items)
            {
                AnimeDataGrid.Items.Add(item);
            }
        }

        private async void DeleteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            IAnimeService animeService = new AnimeService(new JsonAnimeStorage());
            var anime = AnimeDataGrid.SelectedItem as Anime;
            if (AnimeDataGrid.Items.Count > 1)
            {
                await animeService.DeleteAnimeByIdAsync(anime.Id);
                AnimeDataGrid.Items.Remove(anime);
            }
            else
                MessageBox.Show("Нельзя удалить единственный элемент списка", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void AddAnimeButton_Click(object sender, RoutedEventArgs e)
        {
            var anime = new Anime();
            Guid id = Guid.NewGuid();
            if (!String.IsNullOrWhiteSpace(TitleTextBox.Text) && !String.IsNullOrWhiteSpace(GenreTextBox.Text))
            {
                anime.Id = id;
                anime.Title = TitleTextBox.Text;
                anime.Genre = GenreTextBox.Text;
                anime.Status = StatusComboBox.Text;
                AnimeDataGrid.Items.Add(anime);
            }
            else
                MessageBox.Show("Поля ввода не должны быть пустыми", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            
            AnimeDataGrid.Items.Refresh();
        }
    }
}
