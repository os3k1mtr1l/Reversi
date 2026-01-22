namespace Reversi
{
    partial class Settings
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
            radio_switch_false = new RadioButton();
            radio_switch_true = new RadioButton();
            difficulty_group = new GroupBox();
            difficulty_radio_3 = new RadioButton();
            difficulty_radio_2 = new RadioButton();
            difficulty_radio_1 = new RadioButton();
            mode_group = new GroupBox();
            accept_button = new Button();
            cancel_button = new Button();
            difficulty_group.SuspendLayout();
            mode_group.SuspendLayout();
            SuspendLayout();
            // 
            // radio_switch_false
            // 
            radio_switch_false.AutoSize = true;
            radio_switch_false.Location = new Point(27, 37);
            radio_switch_false.Name = "radio_switch_false";
            radio_switch_false.Size = new Size(45, 19);
            radio_switch_false.TabIndex = 0;
            radio_switch_false.Text = "PvP";
            radio_switch_false.UseVisualStyleBackColor = true;
            radio_switch_false.CheckedChanged += radio_switch_false_CheckedChanged;
            // 
            // radio_switch_true
            // 
            radio_switch_true.AutoSize = true;
            radio_switch_true.Location = new Point(27, 90);
            radio_switch_true.Name = "radio_switch_true";
            radio_switch_true.Size = new Size(44, 19);
            radio_switch_true.TabIndex = 1;
            radio_switch_true.Text = "PvE";
            radio_switch_true.UseVisualStyleBackColor = true;
            radio_switch_true.CheckedChanged += radio_switch_true_CheckedChanged;
            // 
            // difficulty_group
            // 
            difficulty_group.BackColor = SystemColors.ControlDark;
            difficulty_group.Controls.Add(difficulty_radio_3);
            difficulty_group.Controls.Add(difficulty_radio_2);
            difficulty_group.Controls.Add(difficulty_radio_1);
            difficulty_group.Enabled = false;
            difficulty_group.Location = new Point(140, 12);
            difficulty_group.Name = "difficulty_group";
            difficulty_group.Size = new Size(111, 154);
            difficulty_group.TabIndex = 2;
            difficulty_group.TabStop = false;
            difficulty_group.Text = "Difficulty";
            // 
            // difficulty_radio_3
            // 
            difficulty_radio_3.AutoSize = true;
            difficulty_radio_3.Location = new Point(11, 112);
            difficulty_radio_3.Name = "difficulty_radio_3";
            difficulty_radio_3.Size = new Size(78, 19);
            difficulty_radio_3.TabIndex = 2;
            difficulty_radio_3.Text = "Advanced";
            difficulty_radio_3.UseVisualStyleBackColor = true;
            // 
            // difficulty_radio_2
            // 
            difficulty_radio_2.AutoSize = true;
            difficulty_radio_2.Location = new Point(11, 67);
            difficulty_radio_2.Name = "difficulty_radio_2";
            difficulty_radio_2.Size = new Size(72, 19);
            difficulty_radio_2.TabIndex = 1;
            difficulty_radio_2.Text = "Standard";
            difficulty_radio_2.UseVisualStyleBackColor = true;
            // 
            // difficulty_radio_1
            // 
            difficulty_radio_1.AutoSize = true;
            difficulty_radio_1.Location = new Point(11, 22);
            difficulty_radio_1.Name = "difficulty_radio_1";
            difficulty_radio_1.Size = new Size(72, 19);
            difficulty_radio_1.TabIndex = 0;
            difficulty_radio_1.Text = "Begginer";
            difficulty_radio_1.UseVisualStyleBackColor = true;
            // 
            // mode_group
            // 
            mode_group.BackColor = SystemColors.ControlDark;
            mode_group.Controls.Add(radio_switch_false);
            mode_group.Controls.Add(radio_switch_true);
            mode_group.Location = new Point(12, 12);
            mode_group.Name = "mode_group";
            mode_group.Size = new Size(98, 154);
            mode_group.TabIndex = 3;
            mode_group.TabStop = false;
            mode_group.Text = "Mode";
            // 
            // accept_button
            // 
            accept_button.BackColor = Color.Green;
            accept_button.BackgroundImage = Properties.Resources.settings;
            accept_button.BackgroundImageLayout = ImageLayout.None;
            accept_button.FlatAppearance.BorderColor = Color.Black;
            accept_button.FlatStyle = FlatStyle.Flat;
            accept_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            accept_button.ForeColor = Color.White;
            accept_button.ImageAlign = ContentAlignment.BottomLeft;
            accept_button.Location = new Point(140, 180);
            accept_button.Name = "accept_button";
            accept_button.Size = new Size(120, 30);
            accept_button.TabIndex = 6;
            accept_button.Text = "Submit";
            accept_button.TextAlign = ContentAlignment.TopRight;
            accept_button.UseVisualStyleBackColor = false;
            accept_button.Click += accept_button_Click;
            // 
            // cancel_button
            // 
            cancel_button.BackColor = Color.Maroon;
            cancel_button.BackgroundImage = Properties.Resources.settings;
            cancel_button.BackgroundImageLayout = ImageLayout.None;
            cancel_button.FlatAppearance.BorderColor = Color.Black;
            cancel_button.FlatStyle = FlatStyle.Flat;
            cancel_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            cancel_button.ForeColor = Color.White;
            cancel_button.ImageAlign = ContentAlignment.BottomLeft;
            cancel_button.Location = new Point(12, 180);
            cancel_button.Name = "cancel_button";
            cancel_button.Size = new Size(120, 30);
            cancel_button.TabIndex = 7;
            cancel_button.Text = "Cancel";
            cancel_button.TextAlign = ContentAlignment.TopRight;
            cancel_button.UseVisualStyleBackColor = false;
            cancel_button.Click += cancel_button_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(274, 221);
            Controls.Add(cancel_button);
            Controls.Add(accept_button);
            Controls.Add(mode_group);
            Controls.Add(difficulty_group);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            difficulty_group.ResumeLayout(false);
            difficulty_group.PerformLayout();
            mode_group.ResumeLayout(false);
            mode_group.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton radio_switch_false;
        private RadioButton radio_switch_true;
        private GroupBox difficulty_group;
        private GroupBox mode_group;
        private Button accept_button;
        private Button cancel_button;
        private RadioButton difficulty_radio_3;
        private RadioButton difficulty_radio_2;
        private RadioButton difficulty_radio_1;
    }
}