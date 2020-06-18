using System;

using DomainModel;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

using static DomainModel.Money;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWP_UI
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private readonly SnackMachine _snackMachine;

        private string helper_NumberOf(string moneyType)
        {
            switch (moneyType)
            {
                case "1C":
                return _snackMachine.TransactionMoney.NbOfCent.ToString();
                case "10C":
                return _snackMachine.TransactionMoney.NbOfTenCent.ToString();
                case "25C":
                return _snackMachine.TransactionMoney.NbOfQuarter.ToString();
                case "1D":
                return _snackMachine.TransactionMoney.NbOfDollar.ToString();
                case "5D":
                return _snackMachine.TransactionMoney.NbOfFiveDollar.ToString();
                case "20D":
                return _snackMachine.TransactionMoney.NbOfTwentyDollar.ToString();
                default:
                throw new Exception("This type of money not used in our system");
            }
        }
        private string helperInside_NumberOf(string moneyType)
        {
            switch (moneyType)
            {
                case "1C":
                return _snackMachine.TransactionMoney.NbOfCent.ToString();
                case "10C":
                return _snackMachine.TransactionMoney.NbOfTenCent.ToString();
                case "25C":
                return _snackMachine.TransactionMoney.NbOfQuarter.ToString();
                case "1D":
                return _snackMachine.TransactionMoney.NbOfDollar.ToString();
                case "5D":
                return _snackMachine.TransactionMoney.NbOfFiveDollar.ToString();
                case "20D":
                return _snackMachine.TransactionMoney.NbOfTwentyDollar.ToString();
                default:
                throw new Exception("This type of money not used in our system");
            }
        }

        public MainPage()
        {
            this.InitializeComponent();

            // Je ne sais pas si c'est le bon endroit pour instancier et initialiser ici !!
            _snackMachine = new SnackMachine();
            numberOf1C.Text = helper_NumberOf("1C");
            numberOf10C.Text = helper_NumberOf("10C");
            numberOf25C.Text = helper_NumberOf("25C");
            numberOf1D.Text = helper_NumberOf("1D");
            numberOf5D.Text = helper_NumberOf("5D");
            numberOf20D.Text = helper_NumberOf("20D");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();

            numberOf1C_Inside.Text = helperInside_NumberOf("1C");
            numberOf10C_Inside.Text = helperInside_NumberOf("10C");
            numberOf25C_Inside.Text = helperInside_NumberOf("25C");
            numberOf1D_Inside.Text = helperInside_NumberOf("1D");
            numberOf5D_Inside.Text = helperInside_NumberOf("5D");
            numberOf20D_Inside.Text = helperInside_NumberOf("20D");
            insertedAmount_Inside.Text = _snackMachine.SnackMachineMoney.ToString();

            chocolateLeft.Text = "0";
            sodaLeft.Text = "0";
            gumLet.Text = "0";


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
        }

        // Insert Cents ----------------------------------------------------------------------
        private void OneCent_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(Cent);

            // change View
            numberOf1C.Text = helper_NumberOf("1C");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
            //numberOf1C.Text = (int.Parse(numberOf1C.Text) + 1).ToString(); to delete
        }
        private void TenCents_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(TenCent);

            // change View
            numberOf10C.Text = helper_NumberOf("10C");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
        }
        private void TwentyFiveCents_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(Quarter);

            // change View
            numberOf25C.Text = helper_NumberOf("25C");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
        }

        // Insert Dollars ----------------------------------------------------------------------
        private void OneDollar_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(Dollar);

            // change View
            numberOf1D.Text = helper_NumberOf("1D");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
        }

        private void FiveDollars_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(FiveDollar);

            // change View
            numberOf5D.Text = helper_NumberOf("5D");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
        }

        private void TwentyDollars_Click(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.InsertMoney(TwentyDollar);

            // change View
            numberOf20D.Text = helper_NumberOf("20D");
            insertedAmount.Text = _snackMachine.TransactionMoney.ToString();
        }

        // Return my money ----------------------------------------------------------------------
        private void CancelPurchase(object sender, RoutedEventArgs e)
        {
            // change Model
            _snackMachine.ReturnMoneyBack();

            // change View
            numberOf1C.Text = helper_NumberOf("1C");
            numberOf10C.Text = helper_NumberOf("10C");
            numberOf25C.Text = helper_NumberOf("25C");
            numberOf1D.Text = helper_NumberOf("1D");
            numberOf5D.Text = helper_NumberOf("5D");
            numberOf20D.Text = helper_NumberOf("20D");

            insertedAmount.Text = insertedAmount_Inside.Text.ToString();
        }

        // Choose snack ----------------------------------------------------------------------
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
