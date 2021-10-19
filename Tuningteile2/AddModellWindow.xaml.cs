﻿using System;
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
    /// Interaction logic for AddModellWindow.xaml
    /// </summary>
    public partial class AddModellWindow : Window
    {
        DataLogic dataLogic = new DataLogic();
        public AddModellWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txtBoxTitle.Text != null && txtBoxYearManufactured != null)
            {
                Modell modell = new Modell();
                modell.Title = txtBoxTitle.Text;
                modell.YearManufactured = Convert.ToInt32(txtBoxYearManufactured.Text);
                dataLogic.AddModell(modell);
                this.Close();
            }
            else
            {
                MessageBox.Show("Bitte geben Sie etwas ein!");
            }
        }
    }
}
