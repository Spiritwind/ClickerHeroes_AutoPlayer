namespace clickerheroes.autoplayer
{
    partial class TaskList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskList));
            this.TaskBox = new System.Windows.Forms.TextBox();
            this.saveBtn = new System.Windows.Forms.Button();
            this.reloadBtn = new System.Windows.Forms.Button();
            this.activeBtn = new System.Windows.Forms.Button();
            this.idleBtn = new System.Windows.Forms.Button();
            this.costBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TaskBox
            // 
            this.TaskBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TaskBox.Location = new System.Drawing.Point(12, 12);
            this.TaskBox.MaxLength = 2000000;
            this.TaskBox.Multiline = true;
            this.TaskBox.Name = "TaskBox";
            this.TaskBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TaskBox.Size = new System.Drawing.Size(411, 355);
            this.TaskBox.TabIndex = 0;
            this.TaskBox.WordWrap = false;
            // 
            // saveBtn
            // 
            this.saveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveBtn.Location = new System.Drawing.Point(348, 373);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 1;
            this.saveBtn.Text = "Save";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // reloadBtn
            // 
            this.reloadBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reloadBtn.Location = new System.Drawing.Point(267, 373);
            this.reloadBtn.Name = "reloadBtn";
            this.reloadBtn.Size = new System.Drawing.Size(75, 23);
            this.reloadBtn.TabIndex = 2;
            this.reloadBtn.Text = "Reload";
            this.reloadBtn.UseVisualStyleBackColor = true;
            this.reloadBtn.Click += new System.EventHandler(this.reloadBtn_Click);
            // 
            // activeBtn
            // 
            this.activeBtn.Location = new System.Drawing.Point(13, 373);
            this.activeBtn.Name = "activeBtn";
            this.activeBtn.Size = new System.Drawing.Size(75, 23);
            this.activeBtn.TabIndex = 3;
            this.activeBtn.Text = "Active";
            this.activeBtn.UseVisualStyleBackColor = true;
            this.activeBtn.Click += new System.EventHandler(this.activeBtn_Click);
            // 
            // idleBtn
            // 
            this.idleBtn.Location = new System.Drawing.Point(94, 373);
            this.idleBtn.Name = "idleBtn";
            this.idleBtn.Size = new System.Drawing.Size(75, 23);
            this.idleBtn.TabIndex = 4;
            this.idleBtn.Text = "Idle";
            this.idleBtn.UseVisualStyleBackColor = true;
            this.idleBtn.Click += new System.EventHandler(this.idleBtn_Click);
            // 
            // costBtn
            // 
            this.costBtn.Location = new System.Drawing.Point(175, 373);
            this.costBtn.Name = "costBtn";
            this.costBtn.Size = new System.Drawing.Size(75, 23);
            this.costBtn.TabIndex = 5;
            this.costBtn.Text = "Cost";
            this.costBtn.UseVisualStyleBackColor = true;
            this.costBtn.Click += new System.EventHandler(this.costBtn_Click);
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 406);
            this.Controls.Add(this.costBtn);
            this.Controls.Add(this.idleBtn);
            this.Controls.Add(this.activeBtn);
            this.Controls.Add(this.reloadBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.TaskBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(451, 444);
            this.Name = "TaskList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "TaskList";
            this.Load += new System.EventHandler(this.TaskList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TaskBox;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button reloadBtn;
        private System.Windows.Forms.Button activeBtn;
        private System.Windows.Forms.Button idleBtn;
        private System.Windows.Forms.Button costBtn;

    }
}