namespace WoWTools.Views.Forms
{
    partial class ProspectingForm
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
            prospectingInput = new RichTextBox();
            prospectingInputBtn = new Button();
            prospectDataGridView = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            ProspectingLink = new LinkLabel();
            ((System.ComponentModel.ISupportInitialize)prospectDataGridView).BeginInit();
            SuspendLayout();
            // 
            // prospectingInput
            // 
            prospectingInput.BackColor = SystemColors.ControlDark;
            prospectingInput.Location = new Point(12, 58);
            prospectingInput.Name = "prospectingInput";
            prospectingInput.Size = new Size(348, 247);
            prospectingInput.TabIndex = 1;
            prospectingInput.Text = "";
            // 
            // prospectingInputBtn
            // 
            prospectingInputBtn.BackColor = Color.DarkOrange;
            prospectingInputBtn.FlatStyle = FlatStyle.Flat;
            prospectingInputBtn.Location = new Point(327, 338);
            prospectingInputBtn.Name = "prospectingInputBtn";
            prospectingInputBtn.Size = new Size(75, 23);
            prospectingInputBtn.TabIndex = 2;
            prospectingInputBtn.Text = "Generate";
            prospectingInputBtn.UseVisualStyleBackColor = false;
            prospectingInputBtn.Click += prospectingInputBtn_Click;
            // 
            // prospectDataGridView
            // 
            prospectDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            prospectDataGridView.Location = new Point(378, 58);
            prospectDataGridView.Name = "prospectDataGridView";
            prospectDataGridView.Size = new Size(420, 247);
            prospectDataGridView.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(225, 15);
            label1.TabIndex = 4;
            label1.Text = "Copy export result from Auctionator here";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(378, 31);
            label2.Name = "label2";
            label2.Size = new Size(160, 15);
            label2.TabIndex = 5;
            label2.Text = "Profit after Auctionhouse cut";
            // 
            // ProspectingLink
            // 
            ProspectingLink.AutoSize = true;
            ProspectingLink.Location = new Point(558, 378);
            ProspectingLink.Name = "ProspectingLink";
            ProspectingLink.Size = new Size(240, 15);
            ProspectingLink.TabIndex = 6;
            ProspectingLink.TabStop = true;
            ProspectingLink.Text = "Get string for Auctioneer Shopping List Here";
            ProspectingLink.LinkClicked += ProspectingLink_LinkClicked;
            // 
            // ProspectingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(810, 402);
            Controls.Add(ProspectingLink);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(prospectDataGridView);
            Controls.Add(prospectingInputBtn);
            Controls.Add(prospectingInput);
            Name = "ProspectingForm";
            Text = "Prospecting";
            ((System.ComponentModel.ISupportInitialize)prospectDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox prospectingInput;
        private Button prospectingInputBtn;
        private DataGridView prospectDataGridView;
        private Label label1;
        private Label label2;
        private LinkLabel ProspectingLink;
    }
}