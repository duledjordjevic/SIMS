using Biblioteka.Enums;
using Biblioteka.Model;
using Biblioteka.Service;
using Biblioteka.Service.Interface;
using Biblioteka.ViewModel.Dialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka.Command
{
    public class AddMemberCommand : CommandBase
    {
        private AddMemberDialogViewModel _addMemberDialogViewModel;
        private IUserAccountService _userAccountService;
        private IMemberService _memberService;
        private IPaymentService _paymentService;
        public AddMemberCommand(AddMemberDialogViewModel addMemberDialogViewModel, IUserAccountService userAccountService, IMemberService memberService, IPaymentService paymentService)
        {
            _addMemberDialogViewModel = addMemberDialogViewModel;
            _addMemberDialogViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _userAccountService = userAccountService;
            _memberService = memberService;
            _paymentService = paymentService;

        }
        public override bool CanExecute(object? parameter)
        {
            return ((_addMemberDialogViewModel.Name is not null) &&
                    (_addMemberDialogViewModel.LastName is not null) &&
                    !(_addMemberDialogViewModel.Jmbg == null) &&
                    !(_addMemberDialogViewModel.Telephone == null) &&
                    !(_addMemberDialogViewModel.Email == null) &&
                    !(_addMemberDialogViewModel.Password == null) &&
                    !(_addMemberDialogViewModel.Street == null) &&
                    !(_addMemberDialogViewModel.City == null) &&
                    (_addMemberDialogViewModel.PostalCode != 0));
        }

        public override void Execute(object? parameter)
        {
            if (!_userAccountService.IsEmailValid(_addMemberDialogViewModel.Email)){
                OnExecutionCompleted(false, "Email je u losem formatu.");
            }else if (_userAccountService.CheckUserExistanceEmail(_addMemberDialogViewModel.Email))
            {
                OnExecutionCompleted(false, "Korisnik sa ovom email adresom vec postoji");
            }else if (_memberService.CheckMemberExistenceJmbg(_addMemberDialogViewModel.Jmbg))
            {
                OnExecutionCompleted(false, "Clan sa tim JMBG-om vec ima clansku karticu");
            }
            else
            {
                _userAccountService.Add(_addMemberDialogViewModel.Email, _addMemberDialogViewModel.Password, AccountType.MEMBER);
                var id = _userAccountService.GetByEmail(_addMemberDialogViewModel.Email).Id;
                _memberService.Add(_addMemberDialogViewModel.Name, _addMemberDialogViewModel.LastName, _addMemberDialogViewModel.Jmbg, _addMemberDialogViewModel.Telephone,
                    _addMemberDialogViewModel.SelectedMembershipType, id, _addMemberDialogViewModel.Street, _addMemberDialogViewModel.City, _addMemberDialogViewModel.PostalCode);
                _paymentService.Add(new Payment(PaymentType.MEMBERSHIP_FEE, 500, DateTime.Now, id));
                OnExecutionCompleted(true, "Clan je uspesno dodat.");
            }
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_addMemberDialogViewModel.Name)
                || e.PropertyName == nameof(_addMemberDialogViewModel.LastName)
                || e.PropertyName == nameof(_addMemberDialogViewModel.Jmbg)
                || e.PropertyName == nameof(_addMemberDialogViewModel.Telephone)
                || e.PropertyName == nameof(_addMemberDialogViewModel.Email)
                || e.PropertyName == nameof(_addMemberDialogViewModel.Password)
                || e.PropertyName == nameof(_addMemberDialogViewModel.Street)
                || e.PropertyName == nameof(_addMemberDialogViewModel.City)
                || e.PropertyName == nameof(_addMemberDialogViewModel.PostalCode))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
