namespace ReagentTierUpProfitEstimation
{
    partial class RefinementForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RefinementForm));
            MainInputTextbox = new RichTextBox();
            MainInputLabel = new Label();
            MainInputButton = new Button();
            resultsViewAfter = new DataGridView();
            resultViewBefore = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)resultsViewAfter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultViewBefore).BeginInit();
            SuspendLayout();
            // 
            // MainInputTextbox
            // 
            MainInputTextbox.Location = new Point(12, 75);
            MainInputTextbox.Name = "MainInputTextbox";
            MainInputTextbox.Size = new Size(242, 373);
            MainInputTextbox.TabIndex = 0;
            MainInputTextbox.Text = "";
            MainInputTextbox.TextChanged += MainInputTextbox_TextChanged;
            // 
            // MainInputLabel
            // 
            MainInputLabel.AutoSize = true;
            MainInputLabel.Location = new Point(12, 48);
            MainInputLabel.Name = "MainInputLabel";
            MainInputLabel.Size = new Size(225, 15);
            MainInputLabel.TabIndex = 1;
            MainInputLabel.Text = "Copy export result from Auctionator here";
            MainInputLabel.Click += label1_Click;
            // 
            // MainInputButton
            // 
            MainInputButton.Location = new Point(560, 480);
            MainInputButton.Name = "MainInputButton";
            MainInputButton.Size = new Size(153, 23);
            MainInputButton.TabIndex = 2;
            MainInputButton.Text = "Show me the money";
            MainInputButton.UseVisualStyleBackColor = true;
            MainInputButton.Click += button1_Click;
            // 
            // resultsViewAfter
            // 
            resultsViewAfter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsViewAfter.Location = new Point(751, 75);
            resultsViewAfter.Name = "resultsViewAfter";
            resultsViewAfter.Size = new Size(427, 373);
            resultsViewAfter.TabIndex = 3;
            resultsViewAfter.CellContentClick += Results_CellContentClick;
            // 
            // resultViewBefore
            // 
            resultViewBefore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultViewBefore.Location = new Point(286, 75);
            resultViewBefore.Name = "resultViewBefore";
            resultViewBefore.Size = new Size(427, 373);
            resultViewBefore.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(422, 48);
            label1.Name = "label1";
            label1.Size = new Size(170, 15);
            label1.TabIndex = 5;
            label1.Text = "Profit before Auctionhouse cut";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(869, 48);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 6;
            label2.Text = "Profit after Auctionhouse cut";
            label2.Click += label2_Click;
            // 
            // RefinementForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1195, 515);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(resultViewBefore);
            Controls.Add(resultsViewAfter);
            Controls.Add(MainInputButton);
            Controls.Add(MainInputLabel);
            Controls.Add(MainInputTextbox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RefinementForm";
            Text = "Profit Estimation";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)resultsViewAfter).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultViewBefore).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox MainInputTextbox;
        private Label MainInputLabel;
        private Button MainInputButton;
        private DataGridView resultsViewAfter;
        private DataGridView resultViewBefore;
        private Label label1;
        private Label label2;
    }
}