using ADO.NET_Task1.Commands;
using ADO.NET_Task1.Helpers;
using ADO.NET_Task1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ADO.NET_Task1.ViewModels
{
    public class EditWindowViewModel : BaseViewModel
    {
        public RelayCommand SaveChangesCommand { get; set; }

        public Author Author { get; set; }

        private string firstname;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }

        private string lastname;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged(); }
        }

        public EditWindowViewModel(Author author)
        {
            Author = author;
            Firstname = author.FirstName;
            Lastname = author.LastName;

            SaveChangesCommand = new RelayCommand((s) => 
            {
                DatabaseHelper.EditAuthorsByID(author.Id, Firstname, Lastname);
                (App.Current.MainWindow.DataContext as MainWindowViewModel).AddAuthorsToView(DatabaseHelper.GetAuthorsFromDb());
                App.ChildWindow.Close();
                App.ChildWindow = null;
                MessageBox.Show(App.Current.MainWindow, $"Author updated successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            });
        }
    }
}
