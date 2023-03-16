namespace Project
{
    partial class Form1
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
            this.loadArt = new System.Windows.Forms.Button();
            this.currentChunk = new System.Windows.Forms.PictureBox();
            this.currentTile = new System.Windows.Forms.PictureBox();
            this.currentBlock = new System.Windows.Forms.PictureBox();
            this.tileHflip = new System.Windows.Forms.CheckBox();
            this.tileVflip = new System.Windows.Forms.CheckBox();
            this.loadBlock = new System.Windows.Forms.Button();
            this.loadChunk = new System.Windows.Forms.Button();
            this.blockID = new System.Windows.Forms.NumericUpDown();
            this.ChunkID = new System.Windows.Forms.NumericUpDown();
            this.paleteLine = new System.Windows.Forms.NumericUpDown();
            this.loadPal = new System.Windows.Forms.Button();
            this.tileID = new System.Windows.Forms.NumericUpDown();
            this.blockHflip = new System.Windows.Forms.CheckBox();
            this.blockVflip = new System.Windows.Forms.CheckBox();
            this.chunkHflip = new System.Windows.Forms.CheckBox();
            this.chunkVflip = new System.Windows.Forms.CheckBox();
            this.saveChunk = new System.Windows.Forms.Button();
            this.saveTile = new System.Windows.Forms.Button();
            this.saveBlock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.currentChunk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBlock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChunkID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paleteLine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileID)).BeginInit();
            this.SuspendLayout();
            // 
            // loadArt
            // 
            this.loadArt.Location = new System.Drawing.Point(413, 25);
            this.loadArt.Name = "loadArt";
            this.loadArt.Size = new System.Drawing.Size(195, 23);
            this.loadArt.TabIndex = 0;
            this.loadArt.Text = "Select art";
            this.loadArt.UseVisualStyleBackColor = true;
            this.loadArt.Click += new System.EventHandler(this.loadTiles_Click);
            // 
            // currentChunk
            // 
            this.currentChunk.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentChunk.Location = new System.Drawing.Point(12, 36);
            this.currentChunk.MaximumSize = new System.Drawing.Size(384, 384);
            this.currentChunk.MinimumSize = new System.Drawing.Size(128, 128);
            this.currentChunk.Name = "currentChunk";
            this.currentChunk.Size = new System.Drawing.Size(384, 384);
            this.currentChunk.TabIndex = 1;
            this.currentChunk.TabStop = false;
            this.currentChunk.Paint += new System.Windows.Forms.PaintEventHandler(this.currentChunk_Paint);
            // 
            // currentTile
            // 
            this.currentTile.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentTile.Location = new System.Drawing.Point(413, 366);
            this.currentTile.MaximumSize = new System.Drawing.Size(80, 80);
            this.currentTile.MinimumSize = new System.Drawing.Size(8, 8);
            this.currentTile.Name = "currentTile";
            this.currentTile.Size = new System.Drawing.Size(80, 80);
            this.currentTile.TabIndex = 2;
            this.currentTile.TabStop = false;
            this.currentTile.Paint += new System.Windows.Forms.PaintEventHandler(this.currentTile_Paint);
            // 
            // currentBlock
            // 
            this.currentBlock.BackColor = System.Drawing.SystemColors.ControlLight;
            this.currentBlock.Location = new System.Drawing.Point(402, 141);
            this.currentBlock.MaximumSize = new System.Drawing.Size(160, 160);
            this.currentBlock.MinimumSize = new System.Drawing.Size(16, 16);
            this.currentBlock.Name = "currentBlock";
            this.currentBlock.Size = new System.Drawing.Size(160, 160);
            this.currentBlock.TabIndex = 3;
            this.currentBlock.TabStop = false;
            this.currentBlock.Paint += new System.Windows.Forms.PaintEventHandler(this.currentBlock_Paint);
            // 
            // tileHflip
            // 
            this.tileHflip.AutoSize = true;
            this.tileHflip.Location = new System.Drawing.Point(499, 400);
            this.tileHflip.Name = "tileHflip";
            this.tileHflip.Size = new System.Drawing.Size(56, 20);
            this.tileHflip.TabIndex = 4;
            this.tileHflip.Text = "Hflip";
            this.tileHflip.UseVisualStyleBackColor = true;
            this.tileHflip.CheckedChanged += new System.EventHandler(this.tileHflip_CheckedChanged);
            // 
            // tileVflip
            // 
            this.tileVflip.AutoSize = true;
            this.tileVflip.Location = new System.Drawing.Point(500, 426);
            this.tileVflip.Name = "tileVflip";
            this.tileVflip.Size = new System.Drawing.Size(55, 20);
            this.tileVflip.TabIndex = 5;
            this.tileVflip.Text = "Vfilp";
            this.tileVflip.UseVisualStyleBackColor = true;
            this.tileVflip.CheckedChanged += new System.EventHandler(this.tileHflip_CheckedChanged);
            // 
            // loadBlock
            // 
            this.loadBlock.Location = new System.Drawing.Point(413, 83);
            this.loadBlock.Name = "loadBlock";
            this.loadBlock.Size = new System.Drawing.Size(195, 23);
            this.loadBlock.TabIndex = 6;
            this.loadBlock.Text = "Select block mappings";
            this.loadBlock.UseVisualStyleBackColor = true;
            this.loadBlock.Click += new System.EventHandler(this.loadBlock_Click);
            // 
            // loadChunk
            // 
            this.loadChunk.Location = new System.Drawing.Point(413, 112);
            this.loadChunk.Name = "loadChunk";
            this.loadChunk.Size = new System.Drawing.Size(195, 23);
            this.loadChunk.TabIndex = 7;
            this.loadChunk.Text = "Select chunck mappings";
            this.loadChunk.UseVisualStyleBackColor = true;
            this.loadChunk.Click += new System.EventHandler(this.loadChunk_Click);
            // 
            // blockID
            // 
            this.blockID.Hexadecimal = true;
            this.blockID.Location = new System.Drawing.Point(402, 318);
            this.blockID.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.blockID.Name = "blockID";
            this.blockID.Size = new System.Drawing.Size(52, 22);
            this.blockID.TabIndex = 8;
            this.blockID.ValueChanged += new System.EventHandler(this.blockID_ValueChanged);
            // 
            // ChunkID
            // 
            this.ChunkID.Hexadecimal = true;
            this.ChunkID.Location = new System.Drawing.Point(135, 426);
            this.ChunkID.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ChunkID.Name = "ChunkID";
            this.ChunkID.Size = new System.Drawing.Size(52, 22);
            this.ChunkID.TabIndex = 9;
            this.ChunkID.ValueChanged += new System.EventHandler(this.ChunkID_ValueChanged);
            // 
            // paleteLine
            // 
            this.paleteLine.Hexadecimal = true;
            this.paleteLine.Location = new System.Drawing.Point(500, 372);
            this.paleteLine.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.paleteLine.Name = "paleteLine";
            this.paleteLine.Size = new System.Drawing.Size(52, 22);
            this.paleteLine.TabIndex = 10;
            this.paleteLine.ValueChanged += new System.EventHandler(this.paleteLine_ValueChanged);
            // 
            // loadPal
            // 
            this.loadPal.Location = new System.Drawing.Point(413, 54);
            this.loadPal.Name = "loadPal";
            this.loadPal.Size = new System.Drawing.Size(195, 23);
            this.loadPal.TabIndex = 11;
            this.loadPal.Text = "Select pallet";
            this.loadPal.UseVisualStyleBackColor = true;
            this.loadPal.Click += new System.EventHandler(this.loadPal_Click);
            // 
            // tileID
            // 
            this.tileID.Hexadecimal = true;
            this.tileID.Location = new System.Drawing.Point(413, 452);
            this.tileID.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tileID.Name = "tileID";
            this.tileID.Size = new System.Drawing.Size(52, 22);
            this.tileID.TabIndex = 13;
            this.tileID.ValueChanged += new System.EventHandler(this.tileID_ValueChanged);
            // 
            // blockHflip
            // 
            this.blockHflip.AutoSize = true;
            this.blockHflip.Location = new System.Drawing.Point(568, 266);
            this.blockHflip.Name = "blockHflip";
            this.blockHflip.Size = new System.Drawing.Size(56, 20);
            this.blockHflip.TabIndex = 14;
            this.blockHflip.Text = "Hflip";
            this.blockHflip.UseVisualStyleBackColor = true;
            this.blockHflip.CheckedChanged += new System.EventHandler(this.blockHflip_CheckedChanged);
            // 
            // blockVflip
            // 
            this.blockVflip.AutoSize = true;
            this.blockVflip.Location = new System.Drawing.Point(568, 292);
            this.blockVflip.Name = "blockVflip";
            this.blockVflip.Size = new System.Drawing.Size(55, 20);
            this.blockVflip.TabIndex = 15;
            this.blockVflip.Text = "Vfilp";
            this.blockVflip.UseVisualStyleBackColor = true;
            this.blockVflip.CheckedChanged += new System.EventHandler(this.blockVflip_CheckedChanged);
            // 
            // chunkHflip
            // 
            this.chunkHflip.AutoSize = true;
            this.chunkHflip.Location = new System.Drawing.Point(12, 428);
            this.chunkHflip.Name = "chunkHflip";
            this.chunkHflip.Size = new System.Drawing.Size(56, 20);
            this.chunkHflip.TabIndex = 16;
            this.chunkHflip.Text = "Hflip";
            this.chunkHflip.UseVisualStyleBackColor = true;
            this.chunkHflip.CheckedChanged += new System.EventHandler(this.chunkHflip_CheckedChanged);
            // 
            // chunkVflip
            // 
            this.chunkVflip.AutoSize = true;
            this.chunkVflip.Location = new System.Drawing.Point(74, 428);
            this.chunkVflip.Name = "chunkVflip";
            this.chunkVflip.Size = new System.Drawing.Size(55, 20);
            this.chunkVflip.TabIndex = 17;
            this.chunkVflip.Text = "Vfilp";
            this.chunkVflip.UseVisualStyleBackColor = true;
            this.chunkVflip.CheckedChanged += new System.EventHandler(this.chunkVflip_CheckedChanged);
            // 
            // saveChunk
            // 
            this.saveChunk.Location = new System.Drawing.Point(206, 425);
            this.saveChunk.Name = "saveChunk";
            this.saveChunk.Size = new System.Drawing.Size(134, 23);
            this.saveChunk.TabIndex = 18;
            this.saveChunk.Text = "save chunk as bmp";
            this.saveChunk.UseVisualStyleBackColor = true;
            // 
            // saveTile
            // 
            this.saveTile.Location = new System.Drawing.Point(471, 452);
            this.saveTile.Name = "saveTile";
            this.saveTile.Size = new System.Drawing.Size(116, 23);
            this.saveTile.TabIndex = 19;
            this.saveTile.Text = "save tile as bmp";
            this.saveTile.UseVisualStyleBackColor = true;
            // 
            // saveBlock
            // 
            this.saveBlock.Location = new System.Drawing.Point(460, 318);
            this.saveBlock.Name = "saveBlock";
            this.saveBlock.Size = new System.Drawing.Size(148, 23);
            this.saveBlock.TabIndex = 20;
            this.saveBlock.Text = "save block as bmp";
            this.saveBlock.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 493);
            this.Controls.Add(this.saveBlock);
            this.Controls.Add(this.saveTile);
            this.Controls.Add(this.saveChunk);
            this.Controls.Add(this.chunkVflip);
            this.Controls.Add(this.chunkHflip);
            this.Controls.Add(this.blockVflip);
            this.Controls.Add(this.blockHflip);
            this.Controls.Add(this.tileID);
            this.Controls.Add(this.loadPal);
            this.Controls.Add(this.paleteLine);
            this.Controls.Add(this.ChunkID);
            this.Controls.Add(this.blockID);
            this.Controls.Add(this.loadChunk);
            this.Controls.Add(this.loadBlock);
            this.Controls.Add(this.tileVflip);
            this.Controls.Add(this.tileHflip);
            this.Controls.Add(this.currentBlock);
            this.Controls.Add(this.currentTile);
            this.Controls.Add(this.currentChunk);
            this.Controls.Add(this.loadArt);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.currentChunk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentTile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentBlock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blockID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChunkID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paleteLine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileID)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button loadArt;
        public System.Windows.Forms.PictureBox currentChunk;
        public System.Windows.Forms.PictureBox currentTile;
        public System.Windows.Forms.PictureBox currentBlock;
        private System.Windows.Forms.CheckBox tileHflip;
        private System.Windows.Forms.CheckBox tileVflip;
        private System.Windows.Forms.Button loadBlock;
        private System.Windows.Forms.Button loadChunk;
        private System.Windows.Forms.NumericUpDown blockID;
        private System.Windows.Forms.NumericUpDown ChunkID;
        private System.Windows.Forms.Button loadPal;
        private System.Windows.Forms.NumericUpDown tileID;
        private System.Windows.Forms.CheckBox blockHflip;
        private System.Windows.Forms.CheckBox blockVflip;
        private System.Windows.Forms.CheckBox chunkHflip;
        private System.Windows.Forms.CheckBox chunkVflip;
        private System.Windows.Forms.Button saveChunk;
        private System.Windows.Forms.Button saveTile;
        private System.Windows.Forms.Button saveBlock;
        public System.Windows.Forms.NumericUpDown paleteLine;
    }
}

