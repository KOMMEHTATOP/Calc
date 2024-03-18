using Calc;
using Calc.Model;
using NUnit.Framework.Legacy;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimplePlus()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            decimal res = calculatorModel.Result;
            Assert.That(res, Is.EqualTo(44));
        }

        [Test]
        public void SimpleMinus()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            decimal res = calculatorModel.Result;
            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void InputDot()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber(",");
            bool v = calculatorModel.DialText == "0,";
            Assert.That(v, Is.EqualTo(true));
        }

        [Test]
        public void InputSpamDot()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber(",");
            Assert.That(condition: calculatorModel.DialText == "0,");
        }

        [Test]
        public void InputDotFirstNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber(",");
            Assert.That(condition: calculatorModel.DialText == "22,");
        }

        [Test]
        public void InputSpamDotFirstNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber("1");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber(",");
            Assert.That(condition: calculatorModel.DialText == "22,1");
        }

        [Test]
        public void InputDotSecondNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber(",");
            Assert.That(condition: calculatorModel.DialText == "0,");
        }

        [Test]
        public void InputSpamDotSecondNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber("1");
            calculatorModel.TrySetNumber(",");
            calculatorModel.TrySetNumber(",");
            Assert.That(condition: calculatorModel.DialText == "0,1");
        }

        [Test]
        public void InputSpamZeroFirstNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("0");
            calculatorModel.TrySetNumber("0");
            calculatorModel.TrySetNumber("0");
            Assert.That(condition: calculatorModel.DialText == "0");
        }

        [Test]
        public void InputSpamZeroSecondNumber()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("0");
            calculatorModel.TrySetNumber("0");
            calculatorModel.TrySetNumber("0");
            Assert.That(condition: calculatorModel.DialText == "0");
        }

        [Test]
        public void InputNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("5");
            Assert.That(condition: calculatorModel.DialText == "5");
        }

        [Test]
        public void LastOperationInputNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("5");
            Assert.That(condition: calculatorModel.LastOperation == string.Empty);
        }

        [Test]
        public void CheckFirstNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("5");
            calculatorModel.TryOperator("-");
            Assert.That(calculatorModel.FirstNumber, Is.EqualTo(5));
        }

        [Test]
        public void CheckSecondNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("55");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("5");
            calculatorModel.TryResult();
            Assert.That(calculatorModel.Result, Is.EqualTo(50));
        }

        [Test]
        public void CheckRefresh()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            calculatorModel.RefreshOn();
            Assert.That(calculatorModel.state, Is.EqualTo(State.First));
            Assert.That(calculatorModel.FirstNumber, Is.EqualTo(0));
            Assert.That(calculatorModel.MathOperator, Is.EqualTo(string.Empty));
            Assert.That(calculatorModel.SecondNumber, Is.EqualTo(0));
            Assert.That(calculatorModel.Result, Is.EqualTo(0));
            Assert.That(calculatorModel.LastOperation, Is.EqualTo(string.Empty));
            Assert.That(calculatorModel.CanBeRefreshed, Is.EqualTo(true));
        }

        [Test]
        public void CheckResultAfterRefresh()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            Assert.That(calculatorModel.Result, Is.EqualTo(44));
            Assert.That(calculatorModel.DialText, Is.EqualTo("44"));
        }

        [Test]
        public void CheckModelSecondNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("1");
            calculatorModel.TryResult();
            Assert.That(calculatorModel.Result, Is.EqualTo(23));
            Assert.That(calculatorModel.DialText, Is.EqualTo("23"));
        }

        [Test]
        public void InputNumAndOperatorAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber("22");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("1");
            calculatorModel.TryOperator("+");
            calculatorModel.TryResult();
            Assert.That(calculatorModel.Result, Is.EqualTo(2));
            Assert.That(calculatorModel.DialText, Is.EqualTo("2"));
        }

        [Test]
        public void InputDotInFirstNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber(",6");
            calculatorModel.TryOperator("+");
            calculatorModel.TrySetNumber(",4");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber(",");
            Assert.That(calculatorModel.DialText, Is.EqualTo("0,"));
        }

    }
}