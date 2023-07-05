using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Biblioteka.Command;
using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Repository;
using Biblioteka.Service;

namespace Biblioteka.ViewModel.Table
{
    public class PaymentReportViewModel: ViewModelBase
    {
        private string _baseMembershipLabel;
        private string _baseBookDamageLabel;
        private string _baseTotalBookDamageLabel;
        private string _baseLateLabel;
        private string _membershipLabel;
        public string MembershipLabel
        {
            get { return _membershipLabel; }
            set
            {
                _membershipLabel = value;
                OnPropertyChanged(nameof(MembershipLabel));
            }
        }

        private string _bookDamageLabel;
        public string BookDamageLabel
        {
            get { return _bookDamageLabel; }
            set
            {
                _bookDamageLabel = value;
                OnPropertyChanged(nameof(BookDamageLabel));
            }
        }
        private string _totalBookDamageLabel;
        public string TotalBookDamageLabel
        {
            get { return _totalBookDamageLabel; }
            set
            {
                _totalBookDamageLabel = value;
                OnPropertyChanged(nameof(TotalBookDamageLabel));
            }
        }
        private string _lateLabel;
        public string LateLabel
        {
            get { return _lateLabel; }
            set
            {
                _lateLabel = value;
                OnPropertyChanged(nameof(LateLabel));
            }
        }
        public ICommand CloseCommand { get; }
        public ICommand GetReportCommand { get; }
        private DateTime? _startDate;
        private DateTime? _endDate;

        public DateTime? StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        public DateTime? EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }


        private IPaymentService _paymentService;
        public PaymentReportViewModel(Window window, IPaymentService paymentService)
        {
            CloseCommand = new CloseCommand(window);
            _paymentService = paymentService;
            GetReportCommand = new RelayCommand(GetReport, CanExecute);
            GenerateLabels();
        }

        public bool CanExecute()
        {
            if (!_startDate.HasValue || !_endDate.HasValue) return false;

            if(_endDate.Value.Date > DateTime.Today.Date) return false;

            if (_startDate.Value.Date > _endDate.Value.Date) return false;

            return true;
        }

        public void GetReport()
        {
            Dictionary<int, Payment> paymentDictionary = _paymentService.GetAll();
            List<Payment> paymentsList = paymentDictionary.Values.ToList();

            Dictionary<PaymentType, double> report = new Dictionary<PaymentType, double>();
            foreach(PaymentType paymentType in Enum.GetValues(typeof(PaymentType)))
            {
                report.Add(paymentType, 0);
            }
            foreach(Payment payment in paymentsList)
            {
                if (!(payment.Date >= _startDate && payment.Date <= _endDate))
                {
                    continue;
                }
                if (report.ContainsKey(payment.PaymentType))
                {
                    report[payment.PaymentType] += payment.Amount;
                }
            }

            WriteLabels(report);
        }

        public void GenerateLabels()
        {
            _baseMembershipLabel = "Ukupna naplata mesecne clanarine je ";
            _baseBookDamageLabel = "Ukupna naplata za ostecenje knjige je ";
            _baseTotalBookDamageLabel = "Ukupna naplata za totalno ostecenje knjige je ";
            _baseLateLabel = "Ukupna naplata za kasno vracanje je ";
            MembershipLabel = _baseMembershipLabel + "0";
            BookDamageLabel = _baseBookDamageLabel + "0";
            TotalBookDamageLabel = _baseTotalBookDamageLabel + "0";
            LateLabel = _baseLateLabel + "0";
        }
        public void WriteLabels(Dictionary<PaymentType, double> report)
        {
            MembershipLabel = _baseMembershipLabel + string.Concat(report[PaymentType.MEMBERSHIP_FEE]);
            BookDamageLabel = _baseBookDamageLabel + string.Concat(report[PaymentType.BOOK_DAMAGE]);
            TotalBookDamageLabel = _baseTotalBookDamageLabel + string.Concat(report[PaymentType.TOTAL_BOOK_DAMAGE]);
            LateLabel = _baseLateLabel + string.Concat(report[PaymentType.LATE_FEE]);
        }
    }
}
