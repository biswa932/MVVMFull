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
    public class ParameterAListViewModel : BaseParameterAViewModel
    {
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteAllParametersCommand { get; private set; }

        public ParameterAListViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _parameterRepository = new ParameterARepository();

            AddCommand = new Command(async () => await ShowAddParameterA());
            DeleteAllParametersCommand = new Command(async () => await DeleteAllParameters());

            FetchParameters();
        }

        void FetchParameters()
        {
            ParameterList = _parameterRepository.GetAllParameterData();
        }

        async Task ShowAddParameterA()
        {
            await _navigation.PushAsync(new AddParameterA());
        }

        async Task DeleteAllParameters()
        {
            bool isUserAccept = await Application.Current.MainPage.DisplayAlert("ParameterA List", "Delete All ParameterA Details ?", "OK", "Cancel");
            if (isUserAccept)
            {
                _parameterRepository.DeleteAllParameters();
                await _navigation.PushAsync(new AddParameterA());
            }
        }

        async void ShowParameterDetails(int selectedID)
        {
            await _navigation.PushAsync(new DetailsPage(selectedID));
        }

        ParameterA _selectedItem;
        public ParameterA SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                    ShowParameterDetails(value.Id);
                }
            }
        }
    }
}
