using InterviewDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InterviewDemo.Mobile
{
	public partial class MainPage : ContentPage
	{
        private readonly DataAccess dataAccess;

        public MainPage()
		{
			InitializeComponent();

            dataAccess = DataAccess.Instance;
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            lvEmployee.ItemsSource = await dataAccess.GetData();

        }


        async void OnRefreshing(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;

            lvEmployee.ItemsSource = await dataAccess.GetData(); //EmployeeFactory.GetData();

            lv.IsRefreshing = false;
        }



        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Employee tappedPerson = (Employee)e.Item;
            await this.Navigation.PushAsync(new Detail(tappedPerson));
        }


    }
}
