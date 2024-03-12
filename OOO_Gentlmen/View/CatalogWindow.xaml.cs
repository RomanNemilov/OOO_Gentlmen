using OOO_Gentlmen.Classes;
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
using System.Windows.Shapes;

namespace OOO_Gentlmen.View
{
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    /// <summary>
    /// Логика взаимодействия для CatalogWindow.xaml
    /// </summary>
    public partial class CatalogWindow : Window
    {
        public CatalogWindow()
        {
            InitializeComponent();
            Closed += WindowClosed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            buttonOpenCart.Visibility = Visibility.Hidden;

            using (Model.dbGentlmen db = new Model.dbGentlmen { })
            {
                List<Model.Category> categories = db.Category.ToList();
                var allCategories = new Model.Category()
                {
                    CategoryID = 0,
                    CategoryName = "Все категории"
                };
                categories.Insert(0, allCategories);
                comboBoxFilterCategory.ItemsSource = categories;
                comboBoxFilterCategory.DisplayMemberPath = "CategoryName";
                comboBoxFilterCategory.SelectedValuePath = "CategoryID";
                comboBoxFilterCategory.SelectedIndex = 0;
                comboBoxSort.SelectedIndex = 0;
                comboBoxFilterDiscount.SelectedIndex = 0;
                if (Helper.User != null)
                {
                    TextBlockName.Text = Helper.User.UserFullName;
                }
                else
                {
                    TextBlockName.Text = "Гость";
                }
                UpdateProduct();
            }
            if (Helper.User == null || Helper.User.UserID == 2)
            {
                contextMenuAdd.Visibility = Visibility.Visible;
            }
            else
            {
                contextMenuAdd.Visibility = Visibility.Collapsed;
            }
            Helper.Order = new Order();
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Owner.Show();
        }
        private void UpdateProduct()
        {
            using (Model.dbGentlmen db = new Model.dbGentlmen())
            {
                List<Model.Product> products = db.Product.ToList();

                switch (comboBoxSort.SelectedIndex)
                {
                    case 1:
                        products = products.OrderBy(pr => pr.ProductCost).ToList();
                        break;
                    case 2:
                        products = products.OrderByDescending(pr => pr.ProductCost).ToList();
                        break;
                }
                int totalAmount = products.Count;
                switch (comboBoxFilterDiscount.SelectedIndex)
                {
                    case 1:
                        products = products.Where(pr => pr.ProductDiscount >= 0 && pr.ProductDiscount < 10).ToList();
                        break;
                    case 2:
                        products = products.Where(pr => pr.ProductDiscount >= 10 && pr.ProductDiscount < 15).ToList();
                        break;
                    case 3:
                        products = products.Where(pr => pr.ProductDiscount >= 15).ToList();
                        break;
                    default:
                        break;
                }
                if (comboBoxFilterCategory.SelectedValue != null && (int)comboBoxFilterCategory.SelectedValue != 0)
                {
                    products = products.Where(pr => pr.ProductCategory == (int)comboBoxFilterCategory.SelectedValue).ToList();
                }

                if (!String.IsNullOrEmpty(textBoxSearch.Text))
                {
                    products = products.Where(pr => pr.ProductName.ToLower().Contains(textBoxSearch.Text.ToLower())).ToList();
                }

                List<ProductExtended> productsExtended = new List<ProductExtended>();

                foreach (Model.Product product in products)
                {
                    ProductExtended productExtended = new ProductExtended(product);
                    productsExtended.Add(productExtended);
                    Console.WriteLine(productExtended.ProductName);

                }


                listBoxProducts.ItemsSource = null;
                listBoxProducts.ItemsSource = productsExtended;

            }
        }

        private void comboBoxSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void comboBoxFilterDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void comboBoxFilterCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void textBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateProduct();
        }

        private void addProduct_Click(object sender, RoutedEventArgs e)
        {
            Helper.Order.AddProduct(listBoxProducts.SelectedItem as ProductExtended);
            buttonOpenCart.Visibility = Visibility.Visible;
        }

        private void ButtonOpenCart_OnClick(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.Owner = this;
            orderWindow.Show();
            this.Hide();
        }
    }
}
