﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using OOO_Gentlmen.Classes;
using OOO_Gentlmen.Model;
namespace OOO_Gentlmen.View
{
    /// <summary>
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        public OrderWindow()
        {
            InitializeComponent();
            Closed += WindowClosed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateCosts();
            UpdateList();
            TextBlockName.Text = Helper.User == null ? "" : Helper.User.UserFullName;
            ComboBoxClient.DisplayMemberPath = "UserLogin";
            ComboBoxClient.SelectedValuePath = "UserID";
            SearchClient();
        }

        private void UpdateStatus()
        {

        }

        private void UpdateCosts()
        {
            TextBlockTotal.Text = "Сумма: " + Helper.Order.Total.ToString("F") + " руб.";
            TextBlockDiscount.Text = "Скидка: " + Helper.Order.Discount.ToString("F") + " руб.";
            TextBlockTotalWithDiscount.Text = "Итого: " + Helper.Order.TotalWithDiscount.ToString("F") + " руб.";
        }

        private void UpdateList()
        {
            ListBoxProducts.ItemsSource = null;
            ListBoxProducts.ItemsSource = Helper.Order.Products;
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void WindowClosed(object sender, EventArgs e)
        {
            Owner.Show();
        }

        private void TextBoxCount_TextChanged(object sender, RoutedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            ProductInOrder Product = textBox.DataContext as ProductInOrder;
            if (string.IsNullOrEmpty(textBox.Text)) return;
            int count;
            try
            {
                count = Convert.ToInt32(textBox.Text);
            }
            catch
            {
                return;
            }
            if (count == 0)
            {
                Helper.Order.RemoveProduct(Product.ProductExtended);
                UpdateList();
                UpdateCosts();
                return;
            }
            Product.Count = count;
            UpdateCosts();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            Helper.Order.RemoveProduct(((sender as Button).DataContext as ProductInOrder).ProductExtended);
            UpdateList();
            UpdateCosts();
        }

        private void ButtonCreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Helper.Order.Products.Count == 0)
            {
                MessageBox.Show("Корзина пуста!");
                return;
            }
            if (ComboBoxClient.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента!");
                return;
            }
            Model.Order orderDB = new Model.Order
            {
                OrderDate = DateTime.Now,
                OrderStatus = 1,
                OrderManager = Helper.User.UserID,
                OrderClient = (int)ComboBoxClient.SelectedValue
            };

            if (!String.IsNullOrEmpty(TextBoxComment.Text))
            {
                orderDB.OrderComment = TextBoxComment.Text;
            }

            try
            {
                using (Model.dbGentlmen db = new Model.dbGentlmen())
                {
                    db.Order.Add(orderDB);
                    db.SaveChanges();
                    foreach (var product in Helper.Order.Products)
                    {
                        Model.OrderProduct orderProduct = new OrderProduct
                        {
                            OrderID = orderDB.OrderID,
                            ProductArticle = product.ProductExtended.ProductArticle,
                            ProductCount = product.Count
                        };
                        db.OrderProduct.Add(orderProduct);
                    }
                    db.SaveChanges();
                    Helper.Order.Clear();
                    UpdateList();
                    MessageBox.Show("Ваш заказ оформлен");
                }
            }
            catch
            {
                MessageBox.Show("При добавлении данных произошла ошибка");
            }
        }
        private void SearchClient()
        {
            using (Model.dbGentlmen db = new Model.dbGentlmen())
            {
                string search = "%" + TextBoxClient.Text + "%";
                ComboBoxClient.ItemsSource = null;
                ComboBoxClient.ItemsSource = db.User.Where(u => u.UserRole == 1 && DbFunctions.Like(u.UserLogin, search)).ToList();
            }
        }
        private void TextBoxClient_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchClient();
        }
    }
}
