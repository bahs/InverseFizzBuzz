using InverseFizzBuzzGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InverseFizzBizzNew
{
    public partial class MainForm : Form
    {
        IInverseFizzBuzz _fizzBuzzService;

        public MainForm(IInverseFizzBuzz fizzBuzzService)
        {
            _fizzBuzzService = fizzBuzzService;
            InitializeComponent();
        }

        private void inputTextBox_TextChanged(object sender, EventArgs e)
        {
            resultLabel.Text = _fizzBuzzService.FindShortSequence(inputTextBox.Text);
        }

    }
}
