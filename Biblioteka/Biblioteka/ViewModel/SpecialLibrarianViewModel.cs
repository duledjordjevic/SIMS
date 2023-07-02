using Biblioteka.Command;
using Biblioteka.View.Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class SpecialLibrarianViewModel : ViewModelBase
    {
        public ICommand OpenBooksCommand { get; }
        public SpecialLibrarianViewModel()
        {
            OpenBooksCommand = new RelayCommand(OpenBooks, CanClick);
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenBooks()
        {
            var addingBookTitleTableView = new AddingBookTitleTableView();
            //patientAppointments.DataContext = new PatientAppointmentTableViewModel(_patient, _schedulingService, _appointmentService, _doctorScheduleService, _patientService, _doctorService);
            addingBookTitleTableView.ShowDialog();
        }
    }
}
