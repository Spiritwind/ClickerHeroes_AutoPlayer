using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clickerheroes.autoplayer.Forms
{
    public partial class OCRLearn : Form
    {
        public char Character { get; set; }

        public OCRLearn(Bitmap image, char guessedChar = '\0')
        {
            InitializeComponent();

            pictureBox1.Image = image;
            Character = guessedChar;
            textBox1.Text = guessedChar.ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                Character = textBox1.Text[0];
            }
            else
            {
                Character = '\0';
            }
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Character = '\0';
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
