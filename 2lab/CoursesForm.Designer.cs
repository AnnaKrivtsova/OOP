
namespace _2lab
{
    partial class CoursesForm
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
            this.groupBox_infoCourses = new System.Windows.Forms.GroupBox();
            this.groupBox_placeCourse = new System.Windows.Forms.GroupBox();
            this.radioButton_placeUniversity = new System.Windows.Forms.RadioButton();
            this.radioButton_placeCompany = new System.Windows.Forms.RadioButton();
            this.groupBox_subjectCourses = new System.Windows.Forms.GroupBox();
            this.checkBox_Sharp = new System.Windows.Forms.CheckBox();
            this.checkBox_Java = new System.Windows.Forms.CheckBox();
            this.checkBox_Plus = new System.Windows.Forms.CheckBox();
            this.richTextBox_outputAboutCourse = new System.Windows.Forms.RichTextBox();
            this.button_outputAboutCourse = new System.Windows.Forms.Button();
            this.groupBox_infoCourses.SuspendLayout();
            this.groupBox_placeCourse.SuspendLayout();
            this.groupBox_subjectCourses.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_infoCourses
            // 
            this.groupBox_infoCourses.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox_infoCourses.Controls.Add(this.button_outputAboutCourse);
            this.groupBox_infoCourses.Controls.Add(this.richTextBox_outputAboutCourse);
            this.groupBox_infoCourses.Controls.Add(this.groupBox_subjectCourses);
            this.groupBox_infoCourses.Controls.Add(this.groupBox_placeCourse);
            this.groupBox_infoCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox_infoCourses.Location = new System.Drawing.Point(27, 24);
            this.groupBox_infoCourses.Name = "groupBox_infoCourses";
            this.groupBox_infoCourses.Size = new System.Drawing.Size(509, 298);
            this.groupBox_infoCourses.TabIndex = 9;
            this.groupBox_infoCourses.TabStop = false;
            this.groupBox_infoCourses.Text = "Информация о курсах";
            // 
            // groupBox_placeCourse
            // 
            this.groupBox_placeCourse.Controls.Add(this.radioButton_placeUniversity);
            this.groupBox_placeCourse.Controls.Add(this.radioButton_placeCompany);
            this.groupBox_placeCourse.Location = new System.Drawing.Point(11, 42);
            this.groupBox_placeCourse.Name = "groupBox_placeCourse";
            this.groupBox_placeCourse.Size = new System.Drawing.Size(200, 100);
            this.groupBox_placeCourse.TabIndex = 16;
            this.groupBox_placeCourse.TabStop = false;
            this.groupBox_placeCourse.Text = "Место проведения";
            // 
            // radioButton_placeUniversity
            // 
            this.radioButton_placeUniversity.AutoSize = true;
            this.radioButton_placeUniversity.Checked = true;
            this.radioButton_placeUniversity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton_placeUniversity.Location = new System.Drawing.Point(6, 19);
            this.radioButton_placeUniversity.Name = "radioButton_placeUniversity";
            this.radioButton_placeUniversity.Size = new System.Drawing.Size(180, 29);
            this.radioButton_placeUniversity.TabIndex = 28;
            this.radioButton_placeUniversity.TabStop = true;
            this.radioButton_placeUniversity.Text = "В университете";
            this.radioButton_placeUniversity.UseVisualStyleBackColor = true;
            // 
            // radioButton_placeCompany
            // 
            this.radioButton_placeCompany.AutoSize = true;
            this.radioButton_placeCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButton_placeCompany.Location = new System.Drawing.Point(6, 54);
            this.radioButton_placeCompany.Name = "radioButton_placeCompany";
            this.radioButton_placeCompany.Size = new System.Drawing.Size(142, 29);
            this.radioButton_placeCompany.TabIndex = 29;
            this.radioButton_placeCompany.Text = "В компании";
            this.radioButton_placeCompany.UseVisualStyleBackColor = true;
            // 
            // groupBox_subjectCourses
            // 
            this.groupBox_subjectCourses.Controls.Add(this.checkBox_Plus);
            this.groupBox_subjectCourses.Controls.Add(this.checkBox_Java);
            this.groupBox_subjectCourses.Controls.Add(this.checkBox_Sharp);
            this.groupBox_subjectCourses.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox_subjectCourses.Location = new System.Drawing.Point(11, 148);
            this.groupBox_subjectCourses.Name = "groupBox_subjectCourses";
            this.groupBox_subjectCourses.Size = new System.Drawing.Size(200, 130);
            this.groupBox_subjectCourses.TabIndex = 26;
            this.groupBox_subjectCourses.TabStop = false;
            this.groupBox_subjectCourses.Text = "Курсы:";
            // 
            // checkBox_Sharp
            // 
            this.checkBox_Sharp.AutoSize = true;
            this.checkBox_Sharp.Checked = true;
            this.checkBox_Sharp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Sharp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBox_Sharp.Location = new System.Drawing.Point(6, 25);
            this.checkBox_Sharp.Name = "checkBox_Sharp";
            this.checkBox_Sharp.Size = new System.Drawing.Size(60, 29);
            this.checkBox_Sharp.TabIndex = 27;
            this.checkBox_Sharp.Text = "C#";
            this.checkBox_Sharp.UseVisualStyleBackColor = true;
            // 
            // checkBox_Java
            // 
            this.checkBox_Java.AutoSize = true;
            this.checkBox_Java.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBox_Java.Location = new System.Drawing.Point(6, 55);
            this.checkBox_Java.Name = "checkBox_Java";
            this.checkBox_Java.Size = new System.Drawing.Size(77, 29);
            this.checkBox_Java.TabIndex = 28;
            this.checkBox_Java.Text = "Java";
            this.checkBox_Java.UseVisualStyleBackColor = true;
            // 
            // checkBox_Plus
            // 
            this.checkBox_Plus.AutoSize = true;
            this.checkBox_Plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.checkBox_Plus.Location = new System.Drawing.Point(6, 85);
            this.checkBox_Plus.Name = "checkBox_Plus";
            this.checkBox_Plus.Size = new System.Drawing.Size(73, 29);
            this.checkBox_Plus.TabIndex = 29;
            this.checkBox_Plus.Text = "C++";
            this.checkBox_Plus.UseVisualStyleBackColor = true;
            // 
            // richTextBox_outputAboutCourse
            // 
            this.richTextBox_outputAboutCourse.Location = new System.Drawing.Point(227, 42);
            this.richTextBox_outputAboutCourse.Name = "richTextBox_outputAboutCourse";
            this.richTextBox_outputAboutCourse.ReadOnly = true;
            this.richTextBox_outputAboutCourse.Size = new System.Drawing.Size(224, 160);
            this.richTextBox_outputAboutCourse.TabIndex = 27;
            this.richTextBox_outputAboutCourse.Text = "";
            // 
            // button_outputAboutCourse
            // 
            this.button_outputAboutCourse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button_outputAboutCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.button_outputAboutCourse.Location = new System.Drawing.Point(236, 227);
            this.button_outputAboutCourse.Name = "button_outputAboutCourse";
            this.button_outputAboutCourse.Size = new System.Drawing.Size(204, 39);
            this.button_outputAboutCourse.TabIndex = 28;
            this.button_outputAboutCourse.Text = "Узнать цену";
            this.button_outputAboutCourse.UseVisualStyleBackColor = false;
            this.button_outputAboutCourse.Click += new System.EventHandler(this.button_outputAboutCourse_Click);
            // 
            // Coursescs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 368);
            this.Controls.Add(this.groupBox_infoCourses);
            this.Name = "Coursescs";
            this.Text = "Coursescs";
            this.groupBox_infoCourses.ResumeLayout(false);
            this.groupBox_placeCourse.ResumeLayout(false);
            this.groupBox_placeCourse.PerformLayout();
            this.groupBox_subjectCourses.ResumeLayout(false);
            this.groupBox_subjectCourses.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_infoCourses;
        private System.Windows.Forms.GroupBox groupBox_placeCourse;
        private System.Windows.Forms.RadioButton radioButton_placeUniversity;
        private System.Windows.Forms.RadioButton radioButton_placeCompany;
        private System.Windows.Forms.GroupBox groupBox_subjectCourses;
        private System.Windows.Forms.CheckBox checkBox_Java;
        private System.Windows.Forms.CheckBox checkBox_Sharp;
        private System.Windows.Forms.Button button_outputAboutCourse;
        private System.Windows.Forms.RichTextBox richTextBox_outputAboutCourse;
        private System.Windows.Forms.CheckBox checkBox_Plus;
    }
}