using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for AnimationOptions.xaml
    /// </summary>
    public partial class AnimationOptions : Window
    {
        MainWindow mw;

        public AnimationOptions(MainWindow mw)
        {
            this.mw = mw;

            InitializeComponent();

            foreach (PropertyInfo prop in typeof(System.Drawing.Color).GetProperties())
            {
                if (prop.PropertyType.FullName == "System.Drawing.Color")
                {
                    cbAnimColor.Items.Add(prop.Name);

                }
            }
        }

        private void cbAnimColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbAnimColor.SelectedItem != null)
            {
                System.Windows.Media.BrushConverter converter = new System.Windows.Media.BrushConverter();
                mw.animColor = (SolidColorBrush)converter.ConvertFromString(cbAnimColor.SelectedItem.ToString());
            }
        }

        private void submitAnim_Click(object sender, RoutedEventArgs e)
        {
            bool validated = true;

            if (!System.Text.RegularExpressions.Regex.IsMatch(animationScale.Text, @"\d+(?:\.\d+)?"))
            {
                MessageBox.Show("Please enter a number for EllipseStrokeThickness.");
                animationScale.Text = animationScale.Text.Remove(0);
                validated = false;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(animationDuration.Text, @"\d+(?:\.\d+)?"))
            {
                MessageBox.Show("Please enter a number for EllipseStrokeThickness.");
                animationDuration.Text = animationDuration.Text.Remove(0);
                validated = false;
            }

            if (validated)
            {
                mw.animScale = Int32.Parse(animationScale.Text);
                mw.animDuration = Int32.Parse(animationDuration.Text);

                this.Close();
            }
        }

        private void initialAnim_Click(object sender, RoutedEventArgs e)
        {
            mw.animScale = 10;
            mw.animDuration = 4;
            mw.animColor = new SolidColorBrush(System.Windows.Media.Colors.Beige);
            this.Close();
        }
    }
}
