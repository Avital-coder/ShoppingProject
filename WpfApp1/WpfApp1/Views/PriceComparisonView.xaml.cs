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
using BE;
using BL;

namespace WpfApp1.Views
{
    /// <summary>
    /// Interaction logic for PriceComparison.xaml
    /// </summary>
    public partial class PriceComparisonView : UserControl
    {
        public PriceComparisonView()
        {
            InitializeComponent();
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();

            // Launch OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                FileNameTextBox.Text = openFileDlg.FileName;
                IBL bl = new BLImp(((App)Application.Current).Currents.CurrentUser);
                Item item = bl.GetItemByQR(openFileDlg.FileName);
                if (item != null)
                {
                    TextBlock1.Text = item.Name;
                    TextBlock2.Text = item.Description;
                    TextBlock3.Text = item.ShopName;
                    TextBlock4.Text = item.BranchName;
                    TextBlock5.Text = item.Price.ToString();

                    BitmapImage glowIcon = new BitmapImage();
                    glowIcon.BeginInit();
                    glowIcon.UriSource = new Uri(item.ImagePath);
                    glowIcon.EndInit();
                    TextBlock6.Source = glowIcon;
                }
                else
                {
                    TextBlock1.Text = "Unknown Item";
                    TextBlock2.Text = "";
                    TextBlock3.Text = "";
                    TextBlock4.Text = "";
                    TextBlock5.Text = "";
                    TextBlock6.Source = null;
                }
            }
        }
    }
}
