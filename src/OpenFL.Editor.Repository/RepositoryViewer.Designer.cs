namespace OpenFL.Editor.Repository
{
    partial class RepositoryViewer
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
            this.tvRepos = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvRepos
            // 
            this.tvRepos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvRepos.Location = new System.Drawing.Point(0, 0);
            this.tvRepos.Name = "tvRepos";
            this.tvRepos.Size = new System.Drawing.Size(800, 450);
            this.tvRepos.TabIndex = 0;
            this.tvRepos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvRepos_AfterSelect);
            // 
            // RepositoryViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tvRepos);
            this.Name = "RepositoryViewer";
            this.Text = "RepositoryViewer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvRepos;
    }
}