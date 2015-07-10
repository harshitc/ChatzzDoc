using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace ChatApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            pivot1.SelectedIndex = 1;
        }
         ApplicationDataContainer localsettings = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }



        private async void Register_Clicked(object sender, RoutedEventArgs e)
        {
            DateTime cDate=DateTime.Now;            
            DateTime Udob=DateTime.Parse(rDOB.Date.ToString("dd-MM-yyyy"));
            DateTime checkDOB=Udob.AddYears(12);
            string gen="";
            if (Clist.SelectedValue == "select country") 
            {
                vClist.Text="please select a country";
                //return;
            }
            if (maleRb.IsChecked == true)

                gen = "male";
            else if (femaleRb.IsChecked == true)
                gen = "female";
            else if (othersRb.IsChecked == true)
                gen = "others";
            else
            {
                vGender.Text = "Select Any Gender";
                return;
            }

            try
            {
                if(rFnameTxt.Text=="")
                {
                    vFnameTxt.Text = "First name should not be empty";
                    return;
                }
                if(rLnameTxt.Text=="")
                {
                    vLnameTxt.Text = "Last name should not be empty";
                    return;
                }
                if(rUnameTxt.Text=="")
                {
                    vUnameTxt.Text = "Username should not be empty";
                    return;
                }
                if(UnameFlag==0)
                {
                    vUnameTxt.Text = "Username alredy exists";
                    return;
                }
                if(rPasswordTxt.Password=="" & rPasswordTxt.Password.Length<6)
                {
                    vPasswordTxt.Text = "Your password must be atleast 6 characters long";
                    return;
                }
                if(rCpasswordTxt.Password!=rPasswordTxt.Password)
                {
                    vCpasswordTxt.Text = "Passwords don't match";
                    return;
                }
                if(checkDOB.Date>=cDate.Date)
                {
                    vDOB.Text = "User should be greater than 12 years of age";
                    return;
                }

                StatusTxt.Text = "Loading.....";
                StatusBar.IsIndeterminate = true;
                regButton.IsEnabled = false;
                PrateekPDM p1 = new PrateekPDM
                {
                    fname = rFnameTxt.Text,
                    lname = rLnameTxt.Text,
                    uname = rUnameTxt.Text,
                    password = rPasswordTxt.Password,
                    dob = rDOB.Date.ToString("dd-MM-yyyy"),
                    gender = gen,
                    country = Clist.SelectedItems.ToString(),
                    phone = rPhoneTxt.Text
                };
                  await App.MobileService.GetTable<PrateekPDM>().InsertAsync(p1);
                StatusTxt.Text = "";
                StatusBar.IsIndeterminate = false;
                pivot1.SelectedIndex = 0;
            
                
                
                }
            catch(Exception ex)
            {
                var msg=new MessageDialog("Error"+ex).ShowAsync();
            }
                
            }
        List<PrateekPDM> loggedlist = new List<PrateekPDM>();

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            if (lUnameTxt.Text == "")
            {
                vlUnameTxt.Text = "Enter username";
                return;
            }
            if (lPasswordTxt.Password == "" & lPasswordTxt.Password.Length < 6)
            {
                vlPasswordTxt.Text = "Enter Proper Password";
                return;
            }
            StatusTxt.Text = "Loggin in";
            StatusBar.IsIndeterminate = true;
            LoginButton.IsEnabled = false;
            loggedlist =await App.MobileService.GetTable<PrateekPDM>().Where(x => x.uname == lUnameTxt.Text & x.password == lPasswordTxt.Password).ToListAsync();
            if(loggedlist.Count==1)
            {
                localsettings.Values["Fname"] = loggedlist[0].fname;
                localsettings.Values["Lname"] = loggedlist[0].lname;
                localsettings.Values["Uname"] = loggedlist[0].uname;
                localsettings.Values["Password"] = loggedlist[0].password;
                localsettings.Values["DOB"] = loggedlist[0].dob;
                localsettings.Values["Gender"] = loggedlist[0].gender;
                localsettings.Values["Country"] = loggedlist[0].country;
                localsettings.Values["Mobile"] = loggedlist[0].phone;
                this.Frame.Navigate(typeof(dashboard));
            }
            else
            {
                var m1 = new MessageDialog("Invalid Login").ShowAsync();
                StatusTxt.Text = "";
                StatusBar.IsIndeterminate = false;
                LoginButton.IsEnabled = true;
            }

        }

        List<PrateekPDM> tempEmail = new List<PrateekPDM>();
        int UnameFlag = 0;


        private async void Uname_lostFocus(object sender, RoutedEventArgs e)
        {
            if (rUnameTxt.Text != "")
            {
                tempEmail = await App.MobileService.GetTable<PrateekPDM>().Where(x => x.uname == rUnameTxt.Text).ToListAsync();
                if (tempEmail.Count != 0)
                {
                    vUnameTxt.Text = "username already exists";
                    UnameFlag = 0;
                }
                else
                {
                    vUnameTxt.Text = "Valid username";
                    UnameFlag = 1;
                }
            }
        }

    }
}

