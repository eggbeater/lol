namespace lol
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
            this.basicSummonerInfo = new System.Windows.Forms.Button();
            this.outputBox = new System.Windows.Forms.RichTextBox();
            this.SumNameTextBox = new System.Windows.Forms.TextBox();
            this.SumNameLabel = new System.Windows.Forms.Label();
            this.getChampData = new System.Windows.Forms.Button();
            this.testButton = new System.Windows.Forms.Button();
            this.championLalbel = new System.Windows.Forms.Label();
            this.champBox = new System.Windows.Forms.ComboBox();
            this.checkMasteryButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.rankedStatsButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // basicSummonerInfo
            // 
            this.basicSummonerInfo.Location = new System.Drawing.Point(12, 19);
            this.basicSummonerInfo.Name = "basicSummonerInfo";
            this.basicSummonerInfo.Size = new System.Drawing.Size(111, 23);
            this.basicSummonerInfo.TabIndex = 0;
            this.basicSummonerInfo.Text = "Basic Info";
            this.basicSummonerInfo.UseVisualStyleBackColor = true;
            this.basicSummonerInfo.Click += new System.EventHandler(this.button1_Click);
            // 
            // outputBox
            // 
            this.outputBox.Location = new System.Drawing.Point(12, 178);
            this.outputBox.Name = "outputBox";
            this.outputBox.Size = new System.Drawing.Size(353, 228);
            this.outputBox.TabIndex = 1;
            this.outputBox.Text = "";
            // 
            // SumNameTextBox
            // 
            this.SumNameTextBox.Location = new System.Drawing.Point(238, 26);
            this.SumNameTextBox.Name = "SumNameTextBox";
            this.SumNameTextBox.Size = new System.Drawing.Size(172, 20);
            this.SumNameTextBox.TabIndex = 2;
            // 
            // SumNameLabel
            // 
            this.SumNameLabel.AutoSize = true;
            this.SumNameLabel.Location = new System.Drawing.Point(141, 29);
            this.SumNameLabel.Name = "SumNameLabel";
            this.SumNameLabel.Size = new System.Drawing.Size(91, 13);
            this.SumNameLabel.TabIndex = 3;
            this.SumNameLabel.Text = "Summoner Name:";
            // 
            // getChampData
            // 
            this.getChampData.Location = new System.Drawing.Point(12, 54);
            this.getChampData.Name = "getChampData";
            this.getChampData.Size = new System.Drawing.Size(111, 23);
            this.getChampData.TabIndex = 4;
            this.getChampData.Text = "Get Champ Data";
            this.getChampData.UseVisualStyleBackColor = true;
            this.getChampData.Click += new System.EventHandler(this.getChampData_Click);
            // 
            // testButton
            // 
            this.testButton.Location = new System.Drawing.Point(12, 525);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(75, 23);
            this.testButton.TabIndex = 5;
            this.testButton.Text = "Test";
            this.testButton.UseVisualStyleBackColor = true;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // championLalbel
            // 
            this.championLalbel.AutoSize = true;
            this.championLalbel.Location = new System.Drawing.Point(141, 64);
            this.championLalbel.Name = "championLalbel";
            this.championLalbel.Size = new System.Drawing.Size(54, 13);
            this.championLalbel.TabIndex = 6;
            this.championLalbel.Text = "Champion";
            // 
            // champBox
            // 
            this.champBox.FormattingEnabled = true;
            this.champBox.Location = new System.Drawing.Point(289, 56);
            this.champBox.Name = "champBox";
            this.champBox.Size = new System.Drawing.Size(121, 21);
            this.champBox.TabIndex = 7;
            this.champBox.SelectedIndexChanged += new System.EventHandler(this.champBox_SelectedIndexChanged);
            // 
            // checkMasteryButton
            // 
            this.checkMasteryButton.Location = new System.Drawing.Point(12, 89);
            this.checkMasteryButton.Name = "checkMasteryButton";
            this.checkMasteryButton.Size = new System.Drawing.Size(111, 23);
            this.checkMasteryButton.TabIndex = 8;
            this.checkMasteryButton.Text = "Check Mastery";
            this.checkMasteryButton.UseVisualStyleBackColor = true;
            this.checkMasteryButton.Click += new System.EventHandler(this.checkMasteryButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 525);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // rankedStatsButton
            // 
            this.rankedStatsButton.Location = new System.Drawing.Point(12, 124);
            this.rankedStatsButton.Name = "rankedStatsButton";
            this.rankedStatsButton.Size = new System.Drawing.Size(111, 23);
            this.rankedStatsButton.TabIndex = 10;
            this.rankedStatsButton.Text = "Ranked Stats";
            this.rankedStatsButton.UseVisualStyleBackColor = true;
            this.rankedStatsButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(23, 425);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 591);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rankedStatsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkMasteryButton);
            this.Controls.Add(this.champBox);
            this.Controls.Add(this.championLalbel);
            this.Controls.Add(this.testButton);
            this.Controls.Add(this.getChampData);
            this.Controls.Add(this.SumNameLabel);
            this.Controls.Add(this.SumNameTextBox);
            this.Controls.Add(this.outputBox);
            this.Controls.Add(this.basicSummonerInfo);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button basicSummonerInfo;
        private System.Windows.Forms.RichTextBox outputBox;
        private System.Windows.Forms.TextBox SumNameTextBox;
        private System.Windows.Forms.Label SumNameLabel;
        private System.Windows.Forms.Button getChampData;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label championLalbel;
        private System.Windows.Forms.ComboBox champBox;
        private System.Windows.Forms.Button checkMasteryButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button rankedStatsButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

