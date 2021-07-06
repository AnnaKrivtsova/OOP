namespace _1lab
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonXor = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.buttonBinary = new System.Windows.Forms.Button();
            this.buttonOctal = new System.Windows.Forms.Button();
            this.buttonDecimal = new System.Windows.Forms.Button();
            this.buttonHexadecimal = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonTwo = new System.Windows.Forms.Button();
            this.buttonOne = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.textBoxMain = new System.Windows.Forms.TextBox();
            this.buttonThree = new System.Windows.Forms.Button();
            this.buttonZero = new System.Windows.Forms.Button();
            this.buttonNine = new System.Windows.Forms.Button();
            this.buttonSix = new System.Windows.Forms.Button();
            this.buttonFour = new System.Windows.Forms.Button();
            this.buttonFive = new System.Windows.Forms.Button();
            this.buttonSeven = new System.Windows.Forms.Button();
            this.buttonEight = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAnd
            // 
            this.buttonAnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonAnd.Location = new System.Drawing.Point(174, 57);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(75, 30);
            this.buttonAnd.TabIndex = 0;
            this.buttonAnd.Text = "AND";
            this.buttonAnd.UseVisualStyleBackColor = true;
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonOr.Location = new System.Drawing.Point(276, 57);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(75, 30);
            this.buttonOr.TabIndex = 1;
            this.buttonOr.Text = "OR";
            this.buttonOr.UseVisualStyleBackColor = true;
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonXor
            // 
            this.buttonXor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonXor.Location = new System.Drawing.Point(379, 57);
            this.buttonXor.Name = "buttonXor";
            this.buttonXor.Size = new System.Drawing.Size(75, 30);
            this.buttonXor.TabIndex = 2;
            this.buttonXor.Text = "XOR";
            this.buttonXor.UseVisualStyleBackColor = true;
            this.buttonXor.Click += new System.EventHandler(this.buttonXor_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNot.Location = new System.Drawing.Point(480, 57);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(75, 30);
            this.buttonNot.TabIndex = 3;
            this.buttonNot.Text = "NOT";
            this.buttonNot.UseVisualStyleBackColor = true;
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // buttonBinary
            // 
            this.buttonBinary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonBinary.Location = new System.Drawing.Point(6, 108);
            this.buttonBinary.Name = "buttonBinary";
            this.buttonBinary.Size = new System.Drawing.Size(148, 60);
            this.buttonBinary.TabIndex = 4;
            this.buttonBinary.Text = "Binary";
            this.buttonBinary.UseVisualStyleBackColor = true;
            this.buttonBinary.Click += new System.EventHandler(this.buttonBinary_Click);
            // 
            // buttonOctal
            // 
            this.buttonOctal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonOctal.Location = new System.Drawing.Point(6, 197);
            this.buttonOctal.Name = "buttonOctal";
            this.buttonOctal.Size = new System.Drawing.Size(148, 60);
            this.buttonOctal.TabIndex = 5;
            this.buttonOctal.Text = "Octal";
            this.buttonOctal.UseVisualStyleBackColor = true;
            this.buttonOctal.Click += new System.EventHandler(this.buttonOctal_Click);
            // 
            // buttonDecimal
            // 
            this.buttonDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonDecimal.Location = new System.Drawing.Point(6, 281);
            this.buttonDecimal.Name = "buttonDecimal";
            this.buttonDecimal.Size = new System.Drawing.Size(148, 60);
            this.buttonDecimal.TabIndex = 6;
            this.buttonDecimal.Text = "Decimal";
            this.buttonDecimal.UseVisualStyleBackColor = true;
            this.buttonDecimal.Click += new System.EventHandler(this.buttonDecimal_Click);
            // 
            // buttonHexadecimal
            // 
            this.buttonHexadecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonHexadecimal.Location = new System.Drawing.Point(6, 361);
            this.buttonHexadecimal.Name = "buttonHexadecimal";
            this.buttonHexadecimal.Size = new System.Drawing.Size(148, 60);
            this.buttonHexadecimal.TabIndex = 7;
            this.buttonHexadecimal.Text = "Hexadecimal";
            this.buttonHexadecimal.UseVisualStyleBackColor = true;
            this.buttonHexadecimal.Click += new System.EventHandler(this.buttonHexadecimal_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonClear.Location = new System.Drawing.Point(480, 108);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 149);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "C";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonTwo
            // 
            this.buttonTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonTwo.Location = new System.Drawing.Point(276, 108);
            this.buttonTwo.Name = "buttonTwo";
            this.buttonTwo.Size = new System.Drawing.Size(75, 60);
            this.buttonTwo.TabIndex = 10;
            this.buttonTwo.Text = "2";
            this.buttonTwo.UseVisualStyleBackColor = true;
            this.buttonTwo.Click += new System.EventHandler(this.buttonTwo_Click);
            // 
            // buttonOne
            // 
            this.buttonOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonOne.Location = new System.Drawing.Point(174, 108);
            this.buttonOne.Name = "buttonOne";
            this.buttonOne.Size = new System.Drawing.Size(75, 60);
            this.buttonOne.TabIndex = 11;
            this.buttonOne.Text = "1";
            this.buttonOne.UseVisualStyleBackColor = true;
            this.buttonOne.Click += new System.EventHandler(this.buttonOne_Click);
            // 
            // buttonEqual
            // 
            this.buttonEqual.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonEqual.Location = new System.Drawing.Point(480, 281);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(75, 140);
            this.buttonEqual.TabIndex = 12;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            this.buttonEqual.Click += new System.EventHandler(this.buttonEqual_Click);
            // 
            // textBoxMain
            // 
            this.textBoxMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBoxMain.Location = new System.Drawing.Point(174, 19);
            this.textBoxMain.Margin = new System.Windows.Forms.Padding(10, 10, 3, 3);
            this.textBoxMain.Name = "textBoxMain";
            this.textBoxMain.Size = new System.Drawing.Size(381, 30);
            this.textBoxMain.TabIndex = 13;
            this.textBoxMain.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxMain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMain_KeyPress);
            // 
            // buttonThree
            // 
            this.buttonThree.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonThree.Location = new System.Drawing.Point(379, 108);
            this.buttonThree.Name = "buttonThree";
            this.buttonThree.Size = new System.Drawing.Size(75, 60);
            this.buttonThree.TabIndex = 14;
            this.buttonThree.Text = "3";
            this.buttonThree.UseVisualStyleBackColor = true;
            this.buttonThree.Click += new System.EventHandler(this.buttonThree_Click);
            // 
            // buttonZero
            // 
            this.buttonZero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonZero.Location = new System.Drawing.Point(174, 361);
            this.buttonZero.Name = "buttonZero";
            this.buttonZero.Size = new System.Drawing.Size(280, 60);
            this.buttonZero.TabIndex = 15;
            this.buttonZero.Text = "0";
            this.buttonZero.UseVisualStyleBackColor = true;
            this.buttonZero.Click += new System.EventHandler(this.buttonZero_Click);
            // 
            // buttonNine
            // 
            this.buttonNine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNine.Location = new System.Drawing.Point(379, 281);
            this.buttonNine.Name = "buttonNine";
            this.buttonNine.Size = new System.Drawing.Size(75, 60);
            this.buttonNine.TabIndex = 16;
            this.buttonNine.Text = "9";
            this.buttonNine.UseVisualStyleBackColor = true;
            this.buttonNine.Click += new System.EventHandler(this.buttonNine_Click);
            // 
            // buttonSix
            // 
            this.buttonSix.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSix.Location = new System.Drawing.Point(379, 197);
            this.buttonSix.Name = "buttonSix";
            this.buttonSix.Size = new System.Drawing.Size(75, 60);
            this.buttonSix.TabIndex = 17;
            this.buttonSix.Text = "6";
            this.buttonSix.UseVisualStyleBackColor = true;
            this.buttonSix.Click += new System.EventHandler(this.buttonSix_Click);
            // 
            // buttonFour
            // 
            this.buttonFour.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFour.Location = new System.Drawing.Point(174, 197);
            this.buttonFour.Name = "buttonFour";
            this.buttonFour.Size = new System.Drawing.Size(75, 60);
            this.buttonFour.TabIndex = 18;
            this.buttonFour.Text = "4";
            this.buttonFour.UseVisualStyleBackColor = true;
            this.buttonFour.Click += new System.EventHandler(this.buttonFour_Click);
            // 
            // buttonFive
            // 
            this.buttonFive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonFive.Location = new System.Drawing.Point(276, 197);
            this.buttonFive.Name = "buttonFive";
            this.buttonFive.Size = new System.Drawing.Size(75, 60);
            this.buttonFive.TabIndex = 19;
            this.buttonFive.Text = "5";
            this.buttonFive.UseVisualStyleBackColor = true;
            this.buttonFive.Click += new System.EventHandler(this.buttonFive_Click);
            // 
            // buttonSeven
            // 
            this.buttonSeven.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonSeven.Location = new System.Drawing.Point(174, 281);
            this.buttonSeven.Name = "buttonSeven";
            this.buttonSeven.Size = new System.Drawing.Size(75, 60);
            this.buttonSeven.TabIndex = 20;
            this.buttonSeven.Text = "7";
            this.buttonSeven.UseVisualStyleBackColor = true;
            this.buttonSeven.Click += new System.EventHandler(this.buttonSeven_Click);
            // 
            // buttonEight
            // 
            this.buttonEight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonEight.Location = new System.Drawing.Point(276, 281);
            this.buttonEight.Name = "buttonEight";
            this.buttonEight.Size = new System.Drawing.Size(75, 60);
            this.buttonEight.TabIndex = 21;
            this.buttonEight.Text = "8";
            this.buttonEight.UseVisualStyleBackColor = true;
            this.buttonEight.Click += new System.EventHandler(this.buttonEight_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(593, 443);
            this.Controls.Add(this.buttonEight);
            this.Controls.Add(this.buttonSeven);
            this.Controls.Add(this.buttonFive);
            this.Controls.Add(this.buttonFour);
            this.Controls.Add(this.buttonSix);
            this.Controls.Add(this.buttonNine);
            this.Controls.Add(this.buttonZero);
            this.Controls.Add(this.buttonThree);
            this.Controls.Add(this.textBoxMain);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.buttonOne);
            this.Controls.Add(this.buttonTwo);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonHexadecimal);
            this.Controls.Add(this.buttonDecimal);
            this.Controls.Add(this.buttonOctal);
            this.Controls.Add(this.buttonBinary);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonXor);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.buttonAnd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.Button buttonXor;
        private System.Windows.Forms.Button buttonNot;
        private System.Windows.Forms.Button buttonBinary;
        private System.Windows.Forms.Button buttonOctal;
        private System.Windows.Forms.Button buttonDecimal;
        private System.Windows.Forms.Button buttonHexadecimal;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonTwo;
        private System.Windows.Forms.Button buttonOne;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.TextBox textBoxMain;
        private System.Windows.Forms.Button buttonThree;
        private System.Windows.Forms.Button buttonZero;
        private System.Windows.Forms.Button buttonNine;
        private System.Windows.Forms.Button buttonSix;
        private System.Windows.Forms.Button buttonFour;
        private System.Windows.Forms.Button buttonFive;
        private System.Windows.Forms.Button buttonSeven;
        private System.Windows.Forms.Button buttonEight;
    }
}

