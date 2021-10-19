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
    /// Interaction logic for AddCompatabilityWindow.xaml
    /// </summary>
    public partial class AddCompatabilityWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public AddCompatabilityWindow()
        {
            InitializeComponent();
            dgModells.ItemsSource = dataLogic.GetModells();
            dgTuningparts.ItemsSource = dataLogic.GetTuningparts();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            dataLogic.AddCompatability((Modell)dgModells.SelectedItem, (Tuningpart)dgTuningparts.SelectedItem);
            this.Close();
        }
    }
}
