namespace Reversi
{
    partial class Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Window));
            play_zone = new Panel();
            control_bar = new Panel();
            score_text = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            turn_text_background = new Panel();
            turn_indendification = new Label();
            settings_button = new Button();
            reset_button = new Button();
            control_bar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            turn_text_background.SuspendLayout();
            SuspendLayout();
            // 
            // play_zone
            // 
            play_zone.BackColor = SystemColors.ScrollBar;
            play_zone.Location = new Point(0, 50);
            play_zone.Name = "play_zone";
            play_zone.Size = new Size(800, 800);
            play_zone.TabIndex = 0;
            // 
            // control_bar
            // 
            control_bar.BackColor = SystemColors.WindowFrame;
            control_bar.BorderStyle = BorderStyle.FixedSingle;
            control_bar.Controls.Add(score_text);
            control_bar.Controls.Add(pictureBox2);
            control_bar.Controls.Add(pictureBox1);
            control_bar.Controls.Add(turn_text_background);
            control_bar.Controls.Add(settings_button);
            control_bar.Controls.Add(reset_button);
            control_bar.Location = new Point(0, 0);
            control_bar.Name = "control_bar";
            control_bar.Size = new Size(800, 50);
            control_bar.TabIndex = 1;
            // 
            // score_text
            // 
            score_text.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            score_text.ForeColor = Color.White;
            score_text.Location = new Point(358, 12);
            score_text.Name = "score_text";
            score_text.Size = new Size(82, 25);
            score_text.TabIndex = 5;
            score_text.Text = "NN : NN";
            score_text.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.black;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.InitialImage = Properties.Resources.black;
            pictureBox2.Location = new Point(450, -1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.white;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.InitialImage = Properties.Resources.white;
            pictureBox1.Location = new Point(300, -1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // turn_text_background
            // 
            turn_text_background.BackColor = SystemColors.Window;
            turn_text_background.BorderStyle = BorderStyle.Fixed3D;
            turn_text_background.Controls.Add(turn_indendification);
            turn_text_background.Cursor = Cursors.IBeam;
            turn_text_background.Location = new Point(604, 10);
            turn_text_background.Name = "turn_text_background";
            turn_text_background.Size = new Size(184, 30);
            turn_text_background.TabIndex = 3;
            // 
            // turn_indendification
            // 
            turn_indendification.AutoSize = true;
            turn_indendification.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            turn_indendification.Location = new Point(3, 2);
            turn_indendification.Name = "turn_indendification";
            turn_indendification.Size = new Size(102, 21);
            turn_indendification.TabIndex = 0;
            turn_indendification.Text = "Player N turn";
            turn_indendification.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // settings_button
            // 
            settings_button.BackColor = Color.Green;
            settings_button.BackgroundImage = Properties.Resources.settings;
            settings_button.BackgroundImageLayout = ImageLayout.None;
            settings_button.FlatAppearance.BorderColor = Color.Black;
            settings_button.FlatStyle = FlatStyle.Flat;
            settings_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            settings_button.ForeColor = Color.White;
            settings_button.ImageAlign = ContentAlignment.BottomLeft;
            settings_button.Location = new Point(138, 10);
            settings_button.Name = "settings_button";
            settings_button.Size = new Size(120, 30);
            settings_button.TabIndex = 2;
            settings_button.Text = "Settings";
            settings_button.TextAlign = ContentAlignment.TopRight;
            settings_button.UseVisualStyleBackColor = false;
            settings_button.Click += OnSettings_Click;
            // 
            // reset_button
            // 
            reset_button.BackColor = Color.Green;
            reset_button.BackgroundImage = Properties.Resources.game;
            reset_button.BackgroundImageLayout = ImageLayout.None;
            reset_button.FlatAppearance.BorderColor = Color.Black;
            reset_button.FlatStyle = FlatStyle.Flat;
            reset_button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            reset_button.ForeColor = Color.White;
            reset_button.ImageAlign = ContentAlignment.BottomLeft;
            reset_button.Location = new Point(12, 10);
            reset_button.Name = "reset_button";
            reset_button.RightToLeft = RightToLeft.No;
            reset_button.Size = new Size(120, 30);
            reset_button.TabIndex = 1;
            reset_button.Text = "Reset";
            reset_button.TextAlign = ContentAlignment.TopRight;
            reset_button.UseVisualStyleBackColor = false;
            reset_button.Click += OnRestart_Click;
            // 
            // Window
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 850);
            Controls.Add(control_bar);
            Controls.Add(play_zone);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Window";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reversi";
            control_bar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            turn_text_background.ResumeLayout(false);
            turn_text_background.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel play_zone;
        private Panel control_bar;
        private Panel turn_text_background;
        private Button settings_button;
        private Button reset_button;
        private Label turn_indendification;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label score_text;
    }
}
