using MVVMAssignment1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMAssignment1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ParameterAList : ContentPage
	{
		public ParameterAList ()
		{
			InitializeComponent ();
		}
        protected override void OnAppearing()
        {
            this.BindingContext = new ParameterAListViewModel(Navigation);
        }
    }
}