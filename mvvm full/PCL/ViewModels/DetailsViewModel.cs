using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MVVMAssignment1.Models;
using MVVMAssignment1.Helpers;
using MVVMAssignment1.Services;
using Xamarin.Forms;
using MVVMAssignment1.Views;

namespace MVVMAssignment1.ViewModels
{
    public class DetailsViewModel: BaseParameterAViewModel
    {
        public ICommand UpdateParameterCommand { get; private set; }
        public ICommand DeleteParameterCommand { get; private set; }

        public DetailsViewModel(INavigation navigation, int selectedID)
        {
            _navigation = navigation;
            _parameter = new ParameterA();
            _parameter.Id = selectedID;
            _parameterRepository = new ParameterARepository();

            UpdateParameterCommand = new Command(async () => await UpdateParameter());
            DeleteParameterCommand = new Command(async () => await DeleteParameter());

            FetchParameterDetails();
        }

        void FetchParameterDetails()
        {
            _parameter = _parameterRepository.GetParameterData(_parameter.Id);
        }

        async Task UpdateParameter()
        {  

                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("ParameterA Details", "Update ParameterA Details", "OK", "Cancel");
                if (isUserAccept)
                {
                _parameterRepository.UpdateParameter(_parameter);
                    await _navigation.PopAsync();
                }
            
        }

        async Task DeleteParameter()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("ParameterA Details", "Delete ParameterA Details", "OK", "Cancel");
            if (isUserAccept)
            {
                _parameterRepository.DeleteParameter(_parameter.Id);
                await _navigation.PopAsync();
            }
        }
    }
}
