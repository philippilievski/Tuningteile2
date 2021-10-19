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
using Tuningteile2.Logic;
using Tuningteile2.Model;

namespace Tuningteile2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public MainWindow()
        {
            InitializeComponent();
            dgModells.ItemsSource = dataLogic.GetModells();
            dgTuningparts.ItemsSource = dataLogic.GetTuningparts();
            
        }

        private void dgModells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgModellTuningparts.ItemsSource = dataLogic.GetModellTuningparts((Modell)dgModells.SelectedItem);
        }

        private void btnAddTuningpart_Click(object sender, RoutedEventArgs e)
        {
            AddTuningpartWindow addTuningpartWindow = new AddTuningpartWindow();
            addTuningpartWindow.ShowDialog();
        }

        private void btnEditColumn_Click(object sender, RoutedEventArgs e)
        {
            EditTuningpartWindow editTuningpartWindow = new EditTuningpartWindow((Tuningpart)dgTuningparts.SelectedItem);
            editTuningpartWindow.ShowDialog();
        }

        private void btnDeleteColumn_Click(object sender, RoutedEventArgs e)
        {
            dataLogic.RemoveTuningPart((Tuningpart)dgTuningparts.SelectedItem);
            dgTuningparts.ItemsSource = dataLogic.GetTuningparts();
        }
    }
}
