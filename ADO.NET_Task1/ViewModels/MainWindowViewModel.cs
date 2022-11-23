using ADO.NET_Task1.Commands;
using ADO.NET_Task1.Helpers;
using ADO.NET_Task1.Models;
using ADO.NET_Task1.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ADO.NET_Task1.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public RelayCommand MouseEnterCommand { get; set; }
        public RelayCommand MouseLeaveCommand { get; set; }
        public RelayCommand IsNotFocusedCommand { get; set; }
        public RelayCommand ClearSearchCommand { get; set; }
        public RelayCommand KeyDownCommand { get; set; }
        public RelayCommand CheckAllCommand { get; set; }
        public RelayCommand DeleteCommmand { get; set; }
        public RelayCommand RefreshCommand { get; set; }
        public RelayCommand AddAuthorCommand { get; set; }

        public TextBox SearchTb { get; set; }
        public WrapPanel AuthorsWrapPanel { get; internal set; }

        private string DefaultText = "Search";

        bool checkAll = true;

        public MainWindowViewModel()
        {
            AddAuthorCommand = new RelayCommand((a) =>
            {
                var addWindow = new AddAuthorWindow();
                var addWindowViewModel = new AddAuthorViewModel();
                addWindow.DataContext = addWindowViewModel;
                App.ChildWindow = addWindow;
                addWindow.Show();
            });

            RefreshCommand = new RelayCommand((r) =>
            {
                AddAuthorsToView(DatabaseHelper.GetAuthorsFromDb());
                MessageBox.Show(App.Current.MainWindow, "Successfully refreshed!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            });

            DeleteCommmand = new RelayCommand((d) =>
            {
                if (AuthorsWrapPanel.Children[0] is NoResultFoundUC)
                    return;

                var IDs = new List<string>();
                foreach (var view in AuthorsWrapPanel.Children)
                {
                    var viewModel = (view as AuthorUC).DataContext as AuthorUCViewModel;
                    if (viewModel.IsChecked == true)
                    {
                        IDs.Add(viewModel.Author.Id);
                    }
                }
                if (IDs.Count == 0)
                {
                    MessageBox.Show(App.Current.MainWindow, "Please, check author!", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
                    return;
                }
                DatabaseHelper.DeleteAuthorsByID(IDs);
                AddAuthorsToView(DatabaseHelper.GetAuthorsFromDb());
                MessageBox.Show(App.Current.MainWindow, $"{IDs.Count} author(s) deleted successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            });

            CheckAllCommand = new RelayCommand((c) =>
            {
                if (AuthorsWrapPanel.Children[0] is NoResultFoundUC)
                    return;

                foreach (var view in AuthorsWrapPanel.Children)
                {
                    ((view as AuthorUC).DataContext as AuthorUCViewModel).IsChecked = checkAll;
                }
                checkAll = !checkAll;
            });

            KeyDownCommand = new RelayCommand((key) =>
            {
                Search();
            });

            MouseEnterCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == DefaultText)
                {
                    SearchTb.Text = String.Empty;
                }
            });

            MouseLeaveCommand = new RelayCommand((m) =>
            {
                if (SearchTb.Text.Trim() == String.Empty && SearchTb.IsFocused == false)
                {
                    SearchTb.Text = DefaultText;
                }
            });

            IsNotFocusedCommand = new RelayCommand((i) =>
            {
                string text = SearchTb.Text.Trim();
                if (text == String.Empty || text == DefaultText)
                {
                    SearchTb.Foreground = Brushes.Black;
                    SearchTb.Text = DefaultText;
                }
            });

            ClearSearchCommand = new RelayCommand((c) =>
            {
                string text = SearchTb.Text.Trim();
                if (text != DefaultText && text != string.Empty)
                {
                    SearchTb.Text = string.Empty;
                    Search();
                }
            });
        }

        public void AddAuthorsToView(List<Author> authors)
        {
            AuthorsWrapPanel.Children.Clear();

            if (authors.Count == 0)
            {
                var noResultUC = new NoResultFoundUC();
                AuthorsWrapPanel.Children.Add(noResultUC);
                return;
            }
            foreach (var author in authors)
            {
                var authorUC = new AuthorUC();
                var authorUCViewModel = new AuthorUCViewModel(author);
                authorUC.DataContext = authorUCViewModel;
                AuthorsWrapPanel.Children.Add(authorUC);
            }
        }

        public void Search()
        {
            var authors = new List<Author>();
            var text = SearchTb.Text;
            if (text.Trim() == String.Empty)
            {
                AddAuthorsToView(App.CurrentAuthors);
                return;
            }

            foreach (var author in App.CurrentAuthors)
            {
                if (author.FirstName.ToLower().Contains(text.ToLower()) || author.LastName.ToLower().Contains(text.ToLower()) || author.Id.ToLower().Contains(text.ToLower()))
                {
                    authors.Add(author);
                }
            }
            AddAuthorsToView(authors);
        }
    }
}
