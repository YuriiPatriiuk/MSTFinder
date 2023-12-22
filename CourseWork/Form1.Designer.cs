namespace CourseWork
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mouseButton = new System.Windows.Forms.ToolStripMenuItem();
            this.vertexButton = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteButton = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.solvingsComboBox = new System.Windows.Forms.ComboBox();
            this.solveButton = new System.Windows.Forms.Button();
            this.listBoxWeightMatrix = new System.Windows.Forms.ListBox();
            this.speedTrackBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.saveResultButton = new System.Windows.Forms.Button();
            this.weightLabel = new System.Windows.Forms.Label();
            this.comparisonLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.Location = new System.Drawing.Point(12, 82);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(608, 584);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mouseButton,
            this.vertexButton,
            this.edgeButton,
            this.deleteButton,
            this.clearButton});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1063, 78);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mouseButton
            // 
            this.mouseButton.Image = ((System.Drawing.Image)(resources.GetObject("mouseButton.Image")));
            this.mouseButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mouseButton.Name = "mouseButton";
            this.mouseButton.Size = new System.Drawing.Size(65, 74);
            this.mouseButton.Text = "Миша";
            this.mouseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mouseButton.Click += new System.EventHandler(this.mouseButton_Click);
            // 
            // vertexButton
            // 
            this.vertexButton.Image = ((System.Drawing.Image)(resources.GetObject("vertexButton.Image")));
            this.vertexButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vertexButton.Name = "vertexButton";
            this.vertexButton.Size = new System.Drawing.Size(87, 74);
            this.vertexButton.Text = "Вершина";
            this.vertexButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.vertexButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.vertexButton.Click += new System.EventHandler(this.vertexButton_Click);
            // 
            // edgeButton
            // 
            this.edgeButton.Image = ((System.Drawing.Image)(resources.GetObject("edgeButton.Image")));
            this.edgeButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.edgeButton.Name = "edgeButton";
            this.edgeButton.Size = new System.Drawing.Size(66, 74);
            this.edgeButton.Text = "Ребро";
            this.edgeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.edgeButton.Click += new System.EventHandler(this.edgeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(89, 74);
            this.deleteButton.Text = "Видалити";
            this.deleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Image = ((System.Drawing.Image)(resources.GetObject("clearButton.Image")));
            this.clearButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(88, 74);
            this.clearButton.Text = "Очистити";
            this.clearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // solvingsComboBox
            // 
            this.solvingsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.solvingsComboBox.FormattingEnabled = true;
            this.solvingsComboBox.Location = new System.Drawing.Point(640, 481);
            this.solvingsComboBox.MaxDropDownItems = 3;
            this.solvingsComboBox.Name = "solvingsComboBox";
            this.solvingsComboBox.Size = new System.Drawing.Size(210, 28);
            this.solvingsComboBox.TabIndex = 2;
            // 
            // solveButton
            // 
            this.solveButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.solveButton.Location = new System.Drawing.Point(903, 457);
            this.solveButton.Name = "solveButton";
            this.solveButton.Size = new System.Drawing.Size(148, 67);
            this.solveButton.TabIndex = 3;
            this.solveButton.Text = "Вирішити";
            this.solveButton.UseVisualStyleBackColor = true;
            this.solveButton.Click += new System.EventHandler(this.solveButton_Click);
            // 
            // listBoxWeightMatrix
            // 
            this.listBoxWeightMatrix.FormattingEnabled = true;
            this.listBoxWeightMatrix.ItemHeight = 20;
            this.listBoxWeightMatrix.Location = new System.Drawing.Point(640, 87);
            this.listBoxWeightMatrix.Name = "listBoxWeightMatrix";
            this.listBoxWeightMatrix.Size = new System.Drawing.Size(411, 284);
            this.listBoxWeightMatrix.TabIndex = 4;
            // 
            // speedTrackBar
            // 
            this.speedTrackBar.Location = new System.Drawing.Point(772, 399);
            this.speedTrackBar.Maximum = 1;
            this.speedTrackBar.Minimum = 1;
            this.speedTrackBar.Name = "speedTrackBar";
            this.speedTrackBar.Size = new System.Drawing.Size(279, 56);
            this.speedTrackBar.TabIndex = 5;
            this.speedTrackBar.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(640, 399);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 32);
            this.label1.TabIndex = 6;
            this.label1.Text = "Швидкість:";
            // 
            // saveResultButton
            // 
            this.saveResultButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveResultButton.Location = new System.Drawing.Point(785, 601);
            this.saveResultButton.Name = "saveResultButton";
            this.saveResultButton.Size = new System.Drawing.Size(148, 59);
            this.saveResultButton.TabIndex = 7;
            this.saveResultButton.Text = "Зберегти";
            this.saveResultButton.UseVisualStyleBackColor = true;
            this.saveResultButton.Click += new System.EventHandler(this.saveResultButton_Click);
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.weightLabel.Location = new System.Drawing.Point(640, 552);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(119, 30);
            this.weightLabel.TabIndex = 8;
            this.weightLabel.Text = "Вага МОД:";
            this.weightLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // comparisonLabel
            // 
            this.comparisonLabel.AutoSize = true;
            this.comparisonLabel.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comparisonLabel.Location = new System.Drawing.Point(861, 552);
            this.comparisonLabel.Name = "comparisonLabel";
            this.comparisonLabel.Size = new System.Drawing.Size(125, 30);
            this.comparisonLabel.TabIndex = 9;
            this.comparisonLabel.Text = "Порівнянь:";
            this.comparisonLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1063, 683);
            this.Controls.Add(this.comparisonLabel);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.saveResultButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedTrackBar);
            this.Controls.Add(this.listBoxWeightMatrix);
            this.Controls.Add(this.solveButton);
            this.Controls.Add(this.solvingsComboBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1081, 730);
            this.MinimumSize = new System.Drawing.Size(1081, 730);
            this.Name = "Form1";
            this.Text = "Minimum Spanning Tree";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mouseButton;
        private ToolStripMenuItem vertexButton;
        private ToolStripMenuItem edgeButton;
        private ToolStripMenuItem deleteButton;
        private ToolStripMenuItem clearButton;
        private ComboBox solvingsComboBox;
        private Button solveButton;
        private ListBox listBoxWeightMatrix;
        private TrackBar speedTrackBar;
        private Label label1;
        private Button saveResultButton;
        private Label weightLabel;
        private Label comparisonLabel;
    }
}