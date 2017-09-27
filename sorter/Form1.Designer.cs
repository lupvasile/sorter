namespace sorter
{
    partial class form_principal
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
            this.button_source = new System.Windows.Forms.Button();
            this.button_destination = new System.Windows.Forms.Button();
            this.label_source = new System.Windows.Forms.Label();
            this.label_destinatie = new System.Windows.Forms.Label();
            this.folderBrowserDialog_source = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_destination = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extensionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.start_button = new System.Windows.Forms.Button();
            this.checkBox_copiere = new System.Windows.Forms.CheckBox();
            this.checkBox_subfolders = new System.Windows.Forms.CheckBox();
            this.get_extensions_button = new System.Windows.Forms.Button();
            this.checkBox_move = new System.Windows.Forms.CheckBox();
            this.checkBox_list_files = new System.Windows.Forms.CheckBox();
            this.button_repair_file_names = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_source
            // 
            this.button_source.Location = new System.Drawing.Point(12, 47);
            this.button_source.Name = "button_source";
            this.button_source.Size = new System.Drawing.Size(84, 36);
            this.button_source.TabIndex = 9;
            this.button_source.Text = "source";
            this.button_source.UseVisualStyleBackColor = true;
            this.button_source.Click += new System.EventHandler(this.button_source_Click);
            // 
            // button_destination
            // 
            this.button_destination.Location = new System.Drawing.Point(12, 103);
            this.button_destination.Name = "button_destination";
            this.button_destination.Size = new System.Drawing.Size(84, 36);
            this.button_destination.TabIndex = 10;
            this.button_destination.Text = "destination";
            this.button_destination.UseVisualStyleBackColor = true;
            this.button_destination.Click += new System.EventHandler(this.button_destination_Click);
            // 
            // label_source
            // 
            this.label_source.AutoSize = true;
            this.label_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_source.Location = new System.Drawing.Point(120, 57);
            this.label_source.Name = "label_source";
            this.label_source.Size = new System.Drawing.Size(0, 15);
            this.label_source.TabIndex = 11;
            // 
            // label_destinatie
            // 
            this.label_destinatie.AutoSize = true;
            this.label_destinatie.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_destinatie.Location = new System.Drawing.Point(120, 113);
            this.label_destinatie.Name = "label_destinatie";
            this.label_destinatie.Size = new System.Drawing.Size(0, 17);
            this.label_destinatie.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(468, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.monthsToolStripMenuItem,
            this.extensionsToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // monthsToolStripMenuItem
            // 
            this.monthsToolStripMenuItem.Name = "monthsToolStripMenuItem";
            this.monthsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.monthsToolStripMenuItem.Text = "Months";
            this.monthsToolStripMenuItem.Click += new System.EventHandler(this.monthsToolStripMenuItem_Click);
            // 
            // extensionsToolStripMenuItem
            // 
            this.extensionsToolStripMenuItem.Name = "extensionsToolStripMenuItem";
            this.extensionsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.extensionsToolStripMenuItem.Text = "Extensions";
            this.extensionsToolStripMenuItem.Click += new System.EventHandler(this.extensionsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(12, 328);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(196, 83);
            this.start_button.TabIndex = 14;
            this.start_button.Text = "start";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox_copiere
            // 
            this.checkBox_copiere.AutoSize = true;
            this.checkBox_copiere.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_copiere.Location = new System.Drawing.Point(13, 196);
            this.checkBox_copiere.Name = "checkBox_copiere";
            this.checkBox_copiere.Size = new System.Drawing.Size(64, 24);
            this.checkBox_copiere.TabIndex = 15;
            this.checkBox_copiere.Text = "Copy";
            this.checkBox_copiere.UseVisualStyleBackColor = true;
            this.checkBox_copiere.CheckedChanged += new System.EventHandler(this.checkBox_copiere_CheckedChanged);
            // 
            // checkBox_subfolders
            // 
            this.checkBox_subfolders.AutoSize = true;
            this.checkBox_subfolders.Checked = true;
            this.checkBox_subfolders.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_subfolders.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_subfolders.Location = new System.Drawing.Point(12, 226);
            this.checkBox_subfolders.Name = "checkBox_subfolders";
            this.checkBox_subfolders.Size = new System.Drawing.Size(158, 24);
            this.checkBox_subfolders.TabIndex = 16;
            this.checkBox_subfolders.Text = "Include subfolders";
            this.checkBox_subfolders.UseVisualStyleBackColor = true;
            // 
            // get_extensions_button
            // 
            this.get_extensions_button.Location = new System.Drawing.Point(245, 328);
            this.get_extensions_button.Name = "get_extensions_button";
            this.get_extensions_button.Size = new System.Drawing.Size(186, 83);
            this.get_extensions_button.TabIndex = 17;
            this.get_extensions_button.Text = "get extensions";
            this.get_extensions_button.UseVisualStyleBackColor = true;
            this.get_extensions_button.Click += new System.EventHandler(this.get_paths_button_Click);
            // 
            // checkBox_move
            // 
            this.checkBox_move.AutoSize = true;
            this.checkBox_move.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_move.Location = new System.Drawing.Point(13, 166);
            this.checkBox_move.Name = "checkBox_move";
            this.checkBox_move.Size = new System.Drawing.Size(66, 24);
            this.checkBox_move.TabIndex = 18;
            this.checkBox_move.Text = "Move";
            this.checkBox_move.UseVisualStyleBackColor = true;
            this.checkBox_move.CheckedChanged += new System.EventHandler(this.checkBox_move_CheckedChanged);
            // 
            // checkBox_list_files
            // 
            this.checkBox_list_files.AutoSize = true;
            this.checkBox_list_files.Checked = true;
            this.checkBox_list_files.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_list_files.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_list_files.Location = new System.Drawing.Point(13, 256);
            this.checkBox_list_files.Name = "checkBox_list_files";
            this.checkBox_list_files.Size = new System.Drawing.Size(85, 24);
            this.checkBox_list_files.TabIndex = 19;
            this.checkBox_list_files.Text = "List files";
            this.checkBox_list_files.UseVisualStyleBackColor = true;
            // 
            // button_repair_file_names
            // 
            this.button_repair_file_names.Location = new System.Drawing.Point(163, 426);
            this.button_repair_file_names.Name = "button_repair_file_names";
            this.button_repair_file_names.Size = new System.Drawing.Size(115, 30);
            this.button_repair_file_names.TabIndex = 20;
            this.button_repair_file_names.Text = "repair file names";
            this.button_repair_file_names.UseVisualStyleBackColor = true;
            this.button_repair_file_names.Click += new System.EventHandler(this.button_repair_file_names_Click);
            // 
            // form_principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 468);
            this.Controls.Add(this.button_repair_file_names);
            this.Controls.Add(this.checkBox_list_files);
            this.Controls.Add(this.checkBox_move);
            this.Controls.Add(this.get_extensions_button);
            this.Controls.Add(this.checkBox_subfolders);
            this.Controls.Add(this.checkBox_copiere);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.label_destinatie);
            this.Controls.Add(this.label_source);
            this.Controls.Add(this.button_destination);
            this.Controls.Add(this.button_source);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "form_principal";
            this.Text = "sorter";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_source;
        private System.Windows.Forms.Button button_destination;
        private System.Windows.Forms.Label label_source;
        private System.Windows.Forms.Label label_destinatie;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_source;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_destination;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.ToolStripMenuItem extensionsToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox_copiere;
        private System.Windows.Forms.CheckBox checkBox_subfolders;
        private System.Windows.Forms.Button get_extensions_button;
        private System.Windows.Forms.CheckBox checkBox_move;
        private System.Windows.Forms.CheckBox checkBox_list_files;
        private System.Windows.Forms.Button button_repair_file_names;




    }
}

