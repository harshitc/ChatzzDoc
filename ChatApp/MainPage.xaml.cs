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
            countrymethod();// called the countrynames in listbox
            this.NavigationCacheMode = NavigationCacheMode.Required;
            pivot1.SelectedIndex = 1;
        }
        public class countryclass
        {
            public string name { get; set; }

        }
        string[] countrynames = new string[]
    {
        "select country",
	"Afghanistan",
	"Albania",
	"Algeria",
	"American Samoa",
	"Andorra",
	"Angola",
	"Anguilla",
	"Antarctica",
	"Antigua and Barbuda",
	"Argentina",
	"Armenia",
	"Aruba",
	"Australia",
	"Austria",
	"Azerbaijan",
	"Bahamas",
	"Bahrain",
	"Bangladesh",
	"Barbados",
	"Belarus",
	"Belgium",
	"Belize",
	"Benin",
	"Bermuda",
	"Bhutan",
	"Bolivia",
	"Bosnia and Herzegovina",
	"Botswana",
	"Bouvet Island",
	"Brazil",
	"British Indian Ocean Territory",
	"Brunei Darussalam",
	"Bulgaria",
	"Burkina Faso",
	"Burundi",
	"Cambodia",
	"Cameroon",
	"Canada",
	"Cape Verde",
	"Cayman Islands",
	"Central African Republic",
	"Chad",
	"Chile",
	"China",
	"Christmas Island",
	"Cocos (Keeling) Islands",
	"Colombia",
	"Comoros",
	"Congo",
	"Congo, the Democratic Republic of the",
	"Cook Islands",
	"Costa Rica",
	"Cote D'Ivoire",
	"Croatia",
	"Cuba",
	"Cyprus",
	"Czech Republic",
	"Denmark",
	"Djibouti",
	"Dominica",
	"Dominican Republic",
	"Ecuador",
	"Egypt",
	"El Salvador",
	"Equatorial Guinea",
	"Eritrea",
	"Estonia",
	"Ethiopia",
	"Falkland Islands (Malvinas)",
	"Faroe Islands",
	"Fiji",
	"Finland",
	"France",
	"French Guiana",
	"French Polynesia",
	"French Southern Territories",
	"Gabon",
	"Gambia",
	"Georgia",
	"Germany",
	"Ghana",
	"Gibraltar",
	"Greece",
	"Greenland",
	"Grenada",
	"Guadeloupe",
	"Guam",
	"Guatemala",
	"Guinea",
	"Guinea-Bissau",
	"Guyana",
	"Haiti",
	"Heard Island and Mcdonald Islands",
	"Holy See (Vatican City State)",
	"Honduras",
	"Hong Kong",
	"Hungary",
	"Iceland",
	"India",
	"Indonesia",
	"Iran, Islamic Republic of",
	"Iraq",
	"Ireland",
	"Israel",
	"Italy",
	"Jamaica",
	"Japan",
	"Jordan",
	"Kazakhstan",
	"Kenya",
	"Kiribati",
	"Korea, Democratic People's Republic of",
	"Korea, Republic of",
	"Kuwait",
	"Kyrgyzstan",
	"Lao People's Democratic Republic",
	"Latvia",
	"Lebanon",
	"Lesotho",
	"Liberia",
	"Libyan Arab Jamahiriya",
	"Liechtenstein",
	"Lithuania",
	"Luxembourg",
	"Macao",
	"Macedonia, the Former Yugoslav Republic of",
	"Madagascar",
	"Malawi",
	"Malaysia",
	"Maldives",
	"Mali",
	"Malta",
	"Marshall Islands",
	"Martinique",
	"Mauritania",
	"Mauritius",
	"Mayotte",
	"Mexico",
	"Micronesia, Federated States of",
	"Moldova, Republic of",
	"Monaco",
	"Mongolia",
	"Montserrat",
	"Morocco",
	"Mozambique",
	"Myanmar",
	"Namibia",
	"Nauru",
	"Nepal",
	"Netherlands",
	"Netherlands Antilles",
	"New Caledonia",
	"New Zealand",
	"Nicaragua",
	"Niger",
	"Nigeria",
	"Niue",
	"Norfolk Island",
	"Northern Mariana Islands",
	"Norway",
	"Oman",
	"Pakistan",
	"Palau",
	"Palestinian Territory, Occupied",
	"Panama",
	"Papua New Guinea",
	"Paraguay",
	"Peru",
	"Philippines",
	"Pitcairn",
	"Poland",
	"Portugal",
	"Puerto Rico",
	"Qatar",
	"Reunion",
	"Romania",
	"Russian Federation",
	"Rwanda",
	"Saint Helena",
	"Saint Kitts and Nevis",
	"Saint Lucia",
	"Saint Pierre and Miquelon",
	"Saint Vincent and the Grenadines",
	"Samoa",
	"San Marino",
	"Sao Tome and Principe",
	"Saudi Arabia",
	"Senegal",
	"Serbia and Montenegro",
	"Seychelles",
	"Sierra Leone",
	"Singapore",
	"Slovakia",
	"Slovenia",
	"Solomon Islands",
	"Somalia",
	"South Africa",
	"South Georgia and the South Sandwich Islands",
	"Spain",
	"Sri Lanka",
	"Sudan",
	"Suriname",
	"Svalbard and Jan Mayen",
	"Swaziland",
	"Sweden",
	"Switzerland",
	"Syrian Arab Republic",
	"Taiwan, Province of China",
	"Tajikistan",
	"Tanzania, United Republic of",
	"Thailand",
	"Timor-Leste",
	"Togo",
	"Tokelau",
	"Tonga",
	"Trinidad and Tobago",
	"Tunisia",
	"Turkey",
	"Turkmenistan",
	"Turks and Caicos Islands",
	"Tuvalu",
	"Uganda",
	"Ukraine",
	"United Arab Emirates",
	"United Kingdom",
	"United States",
	"United States Minor Outlying Islands",
	"Uruguay",
	"Uzbekistan",
	"Vanuatu",
	"Venezuela",
	"Viet Nam",
	"Virgin Islands, British",
	"Virgin Islands, US",
	"Wallis and Futuna",
	"Western Sahara",
	"Yemen",
	"Zambia",
	"Zimbabwe",
    };
        public void countrymethod()
        {
            for (int i = 0; i < 239; i++)
            {
                //Create a new object of Result class
                countryclass obj = new countryclass();

                //add the corresponding data from the sample array
                obj.name = countrynames[i];


                //add the object directly into the list box
                Clist.Items.Add(obj);

            }
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
            DateTime cDate = DateTime.Now;
            DateTime Udob = DateTime.Parse(rDOB.Date.ToString("dd-MM-yyyy"));
            DateTime checkDOB = Udob.AddYears(12);
            string gen = "";
            if (Clist.SelectedItem == "select country")
            {
                vClist.Text = "please select a country";
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
                if (rFnameTxt.Text == "")
                {
                    vFnameTxt.Text = "First name should not be empty";
                    return;
                }
                if (rLnameTxt.Text == "")
                {
                    vLnameTxt.Text = "Last name should not be empty";
                    return;
                }
                if (rUnameTxt.Text == "")
                {
                    vUnameTxt.Text = "Username should not be empty";
                    return;
                }
                if (UnameFlag == 0)
                {
                    vUnameTxt.Text = "Username alredy exists";
                    return;
                }
                if (rPasswordTxt.Password == "" & rPasswordTxt.Password.Length < 6)
                {
                    vPasswordTxt.Text = "Your password must be atleast 6 characters long";
                    return;
                }
                if (rCpasswordTxt.Password != rPasswordTxt.Password)
                {
                    vCpasswordTxt.Text = "Passwords don't match";
                    return;
                }
                if (checkDOB.Date >= cDate.Date)
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
                    country = Clist.SelectedItem.ToString(),
                    phone = rPhoneTxt.Text
                };
                await App.MobileService.GetTable<PrateekPDM>().InsertAsync(p1);
                StatusTxt.Text = "";
                StatusBar.IsIndeterminate = false;
                pivot1.SelectedIndex = 0;



            }
            catch (Exception ex)
            {
                var msg = new MessageDialog("Error" + ex).ShowAsync();
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
            loggedlist = await App.MobileService.GetTable<PrateekPDM>().Where(x => x.uname == lUnameTxt.Text & x.password == lPasswordTxt.Password).ToListAsync();
            if (loggedlist.Count == 1)
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

