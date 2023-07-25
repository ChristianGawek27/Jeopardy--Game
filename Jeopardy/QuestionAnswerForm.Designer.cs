
namespace Jeopardy
{
    partial class QuestionAnswerForm
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
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnPlayer1Buzzer = new System.Windows.Forms.Button();
            this.btnPlayer2Buzzer = new System.Windows.Forms.Button();
            this.grpPlayerAnswer = new System.Windows.Forms.GroupBox();
            this.btnPlayerSubmit = new System.Windows.Forms.Button();
            this.txtPlayerAnswer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlayerAnswer.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblQuestion.ForeColor = System.Drawing.Color.White;
            this.lblQuestion.Location = new System.Drawing.Point(14, 25);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(139, 41);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            // 
            // btnPlayer1Buzzer
            // 
            this.btnPlayer1Buzzer.BackColor = System.Drawing.Color.Aqua;
            this.btnPlayer1Buzzer.Location = new System.Drawing.Point(79, 256);
            this.btnPlayer1Buzzer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPlayer1Buzzer.Name = "btnPlayer1Buzzer";
            this.btnPlayer1Buzzer.Size = new System.Drawing.Size(145, 151);
            this.btnPlayer1Buzzer.TabIndex = 1;
            this.btnPlayer1Buzzer.Text = "Player 1 Buzzer";
            this.btnPlayer1Buzzer.UseVisualStyleBackColor = false;
            this.btnPlayer1Buzzer.Click += new System.EventHandler(this.btnPlayer1Buzzer_Click);
            // 
            // btnPlayer2Buzzer
            // 
            this.btnPlayer2Buzzer.BackColor = System.Drawing.Color.Aqua;
            this.btnPlayer2Buzzer.Location = new System.Drawing.Point(1131, 246);
            this.btnPlayer2Buzzer.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPlayer2Buzzer.Name = "btnPlayer2Buzzer";
            this.btnPlayer2Buzzer.Size = new System.Drawing.Size(145, 151);
            this.btnPlayer2Buzzer.TabIndex = 2;
            this.btnPlayer2Buzzer.Text = "Player 2 Buzzer";
            this.btnPlayer2Buzzer.UseVisualStyleBackColor = false;
            this.btnPlayer2Buzzer.Click += new System.EventHandler(this.btnPlayer2Buzzer_Click);
            // 
            // grpPlayerAnswer
            // 
            this.grpPlayerAnswer.Controls.Add(this.btnPlayerSubmit);
            this.grpPlayerAnswer.Controls.Add(this.txtPlayerAnswer);
            this.grpPlayerAnswer.Controls.Add(this.label1);
            this.grpPlayerAnswer.ForeColor = System.Drawing.Color.White;
            this.grpPlayerAnswer.Location = new System.Drawing.Point(539, 150);
            this.grpPlayerAnswer.Name = "grpPlayerAnswer";
            this.grpPlayerAnswer.Size = new System.Drawing.Size(293, 335);
            this.grpPlayerAnswer.TabIndex = 3;
            this.grpPlayerAnswer.TabStop = false;
            this.grpPlayerAnswer.Text = "Player 1 Answer Form";
            // 
            // btnPlayerSubmit
            // 
            this.btnPlayerSubmit.BackColor = System.Drawing.Color.Aqua;
            this.btnPlayerSubmit.ForeColor = System.Drawing.Color.Black;
            this.btnPlayerSubmit.Location = new System.Drawing.Point(75, 247);
            this.btnPlayerSubmit.Name = "btnPlayerSubmit";
            this.btnPlayerSubmit.Size = new System.Drawing.Size(149, 29);
            this.btnPlayerSubmit.TabIndex = 2;
            this.btnPlayerSubmit.Text = "Submit Answer";
            this.btnPlayerSubmit.UseVisualStyleBackColor = false;
            this.btnPlayerSubmit.Click += new System.EventHandler(this.btnPlayerSubmit_Click);
            // 
            // txtPlayerAnswer
            // 
            this.txtPlayerAnswer.Location = new System.Drawing.Point(75, 147);
            this.txtPlayerAnswer.Name = "txtPlayerAnswer";
            this.txtPlayerAnswer.Size = new System.Drawing.Size(125, 27);
            this.txtPlayerAnswer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(75, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Answer";
            // 
            // QuestionAnswerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Blue;
            this.ClientSize = new System.Drawing.Size(1382, 663);
            this.Controls.Add(this.grpPlayerAnswer);
            this.Controls.Add(this.btnPlayer2Buzzer);
            this.Controls.Add(this.btnPlayer1Buzzer);
            this.Controls.Add(this.lblQuestion);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuestionAnswerForm";
            this.Text = "QuestionAnswerForm";
            this.Load += new System.EventHandler(this.QuestionAnswerForm_Load);
            this.grpPlayerAnswer.ResumeLayout(false);
            this.grpPlayerAnswer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnPlayer1Buzzer;
        private System.Windows.Forms.Button btnPlayer2Buzzer;
        private System.Windows.Forms.GroupBox grpPlayerAnswer;
        private System.Windows.Forms.Button btnPlayerSubmit;
        private System.Windows.Forms.TextBox txtPlayerAnswer;
        private System.Windows.Forms.Label label1;
    }
}