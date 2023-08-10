using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.XamarinForms.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CevikMetalTeknik.Planlama
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrmPlanlama : ContentPage
    {
        public FrmPlanlama()
        {
            InitializeComponent();
        }
        //private void CalendarLoaded(object sender, EventArgs args)
        //{
        //    (sender as RadCalendar).TrySetViewMode(CalendarViewMode.Day);
        //}
    }
}