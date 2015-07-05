using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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



        private void Register_Clicked(object sender, RoutedEventArgs e)
        {
            DateTime cDate=DateTime.Now;            
            DateTime Udob=DateTime.Parse(rDOB.Date.ToString("dd-MM-yyyy"));
            DateTime checkDOB=Udob.AddYears(12);

            try
            {
                if(rFnameTxt.Text=="")
                {
                    vFnameTxt.Text = "First name  not be empty";
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
                }
            catch(Exception ex)
            {
                var msg=new MessageDialog("Error"+ex).ShowAsync();
            }
                
            }
       

        private void Login_Click(object sender, RoutedEventArgs e)
        {


        }



        private void Phone_lostFocus(object sender, RoutedEventArgs e)
        {

        }

        int UnameFlag = 0;
        private void Uname_lostFocus(object sender, RoutedEventArgs e)
        {

        }

    }
}

