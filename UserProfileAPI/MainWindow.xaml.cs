using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;
using UserProfileAPI.Modal;
using UserProfileAPI.ViewModel;
namespace UserProfileAPI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

  
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = new PatientDataViewModels();

            //Create an instance of the ViewModel
            PatientDataViewModels viewModel = new PatientDataViewModels();

            //set the DataContext for the bindings
            this.DataContext = viewModel;

            //Load the patient data from json file
            LoadPatientData(viewModel);
        }

        private void LoadPatientData(PatientDataViewModels viewModel)
        {
            try
            {
                // Specify the path to the json file
                string jsonFilePath = "patientData.json"; // You might need to provide the full path if it's not in the output directory

                // Read the file content
                string jsonContent = File.ReadAllText(jsonFilePath);

                // Deserialize the content to the PatientData object
                PatientData patientData = JsonConvert.DeserializeObject<PatientData>(jsonContent);

                // Check if patientData is not null before setting it
                if (patientData != null)
                {
                    viewModel.PatientData = patientData;
                }
                else
                {
                    MessageBox.Show("The patient data could not be loaded.");
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"The patient data file was not found: {ex.Message}");
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"There was an error reading the patient data: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}