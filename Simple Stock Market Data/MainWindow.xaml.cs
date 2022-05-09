using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Simple_Stock_Market_Data
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        public string HTMLParser (string url, string start, string stop)
        {
            var startPosition = url.IndexOf(start);
            var stopPosition = url.IndexOf(stop, startPosition + start.Length);

            return url.Substring(startPosition + start.Length, stopPosition - startPosition - start.Length);
        }
        public string AAPL()
        {
            // Line from HTML for data
            //<div class="YMlKec fxKbKc">153,28&nbsp;$</div>
            string Start = "YMlKec fxKbKc\">$";
            string Stop = "</div>";

            WebClient client = new WebClient();
            string Url = client.DownloadString(@"https://www.google.com/finance/quote/AAPL:NASDAQ");
            return HTMLParser(Url, Start, Stop);
        }
        public string MSFT()
        {
            //< div class="YMlKec fxKbKc">266,38&nbsp;$</div>
            string Start = "YMlKec fxKbKc\">$";
            string Stop = "</div>";

            WebClient client = new WebClient();
            string Url = client.DownloadString(@"https://www.google.com/finance/quote/MSFT:NASDAQ");
            return HTMLParser(Url, Start, Stop);
        }
        public string SP500()
        {
            //< div class="YMlKec fxKbKc">4&nbsp;016,98</div>
            string Start = "YMlKec fxKbKc\">";
            string Stop = "</div>";

            WebClient client = new WebClient();
            string Url = client.DownloadString(@"https://www.google.com/finance/quote/.INX:INDEXSP");
            return HTMLParser(Url, Start, Stop);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Element1Value.Text = AAPL();
            Element2Value.Text = MSFT();
            Element3Value.Text = SP500();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Element1Value.Text = AAPL();
            Element2Value.Text = MSFT();
            Element3Value.Text = SP500();
        }
    }
}
