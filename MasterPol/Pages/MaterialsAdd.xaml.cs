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
using MasterPol.Models;

namespace MasterPol
{
    /// <summary>
    /// Логика взаимодействия для MaterialsAdd.xaml
    /// </summary>
    public partial class MaterialsAdd : Page
    {
        public MaterialsAdd()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            using var context = new Wsr1DexDemoContext();

            var types = context.ProductTypes.ToArray();
            PrType.ItemsSource = types;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            decimal price = 0;
            if(PrType.SelectedItem == null)
            {
                MessageBox.Show("Название не заполнено");
                return;
            }

            if (TbName.Text == "")
            {
                MessageBox.Show("Название не заполнено");
                return;
            }

            try
            {
                price = decimal.Parse(TbPrice.Text);
            }
            catch {
                MessageBox.Show("Цена указана неверно");
                return;
            }
            try
            {
                using var context = new Wsr1DexDemoContext();
                var type = (ProductType)PrType.SelectedItem;

                context.Add(new Product
                {
                    TypeId = type.Id,
                    Name = TbName.Text,
                    Article = 0,
                    MinPrice = price
                });
                context.SaveChanges();

                NavigationService.GoBack();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");

            }
        }
    }
}
