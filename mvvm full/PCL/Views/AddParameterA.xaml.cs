using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMAssignment1.ViewModels;

namespace MVVMAssignment1.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddParameterA : ContentPage
	{
		public AddParameterA ()
		{
			InitializeComponent ();
            BindingContext = new AddParameterAViewModel(Navigation);
        }
	}
}