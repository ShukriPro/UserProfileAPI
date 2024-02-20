using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileAPI.Modal;

namespace UserProfileAPI.ViewModel
{
    public class PatientDataViewModels
    {
       
        private PatientData _patientData;

        public PatientData PatientData
        {
            get => _patientData;
            set
            {
                _patientData = value;
                OnPropertyChanged(nameof(PatientData));
                // Trigger UI updates for dependent properties
                OnPropertyChanged(nameof(PatientIdDisplay));
                OnPropertyChanged(nameof(DateCalcDisplay));
                OnPropertyChanged(nameof(FactorsDisplay));
                OnPropertyChanged(nameof(FactorsCollection)); // Notify that the collection has changed
            }
        }


        //Display properties with fallback vlues
        public string PatientIdDisplay => $"Patient Id: {PatientData?.Patient_Id.ToString() ?? "N/A"}";
        public string DateCalcDisplay => PatientData?.datecalc ?? "N/A";
        public string FactorsDisplay => string.IsNullOrWhiteSpace(PatientData?.Description.Factors) ? "N/A" : PatientData.Description.Factors;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        // Converts the Factors string into an IEnumerable<string> for binding
        public IEnumerable<string> FactorsCollection
        {
            get
            {
                return PatientData?.Description?.Factors?.Split(new[] { " | " }, StringSplitOptions.RemoveEmptyEntries)
                       ?? Enumerable.Empty<string>();
            }
        }
    }

}
