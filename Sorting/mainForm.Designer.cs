namespace Sorting
{
    partial class mainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.cbSortSelector = new System.Windows.Forms.ComboBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbrand = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(593, 573);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 22);
            this.button1.TabIndex = 2;
            this.button1.Text = "Watch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbSortSelector
            // 
            this.cbSortSelector.DisplayMember = "dsaaa";
            this.cbSortSelector.FormattingEnabled = true;
            this.cbSortSelector.Items.AddRange(new object[] {
            "Bubble sort",
            "Not so bubble sort",
            "Insertion sort",
            "Radix sort",
            "Counting sort",
            "Gnome sort",
            "Shell sort",
            "Cocktail sort"});
            this.cbSortSelector.Location = new System.Drawing.Point(449, 575);
            this.cbSortSelector.Name = "cbSortSelector";
            this.cbSortSelector.Size = new System.Drawing.Size(135, 21);
            this.cbSortSelector.TabIndex = 3;
            this.cbSortSelector.Text = "Bubble sort";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(521, 603);
            this.trackBar1.Maximum = 500;
            this.trackBar1.Minimum = 1;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 4;
            this.trackBar1.Value = 10;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(479, 614);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "faster";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(631, 614);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "slower";
            // 
            // cbrand
            // 
            this.cbrand.AutoSize = true;
            this.cbrand.Checked = true;
            this.cbrand.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbrand.Location = new System.Drawing.Point(674, 577);
            this.cbrand.Name = "cbrand";
            this.cbrand.Size = new System.Drawing.Size(276, 17);
            this.cbrand.TabIndex = 7;
            this.cbrand.Text = "Randomize? (unchecking is interesting on Radix sort)";
            this.cbrand.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 614);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(442, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Legend: select alghoritm and watch it works. Red for value changes, green for arr" +
    "ay access.";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 653);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.cbSortSelector);
            this.Controls.Add(this.button1);
            this.Name = "mainForm";
            this.Text = "Sorting Visuals";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cbSortSelector;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbrand;
        private System.Windows.Forms.Label label3;


    }
}

