using System.Windows;
using System.Windows.Controls;

namespace pz_008
{
    /// <summary>
    /// Логика взаимодействия для ContactInfoPage.xaml
    /// </summary>
    public partial class ContactInfoPage : Page
    {
        bool firstView = true;
        public ContactInfoPage()
        {
            InitializeComponent();
            firstView = !firstView;

            //foodInfo.DataContext = new FoodContact("dfdsg", 42344312,"fsdsfd","fsddf", new string[] { "fsdf", "fsdfsd"});
        }

        private void createNewContact_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
