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
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // picture
            // 
            picture.Location = new Point(12, 12);
            picture.Name = "picture";
            picture.Size = new Size(640, 360);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabIndex = 0;
            picture.TabStop = false;
            // 
            // next
            // 
            next.Location = new Point(539, 546);
            next.Name = "next";
            next.Size = new Size(111, 23);
            next.TabIndex = 2;
            next.Text = "Next";
            next.UseVisualStyleBackColor = true;
            next.Click += next_Click;
            // 
            // nextUnannotate
            // 
            nextUnannotate.Location = new Point(539, 517);
            nextUnannotate.Name = "nextUnannotate";
            nextUnannotate.Size = new Size(111, 23);
            nextUnannotate.TabIndex = 3;
            nextUnannotate.Text = "NextUnannotate";
            nextUnannotate.UseVisualStyleBackColor = true;
            nextUnannotate.Click += nextUnannotate_Click;
            // 
            // prevUnannotate
            // 
            prevUnannotate.Location = new Point(12, 517);
            prevUnannotate.Name = "prevUnannotate";
            prevUnannotate.Size = new Size(111, 23);
            prevUnannotate.TabIndex = 5;
            prevUnannotate.Text = "PrevUnannotate";
            prevUnannotate.UseVisualStyleBackColor = true;
            prevUnannotate.Click += prevUnannotate_Click;
            // 
            // prev
            // 
            prev.Location = new Point(12, 546);
            prev.Name = "prev";
            prev.Size = new Size(111, 23);
            prev.TabIndex = 6;
            prev.Text = "Prev";
            prev.UseVisualStyleBackColor = true;
            prev.Click += prev_Click;
            // 
            // save
            // 
            save.Location = new Point(275, 517);
            save.Name = "save";
            save.Size = new Size(111, 23);
            save.TabIndex = 7;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // export
            // 
            export.Location = new Point(275, 546);
            export.Name = "export";
            export.Size = new Size(111, 23);
            export.TabIndex = 8;
            export.Text = "Export";
            export.UseVisualStyleBackColor = true;
            export.Click += export_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            ClientSize = new Size(662, 581);
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
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
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
    }
}
