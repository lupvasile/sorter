namespace sorter
{
    partial class form_extensions
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
            this.extensions = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // extensions
            // 
            this.extensions.Location = new System.Drawing.Point(12, 12);
            this.extensions.Name = "extensions";
            this.extensions.Size = new System.Drawing.Size(83, 238);
            this.extensions.TabIndex = 0;
            this.extensions.Text = "jpg\nnef";
            // 
            // form_extensions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(195, 262);
            this.Controls.Add(this.extensions);
            this.Name = "form_extensions";
            this.Text = "Extensions";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox extensions;



    }
}