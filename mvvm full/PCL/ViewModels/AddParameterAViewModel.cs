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
    public class AddParameterAViewModel:BaseParameterAViewModel
    {
        public ICommand AddParameterACommand { get; private set; }
        public ICommand ViewAllParametersCommand { get; private set; }
        public AddParameterAViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _parameter = new ParameterA();
            _parameterRepository = new ParameterARepository();
            AddParameterACommand = new Command(async () => await AddParameterA());
            ViewAllParametersCommand = new Command(async () => await ShowParameterAList());

        }
            async Task AddParameterA()
            {
                bool isUserAccept = await Application.Current.MainPage.DisplayAlert("Program ParameterA", "Do you want to program ParameterA?", "OK", "Cancel");
                if (isUserAccept)
                {
                    _parameterRepository.InsertParameter(_parameter);
                    await _navigation.PushAsync(new ParameterAList());
                }
            }
            async Task ShowParameterAList()
            {
                await _navigation.PushAsync(new ParameterAList());
            }
        
            public bool IsViewAll => _parameterRepository.GetAllParameterData().Count > 0 ? true : false;
        
    }
}
