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
using MasterPol.Pages;
using Microsoft.EntityFrameworkCore;

namespace MasterPol
{
    /// <summary>
    /// Логика взаимодействия для MaterialList.xaml
    /// </summary>
    public partial class MaterialList : Page
    {
        public MaterialList()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            try
            {
                using var context = new Wsr1DexDemoContext();

                var mapped = context.Partners
                    .Include(p => p.Histories)
                    .Select(p => new {
                        p.Id,
                        p.Type,
                        p.Name,
                        p.DirectorName,
                        p.DirectorPhone,
                        p.Rank,
                        Discount = $"{DiscountHelper.Calculate(p.Histories.Sum(p => p.Count))} %"

                    })
                    .ToArray();

                Partners.ItemsSource = mapped;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        private void Partners_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MaterialsAdd());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductsList())
;        }
    }
}
