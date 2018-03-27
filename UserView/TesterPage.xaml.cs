﻿using PrinterSimulator;
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

namespace Host
{
    /// <summary>
    /// Interaction logic for TesterPage.xaml
    /// </summary>
    public partial class TesterPage : Canvas
    {
        private MainWindow mainWindow;
        private UserPage userPage;
        private HostHandler handler;
        private bool laser = false;
        public TesterPage(MainWindow mainWindow, HostHandler handler)
        {
            InitializeComponent();
            this.handler = handler;
            this.mainWindow = mainWindow;
            this.TFirmwareVersion.Content = handler.firmwareVersion;
        }
        public void SetUserPage(UserPage page)
        {
            this.userPage = page;
        }

        private void Switch_To_User(object sender, RoutedEventArgs e)
        {
            (this.Parent as Viewbox).Child = userPage;
            //(this.Parent as MainWindow).Content = userPage;
        }

        private void Reset_Stepper(object sender, RoutedEventArgs e)
        {
            handler.execute(Command.ResetStepper, new float[0]);
        }

        private void Toggle_Laser(object sender, RoutedEventArgs e)
        {
            laser = !laser;
        }

        private void Step_Stepper_Up(object sender, RoutedEventArgs e)
        {
            handler.execute(Command.StepStepper, new float[1] { 1 });
        }

        private void Step_Stepper_Down(object sender, RoutedEventArgs e)
        {
            handler.execute(Command.StepStepper, new float[1] { 0 });
        }
    }
}
