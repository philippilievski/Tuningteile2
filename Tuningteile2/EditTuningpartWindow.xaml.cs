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
    /// Interaction logic for EditTuningpartWindow.xaml
    /// </summary>
    public partial class EditTuningpartWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        Tuningpart tuningpart;
        public EditTuningpartWindow(Tuningpart tuningpart)
        {
            InitializeComponent();
            this.tuningpart = tuningpart;
            txtBoxTitle.Text = tuningpart.Title;
            txtBoxPrice.Text = Convert.ToString(tuningpart.Price);
            cmbBoxCategory.ItemsSource = dataLogic.GetCategories();
            cmbBoxCategory.SelectedItem = tuningpart.Category;
            
        }

        private void btnEditTuningPart_Click(object sender, RoutedEventArgs e)
        {
            if (txtBoxPrice.Text != null && txtBoxTitle.Text != null && cmbBoxCategory.SelectedItem != null)
            {
                tuningpart.Title = txtBoxTitle.Text;
                tuningpart.Price = Convert.ToDecimal(txtBoxPrice.Text);
                tuningpart.Category = (Category)cmbBoxCategory.SelectedItem;
                dataLogic.UpdateTuningpart(tuningpart);
                this.Close();
            }
        }
    }
}
