using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Style reveal = Resources.ThemeDictionaries["ButtonRevealStyle"] as Style;
            //foreach (Button b in gridCalculator.Children.OfType<Button>())
            //{
            //    b.FontSize = 24;
            //    b.Width = 54;
            //    b.Height = 54;
            //    b.Style = reveal;
            //}

            numberOf1C.Text =  "0";
            numberOf10C.Text = "0";
            numberOf25C.Text = "0";
            numberOf1D.Text =  "0";
            numberOf5D.Text =  "0";
            numberOf20D.Text = "0";
            insertedAmount.Text = $"{0:C}";

            numberOf1C_Inside.Text =  "0";
            numberOf10C_Inside.Text = "0";
            numberOf25C_Inside.Text = "0";
            numberOf1D_Inside.Text =  "0";
            numberOf5D_Inside.Text =  "0";
            numberOf20D_Inside.Text = "0";
            insertedAmount_Inside.Text = $"{0:C}";

            chocolateLeft.Text = "0";
            sodaLeft.Text = "0";
            gumLet.Text = "0";

        }

        // Cents ----------------------------------------------------------------------
        private void OneCent_Click(object sender, RoutedEventArgs e)
        {
            numberOf1C.Text = (int.Parse(numberOf1C.Text) + 1).ToString();
        }

        private void TenCents_Click(object sender, RoutedEventArgs e)
        {
            numberOf10C.Text = (int.Parse(numberOf10C.Text) + 1).ToString();

        }
        private void TwentyFiveCents_Click(object sender, RoutedEventArgs e)
        {
            numberOf25C.Text = (int.Parse(numberOf25C.Text) + 1).ToString();
        }


        // Dollars ----------------------------------------------------------------------
        private void OneDollar_Click(object sender, RoutedEventArgs e)
        {
            numberOf1D.Text = (int.Parse(numberOf1D.Text) + 1).ToString();
        }

        private void FiveDollars_Click(object sender, RoutedEventArgs e)
        {
            numberOf5D.Text = (int.Parse(numberOf5D.Text) + 1).ToString();
        }

        private void TwentyDollars_Click(object sender, RoutedEventArgs e)
        {
            numberOf20D.Text = (int.Parse(numberOf20D.Text) + 1).ToString();

        }

        private void CancelPurchase(object sender, RoutedEventArgs e)
        {
            numberOf1C.Text = "0";
            numberOf10C.Text = "0";
            numberOf25C.Text = "0";
            numberOf1D.Text = "0";
            numberOf5D.Text = "0";
            numberOf20D.Text = "0";
            insertedAmount.Text = $"{0:C}";
        }

        private void chocolate_Click(object sender, RoutedEventArgs e)
        {

        }

        private void soda_Click(object sender, RoutedEventArgs e)
        {

        }

        private void gum_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
