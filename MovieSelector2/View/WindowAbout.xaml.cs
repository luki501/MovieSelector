﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MovieSelector2.View
{
    /// <summary>
    /// Interaction logic for WindowAbout.xaml
    /// </summary>
    public partial class WindowAbout : Window
    {
        public WindowAbout()
        {
            InitializeComponent();
            tbWersja.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            tbNazwa.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            //TODO
            //imgLogoProgramu.Source = 
        }
    }
}
