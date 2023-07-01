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
        public AddMemberCommand(AddMemberDialogViewModel addMemberDialogViewModel, IUserAccountService userAccountService, IMemberService memberService)
        {
            _addMemberDialogViewModel = addMemberDialogViewModel;
            _addMemberDialogViewModel.PropertyChanged += OnViewModelPropertyChanged;
            _userAccountService = userAccountService;
            _memberService = memberService;
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
                    !(_addMemberDialogViewModel.PostalCode != 0));
        }

        public override void Execute(object? parameter)
        {
           
            OnExecutionCompleted(true, "Clan je uspesno dodat.");
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
