
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
            this.examinerImg = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
            this.TimerSpeak = new System.Windows.Forms.Timer(this.components);
            this.MicWave = new System.Windows.Forms.ProgressBar();
            this.ContinueBtn = new System.Windows.Forms.Button();
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
            this.startBtn.Location = new System.Drawing.Point(348, 520);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(149, 45);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // TimerSpeak
            // 
            this.TimerSpeak.Interval = 1;
            this.TimerSpeak.Tick += new System.EventHandler(this.TimerSpeak_Tick);
            // 
            // MicWave
            // 
            this.MicWave.Location = new System.Drawing.Point(193, 517);
            this.MicWave.Name = "MicWave";
            this.MicWave.Size = new System.Drawing.Size(454, 50);
            this.MicWave.TabIndex = 2;
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContinueBtn.Location = new System.Drawing.Point(325, 571);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(194, 36);
            this.ContinueBtn.TabIndex = 3;
            this.ContinueBtn.Text = "Continue";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            this.ContinueBtn.Click += new System.EventHandler(this.ContinueBtn_Click);
            // 
            // IELTSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 622);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.examinerImg);
            this.Controls.Add(this.MicWave);
            this.Name = "IELTSpeaking";
            this.Text = "IELTSpeaking";
            this.Load += new System.EventHandler(this.IELTSpeaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.examinerImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox examinerImg;
        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.Timer TimerSpeak;
        private System.Windows.Forms.ProgressBar MicWave;
        private System.Windows.Forms.Button ContinueBtn;
    }
}

