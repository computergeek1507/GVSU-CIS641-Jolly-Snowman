
namespace Emgu_Test
{
    partial class VideoSelect
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
            this.radioButtonLocal = new System.Windows.Forms.RadioButton();
            this.radioButtonRemote = new System.Windows.Forms.RadioButton();
            this.comboBoxLocal = new System.Windows.Forms.ComboBox();
            this.radioButtonFile = new System.Windows.Forms.RadioButton();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonTestRemote = new System.Windows.Forms.Button();
            this.textBoxRemote = new System.Windows.Forms.TextBox();
            this.textBoxVideoFile = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.openFileDialogVideo = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // radioButtonLocal
            // 
            this.radioButtonLocal.AutoSize = true;
            this.radioButtonLocal.Location = new System.Drawing.Point(14, 16);
            this.radioButtonLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonLocal.Name = "radioButtonLocal";
            this.radioButtonLocal.Size = new System.Drawing.Size(123, 24);
            this.radioButtonLocal.TabIndex = 0;
            this.radioButtonLocal.TabStop = true;
            this.radioButtonLocal.Text = "Local Camera:";
            this.radioButtonLocal.UseVisualStyleBackColor = true;
            // 
            // radioButtonRemote
            // 
            this.radioButtonRemote.AutoSize = true;
            this.radioButtonRemote.Location = new System.Drawing.Point(14, 56);
            this.radioButtonRemote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonRemote.Name = "radioButtonRemote";
            this.radioButtonRemote.Size = new System.Drawing.Size(140, 24);
            this.radioButtonRemote.TabIndex = 1;
            this.radioButtonRemote.TabStop = true;
            this.radioButtonRemote.Text = "Remote Camera:";
            this.radioButtonRemote.UseVisualStyleBackColor = true;
            // 
            // comboBoxLocal
            // 
            this.comboBoxLocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLocal.FormattingEnabled = true;
            this.comboBoxLocal.Location = new System.Drawing.Point(150, 16);
            this.comboBoxLocal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxLocal.Name = "comboBoxLocal";
            this.comboBoxLocal.Size = new System.Drawing.Size(228, 28);
            this.comboBoxLocal.TabIndex = 2;
            this.comboBoxLocal.SelectedIndexChanged += new System.EventHandler(this.comboBoxLocal_SelectedIndexChanged);
            // 
            // radioButtonFile
            // 
            this.radioButtonFile.AutoSize = true;
            this.radioButtonFile.Location = new System.Drawing.Point(14, 95);
            this.radioButtonFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.radioButtonFile.Name = "radioButtonFile";
            this.radioButtonFile.Size = new System.Drawing.Size(99, 24);
            this.radioButtonFile.TabIndex = 3;
            this.radioButtonFile.TabStop = true;
            this.radioButtonFile.Text = "Video File:";
            this.radioButtonFile.UseVisualStyleBackColor = true;
            // 
            // buttonFile
            // 
            this.buttonFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonFile.Location = new System.Drawing.Point(384, 92);
            this.buttonFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(54, 31);
            this.buttonFile.TabIndex = 4;
            this.buttonFile.Text = "...";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonTestRemote
            // 
            this.buttonTestRemote.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTestRemote.Location = new System.Drawing.Point(385, 53);
            this.buttonTestRemote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonTestRemote.Name = "buttonTestRemote";
            this.buttonTestRemote.Size = new System.Drawing.Size(54, 31);
            this.buttonTestRemote.TabIndex = 5;
            this.buttonTestRemote.Text = "Test";
            this.buttonTestRemote.UseVisualStyleBackColor = true;
            this.buttonTestRemote.Click += new System.EventHandler(this.buttonTestRemote_Click);
            // 
            // textBoxRemote
            // 
            this.textBoxRemote.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRemote.Location = new System.Drawing.Point(150, 55);
            this.textBoxRemote.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxRemote.Name = "textBoxRemote";
            this.textBoxRemote.Size = new System.Drawing.Size(228, 27);
            this.textBoxRemote.TabIndex = 6;
            // 
            // textBoxVideoFile
            // 
            this.textBoxVideoFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVideoFile.Location = new System.Drawing.Point(150, 93);
            this.textBoxVideoFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBoxVideoFile.Name = "textBoxVideoFile";
            this.textBoxVideoFile.Size = new System.Drawing.Size(228, 27);
            this.textBoxVideoFile.TabIndex = 7;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(385, 161);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(86, 31);
            this.buttonCancel.TabIndex = 8;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(293, 161);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(86, 31);
            this.buttonOK.TabIndex = 9;
            this.buttonOK.Text = "Ok";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // openFileDialogVideo
            // 
            this.openFileDialogVideo.Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*";
            this.openFileDialogVideo.Title = "Select Video File";
            // 
            // VideoSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(480, 200);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBoxVideoFile);
            this.Controls.Add(this.textBoxRemote);
            this.Controls.Add(this.buttonTestRemote);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.radioButtonFile);
            this.Controls.Add(this.comboBoxLocal);
            this.Controls.Add(this.radioButtonRemote);
            this.Controls.Add(this.radioButtonLocal);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(440, 219);
            this.Name = "VideoSelect";
            this.Text = "Input Select";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonLocal;
        private System.Windows.Forms.RadioButton radioButtonRemote;
        private System.Windows.Forms.ComboBox comboBoxLocal;
        private System.Windows.Forms.RadioButton radioButtonFile;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonTestRemote;
        private System.Windows.Forms.TextBox textBoxRemote;
        private System.Windows.Forms.TextBox textBoxVideoFile;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.OpenFileDialog openFileDialogVideo;
    }
}