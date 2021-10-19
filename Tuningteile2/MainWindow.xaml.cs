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
        /// <summary>
        /// Erstellt ein Fenster und befüllt die Datagrids mit Werten
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            dgModells.ItemsSource = dataLogic.GetModells();
            dgTuningparts.ItemsSource = dataLogic.GetTuningparts();
            
        }

        /// <summary>
        /// Wenn sich die Auswahl im Datagrid Modells ändert, ändern sich dementsprechend die Werte im Datagrid ModellTuningparts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgModells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgModellTuningparts.ItemsSource = dataLogic.GetModellTuningparts((Modell)dgModells.SelectedItem);
        }

        /// <summary>
        /// Öffnet ein Fenster mit Möglichkeit ein Tuningteil hinzuzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTuningpart_Click(object sender, RoutedEventArgs e)
        {
            AddTuningpartWindow addTuningpartWindow = new AddTuningpartWindow();
            addTuningpartWindow.ShowDialog();
        }

        /// <summary>
        /// Öffnet ein Fenster mit Möglichkeit das ausgewählte Tuningteil zu ändern
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditColumn_Click(object sender, RoutedEventArgs e)
        {
            EditTuningpartWindow editTuningpartWindow = new EditTuningpartWindow((Tuningpart)dgTuningparts.SelectedItem);
            editTuningpartWindow.ShowDialog();
        }

        /// <summary>
        /// Löscht den ausgewählten Datensatz aus der Datenbank
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeleteColumn_Click(object sender, RoutedEventArgs e)
        {
            dataLogic.RemoveTuningPart((Tuningpart)dgTuningparts.SelectedItem);
            dgTuningparts.ItemsSource = dataLogic.GetTuningparts();
        }

        /// <summary>
        /// Öffnet ein Fenster mit der Möglchkeit der Datenbank ein Modell hinzuzufügen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddModell_Click(object sender, RoutedEventArgs e)
        {
            AddModellWindow addModellWindow = new AddModellWindow();
            addModellWindow.ShowDialog();
        }


        /// <summary>
        /// Öffnet ein Fenster mit der Möglichkeit die Tuningteile und Modelle zu verknüpfen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddCompatability_Click(object sender, RoutedEventArgs e)
        {
            AddCompatabilityWindow addCompatabilityWindow = new AddCompatabilityWindow();
            addCompatabilityWindow.ShowDialog();
        }
    }
}
