
namespace IELTSpeaking
{
    partial class IELTSpeaking
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IELTSpeaking));
            this.examinerImg = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.TimerSpeak = new System.Windows.Forms.Timer(this.components);
            this.MicWave = new System.Windows.Forms.ProgressBar();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.Part2TxtBox = new System.Windows.Forms.TextBox();
            this.tmrPart2 = new System.Windows.Forms.Timer(this.components);
            this.lblPart2Time = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.examinerImg)).BeginInit();
            this.SuspendLayout();
            // 
            // examinerImg
            // 
            this.examinerImg.Location = new System.Drawing.Point(128, 44);
            this.examinerImg.Name = "examinerImg";
            this.examinerImg.Size = new System.Drawing.Size(589, 391);
            this.examinerImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.examinerImg.TabIndex = 0;
            this.examinerImg.TabStop = false;
            // 
            // startBtn
            // 
            this.startBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startBtn.Location = new System.Drawing.Point(348, 511);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(149, 45);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // TimerSpeak
            // 
            this.TimerSpeak.Tick += new System.EventHandler(this.TimerSpeak_Tick);
            // 
            // MicWave
            // 
            this.MicWave.Location = new System.Drawing.Point(193, 508);
            this.MicWave.Name = "MicWave";
            this.MicWave.Size = new System.Drawing.Size(454, 50);
            this.MicWave.TabIndex = 2;
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueBtn.Location = new System.Drawing.Point(325, 564);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(194, 37);
            this.ContinueBtn.TabIndex = 3;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // Part2TxtBox
            // 
            this.Part2TxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Part2TxtBox.Location = new System.Drawing.Point(128, 44);
            this.Part2TxtBox.Multiline = true;
            this.Part2TxtBox.Name = "Part2TxtBox";
            this.Part2TxtBox.ReadOnly = true;
            this.Part2TxtBox.Size = new System.Drawing.Size(589, 391);
            this.Part2TxtBox.TabIndex = 4;
            // 
            // tmrPart2
            // 
            this.tmrPart2.Interval = 1000;
            this.tmrPart2.Tick += new System.EventHandler(this.tmrPart2_Tick);
            // 
            // lblPart2Time
            // 
            this.lblPart2Time.AutoSize = true;
            this.lblPart2Time.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPart2Time.Location = new System.Drawing.Point(648, 454);
            this.lblPart2Time.Name = "lblPart2Time";
            this.lblPart2Time.Size = new System.Drawing.Size(69, 29);
            this.lblPart2Time.TabIndex = 5;
            this.lblPart2Time.Text = "Time";
            // 
            // IELTSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 622);
            this.Controls.Add(this.lblPart2Time);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.MicWave);
            this.Controls.Add(this.examinerImg);
            this.Controls.Add(this.Part2TxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "IELTSpeaking";
            this.Text = "IELTSpeaking";
            this.Load += new System.EventHandler(this.IELTSpeaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.examinerImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.PictureBox examinerImg;
        public System.Windows.Forms.ProgressBar MicWave;
        public System.Windows.Forms.Label lblPart2Time;
        public System.Windows.Forms.Button ContinueBtn;
        public System.Windows.Forms.Button startBtn;
        public System.Windows.Forms.Timer TimerSpeak;
        public System.Windows.Forms.TextBox Part2TxtBox;
        public System.Windows.Forms.Timer tmrPart2;
    }
}

