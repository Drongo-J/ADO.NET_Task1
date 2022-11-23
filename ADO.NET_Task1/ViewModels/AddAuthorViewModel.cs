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
    public class AddAuthorViewModel : BaseViewModel
    {
        public RelayCommand AddAuthorCommand { get; set; }

        private string firstname = String.Empty;

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; OnPropertyChanged(); }
        }

        private string lastname = String.Empty;

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; OnPropertyChanged(); }
        }

        public AddAuthorViewModel()
        {
            AddAuthorCommand = new RelayCommand((a) =>
            {
                if (Firstname.Trim() == string.Empty)
                {
                    MessageBox.Show("Please, add author firstname!");
                    return;
                }
                if (Lastname.Trim() == string.Empty)
                {
                    MessageBox.Show("Please, add author lastname!", "Warning!");
                    return;
                }

                var author = new Author()
                {
                    FirstName=this.Firstname,
                    LastName=this.Lastname,
                    Id = GetID()
                };
                DatabaseHelper.AddAuthorToDatabase(author);
                (App.Current.MainWindow.DataContext as MainWindowViewModel).AddAuthorsToView(DatabaseHelper.GetAuthorsFromDb());
                App.ChildWindow.Close();
                App.ChildWindow = null;
                MessageBox.Show(App.Current.MainWindow, $"Author added successfully!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.RightAlign);
            });
        }

        private string GetID()
        {
            int id = 0;
            foreach (var author in App.CurrentAuthors)
            {
                int _id = int.Parse(author.Id);
                if (_id > id)
                {
                    id = _id;
                }
            }

            ++id;
            return id.ToString();
        }
    }
}
