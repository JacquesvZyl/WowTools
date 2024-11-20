namespace WoWTools.Views.Forms
{
    partial class Startup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            flowLayoutPanel1 = new FlowLayoutPanel();
            refinementbtn = new Button();
            prospectingBtn = new Button();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.None;
            flowLayoutPanel1.AutoSize = true;
            flowLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(refinementbtn);
            flowLayoutPanel1.Controls.Add(prospectingBtn);
            flowLayoutPanel1.Location = new Point(126, 273);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(284, 61);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // refinementbtn
            // 
            refinementbtn.BackColor = Color.DarkOrange;
            refinementbtn.Cursor = Cursors.Hand;
            refinementbtn.FlatAppearance.BorderColor = Color.Black;
            refinementbtn.FlatAppearance.BorderSize = 2;
            refinementbtn.FlatStyle = FlatStyle.Flat;
            refinementbtn.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refinementbtn.Location = new Point(3, 3);
            refinementbtn.Name = "refinementbtn";
            refinementbtn.Size = new Size(129, 55);
            refinementbtn.TabIndex = 1;
            refinementbtn.Text = "Reagent Refinement";
            refinementbtn.UseVisualStyleBackColor = false;
            refinementbtn.Click += refinementbtn_Click;
            // 
            // prospectingBtn
            // 
            prospectingBtn.BackColor = Color.DarkOrange;
            prospectingBtn.Cursor = Cursors.No;
            prospectingBtn.FlatAppearance.BorderColor = Color.Black;
            prospectingBtn.FlatAppearance.BorderSize = 2;
            prospectingBtn.FlatStyle = FlatStyle.Flat;
            prospectingBtn.Location = new Point(138, 3);
            prospectingBtn.Name = "prospectingBtn";
            prospectingBtn.Size = new Size(143, 55);
            prospectingBtn.TabIndex = 0;
            prospectingBtn.Text = "Prospecting";
            prospectingBtn.UseVisualStyleBackColor = false;
            prospectingBtn.Click += thaumaturgyBtn_Click;
            // 
            // Startup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(569, 506);
            Controls.Add(flowLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Startup";
            Text = "WoWTools";
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Button refinementbtn;
        private Button thaumaturgyBtn;
        private Button prospectingBtn;
    }
}