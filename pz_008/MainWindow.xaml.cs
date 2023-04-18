using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using pz_008.Model.Factory;
using pz_008.Model.Domain;
using System.ComponentModel;

namespace pz_008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IContact currentPhone;

        List<IContact> PhoneBook;

        ContactInfoPage infoPage;
        int ii = 0;

        public MainWindow()
        {
            InitializeComponent();
            infoPage = new();
            PhoneBook = new();

            nWin.Content = infoPage;

            FoodContactFactory testFactory = new("TESTfood", 4324, "aaaaaaa", "bbbbbb", new string[] { "ooooo", "ppppp", "tttttttt" });
            SchoolContactFactory testFactory2 = new("TESTschooooool", 123456789, "orenberg, street2, 10/3", "techno", 1000);
            PersonContactFactory testFactory3 = new("TESTperson", 89998544495, "russia");

            FoodContactFactory testFactory4 = new("TESTfood2", 8353248000, "Волковский проезд, 4, Люберцы, Московская область, 140000", 
                "Как добраться\r\nКотельники\r\n3,4 км\r\n2\r\nПенсионный фонд\r\n34 м\r\n4\r\n\r\nТакси от 139 ₽", 
                new string[] { "Запечённые мозговые косточки с чесночными гренками", "Хрустящая лепешка с мясом", "Гренки чесночные с соусом тартар" });
            SchoolContactFactory testFactory5 = new("TESTschool2", 88002000122, "МАОУ Видновская средняя общеобразовательная школа № 11", "J,otj,hfpjdfybt", 1500);
            PersonContactFactory testFactory6 = new("TESTperson2", 74951075132, "Moscow");

            PhoneBook.Add(testFactory.GetContact());
            PhoneBook.Add(testFactory2.GetContact());
            PhoneBook.Add(testFactory3.GetContact());
            PhoneBook.Add(testFactory4.GetContact());
            PhoneBook.Add(testFactory5.GetContact());
            PhoneBook.Add(testFactory6.GetContact());
            //listBox1.Items.Add(new ListBoxItem() { Content="TEST____ETSTETS"});
            //listBox1.Items.Add(new ListBoxItem() { Content = "TEST____ETSTETS" });
            //listBox1.Items.Add(new ListBoxItem() { Content = "TEST____ETSTETS" });

            currentPhone = testFactory2.GetContact();
            ////MessageBox.Show(TypeDescriptor.GetClassName(currentPhone).Split('.').Last());
            //currentPhone = testFactory.GetContact();
            //currentPhone = testFactory3.GetContact();
            //MessageBox.Show(string.Join('\n', currentPhone.GetInfo()));
        }

        private void ListBoxItem_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var a = new ListBoxItem() { };

            listBox1.Items.Add(a);

            //  xor
            listBox1.IsEnabled ^= true;

            DrawNewContact(a);

            listBox1.IsEnabled ^= true;
        }
            
        private void DrawNewContact(object whoCallMe)
        {
            //currentPhone = new PersonContactFactory("zxczxc", 1234, "moscow").GetContact();

            //nWin = new Frame();

            //PhoneBook.Add(currentPhone);

            infoPage = new ContactInfoPage() { Title = $"page {ii}" };
            //infoPage.foodInfo.DataContext = currentPhone;
            

            //nWin.Content = infoPage;
            
            ((ListBoxItem)whoCallMe).Content = $"contact{ii}";

            MessageBox.Show("спасибо", "thx");
            
            //infoPage.cbContactType.IsEnabled ^= true;

            ii++;
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            uint currentContactNumber = (uint)((ListBox)sender).SelectedIndex-1;

            if (currentContactNumber < PhoneBook.Count)
            {
                infoPage = new ContactInfoPage() { Title = $"page {currentContactNumber}" };

                string currentContactType = TypeDescriptor.GetClassName(PhoneBook[(int)currentContactNumber]).Split('.').Last();
                switch (currentContactType)
                {
                    case "FoodContact":
                        ((ContactInfoPage)(nWin.Content)).pesonInfo.Visibility = Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).schoolInfo.Visibility = Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).foodInfo.Visibility = Visibility.Visible;
                        ((ContactInfoPage)(nWin.Content)).foodInfo.DataContext = (FoodContact)PhoneBook[(int)currentContactNumber];
                        MessageBox.Show("food");
                        break;
                    case "PersonContact":
                        ((ContactInfoPage)(nWin.Content)).schoolInfo.Visibility = Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).foodInfo.Visibility = Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).pesonInfo.Visibility = Visibility.Visible;
                        ((ContactInfoPage)(nWin.Content)).pesonInfo.DataContext = PhoneBook[(int)currentContactNumber];
                        MessageBox.Show("person");
                        break;
                    case "SchoolContact":
                        ((ContactInfoPage)(nWin.Content)).pesonInfo.Visibility= Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).foodInfo.Visibility= Visibility.Hidden;
                        ((ContactInfoPage)(nWin.Content)).schoolInfo.Visibility = Visibility.Visible;
                        ((ContactInfoPage)(nWin.Content)).schoolInfo.DataContext = PhoneBook[(int)currentContactNumber];
                        MessageBox.Show("school");
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
