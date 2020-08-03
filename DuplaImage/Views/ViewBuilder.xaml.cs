using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DuplaImage.Views {
    /// <summary>
    /// This is here solely to build views as for some reason I can't build the views from the page itself
    /// </summary>
    public partial class ViewBuilder : Window {
        public ViewBuilder() {
            InitializeComponent();
        }
    }
}
