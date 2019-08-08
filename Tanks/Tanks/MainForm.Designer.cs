namespace Tanks
{
    partial class MainForm
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
            this.pbxField = new System.Windows.Forms.PictureBox();
            this.btnNewGame = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxField
            // 
            this.pbxField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxField.Location = new System.Drawing.Point(0, 0);
            this.pbxField.Name = "pbxField";
            this.pbxField.Size = new System.Drawing.Size(400, 400);
            this.pbxField.TabIndex = 0;
            this.pbxField.TabStop = false;
            this.pbxField.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AllControls_PreviewKeyDown);
            // 
            // btnNewGame
            // 
            this.btnNewGame.Location = new System.Drawing.Point(508, 12);
            this.btnNewGame.Name = "btnNewGame";
            this.btnNewGame.Size = new System.Drawing.Size(75, 23);
            this.btnNewGame.TabIndex = 1;
            this.btnNewGame.Text = "New Game";
            this.btnNewGame.UseVisualStyleBackColor = true;
            this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
            this.btnNewGame.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.AllControls_PreviewKeyDown);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 492);
            this.Controls.Add(this.btnNewGame);
            this.Controls.Add(this.pbxField);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра Танчики";
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxField)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxField;
        private System.Windows.Forms.Button btnNewGame;
        private System.Windows.Forms.Timer timer1;
    }
}

