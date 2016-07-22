using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;


using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamaAndrTest.Objects;
using Android.Views.InputMethods;

namespace XamaAndrTest
{
    [Activity(Label = "MainActivity", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private User user;
        private TestWcfServiceClient testWcfDimon;
        private Button bLogin;
        private Button bNextTest;
        private EditText etLogin;
        private EditText etPassword;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);

            testWcfDimon = new TestWcfServiceClient();
            /*testWcfDimon.Endpoint.Binding.Name = "BasicHttpBinding_ITestWcfService";
            testWcfDimon.Endpoint.Binding.CloseTimeout = new TimeSpan(0, 1, 0);
            testWcfDimon.Endpoint.Binding.OpenTimeout = new TimeSpan(0, 1, 0);
            testWcfDimon.Endpoint.Binding.ReceiveTimeout = new TimeSpan(0, 10, 0);
            testWcfDimon.Endpoint.Binding.SendTimeout = new TimeSpan(0, 1, 0);
            */

            /*
                        < configuration >
                < system.serviceModel >
                  < bindings >
                    < basicHttpBinding >
          //            < binding name = "BasicHttpBinding_ITestWcfService" closeTimeout = "00:01:00"
           //               openTimeout = "00:01:00" receiveTimeout = "00:10:00" sendTimeout = "00:01:00"
                          allowCookies = "false" bypassProxyOnLocal = "false" hostNameComparisonMode = "StrongWildcard"
                          maxBufferSize = "65536" maxBufferPoolSize = "524288" maxReceivedMessageSize = "65536"
                          messageEncoding = "Text" textEncoding = "utf-8" transferMode = "Buffered"
                          useDefaultWebProxy = "true" >
                        < readerQuotas maxDepth = "32" maxStringContentLength = "8192" maxArrayLength = "16384"
                            maxBytesPerRead = "4096" maxNameTableCharCount = "16384" />

                          < security mode = "None" >

                             < transport clientCredentialType = "None" proxyCredentialType = "None"
                              realm = "" />
                          < message clientCredentialType = "UserName" algorithmSuite = "Default" />

                           </ security >

                         </ binding >

                       </ basicHttpBinding >

                     </ bindings >

                     < client >

                       < endpoint address = "http://win-2uff44c3363:49839/TestWcfService.svc/TestWcfService"
                        binding = "basicHttpBinding" bindingConfiguration = "BasicHttpBinding_ITestWcfService"
                        contract = "ITestWcfService" name = "BasicHttpBinding_ITestWcfService" />

                    </ client >

                  </ system.serviceModel >

                </ configuration >
            */


            user = new User();

            bLogin = FindViewById<Button>(Resource.Id.bLogin);
            bNextTest = FindViewById<Button>(Resource.Id.bNextActivityTemp);
            etLogin = FindViewById<EditText>(Resource.Id.etLogin);
            etPassword = FindViewById<EditText>(Resource.Id.etPassword);

            //user.Login = "root";
            //user.Password = "root";

            bLogin.Click += BLogin_Click;

            bNextTest.Click += delegate {
                Intent intern = new Intent(this, typeof(MenuActivity));
                StartActivity(intern);
            };

        }

        private void BLogin_Click(object sender, EventArgs e)
        {
            /*
            if ((user.Login == etLogin.Text.ToString()) && (user.Password == etPassword.Text.ToString()))
            {
                Intent intern = new Intent(this, typeof(MenuActivity));
                StartActivity(intern);
            }
            else
            {
                Toast.MakeText(this, "Error Login!", ToastLength.Short).Show();
            }
            */
            user.Login = etLogin.Text.ToString();
            user.Password = etPassword.Text.ToString();
            testWcfDimon.Open();
            string result = testWcfDimon.CheckLogPass(user);
            if (result.Equals("ќшибка авторизации"))
            {
                Toast.MakeText(this, "≈бать ты кек!", ToastLength.Short).Show();
            }
            else
            {
                user = result;
                Intent intern = new Intent(this, typeof(MenuActivity));
                StartActivity(intern);
            }

        }
    }
}