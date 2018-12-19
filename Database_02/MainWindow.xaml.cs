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

namespace Database_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        
        }

        NorthwindEntities DBContext = new NorthwindEntities();

        private void buttonDisplayItems_Click(object sender, RoutedEventArgs e)
        {
            var customers =
                from customer in DBContext.Customers
                select customer;

            foreach (var customer in customers)
            {
                textBlock01.Text += customer.ContactName + Environment.NewLine;
            }

            var CustomerSearch = DBContext.Customers.First(customer => customer.Country == "Finland");
            buttonUpdate.Content = string.Format("Update Name : Currently {0}", CustomerSearch.ContactName);
        }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var CustomerSearch = DBContext.Customers.First(customer => customer.Country == "Finland");
            if(CustomerSearch != null)
            {
                CustomerSearch.ContactName = textBox01.Text;
                buttonUpdate.Content = string.Format("Name Updated !!! Now {0}", CustomerSearch.ContactName);
            }
            DBContext.SaveChanges();
        }
    }


    public partial class Customer
    {
        public string getName()
        {
            return ContactName;
        }
    }
}
