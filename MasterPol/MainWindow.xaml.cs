using System.Text;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MasterPol
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        void LoadData()
        {
            using var context = new Wsr1DexDemoContext();
            this.ProductType.ItemsSource = context.ProductTypes.ToArray();
        }
    }
}