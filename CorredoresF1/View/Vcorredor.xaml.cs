using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorredoresF1.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorredoresF1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Vcorredor : ContentPage
    {
        public Vcorredor()
           
        {
            BindingContext = new VMcorredor(Navigation);
            InitializeComponent();
        }
    }
}