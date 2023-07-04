﻿using Biblioteka.Command;
using Biblioteka.Repository;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.View.Table;
using Biblioteka.ViewModel.Table;
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
        private IUserAccountService _userAccountService;
        private IPaymentService _paymentService;
        public ICommand OpenPaymentReportCommand { get; }
        public AdminViewModel(IUserAccountService userAccountService, IPaymentService paymentService)
        {
            _userAccountService = userAccountService;
            _paymentService = paymentService;
            OpenAddLibrarianCommand = new RelayCommand(OpenAddLibrarian, CanClick);
            OpenPaymentReportCommand = new RelayCommand(OpenPaymentReport, CanClick);
        }

        public bool CanClick()
        {
            return true;
        }

        public void OpenAddLibrarian()
        {
            var librarianTableView = new LibrarianTableView();
            librarianTableView.DataContext = new LibrarianTableViewModel(_userAccountService);
            librarianTableView.Show();
        }
        
        public void OpenPaymentReport()
        {
            var paymentReportView = new PaymentReportView();
            paymentReportView.DataContext = new PaymentReportViewModel(paymentReportView, _paymentService);
            paymentReportView.Show();
        }
    }
}
