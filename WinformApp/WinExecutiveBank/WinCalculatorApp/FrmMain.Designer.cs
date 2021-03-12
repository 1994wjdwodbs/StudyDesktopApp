
namespace WinCalculatorApp
{
    partial class FrmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtResult = new System.Windows.Forms.TextBox();
            this.BtnCE = new System.Windows.Forms.Button();
            this.BtnC = new System.Windows.Forms.Button();
            this.BtnDel = new System.Windows.Forms.Button();
            this.BtnMC = new System.Windows.Forms.Button();
            this.BtnMR = new System.Windows.Forms.Button();
            this.BtnMplus = new System.Windows.Forms.Button();
            this.BtnMminus = new System.Windows.Forms.Button();
            this.BtnMS = new System.Windows.Forms.Button();
            this.BtnMod = new System.Windows.Forms.Button();
            this.BtnSqrt = new System.Windows.Forms.Button();
            this.BtnSqr = new System.Windows.Forms.Button();
            this.BtnRecip = new System.Windows.Forms.Button();
            this.BtnDiv = new System.Windows.Forms.Button();
            this.BtnMul = new System.Windows.Forms.Button();
            this.Btn9 = new System.Windows.Forms.Button();
            this.Btn8 = new System.Windows.Forms.Button();
            this.Btn7 = new System.Windows.Forms.Button();
            this.BtnSub = new System.Windows.Forms.Button();
            this.Btn6 = new System.Windows.Forms.Button();
            this.Btn5 = new System.Windows.Forms.Button();
            this.Btn4 = new System.Windows.Forms.Button();
            this.BtnPlus = new System.Windows.Forms.Button();
            this.Btn3 = new System.Windows.Forms.Button();
            this.Btn2 = new System.Windows.Forms.Button();
            this.Btn1 = new System.Windows.Forms.Button();
            this.BtnResult = new System.Windows.Forms.Button();
            this.BtnDot = new System.Windows.Forms.Button();
            this.Btn0 = new System.Windows.Forms.Button();
            this.BtnSign = new System.Windows.Forms.Button();
            this.TxtExp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TxtResult
            // 
            this.TxtResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtResult.Font = new System.Drawing.Font("맑은 고딕", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtResult.Location = new System.Drawing.Point(12, 30);
            this.TxtResult.Name = "TxtResult";
            this.TxtResult.Size = new System.Drawing.Size(240, 32);
            this.TxtResult.TabIndex = 0;
            this.TxtResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnCE
            // 
            this.BtnCE.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnCE.FlatAppearance.BorderSize = 0;
            this.BtnCE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnCE.Location = new System.Drawing.Point(1, 140);
            this.BtnCE.Name = "BtnCE";
            this.BtnCE.Size = new System.Drawing.Size(65, 40);
            this.BtnCE.TabIndex = 1;
            this.BtnCE.Text = "CE";
            this.BtnCE.UseVisualStyleBackColor = false;
            // 
            // BtnC
            // 
            this.BtnC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnC.FlatAppearance.BorderSize = 0;
            this.BtnC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnC.Location = new System.Drawing.Point(67, 140);
            this.BtnC.Name = "BtnC";
            this.BtnC.Size = new System.Drawing.Size(65, 40);
            this.BtnC.TabIndex = 2;
            this.BtnC.Text = "C";
            this.BtnC.UseVisualStyleBackColor = false;
            this.BtnC.Click += new System.EventHandler(this.BtnC_Click);
            // 
            // BtnDel
            // 
            this.BtnDel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDel.FlatAppearance.BorderSize = 0;
            this.BtnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDel.Location = new System.Drawing.Point(133, 140);
            this.BtnDel.Name = "BtnDel";
            this.BtnDel.Size = new System.Drawing.Size(65, 40);
            this.BtnDel.TabIndex = 3;
            this.BtnDel.Text = "<x]";
            this.BtnDel.UseVisualStyleBackColor = false;
            // 
            // BtnMC
            // 
            this.BtnMC.FlatAppearance.BorderSize = 0;
            this.BtnMC.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMC.Location = new System.Drawing.Point(-2, 65);
            this.BtnMC.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMC.Name = "BtnMC";
            this.BtnMC.Size = new System.Drawing.Size(53, 35);
            this.BtnMC.TabIndex = 13;
            this.BtnMC.Text = "MC";
            this.BtnMC.UseVisualStyleBackColor = true;
            this.BtnMC.Click += new System.EventHandler(this.BtnMC_Click);
            // 
            // BtnMR
            // 
            this.BtnMR.FlatAppearance.BorderSize = 0;
            this.BtnMR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMR.Location = new System.Drawing.Point(51, 65);
            this.BtnMR.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMR.Name = "BtnMR";
            this.BtnMR.Size = new System.Drawing.Size(53, 35);
            this.BtnMR.TabIndex = 14;
            this.BtnMR.Text = "MR";
            this.BtnMR.UseVisualStyleBackColor = true;
            this.BtnMR.Click += new System.EventHandler(this.BtnMR_Click);
            // 
            // BtnMplus
            // 
            this.BtnMplus.FlatAppearance.BorderSize = 0;
            this.BtnMplus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMplus.Location = new System.Drawing.Point(104, 65);
            this.BtnMplus.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMplus.Name = "BtnMplus";
            this.BtnMplus.Size = new System.Drawing.Size(53, 35);
            this.BtnMplus.TabIndex = 14;
            this.BtnMplus.Text = "M+";
            this.BtnMplus.UseVisualStyleBackColor = true;
            this.BtnMplus.Click += new System.EventHandler(this.BtnMplus_Click);
            // 
            // BtnMminus
            // 
            this.BtnMminus.FlatAppearance.BorderSize = 0;
            this.BtnMminus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMminus.Location = new System.Drawing.Point(157, 65);
            this.BtnMminus.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMminus.Name = "BtnMminus";
            this.BtnMminus.Size = new System.Drawing.Size(53, 35);
            this.BtnMminus.TabIndex = 14;
            this.BtnMminus.Text = "M-";
            this.BtnMminus.UseVisualStyleBackColor = true;
            this.BtnMminus.Click += new System.EventHandler(this.BtnMminus_Click);
            // 
            // BtnMS
            // 
            this.BtnMS.FlatAppearance.BorderSize = 0;
            this.BtnMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMS.Location = new System.Drawing.Point(210, 65);
            this.BtnMS.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMS.Name = "BtnMS";
            this.BtnMS.Size = new System.Drawing.Size(53, 35);
            this.BtnMS.TabIndex = 15;
            this.BtnMS.Text = "MS";
            this.BtnMS.UseVisualStyleBackColor = true;
            this.BtnMS.Click += new System.EventHandler(this.BtnMS_Click);
            // 
            // BtnMod
            // 
            this.BtnMod.FlatAppearance.BorderSize = 0;
            this.BtnMod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMod.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnMod.Location = new System.Drawing.Point(-2, 103);
            this.BtnMod.Margin = new System.Windows.Forms.Padding(0);
            this.BtnMod.Name = "BtnMod";
            this.BtnMod.Size = new System.Drawing.Size(66, 35);
            this.BtnMod.TabIndex = 16;
            this.BtnMod.Text = "%";
            this.BtnMod.UseVisualStyleBackColor = true;
            // 
            // BtnSqrt
            // 
            this.BtnSqrt.FlatAppearance.BorderSize = 0;
            this.BtnSqrt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSqrt.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSqrt.Location = new System.Drawing.Point(64, 103);
            this.BtnSqrt.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSqrt.Name = "BtnSqrt";
            this.BtnSqrt.Size = new System.Drawing.Size(66, 35);
            this.BtnSqrt.TabIndex = 17;
            this.BtnSqrt.Text = "√";
            this.BtnSqrt.UseVisualStyleBackColor = true;
            // 
            // BtnSqr
            // 
            this.BtnSqr.FlatAppearance.BorderSize = 0;
            this.BtnSqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSqr.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnSqr.Location = new System.Drawing.Point(132, 103);
            this.BtnSqr.Margin = new System.Windows.Forms.Padding(0);
            this.BtnSqr.Name = "BtnSqr";
            this.BtnSqr.Size = new System.Drawing.Size(66, 35);
            this.BtnSqr.TabIndex = 18;
            this.BtnSqr.Text = "x²";
            this.BtnSqr.UseVisualStyleBackColor = true;
            // 
            // BtnRecip
            // 
            this.BtnRecip.FlatAppearance.BorderSize = 0;
            this.BtnRecip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnRecip.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BtnRecip.Location = new System.Drawing.Point(198, 103);
            this.BtnRecip.Margin = new System.Windows.Forms.Padding(0);
            this.BtnRecip.Name = "BtnRecip";
            this.BtnRecip.Size = new System.Drawing.Size(66, 35);
            this.BtnRecip.TabIndex = 19;
            this.BtnRecip.Text = "1/x";
            this.BtnRecip.UseVisualStyleBackColor = true;
            // 
            // BtnDiv
            // 
            this.BtnDiv.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDiv.FlatAppearance.BorderSize = 0;
            this.BtnDiv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDiv.Location = new System.Drawing.Point(199, 140);
            this.BtnDiv.Name = "BtnDiv";
            this.BtnDiv.Size = new System.Drawing.Size(65, 40);
            this.BtnDiv.TabIndex = 20;
            this.BtnDiv.Text = "÷";
            this.BtnDiv.UseVisualStyleBackColor = false;
            this.BtnDiv.Click += new System.EventHandler(this.BtnOp_Click);
            // 
            // BtnMul
            // 
            this.BtnMul.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnMul.FlatAppearance.BorderSize = 0;
            this.BtnMul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMul.Location = new System.Drawing.Point(199, 186);
            this.BtnMul.Name = "BtnMul";
            this.BtnMul.Size = new System.Drawing.Size(65, 40);
            this.BtnMul.TabIndex = 24;
            this.BtnMul.Text = "×";
            this.BtnMul.UseVisualStyleBackColor = false;
            this.BtnMul.Click += new System.EventHandler(this.BtnOp_Click);
            // 
            // Btn9
            // 
            this.Btn9.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn9.FlatAppearance.BorderSize = 0;
            this.Btn9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn9.Location = new System.Drawing.Point(133, 186);
            this.Btn9.Name = "Btn9";
            this.Btn9.Size = new System.Drawing.Size(65, 40);
            this.Btn9.TabIndex = 23;
            this.Btn9.Text = "9";
            this.Btn9.UseVisualStyleBackColor = false;
            this.Btn9.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn8
            // 
            this.Btn8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn8.FlatAppearance.BorderSize = 0;
            this.Btn8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn8.Location = new System.Drawing.Point(67, 186);
            this.Btn8.Name = "Btn8";
            this.Btn8.Size = new System.Drawing.Size(65, 40);
            this.Btn8.TabIndex = 22;
            this.Btn8.Text = "8";
            this.Btn8.UseVisualStyleBackColor = false;
            this.Btn8.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn7
            // 
            this.Btn7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn7.FlatAppearance.BorderSize = 0;
            this.Btn7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn7.Location = new System.Drawing.Point(1, 186);
            this.Btn7.Name = "Btn7";
            this.Btn7.Size = new System.Drawing.Size(65, 40);
            this.Btn7.TabIndex = 21;
            this.Btn7.Text = "7";
            this.Btn7.UseVisualStyleBackColor = false;
            this.Btn7.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // BtnSub
            // 
            this.BtnSub.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSub.FlatAppearance.BorderSize = 0;
            this.BtnSub.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSub.Location = new System.Drawing.Point(199, 232);
            this.BtnSub.Name = "BtnSub";
            this.BtnSub.Size = new System.Drawing.Size(65, 40);
            this.BtnSub.TabIndex = 28;
            this.BtnSub.Text = "-";
            this.BtnSub.UseVisualStyleBackColor = false;
            this.BtnSub.Click += new System.EventHandler(this.BtnOp_Click);
            // 
            // Btn6
            // 
            this.Btn6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn6.FlatAppearance.BorderSize = 0;
            this.Btn6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn6.Location = new System.Drawing.Point(133, 232);
            this.Btn6.Name = "Btn6";
            this.Btn6.Size = new System.Drawing.Size(65, 40);
            this.Btn6.TabIndex = 27;
            this.Btn6.Text = "6";
            this.Btn6.UseVisualStyleBackColor = false;
            this.Btn6.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn5
            // 
            this.Btn5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn5.FlatAppearance.BorderSize = 0;
            this.Btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn5.Location = new System.Drawing.Point(67, 232);
            this.Btn5.Name = "Btn5";
            this.Btn5.Size = new System.Drawing.Size(65, 40);
            this.Btn5.TabIndex = 26;
            this.Btn5.Text = "5";
            this.Btn5.UseVisualStyleBackColor = false;
            this.Btn5.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn4
            // 
            this.Btn4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn4.FlatAppearance.BorderSize = 0;
            this.Btn4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn4.Location = new System.Drawing.Point(1, 232);
            this.Btn4.Name = "Btn4";
            this.Btn4.Size = new System.Drawing.Size(65, 40);
            this.Btn4.TabIndex = 25;
            this.Btn4.Text = "4";
            this.Btn4.UseVisualStyleBackColor = false;
            this.Btn4.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // BtnPlus
            // 
            this.BtnPlus.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnPlus.FlatAppearance.BorderSize = 0;
            this.BtnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPlus.Location = new System.Drawing.Point(198, 278);
            this.BtnPlus.Name = "BtnPlus";
            this.BtnPlus.Size = new System.Drawing.Size(65, 40);
            this.BtnPlus.TabIndex = 32;
            this.BtnPlus.Text = "+";
            this.BtnPlus.UseVisualStyleBackColor = false;
            this.BtnPlus.Click += new System.EventHandler(this.BtnOp_Click);
            // 
            // Btn3
            // 
            this.Btn3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn3.FlatAppearance.BorderSize = 0;
            this.Btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn3.Location = new System.Drawing.Point(132, 278);
            this.Btn3.Name = "Btn3";
            this.Btn3.Size = new System.Drawing.Size(65, 40);
            this.Btn3.TabIndex = 31;
            this.Btn3.Text = "3";
            this.Btn3.UseVisualStyleBackColor = false;
            this.Btn3.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn2
            // 
            this.Btn2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn2.FlatAppearance.BorderSize = 0;
            this.Btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn2.Location = new System.Drawing.Point(66, 278);
            this.Btn2.Name = "Btn2";
            this.Btn2.Size = new System.Drawing.Size(65, 40);
            this.Btn2.TabIndex = 30;
            this.Btn2.Text = "2";
            this.Btn2.UseVisualStyleBackColor = false;
            this.Btn2.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // Btn1
            // 
            this.Btn1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn1.FlatAppearance.BorderSize = 0;
            this.Btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn1.Location = new System.Drawing.Point(0, 278);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(65, 40);
            this.Btn1.TabIndex = 29;
            this.Btn1.Text = "1";
            this.Btn1.UseVisualStyleBackColor = false;
            this.Btn1.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // BtnResult
            // 
            this.BtnResult.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnResult.FlatAppearance.BorderSize = 0;
            this.BtnResult.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnResult.Location = new System.Drawing.Point(198, 324);
            this.BtnResult.Name = "BtnResult";
            this.BtnResult.Size = new System.Drawing.Size(65, 40);
            this.BtnResult.TabIndex = 36;
            this.BtnResult.Text = "=";
            this.BtnResult.UseVisualStyleBackColor = false;
            this.BtnResult.Click += new System.EventHandler(this.BtnEqual_Click);
            // 
            // BtnDot
            // 
            this.BtnDot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnDot.FlatAppearance.BorderSize = 0;
            this.BtnDot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDot.Location = new System.Drawing.Point(132, 324);
            this.BtnDot.Name = "BtnDot";
            this.BtnDot.Size = new System.Drawing.Size(65, 40);
            this.BtnDot.TabIndex = 35;
            this.BtnDot.Text = ".";
            this.BtnDot.UseVisualStyleBackColor = false;
            // 
            // Btn0
            // 
            this.Btn0.BackColor = System.Drawing.Color.WhiteSmoke;
            this.Btn0.FlatAppearance.BorderSize = 0;
            this.Btn0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn0.Location = new System.Drawing.Point(66, 324);
            this.Btn0.Name = "Btn0";
            this.Btn0.Size = new System.Drawing.Size(65, 40);
            this.Btn0.TabIndex = 34;
            this.Btn0.Text = "0";
            this.Btn0.UseVisualStyleBackColor = false;
            this.Btn0.Click += new System.EventHandler(this.BtnNum_Click);
            // 
            // BtnSign
            // 
            this.BtnSign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BtnSign.FlatAppearance.BorderSize = 0;
            this.BtnSign.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSign.Location = new System.Drawing.Point(0, 324);
            this.BtnSign.Name = "BtnSign";
            this.BtnSign.Size = new System.Drawing.Size(65, 40);
            this.BtnSign.TabIndex = 33;
            this.BtnSign.Text = "±";
            this.BtnSign.UseVisualStyleBackColor = false;
            // 
            // TxtExp
            // 
            this.TxtExp.BackColor = System.Drawing.SystemColors.Info;
            this.TxtExp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtExp.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.TxtExp.Location = new System.Drawing.Point(12, 4);
            this.TxtExp.Name = "TxtExp";
            this.TxtExp.Size = new System.Drawing.Size(240, 20);
            this.TxtExp.TabIndex = 37;
            this.TxtExp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(264, 381);
            this.Controls.Add(this.TxtExp);
            this.Controls.Add(this.BtnResult);
            this.Controls.Add(this.BtnDot);
            this.Controls.Add(this.Btn0);
            this.Controls.Add(this.BtnSign);
            this.Controls.Add(this.BtnPlus);
            this.Controls.Add(this.Btn3);
            this.Controls.Add(this.Btn2);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.BtnSub);
            this.Controls.Add(this.Btn6);
            this.Controls.Add(this.Btn5);
            this.Controls.Add(this.Btn4);
            this.Controls.Add(this.BtnMul);
            this.Controls.Add(this.Btn9);
            this.Controls.Add(this.Btn8);
            this.Controls.Add(this.Btn7);
            this.Controls.Add(this.BtnDiv);
            this.Controls.Add(this.BtnRecip);
            this.Controls.Add(this.BtnSqr);
            this.Controls.Add(this.BtnSqrt);
            this.Controls.Add(this.BtnMod);
            this.Controls.Add(this.BtnMS);
            this.Controls.Add(this.BtnMminus);
            this.Controls.Add(this.BtnMplus);
            this.Controls.Add(this.BtnMR);
            this.Controls.Add(this.BtnMC);
            this.Controls.Add(this.BtnDel);
            this.Controls.Add(this.BtnC);
            this.Controls.Add(this.BtnCE);
            this.Controls.Add(this.TxtResult);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "윈도우 계산기";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtResult;
        private System.Windows.Forms.Button BtnCE;
        private System.Windows.Forms.Button BtnC;
        private System.Windows.Forms.Button BtnDel;
        private System.Windows.Forms.Button BtnMC;
        private System.Windows.Forms.Button BtnMR;
        private System.Windows.Forms.Button BtnMplus;
        private System.Windows.Forms.Button BtnMminus;
        private System.Windows.Forms.Button BtnMS;
        private System.Windows.Forms.Button BtnMod;
        private System.Windows.Forms.Button BtnSqrt;
        private System.Windows.Forms.Button BtnSqr;
        private System.Windows.Forms.Button BtnRecip;
        private System.Windows.Forms.Button BtnDiv;
        private System.Windows.Forms.Button BtnMul;
        private System.Windows.Forms.Button Btn9;
        private System.Windows.Forms.Button Btn8;
        private System.Windows.Forms.Button Btn7;
        private System.Windows.Forms.Button BtnSub;
        private System.Windows.Forms.Button Btn6;
        private System.Windows.Forms.Button Btn5;
        private System.Windows.Forms.Button Btn4;
        private System.Windows.Forms.Button BtnPlus;
        private System.Windows.Forms.Button Btn3;
        private System.Windows.Forms.Button Btn2;
        private System.Windows.Forms.Button Btn1;
        private System.Windows.Forms.Button BtnResult;
        private System.Windows.Forms.Button BtnDot;
        private System.Windows.Forms.Button Btn0;
        private System.Windows.Forms.Button BtnSign;
        private System.Windows.Forms.TextBox TxtExp;
    }
}

