namespace Shabat.forms
{
    partial class HomePage
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
            listView1 = new ListView();
            textBox_add = new TextBox();
            button_Add = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(189, 246);
            listView1.Name = "listView1";
            listView1.Size = new Size(388, 182);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // textBox_add
            // 
            textBox_add.Location = new Point(246, 156);
            textBox_add.Name = "textBox_add";
            textBox_add.Size = new Size(277, 27);
            textBox_add.TabIndex = 1;
            // 
            // button_Add
            // 
            button_Add.Location = new Point(332, 189);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(94, 29);
            button_Add.TabIndex = 2;
            button_Add.Text = "Add";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(332, 109);
            label1.Name = "label1";
            label1.Size = new Size(98, 20);
            label1.TabIndex = 3;
            label1.Text = "new category";
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 486);
            Controls.Add(label1);
            Controls.Add(button_Add);
            Controls.Add(textBox_add);
            Controls.Add(listView1);
            Name = "HomePage";
            Text = "HomePage";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private TextBox textBox_add;
        private Button button_Add;
        private Label label1;
    }
}