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
using Tuningteile2.Logic;
using Tuningteile2.Model;

namespace Tuningteile2
{
    /// <summary>
    /// Interaction logic for AddTuningpartWindow.xaml
    /// </summary>
    public partial class AddTuningpartWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public AddTuningpartWindow()
        {
            InitializeComponent();
            cmbBoxCategory.ItemsSource = dataLogic.GetCategories();
        }

        private void btnAddTuningpart_Click(object sender, RoutedEventArgs e)
        {
            Tuningpart tuningpart = new Tuningpart();
            if(txtBoxPrice.Text != null && txtBoxTitle.Text != null && cmbBoxCategory.SelectedItem != null)
            {
                tuningpart.Title = txtBoxTitle.Text;
                tuningpart.Price = Convert.ToDecimal(txtBoxPrice.Text);
                tuningpart.Category = (Category)cmbBoxCategory.SelectedItem;
                tuningpart.Avaliability = true;
                dataLogic.AddTuningpart(tuningpart);
                MainWindow mainWindow = new MainWindow();
                this.Close();
            }
            else
            {
                MessageBox.Show("Geben Sie die Daten korrekt ein.");
            }

        }
    }
}
