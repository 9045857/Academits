using System;
using System.Windows.Forms;
using System.Threading;

namespace Swing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            AcceptButton = button1;
        }

        private void ConvertDegrees()
        {
            string inputTextData = textBox1.Text;

            if (double.TryParse(inputTextData, out double inputData))
            {
                Degrees degree = new Degrees();

                if (radioButton1.Checked)
                {
                    degree.Celsius = inputData;
                }
                else if (radioButton2.Checked)
                {
                    degree.Kelvin = inputData;
                }
                else
                {
                    degree.Fahrenheit = inputData;
                }

                if (radioButton4.Checked)
                {
                    label2.Text = degree.CelsiusValue;
                }
                else if (radioButton5.Checked)
                {
                    label2.Text = degree.KelvinValue;
                }
                else
                {
                    label2.Text = degree.FahrenheitValue;
                }
            }
            else
            {
                //сообщение о введении данных в корректной форме
                MessageBox.Show(
                    "Введенное число должно содержать только цифры." + Environment.NewLine + "В качестве разделителя используйте ','.",
                    "Ошибка: не корректные данные.",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConvertDegrees();
        }

        private void PutEmptyOutputType()
        {
            Degrees degree = new Degrees();

            if (radioButton4.Checked)
            {
                label2.Text = degree.celsiusType;
            }
            else if (radioButton5.Checked)
            {
                label2.Text = degree.kelvinType;
            }
            else
            {
                label2.Text = degree.fahrenheitType;
            }
        }

        private void DoOnChangingInputType()
        {
            string inputTextData = textBox1.Text;

            if (double.TryParse(inputTextData, out double inputData))
            {
                ConvertDegrees();
            }
            else
            {
                PutEmptyOutputType();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Degrees degree = new Degrees();
            label1.Text = degree.celsiusType;

            DoOnChangingInputType();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Degrees degree = new Degrees();
            label1.Text = degree.kelvinType;

            DoOnChangingInputType();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Degrees degree = new Degrees();
            label1.Text = degree.fahrenheitType;

            DoOnChangingInputType();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            DoOnChangingInputType();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            DoOnChangingInputType();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            DoOnChangingInputType();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
