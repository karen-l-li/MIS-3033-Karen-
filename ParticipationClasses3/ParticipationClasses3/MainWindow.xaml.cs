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

namespace ParticipationClasses3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        Student student = new Student();

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            
            {
                student.FirstName = txtFirstName.Text;
                student.LastName = txtLastName.Text;
                student.Major = txtMajor.Text;
                student.GPA = Convert.ToDouble(txtGPA.Text);
            }
            
            student.SetAddress(Convert.ToInt32(txtStreetNumber.Text), txtStreetName.Text, txtState.Text, txtCity.Text, Convert.ToInt32(txtZipcode.Text));

            lstStudents.Items.Add(student.ToString());

            txtFirstName.Clear();
            txtLastName.Clear();
            txtMajor.Clear();
            txtGPA.Clear();
            txtStreetNumber.Clear();
            txtStreetName.Clear();
            txtState.Clear();
            txtCity.Clear();
            txtZipcode.Clear();

        }

        private void lstStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NewForm newentry = new NewForm();
            newentry.txtblockName.Text = $"{student.FirstName} / {student.LastName}";
            newentry.txtAddress.Text = student.GetAddress();
            newentry.ShowDialog();
       
        }

        
    }
}
