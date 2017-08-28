namespace Chess
{
    partial class Main
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
            this.lbCords = new System.Windows.Forms.Label();
            this.NextAvailableMove = new FontAwesomeIcons.IconButton();
            this.LastAvailableMove = new FontAwesomeIcons.IconButton();
            this.FirstMove = new FontAwesomeIcons.IconButton();
            this.CurrentMove = new FontAwesomeIcons.IconButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btMoveAI = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.NextAvailableMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastAvailableMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentMove)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCords
            // 
            this.lbCords.AutoSize = true;
            this.lbCords.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCords.Location = new System.Drawing.Point(589, 9);
            this.lbCords.Name = "lbCords";
            this.lbCords.Size = new System.Drawing.Size(0, 20);
            this.lbCords.TabIndex = 0;
            // 
            // NextAvailableMove
            // 
            this.NextAvailableMove.ActiveColor = System.Drawing.Color.Black;
            this.NextAvailableMove.BackColor = System.Drawing.Color.Transparent;
            this.NextAvailableMove.IconType = FontAwesomeIcons.IconType.StepForward;
            this.NextAvailableMove.InActiveColor = System.Drawing.Color.DimGray;
            this.NextAvailableMove.Location = new System.Drawing.Point(819, 262);
            this.NextAvailableMove.Name = "NextAvailableMove";
            this.NextAvailableMove.Size = new System.Drawing.Size(25, 16);
            this.NextAvailableMove.TabIndex = 1;
            this.NextAvailableMove.TabStop = false;
            this.NextAvailableMove.ToolTipText = null;
            this.NextAvailableMove.Click += new System.EventHandler(this.NextAvailableMove_Click);
            // 
            // LastAvailableMove
            // 
            this.LastAvailableMove.ActiveColor = System.Drawing.Color.Black;
            this.LastAvailableMove.BackColor = System.Drawing.Color.Transparent;
            this.LastAvailableMove.IconType = FontAwesomeIcons.IconType.StepBackward;
            this.LastAvailableMove.InActiveColor = System.Drawing.Color.DimGray;
            this.LastAvailableMove.Location = new System.Drawing.Point(788, 262);
            this.LastAvailableMove.Name = "LastAvailableMove";
            this.LastAvailableMove.Size = new System.Drawing.Size(25, 16);
            this.LastAvailableMove.TabIndex = 2;
            this.LastAvailableMove.TabStop = false;
            this.LastAvailableMove.ToolTipText = null;
            this.LastAvailableMove.Click += new System.EventHandler(this.LastAvailableMove_Click);
            // 
            // FirstMove
            // 
            this.FirstMove.ActiveColor = System.Drawing.Color.Black;
            this.FirstMove.BackColor = System.Drawing.Color.Transparent;
            this.FirstMove.IconType = FontAwesomeIcons.IconType.FastBackward;
            this.FirstMove.InActiveColor = System.Drawing.Color.DimGray;
            this.FirstMove.Location = new System.Drawing.Point(740, 262);
            this.FirstMove.Name = "FirstMove";
            this.FirstMove.Size = new System.Drawing.Size(42, 16);
            this.FirstMove.TabIndex = 3;
            this.FirstMove.TabStop = false;
            this.FirstMove.ToolTipText = null;
            this.FirstMove.Click += new System.EventHandler(this.FirstMove_Click);
            // 
            // CurrentMove
            // 
            this.CurrentMove.ActiveColor = System.Drawing.Color.Black;
            this.CurrentMove.BackColor = System.Drawing.Color.Transparent;
            this.CurrentMove.IconType = FontAwesomeIcons.IconType.FastForward;
            this.CurrentMove.InActiveColor = System.Drawing.Color.DimGray;
            this.CurrentMove.Location = new System.Drawing.Point(850, 262);
            this.CurrentMove.Name = "CurrentMove";
            this.CurrentMove.Size = new System.Drawing.Size(35, 16);
            this.CurrentMove.TabIndex = 4;
            this.CurrentMove.TabStop = false;
            this.CurrentMove.ToolTipText = null;
            this.CurrentMove.Click += new System.EventHandler(this.CurrentMove_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(692, 284);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 174);
            this.dataGridView1.TabIndex = 5;
            // 
            // btMoveAI
            // 
            this.btMoveAI.Location = new System.Drawing.Point(692, 9);
            this.btMoveAI.Name = "btMoveAI";
            this.btMoveAI.Size = new System.Drawing.Size(121, 23);
            this.btMoveAI.TabIndex = 6;
            this.btMoveAI.Text = "Ask AI to Move";
            this.btMoveAI.UseVisualStyleBackColor = true;
            this.btMoveAI.Click += new System.EventHandler(this.btMoveAI_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 711);
            this.Controls.Add(this.btMoveAI);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CurrentMove);
            this.Controls.Add(this.FirstMove);
            this.Controls.Add(this.LastAvailableMove);
            this.Controls.Add(this.NextAvailableMove);
            this.Controls.Add(this.lbCords);
            this.Name = "Main";
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Main_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Main_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.NextAvailableMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LastAvailableMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FirstMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CurrentMove)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbCords;
        private FontAwesomeIcons.IconButton NextAvailableMove;
        private FontAwesomeIcons.IconButton LastAvailableMove;
        private FontAwesomeIcons.IconButton FirstMove;
        private FontAwesomeIcons.IconButton CurrentMove;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btMoveAI;
    }
}

