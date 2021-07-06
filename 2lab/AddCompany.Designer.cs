
namespace _2lab
{
    partial class AddCompany
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox_workPlace = new System.Windows.Forms.GroupBox();
            this.textBox_company = new System.Windows.Forms.TextBox();
            this.label_company = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox_workPlace.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_workPlace
            // 
            this.groupBox_workPlace.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox_workPlace.Controls.Add(this.textBox_company);
            this.groupBox_workPlace.Controls.Add(this.label_company);
            this.groupBox_workPlace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox_workPlace.Location = new System.Drawing.Point(94, 21);
            this.groupBox_workPlace.Name = "groupBox_workPlace";
            this.groupBox_workPlace.Size = new System.Drawing.Size(297, 130);
            this.groupBox_workPlace.TabIndex = 13;
            this.groupBox_workPlace.TabStop = false;
            this.groupBox_workPlace.Text = "Место работы";
            // 
            // textBox_company
            // 
            this.textBox_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.textBox_company.Location = new System.Drawing.Point(24, 70);
            this.textBox_company.Name = "textBox_company";
            this.textBox_company.Size = new System.Drawing.Size(185, 30);
            this.textBox_company.TabIndex = 3;
            this.textBox_company.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_company_KeyPress);
            // 
            // label_company
            // 
            this.label_company.AutoSize = true;
            this.label_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label_company.Location = new System.Drawing.Point(19, 42);
            this.label_company.Name = "label_company";
            this.label_company.Size = new System.Drawing.Size(106, 25);
            this.label_company.TabIndex = 2;
            this.label_company.Text = "Компания\r\n";
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_save.Location = new System.Drawing.Point(94, 174);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(137, 67);
            this.button_save.TabIndex = 14;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_cancel.Location = new System.Drawing.Point(254, 174);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(137, 67);
            this.button_cancel.TabIndex = 15;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(488, 255);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.groupBox_workPlace);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox_workPlace.ResumeLayout(false);
            this.groupBox_workPlace.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_workPlace;
        private System.Windows.Forms.TextBox textBox_company;
        private System.Windows.Forms.Label label_company;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
    }
}