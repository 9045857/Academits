using Swing2.TemperatureTypes;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Swing2
{
    public partial class TemperatureConverterForm : Form
    {
        private ITemperatureType[] inputTypes;
        private ITemperatureType[] outputTypes;

        public TemperatureConverterForm()
        {
            InitializeComponent();
        }

        private void PrepareRadioButtonGroup(ITemperatureType[] typesArray, GroupBox groupBox)
        {
            int widthBeforRadioButtonGroup = ComponentConstants.radioButtonBeforGroup;
            int widthAfterRadioButtonGroup = ComponentConstants.radioButtonAfterGroup;

            int inputTypesCount = typesArray.Length;
            int radioButtonAreaWidth = ComponentConstants.radioButtonsYDelta;

            int xPosition = groupBox.Location.X;
            int yPosition = ComponentConstants.yDeltaBetweenControls;

            groupBox.Location = new Point(xPosition, yPosition); ;
            groupBox.Height = widthBeforRadioButtonGroup + inputTypesCount * radioButtonAreaWidth + widthAfterRadioButtonGroup;

            for (int i = 0; i < inputTypesCount; i++)
            {
                RadioButton radioButton = new RadioButton();

                this.Controls.Add(radioButton);
                radioButton.Parent = groupBox;
                radioButton.Name = string.Concat(groupBox.Name, typesArray[i].Name);
                radioButton.Text = typesArray[i].Name;

                if (i == 0)
                {
                    radioButton.Checked = true;
                }

                xPosition = ComponentConstants.radioButtonFromLeft;
                yPosition = widthBeforRadioButtonGroup + i * radioButtonAreaWidth;
                radioButton.Location = new Point(xPosition, yPosition);

                radioButton.CheckedChanged += new EventHandler(RadioButton_Checked);
            }
        }

        private void RadioButton_Checked(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                ConvertTemperature();
            }
        }

        private void PrepareVerticalSizes()
        {
            int yDeltaBetweenControls = ComponentConstants.yDeltaBetweenControls;

            int maxGroupRadioButtonHeight = (inputGroupBox.Height > outputGroupBox.Height) ? inputGroupBox.Height : outputGroupBox.Height;
            int yPosition = inputGroupBox.Location.Y + maxGroupRadioButtonHeight + yDeltaBetweenControls;

            int xPosition = inputGroupBox.Location.X;

            inputPanel.Location = new Point(xPosition, yPosition);

            xPosition = outputGroupBox.Location.X;
            outputPanel.Location = new Point(xPosition, yPosition);

            yPosition = inputPanel.Location.Y + inputPanel.Height + yDeltaBetweenControls;
            xPosition = inputGroupBox.Location.X;

            convertButton.Location = new Point(xPosition, yPosition);

            Rectangle screenRectangle = RectangleToScreen(this.ClientRectangle);
            int titleHeight = screenRectangle.Top - this.Top;

            int formHeight = titleHeight + yPosition + convertButton.Height + yDeltaBetweenControls + DefaultMargin.Bottom;
            this.Height = formHeight;

            this.MaximizeBox = false;
        }

        private void PrepareHorizontalSizes()
        {
            int textSize = TextRenderer.MeasureText(this.Text, this.Font).Width;
            int lengthSystemButtons = 200;
            this.Width = textSize + lengthSystemButtons;

            int spacesCount = 3;
            int radioButtonGroupCount = 2;
            int spaceWidth = ComponentConstants.xDeltaBetweenControls;
            int totalSpaceWidth = spaceWidth * spacesCount;


            int radioButtonGroupBorderWidth = 2;
            int radioButtonGroupBorderCount = 4;
            int radioButtonGroupBorderTotalWidth = radioButtonGroupBorderWidth * radioButtonGroupBorderCount;

            int radioButtonGroupWidth = (this.Width - totalSpaceWidth - DefaultMargin.Left - DefaultMargin.Right - radioButtonGroupBorderTotalWidth) / radioButtonGroupCount;

            inputGroupBox.Left = spaceWidth;
            inputGroupBox.Width = radioButtonGroupWidth;

            outputGroupBox.Left = inputGroupBox.Right + spaceWidth;
            outputGroupBox.Width = radioButtonGroupWidth;

            inputPanel.Left = spaceWidth;

            outputPanel.Left = outputGroupBox.Left;
            outputPanel.Width = outputGroupBox.Width;

            convertButton.Left = spaceWidth;
            convertButton.Width = 2 * radioButtonGroupWidth + spaceWidth;
        }

        private ITemperatureType GetTemperatureType(GroupBox groupBox)
        {
            foreach (Control control in groupBox.Controls)
            {
                if ((control as RadioButton).Checked)
                {
                    string radioButtonName = control.Name;

                    ITemperatureType type = inputTypes.FirstOrDefault(x => string.Concat(groupBox.Name, x.Name) == radioButtonName);

                    if (!Equals(type, null))
                    {
                        return type;
                    }

                    return outputTypes.FirstOrDefault(x => string.Concat(groupBox.Name, x.Name) == radioButtonName);
                }
            }

            return null;
        }

        private void ConvertTemperature()
        {
            ITemperatureType inputType = GetTemperatureType(inputGroupBox);
            inputSymbolLabel.Text = inputType.Symbol;

            ITemperatureType outputType = GetTemperatureType(outputGroupBox);

            string inputTextBoxText = inputTextBox.Text;

            if (double.TryParse(inputTextBoxText, out double inputTextBoxData))
            {
                double outputTypeData = Math.Round(TemperatureConverter.Convert(inputTextBoxData, inputType, outputType), 2);
                outputLabel.Text = string.Format("{0} {1}", outputTypeData, outputType.Symbol);
            }
            else
            {
                outputLabel.Text = outputType.Symbol;
            }
        }

        private void PrepareForm()
        {
            inputTypes = new ITemperatureType[] { new Celsius(), new Kelvin(), new Fahrenheit() };
            outputTypes = new ITemperatureType[] { new Kelvin(), new Celsius(), new Fahrenheit() };

            PrepareRadioButtonGroup(inputTypes, inputGroupBox);
            PrepareRadioButtonGroup(outputTypes, outputGroupBox);

            PrepareVerticalSizes();
            PrepareHorizontalSizes();

            ConvertTemperature();
        }

        private void ConvertTemperatureWithErrorMessage()
        {
            string inputTemperature = inputTextBox.Text;

            if (double.TryParse(inputTemperature, out double inputData))
            {
                ConvertTemperature();
            }
            else
            {
                MessageBox.Show("Данные введены некорректно.");
            }
        }

        private void ConvertButton_Click(object sender, EventArgs e)
        {
            ConvertTemperatureWithErrorMessage();
        }

        private void TemperatureConverterForm_Load(object sender, EventArgs e)
        {
            PrepareForm();
        }
    }
}
