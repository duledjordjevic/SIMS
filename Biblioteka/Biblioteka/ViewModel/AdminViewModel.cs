using Biblioteka.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Biblioteka.ViewModel
{
    public class AdminViewModel : ViewModelBase
    {
        public ICommand OpenAddLibrarianCommand { get; }
        public AdminViewModel()
        {
            OpenAddLibrarianCommand = new RelayCommand(OpenAddLibrarian, CanClick);
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenAddLibrarian()
        {
            //var patientAppointments = new PatientAppoinmentsView();
            //patientAppointments.DataContext = new PatientAppointmentTableViewModel(_patient, _schedulingService, _appointmentService, _doctorScheduleService, _patientService, _doctorService);
            //patientAppointments.ShowDialog();
        }
    }
}
