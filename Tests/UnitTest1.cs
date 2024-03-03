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
            double res = calculatorModel.Result;
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
            double res = calculatorModel.Result;
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
        public void FirstNumAfterResult()
        {
            CalculatorModel calculatorModel = new CalculatorModel();

            calculatorModel.TrySetNumber("22");
            calculatorModel.TryOperator("-");
            calculatorModel.TrySetNumber("21");
            calculatorModel.TryResult();
            calculatorModel.TrySetNumber("5");
            Assert.That(condition: calculatorModel.LastOperation == string.Empty);
        }
    }
}