using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHack.Mobile.Helper;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using MyHack.Mobile.Models;
using MyHack.Mobile.ViewModels;
using System.Web;
using System.Net.Http;

namespace MyHack.Mobile
{
    public partial class MySchedulePage : ContentPage
    {

        public MySchedulePage()
        {
            BindingContext = App.MyScheduleViewModel;
            InitializeComponent();
        }

        private void CreateButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CreateSchedule());
            App.MyScheduleViewModel.RefreshRequired = true;
        }

        private void Login_Clicked(object sender, EventArgs e)
        {
            //try
            //{

            //    HttpResponse response = null;
            //    //HttpParams httpParameters = new BasicHttpParams();
            //    //HttpConnectionParams.setConnectionTimeout(httpParameters, 20000);
            //    //HttpConnectionParams.setSoTimeout(httpParameters, 20000);
            //    HttpClient client = new HttpClient();

            //    HttpGet request = new HttpGet(
            //      "http://api.fitbit.com/oauth/request_token?oauth_consumer_key=7af733f021f649bcac32f6f7a4fe2e9a&oauth_signature_method=HMAC-SHA1&oauth_timestamp=1358921319&oauth_nonce=456236281&oauth_callback=http://androidhub4you.com/&oauth_version=1.0&oauth_token=5cefb18d2a80073520211f03f8d75321&oauth_signature=QdVUzMvT6tveGyoPu%2BEevzvo07s%3D");
            //    response = client.execute(request);

            //    BufferedReader rd = new BufferedReader(new InputStreamReader(
            //      response.getEntity().getContent()));

            //    String webServiceInfo = "";
            //    while ((webServiceInfo = rd.readLine()) != null)
            //    {
            //        Log.e("****Step 1***", "Webservice: " + webServiceInfo);
            //        String result[] = webServiceInfo.split("=");
            //        String result2 = result[1];
            //        String result3[] = result2.split("&");
            //        authToken = result3[0];
            //        Log.e("Auth token:", "Webservice: " + authToken);

            //    }

            //}
            //catch (Exception e)
            //{
            //    http://google.com/
            //         // TODO: handle exception
            //    e.printStackTrace();
            //}

            //Read more: http://www.androidhub4you.com/2013/11/fitbit-integration-in-android-login.html#ixzz4mimXC0mX
        }

        protected override async void OnAppearing()
        {
            await ((MyScheduleViewModel)BindingContext).LoadData();
        }
    }
}