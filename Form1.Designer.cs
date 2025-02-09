namespace MyPic_Annotator
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
			picture = new PictureBox();
			next = new Button();
			nextUnannotate = new Button();
			prevUnannotate = new Button();
			prev = new Button();
			save = new Button();
			export = new Button();
			subtitleLabel = new Label();
			frameLabel = new Label();
			anotateStatus = new Label();
			numericUpDown1 = new NumericUpDown();
			((System.ComponentModel.ISupportInitialize)picture).BeginInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
			SuspendLayout();
			// 
			// picture
			// 
			picture.Dock = DockStyle.Top;
			picture.Location = new Point(0, 0);
			picture.Name = "picture";
			picture.Size = new Size(662, 360);
			picture.SizeMode = PictureBoxSizeMode.Zoom;
			picture.TabIndex = 0;
			picture.TabStop = false;
			// 
			// next
			// 
			next.Location = new Point(512, 546);
			next.Name = "next";
			next.Size = new Size(138, 23);
			next.TabIndex = 2;
			next.Text = "Next (L)";
			next.UseVisualStyleBackColor = true;
			next.Click += next_Click;
			// 
			// nextUnannotate
			// 
			nextUnannotate.Location = new Point(512, 517);
			nextUnannotate.Name = "nextUnannotate";
			nextUnannotate.Size = new Size(138, 23);
			nextUnannotate.TabIndex = 3;
			nextUnannotate.Text = "NextUnannotate (O)";
			nextUnannotate.UseVisualStyleBackColor = true;
			nextUnannotate.Click += nextUnannotate_Click;
			// 
			// prevUnannotate
			// 
			prevUnannotate.Location = new Point(12, 517);
			prevUnannotate.Name = "prevUnannotate";
			prevUnannotate.Size = new Size(138, 23);
			prevUnannotate.TabIndex = 5;
			prevUnannotate.Text = "PrevUnannotate (U)";
			prevUnannotate.UseVisualStyleBackColor = true;
			prevUnannotate.Click += prevUnannotate_Click;
			// 
			// prev
			// 
			prev.Location = new Point(12, 546);
			prev.Name = "prev";
			prev.Size = new Size(138, 23);
			prev.TabIndex = 6;
			prev.Text = "Prev (J)";
			prev.UseVisualStyleBackColor = true;
			prev.Click += prev_Click;
			// 
			// save
			// 
			save.Location = new Point(275, 517);
			save.Name = "save";
			save.Size = new Size(138, 23);
			save.TabIndex = 7;
			save.Text = "Save (Enter)";
			save.UseVisualStyleBackColor = true;
			save.Click += save_Click;
			// 
			// export
			// 
			export.Location = new Point(275, 546);
			export.Name = "export";
			export.Size = new Size(138, 23);
			export.TabIndex = 8;
			export.Text = "Export";
			export.UseVisualStyleBackColor = true;
			export.Click += export_Click;
			// 
			// subtitleLabel
			// 
			subtitleLabel.Anchor = AnchorStyles.Top;
			subtitleLabel.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
			subtitleLabel.Location = new Point(0, 368);
			subtitleLabel.Name = "subtitleLabel";
			subtitleLabel.Size = new Size(662, 20);
			subtitleLabel.TabIndex = 10;
			subtitleLabel.Text = "subtitleLabel";
			subtitleLabel.TextAlign = ContentAlignment.TopCenter;
			// 
			// frameLabel
			// 
			frameLabel.AutoSize = true;
			frameLabel.Location = new Point(399, 423);
			frameLabel.Name = "frameLabel";
			frameLabel.Size = new Size(77, 15);
			frameLabel.TabIndex = 12;
			frameLabel.Text = "(<)frame(>):";
			// 
			// anotateStatus
			// 
			anotateStatus.AutoSize = true;
			anotateStatus.Font = new Font("Microsoft JhengHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 136);
			anotateStatus.Location = new Point(292, 458);
			anotateStatus.Name = "anotateStatus";
			anotateStatus.Size = new Size(115, 20);
			anotateStatus.TabIndex = 13;
			anotateStatus.Text = "anotateStatus";
			// 
			// numericUpDown1
			// 
			numericUpDown1.Location = new Point(482, 421);
			numericUpDown1.Maximum = new decimal(new int[] { 130000, 0, 0, 0 });
			numericUpDown1.Name = "numericUpDown1";
			numericUpDown1.Size = new Size(120, 23);
			numericUpDown1.TabIndex = 14;
			numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			AutoSize = true;
			ClientSize = new Size(662, 581);
			Controls.Add(numericUpDown1);
			Controls.Add(anotateStatus);
			Controls.Add(frameLabel);
			Controls.Add(subtitleLabel);
			Controls.Add(export);
			Controls.Add(save);
			Controls.Add(prev);
			Controls.Add(prevUnannotate);
			Controls.Add(nextUnannotate);
			Controls.Add(next);
			Controls.Add(picture);
			FormBorderStyle = FormBorderStyle.FixedDialog;
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "Form1";
			Text = "Anontator";
			FormClosing += Form1_FormClosing;
			Load += Form1_Load;
			KeyDown += Form1_KeyDown;
			((System.ComponentModel.ISupportInitialize)picture).EndInit();
			((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private PictureBox picture;
		private Button button1;
		private Button next;
		private Button nextUnannotate;
		private Button prevUnannotate;
		private Button prev;
		private Button save;
		private Button export;
		private Label subtitleLabel;
		private Label frameLabel;
		private Label anotateStatus;
		private NumericUpDown numericUpDown1;
	}
}
