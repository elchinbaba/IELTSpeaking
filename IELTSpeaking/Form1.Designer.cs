
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
            this.examinerImg = new System.Windows.Forms.PictureBox();
            this.startBtn = new System.Windows.Forms.Button();
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
            this.startBtn.Location = new System.Drawing.Point(352, 522);
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(149, 45);
            this.startBtn.TabIndex = 1;
            this.startBtn.Text = "Start";
            this.startBtn.UseVisualStyleBackColor = true;
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // IELTSpeaking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 622);
            this.Controls.Add(this.startBtn);
            this.Controls.Add(this.examinerImg);
            this.Name = "IELTSpeaking";
            this.Text = "IELTSpeaking";
            this.Load += new System.EventHandler(this.IELTSpeaking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.examinerImg)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox examinerImg;
        private System.Windows.Forms.Button startBtn;
    }
}

