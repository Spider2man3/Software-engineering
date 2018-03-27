﻿using Microsoft.Win32;
using PrinterSimulator;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for UserPage.xaml
    /// </summary>
    public partial class UserPage : Canvas
    {
        private MainWindow mainWindow;
        private TesterPage testerPage;
        private HostHandler handler;
        public UserPage(MainWindow mainWindow, HostHandler handler)
        {
            InitializeComponent();
            this.handler = handler;
            this.mainWindow = mainWindow;
            this.UFirmwareVersion.Content = handler.firmwareVersion;
        }
        public void setTesterPage(TesterPage page)
        {
            this.testerPage = page;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog filedialog = new OpenFileDialog();
            filedialog.Title = "Select GCode file";
            filedialog.Multiselect = false;
            if (filedialog.ShowDialog() == true)
            {
                Stream fileStream = filedialog.OpenFile();
            }
        }

        private void Switch_To_Tester(object sender, RoutedEventArgs e)
        {
            (this.Parent as Viewbox).Child = testerPage;
            //(this.Parent as Frame).Content = testerPage;
        }
    }
}
