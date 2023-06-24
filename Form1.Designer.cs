namespace U1_2_krepsinis
{
    partial class Form1
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
            this.output = new System.Windows.Forms.RichTextBox();
            this.input = new System.Windows.Forms.Button();
            this.results = new System.Windows.Forms.Button();
            this.end = new System.Windows.Forms.Button();
            this.age = new System.Windows.Forms.TextBox();
            this.ageLabel = new System.Windows.Forms.Label();
            this.input_age = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.output.Location = new System.Drawing.Point(12, 12);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(788, 418);
            this.output.TabIndex = 0;
            this.output.Text = "";
            // 
            // input
            // 
            this.input.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.input.Location = new System.Drawing.Point(822, 12);
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(219, 57);
            this.input.TabIndex = 1;
            this.input.Text = "Įvesti";
            this.input.UseVisualStyleBackColor = true;
            this.input.Click += new System.EventHandler(this.input_Click);
            // 
            // results
            // 
            this.results.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.results.Location = new System.Drawing.Point(822, 75);
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(219, 57);
            this.results.TabIndex = 2;
            this.results.Text = "Rezultatai";
            this.results.UseVisualStyleBackColor = true;
            this.results.Click += new System.EventHandler(this.results_Click);
            // 
            // end
            // 
            this.end.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.end.ForeColor = System.Drawing.Color.Red;
            this.end.Location = new System.Drawing.Point(822, 447);
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(219, 57);
            this.end.TabIndex = 3;
            this.end.Text = "Baigti";
            this.end.UseVisualStyleBackColor = true;
            this.end.Click += new System.EventHandler(this.end_Click);
            // 
            // age
            // 
            this.age.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.age.ForeColor = System.Drawing.SystemColors.Highlight;
            this.age.Location = new System.Drawing.Point(12, 482);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(413, 34);
            this.age.TabIndex = 4;
            this.age.Text = "Čia užrašykite amžių.";
            // 
            // ageLabel
            // 
            this.ageLabel.AutoSize = true;
            this.ageLabel.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ageLabel.Location = new System.Drawing.Point(12, 444);
            this.ageLabel.Name = "ageLabel";
            this.ageLabel.Size = new System.Drawing.Size(108, 35);
            this.ageLabel.TabIndex = 5;
            this.ageLabel.Text = "Amžius";
            // 
            // input_age
            // 
            this.input_age.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.input_age.Location = new System.Drawing.Point(822, 138);
            this.input_age.Name = "input_age";
            this.input_age.Size = new System.Drawing.Size(219, 57);
            this.input_age.TabIndex = 6;
            this.input_age.Text = "Įvesti amžių";
            this.input_age.UseVisualStyleBackColor = true;
            this.input_age.Click += new System.EventHandler(this.input_age_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 559);
            this.Controls.Add(this.input_age);
            this.Controls.Add(this.ageLabel);
            this.Controls.Add(this.age);
            this.Controls.Add(this.end);
            this.Controls.Add(this.results);
            this.Controls.Add(this.input);
            this.Controls.Add(this.output);
            this.Name = "Form1";
            this.Text = "Krepšinio žaidėjai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button input;
        private System.Windows.Forms.Button results;
        private System.Windows.Forms.Button end;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.Label ageLabel;
        private System.Windows.Forms.Button input_age;
    }
}

