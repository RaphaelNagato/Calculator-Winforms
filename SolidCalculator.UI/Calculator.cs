using System;
using System.Windows.Forms;
using SolidCalculator.Commons;
using SolidCalculator.Core;

namespace SolidCalculator.UI
{
    public partial class Calculator : Form
    {
        private readonly IArithmeticOperationsRepo _arithmeticOperations;
        private string _defaultBigText = "0";
        private char _dot = '.';
        private bool _isOperatorClicked = false;
        private string _previousVal = default;
        private Button _operatorBtn;
        private int maxLength = 15;

        // inject the operations repo into the UI for calculations
        public Calculator(IArithmeticOperationsRepo operationsRepo)
        {
            InitializeComponent();
            _arithmeticOperations = operationsRepo;
        }

        private void NumButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender; // captures the clicked button object
            if (bigTxtDisplay.Text == _defaultBigText || _isOperatorClicked)
            {
                bigTxtDisplay.Clear();
                _isOperatorClicked = false;
            }

            if (bigTxtDisplay.Text.Length <= maxLength)
            {
                bigTxtDisplay.Text += btn.Text; // only append values to text when display text is less than max length
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // reset all to default as the clear button is clicked
            bigTxtDisplay.Text = _defaultBigText;
            smallTxtDisplay.Clear();
            _isOperatorClicked = false;
            _operatorBtn = null;
            _previousVal = default;
        }

        private void btnEqualTo_Click(object sender, EventArgs e)
        {
            smallTxtDisplay.Text += bigTxtDisplay.Text + btnEqualTo.Text; // shows the user a better representation of the operation he/she is about to do

            if (_previousVal != default
                                   &&
                                   (bigTxtDisplay.Text != default || bigTxtDisplay.Text != _defaultBigText))
            {
                try
                {
                    var sign = Utilities.TryParseToOperator(_operatorBtn.Text);
                    var fNum = Utilities.ParseToDouble(_previousVal);
                    var sNum = Utilities.ParseToDouble(bigTxtDisplay.Text);

                    var result = Utilities.ParseToString(_arithmeticOperations.Calc(fNum, sign, sNum));

                    // display text is always less than or equal to max length
                    bigTxtDisplay.Text = result.Length <= maxLength ? result : result.Substring(0, maxLength);

                    // reset all after calculation have been made
                    _previousVal = default;
                    _operatorBtn = null;
                    _isOperatorClicked = true;
                }
                catch (ArgumentException exception)
                {
                    bigTxtDisplay.Text = exception.Message; // for the case of dividing by zero
                }
            }
        }

        private void operatorBtn_Click(object sender, EventArgs e)
        {
            if (_operatorBtn != null)
            {
                this.btnEqualTo_Click(sender, e); //performs the previous operation before the new one is set;
            }

            _isOperatorClicked = true;
            _operatorBtn = (Button)sender;
            smallTxtDisplay.Text = bigTxtDisplay.Text + _operatorBtn.Text; // set smallTxtDisplay after an operatorBtn click
            _previousVal = bigTxtDisplay.Text;
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            // A dot is only appended when there text does not contain one
            if (!bigTxtDisplay.Text.Contains(_dot))
            {
                bigTxtDisplay.Text += _dot;
            }
        }

        private void btnNegator_Click(object sender, EventArgs e)
        {
            // appends "-" only when the value is not zero (0)
            if (bigTxtDisplay.Text != _defaultBigText)
            {
                bigTxtDisplay.Text = bigTxtDisplay.Text.StartsWith('-')
                    ? bigTxtDisplay.Text.Substring(1)
                    : $"-{bigTxtDisplay.Text}";
            }
        }
    }
}