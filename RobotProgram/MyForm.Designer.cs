namespace RobotProgram
{
    partial class MyForm
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
            this.player = new System.Windows.Forms.PictureBox();
            this.cpu = new System.Windows.Forms.PictureBox();
            this.ball = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.idlePic = new System.Windows.Forms.PictureBox();
            this.inTransPic = new System.Windows.Forms.PictureBox();
            this.lookingPic = new System.Windows.Forms.PictureBox();
            this.messageLabel = new System.Windows.Forms.Label();
            this.outTransPic = new System.Windows.Forms.PictureBox();
            this.pongLabel = new System.Windows.Forms.Label();
            this.reactLabel = new System.Windows.Forms.Label();
            this.exitLabel = new System.Windows.Forms.Label();
            this.p1Label = new System.Windows.Forms.Label();
            this.p2Label = new System.Windows.Forms.Label();
            this.p1ScoreLabel = new System.Windows.Forms.Label();
            this.p2ScoreLabel = new System.Windows.Forms.Label();
            this.goLabel = new System.Windows.Forms.Label();
            this.reactMessageLabel = new System.Windows.Forms.Label();
            this.moveLeft = new System.Windows.Forms.Button();
            this.moveRight = new System.Windows.Forms.Button();
            this.headRight = new System.Windows.Forms.Button();
            this.headLeft = new System.Windows.Forms.Button();
            this.colorButton = new System.Windows.Forms.Button();
            this.shakeHead = new System.Windows.Forms.Button();
            this.colorField = new System.Windows.Forms.TextBox();
            this.distanceField = new System.Windows.Forms.TextBox();
            this.distanceLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.idlePic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTransPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookingPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outTransPic)).BeginInit();
            this.SuspendLayout();
            // 
            // player
            // 
            this.player.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.player.Location = new System.Drawing.Point(12, 202);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(28, 63);
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // cpu
            // 
            this.cpu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cpu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.cpu.Location = new System.Drawing.Point(760, 202);
            this.cpu.Name = "cpu";
            this.cpu.Size = new System.Drawing.Size(28, 63);
            this.cpu.TabIndex = 1;
            this.cpu.TabStop = false;
            // 
            // ball
            // 
            this.ball.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ball.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ball.Location = new System.Drawing.Point(386, 194);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(28, 63);
            this.ball.TabIndex = 2;
            this.ball.TabStop = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.ForeColor = System.Drawing.SystemColors.ActiveBorder;
            this.scoreLabel.Location = new System.Drawing.Point(354, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(24, 20);
            this.scoreLabel.TabIndex = 3;
            this.scoreLabel.Text = "0-0";
            this.scoreLabel.UseCompatibleTextRendering = true;
            // 
            // idlePic
            // 
            this.idlePic.BackColor = System.Drawing.Color.White;
            this.idlePic.Image = global::RobotProgram.Properties.Resources.idlePic;
            this.idlePic.Location = new System.Drawing.Point(31, 21);
            this.idlePic.Name = "idlePic";
            this.idlePic.Size = new System.Drawing.Size(100, 50);
            this.idlePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.idlePic.TabIndex = 4;
            this.idlePic.TabStop = false;
            this.idlePic.Click += new System.EventHandler(this.startIdleToMenu);
            // 
            // inTransPic
            // 
            this.inTransPic.BackColor = System.Drawing.Color.Red;
            this.inTransPic.Enabled = false;
            this.inTransPic.Image = global::RobotProgram.Properties.Resources.inTransPic;
            this.inTransPic.Location = new System.Drawing.Point(86, 131);
            this.inTransPic.Name = "inTransPic";
            this.inTransPic.Size = new System.Drawing.Size(100, 13);
            this.inTransPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inTransPic.TabIndex = 5;
            this.inTransPic.TabStop = false;
            this.inTransPic.Visible = false;
            // 
            // lookingPic
            // 
            this.lookingPic.BackColor = System.Drawing.Color.Lime;
            this.lookingPic.Enabled = false;
            this.lookingPic.Image = global::RobotProgram.Properties.Resources.lookingPic;
            this.lookingPic.Location = new System.Drawing.Point(149, 21);
            this.lookingPic.Name = "lookingPic";
            this.lookingPic.Size = new System.Drawing.Size(100, 50);
            this.lookingPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.lookingPic.TabIndex = 6;
            this.lookingPic.TabStop = false;
            this.lookingPic.Visible = false;
            this.lookingPic.Click += new System.EventHandler(this.startIdleToMenu);
            // 
            // messageLabel
            // 
            this.messageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.messageLabel.AutoSize = true;
            this.messageLabel.Font = new System.Drawing.Font("Lucida Console", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.messageLabel.Location = new System.Drawing.Point(47, 423);
            this.messageLabel.Name = "messageLabel";
            this.messageLabel.Size = new System.Drawing.Size(457, 18);
            this.messageLabel.TabIndex = 7;
            this.messageLabel.Text = "Press R to restart game | Press Esc to Exit to main menu";
            this.messageLabel.UseCompatibleTextRendering = true;
            this.messageLabel.UseMnemonic = false;
            // 
            // outTransPic
            // 
            this.outTransPic.BackColor = System.Drawing.Color.Blue;
            this.outTransPic.Enabled = false;
            this.outTransPic.Image = global::RobotProgram.Properties.Resources.outTransPic;
            this.outTransPic.Location = new System.Drawing.Point(192, 131);
            this.outTransPic.Name = "outTransPic";
            this.outTransPic.Size = new System.Drawing.Size(100, 13);
            this.outTransPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outTransPic.TabIndex = 8;
            this.outTransPic.TabStop = false;
            this.outTransPic.Visible = false;
            // 
            // pongLabel
            // 
            this.pongLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pongLabel.AutoSize = true;
            this.pongLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pongLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pongLabel.Location = new System.Drawing.Point(460, 81);
            this.pongLabel.Name = "pongLabel";
            this.pongLabel.Size = new System.Drawing.Size(36, 20);
            this.pongLabel.TabIndex = 9;
            this.pongLabel.Text = "Pong";
            this.pongLabel.UseCompatibleTextRendering = true;
            this.pongLabel.Click += new System.EventHandler(this.startMenuToPong);
            // 
            // reactLabel
            // 
            this.reactLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reactLabel.AutoSize = true;
            this.reactLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reactLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reactLabel.Location = new System.Drawing.Point(460, 131);
            this.reactLabel.Name = "reactLabel";
            this.reactLabel.Size = new System.Drawing.Size(166, 20);
            this.reactLabel.TabIndex = 10;
            this.reactLabel.Text = "Reaction Game (2 Players)";
            this.reactLabel.UseCompatibleTextRendering = true;
            this.reactLabel.Click += new System.EventHandler(this.startMenuToReact);
            // 
            // exitLabel
            // 
            this.exitLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exitLabel.AutoSize = true;
            this.exitLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.exitLabel.ForeColor = System.Drawing.SystemColors.Info;
            this.exitLabel.Location = new System.Drawing.Point(460, 181);
            this.exitLabel.Name = "exitLabel";
            this.exitLabel.Size = new System.Drawing.Size(27, 20);
            this.exitLabel.TabIndex = 11;
            this.exitLabel.Text = "Exit";
            this.exitLabel.UseCompatibleTextRendering = true;
            this.exitLabel.Click += new System.EventHandler(this.startMenuToIdle);
            // 
            // p1Label
            // 
            this.p1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1Label.AutoSize = true;
            this.p1Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1Label.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.p1Label.Location = new System.Drawing.Point(460, 237);
            this.p1Label.Name = "p1Label";
            this.p1Label.Size = new System.Drawing.Size(54, 20);
            this.p1Label.TabIndex = 12;
            this.p1Label.Text = "Player 1";
            this.p1Label.UseCompatibleTextRendering = true;
            // 
            // p2Label
            // 
            this.p2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2Label.AutoSize = true;
            this.p2Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2Label.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.p2Label.Location = new System.Drawing.Point(460, 279);
            this.p2Label.Name = "p2Label";
            this.p2Label.Size = new System.Drawing.Size(54, 20);
            this.p2Label.TabIndex = 13;
            this.p2Label.Text = "Player 2";
            this.p2Label.UseCompatibleTextRendering = true;
            // 
            // p1ScoreLabel
            // 
            this.p1ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p1ScoreLabel.AutoSize = true;
            this.p1ScoreLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p1ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p1ScoreLabel.Location = new System.Drawing.Point(460, 316);
            this.p1ScoreLabel.Name = "p1ScoreLabel";
            this.p1ScoreLabel.Size = new System.Drawing.Size(88, 20);
            this.p1ScoreLabel.TabIndex = 14;
            this.p1ScoreLabel.Text = "p1ScoreLabel";
            this.p1ScoreLabel.UseCompatibleTextRendering = true;
            // 
            // p2ScoreLabel
            // 
            this.p2ScoreLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.p2ScoreLabel.AutoSize = true;
            this.p2ScoreLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.p2ScoreLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.p2ScoreLabel.Location = new System.Drawing.Point(460, 350);
            this.p2ScoreLabel.Name = "p2ScoreLabel";
            this.p2ScoreLabel.Size = new System.Drawing.Size(88, 20);
            this.p2ScoreLabel.TabIndex = 15;
            this.p2ScoreLabel.Text = "p2ScoreLabel";
            this.p2ScoreLabel.UseCompatibleTextRendering = true;
            // 
            // goLabel
            // 
            this.goLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.goLabel.AutoSize = true;
            this.goLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.goLabel.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.goLabel.Location = new System.Drawing.Point(586, 293);
            this.goLabel.Name = "goLabel";
            this.goLabel.Size = new System.Drawing.Size(26, 20);
            this.goLabel.TabIndex = 16;
            this.goLabel.Text = "Go!";
            this.goLabel.UseCompatibleTextRendering = true;
            // 
            // reactMessageLabel
            // 
            this.reactMessageLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.reactMessageLabel.AutoSize = true;
            this.reactMessageLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.reactMessageLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.reactMessageLabel.Location = new System.Drawing.Point(149, 392);
            this.reactMessageLabel.Name = "reactMessageLabel";
            this.reactMessageLabel.Size = new System.Drawing.Size(354, 20);
            this.reactMessageLabel.TabIndex = 17;
            this.reactMessageLabel.Text = "Press R to reset the game | Press Esc to exit to main menu";
            this.reactMessageLabel.UseCompatibleTextRendering = true;
            // 
            // moveLeft
            // 
            this.moveLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveLeft.Location = new System.Drawing.Point(111, 194);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(96, 52);
            this.moveLeft.TabIndex = 18;
            this.moveLeft.Text = "Move Left Arm";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.Click += new System.EventHandler(this.moveLeftArm);
            // 
            // moveRight
            // 
            this.moveRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.moveRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveRight.Location = new System.Drawing.Point(111, 252);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(102, 47);
            this.moveRight.TabIndex = 19;
            this.moveRight.Text = "Move Right Arm";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.Click += new System.EventHandler(this.moveRightArm);
            // 
            // headRight
            // 
            this.headRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.headRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headRight.Location = new System.Drawing.Point(111, 305);
            this.headRight.Name = "headRight";
            this.headRight.Size = new System.Drawing.Size(102, 65);
            this.headRight.TabIndex = 20;
            this.headRight.Text = "Move Head Right";
            this.headRight.UseVisualStyleBackColor = true;
            this.headRight.Click += new System.EventHandler(this.moveHeadRight);
            // 
            // headLeft
            // 
            this.headLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.headLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headLeft.Location = new System.Drawing.Point(217, 194);
            this.headLeft.Name = "headLeft";
            this.headLeft.Size = new System.Drawing.Size(108, 52);
            this.headLeft.TabIndex = 21;
            this.headLeft.Text = "Move Head Left";
            this.headLeft.UseVisualStyleBackColor = true;
            this.headLeft.Click += new System.EventHandler(this.moveHeadLeft);
            // 
            // colorButton
            // 
            this.colorButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.colorButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorButton.Location = new System.Drawing.Point(219, 247);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(108, 52);
            this.colorButton.TabIndex = 22;
            this.colorButton.Text = "Read Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Click += new System.EventHandler(this.readColor);
            // 
            // shakeHead
            // 
            this.shakeHead.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.shakeHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shakeHead.Location = new System.Drawing.Point(219, 305);
            this.shakeHead.Name = "shakeHead";
            this.shakeHead.Size = new System.Drawing.Size(108, 52);
            this.shakeHead.TabIndex = 23;
            this.shakeHead.Text = "Shake Head";
            this.shakeHead.UseVisualStyleBackColor = true;
            this.shakeHead.Click += new System.EventHandler(this.headShake);
            // 
            // colorField
            // 
            this.colorField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorField.Location = new System.Drawing.Point(333, 279);
            this.colorField.Name = "colorField";
            this.colorField.Size = new System.Drawing.Size(100, 30);
            this.colorField.TabIndex = 24;
            // 
            // distanceField
            // 
            this.distanceField.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceField.Location = new System.Drawing.Point(333, 313);
            this.distanceField.Name = "distanceField";
            this.distanceField.Size = new System.Drawing.Size(100, 30);
            this.distanceField.TabIndex = 25;
            // 
            // distanceLabel
            // 
            this.distanceLabel.AutoSize = true;
            this.distanceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.distanceLabel.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.distanceLabel.Location = new System.Drawing.Point(330, 135);
            this.distanceLabel.Name = "distanceLabel";
            this.distanceLabel.Size = new System.Drawing.Size(132, 25);
            this.distanceLabel.TabIndex = 26;
            this.distanceLabel.Text = "Is user close?";
            // 
            // MyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.distanceLabel);
            this.Controls.Add(this.distanceField);
            this.Controls.Add(this.colorField);
            this.Controls.Add(this.shakeHead);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.headLeft);
            this.Controls.Add(this.headRight);
            this.Controls.Add(this.moveRight);
            this.Controls.Add(this.moveLeft);
            this.Controls.Add(this.reactMessageLabel);
            this.Controls.Add(this.goLabel);
            this.Controls.Add(this.p2ScoreLabel);
            this.Controls.Add(this.p1ScoreLabel);
            this.Controls.Add(this.p2Label);
            this.Controls.Add(this.p1Label);
            this.Controls.Add(this.exitLabel);
            this.Controls.Add(this.reactLabel);
            this.Controls.Add(this.pongLabel);
            this.Controls.Add(this.outTransPic);
            this.Controls.Add(this.messageLabel);
            this.Controls.Add(this.lookingPic);
            this.Controls.Add(this.inTransPic);
            this.Controls.Add(this.idlePic);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.cpu);
            this.Controls.Add(this.player);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MyForm";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.SizeChanged += new System.EventHandler(this.formResized);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyUp);
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.idlePic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inTransPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookingPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outTransPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.PictureBox cpu;
        private System.Windows.Forms.PictureBox ball;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.PictureBox idlePic;
        private System.Windows.Forms.PictureBox inTransPic;
        private System.Windows.Forms.PictureBox lookingPic;
        private System.Windows.Forms.Label messageLabel;
        private System.Windows.Forms.PictureBox outTransPic;
        private System.Windows.Forms.Label pongLabel;
        private System.Windows.Forms.Label reactLabel;
        private System.Windows.Forms.Label exitLabel;
        private System.Windows.Forms.Label p1Label;
        private System.Windows.Forms.Label p2Label;
        private System.Windows.Forms.Label p1ScoreLabel;
        private System.Windows.Forms.Label p2ScoreLabel;
        private System.Windows.Forms.Label goLabel;
        private System.Windows.Forms.Label reactMessageLabel;
        private System.Windows.Forms.Button moveLeft;
        private System.Windows.Forms.Button moveRight;
        private System.Windows.Forms.Button headRight;
        private System.Windows.Forms.Button headLeft;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button shakeHead;
        private System.Windows.Forms.TextBox colorField;
        private System.Windows.Forms.TextBox distanceField;
        private System.Windows.Forms.Label distanceLabel;
    }
}

