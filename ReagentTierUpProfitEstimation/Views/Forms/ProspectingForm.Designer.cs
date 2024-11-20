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
            ThaumaturgyInput = new RichTextBox();
            thaumaturgyInputBtn = new Button();
            prospectDataGridView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)prospectDataGridView).BeginInit();
            SuspendLayout();
            // 
            // ThaumaturgyInput
            // 
            ThaumaturgyInput.BackColor = SystemColors.ControlDark;
            ThaumaturgyInput.Location = new Point(12, 39);
            ThaumaturgyInput.Name = "ThaumaturgyInput";
            ThaumaturgyInput.Size = new Size(242, 373);
            ThaumaturgyInput.TabIndex = 1;
            ThaumaturgyInput.Text = "";
            // 
            // thaumaturgyInputBtn
            // 
            thaumaturgyInputBtn.Location = new Point(444, 430);
            thaumaturgyInputBtn.Name = "thaumaturgyInputBtn";
            thaumaturgyInputBtn.Size = new Size(75, 23);
            thaumaturgyInputBtn.TabIndex = 2;
            thaumaturgyInputBtn.Text = "button1";
            thaumaturgyInputBtn.UseVisualStyleBackColor = true;
            thaumaturgyInputBtn.Click += thaumaturgyInputButton_Click;
            // 
            // prospectDataGridView
            // 
            prospectDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            prospectDataGridView.Location = new Point(369, 39);
            prospectDataGridView.Name = "prospectDataGridView";
            prospectDataGridView.Size = new Size(420, 373);
            prospectDataGridView.TabIndex = 3;
            // 
            // ProspectingForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(956, 480);
            Controls.Add(prospectDataGridView);
            Controls.Add(thaumaturgyInputBtn);
            Controls.Add(ThaumaturgyInput);
            Name = "ProspectingForm";
            Text = "Prospecting";
            ((System.ComponentModel.ISupportInitialize)prospectDataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox ThaumaturgyInput;
        private Button thaumaturgyInputBtn;
        private DataGridView prospectDataGridView;
    }
}