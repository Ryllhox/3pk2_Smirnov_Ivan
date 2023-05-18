using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Newtonsoft.Json;
using pz_011.Model;

namespace pz_011.ViewModel
{
    class BookViewModel
    {
        public ObservableCollection<Book> Books { get; set; }
        public ICommand BookCommand { get; set; }
        ICommand BookSelectCommand { get; set; }
        readonly string Path = "books.json";

        public BookViewModel()
        {
            Books = new();

            LoadBooks();

            //TestBooks();

            BookCommand = new RelayCommand( (parameter) => CreatingBook(parameter), (parameter) => true);

            //BookSelectCommand = new RelayCommand((parameter) => true,
            //    (parameter) =>
            //    {
            //        var win = parameter as MainWindow;
            //        win.spNewBook.DataContext = Books;
            //    });
        }

        private void CreatingBook(object abc)
        {
            var win = abc as MainWindow;
            string n = win.tbName.Text;
            string y = win.tbYear.Text;
            string a = win.tbAuthor.Text;

            if(!(string.IsNullOrEmpty(n) && string.IsNullOrEmpty(n) && string.IsNullOrEmpty(a)))
            {
                AddBook(n, y, a);
                win.tbName.Clear();
                win.tbYear.Clear();
                win.tbAuthor.Clear();
            }

            SaveBook();
        }

        //private void JsonAddBook(object xyz)
        //{
        //    var jsonData = JsonConvert.SerializeObject(xyz);
        //    File.WriteAllText(Path, jsonData);
        //}

        private void SaveBook()
        {
            File.WriteAllText(Path, (JsonConvert.SerializeObject(Books)));
        }

        private void LoadBooks()
        {
            if (!File.Exists(Path))
            { 
                MessageBox.Show("json file error");
                return;
            }

            var books2 = JsonConvert.DeserializeObject<ObservableCollection<Book>>(File.ReadAllText(Path));

            for (int i = 0; i < Books.Count-1; i++)
            {
                Books[i] = books2[i];
            }

            //if(books2!=null) foreach(var book in books2) Books.Add(book);
        }

        private void AddBook(string name, string year, string author)
        {
            Books.Add(new(name, year, author));
            LoadBooks();
        }

        void TestBooks()
        {
            Books = new() { new("a","b","c"), new("x", "y", "z"), new("1","2","3"), new("000","001", "010") };
        }
    }
}
