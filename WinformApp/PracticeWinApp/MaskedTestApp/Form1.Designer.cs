﻿
namespace MaskedTestApp
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtHiredDate = new System.Windows.Forms.MaskedTextBox();
            this.TxtZipcode = new System.Windows.Forms.MaskedTextBox();
            this.TxtAddress = new System.Windows.Forms.MaskedTextBox();
            this.TxtMobile = new System.Windows.Forms.MaskedTextBox();
            this.TxtSocialNumber = new System.Windows.Forms.MaskedTextBox();
            this.TxtEmail = new System.Windows.Forms.MaskedTextBox();
            this.BtnRegister = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "임시일";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "우편번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "주소";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "휴대폰번호";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "주민번호";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 220);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "이메일";
            // 
            // TxtHiredDate
            // 
            this.TxtHiredDate.Location = new System.Drawing.Point(94, 22);
            this.TxtHiredDate.Mask = "0000-00-00";
            this.TxtHiredDate.Name = "TxtHiredDate";
            this.TxtHiredDate.Size = new System.Drawing.Size(75, 21);
            this.TxtHiredDate.TabIndex = 6;
            this.TxtHiredDate.ValidatingType = typeof(System.DateTime);
            // 
            // TxtZipcode
            // 
            this.TxtZipcode.Location = new System.Drawing.Point(94, 61);
            this.TxtZipcode.Mask = "00000";
            this.TxtZipcode.Name = "TxtZipcode";
            this.TxtZipcode.Size = new System.Drawing.Size(44, 21);
            this.TxtZipcode.TabIndex = 7;
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(94, 100);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(421, 21);
            this.TxtAddress.TabIndex = 8;
            // 
            // TxtMobile
            // 
            this.TxtMobile.Location = new System.Drawing.Point(94, 139);
            this.TxtMobile.Mask = "000-9000-0000";
            this.TxtMobile.Name = "TxtMobile";
            this.TxtMobile.Size = new System.Drawing.Size(92, 21);
            this.TxtMobile.TabIndex = 9;
            // 
            // TxtSocialNumber
            // 
            this.TxtSocialNumber.Location = new System.Drawing.Point(94, 178);
            this.TxtSocialNumber.Mask = "000000-0000000";
            this.TxtSocialNumber.Name = "TxtSocialNumber";
            this.TxtSocialNumber.Size = new System.Drawing.Size(102, 21);
            this.TxtSocialNumber.TabIndex = 10;
            // 
            // TxtEmail
            // 
            this.TxtEmail.Location = new System.Drawing.Point(94, 217);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(153, 21);
            this.TxtEmail.TabIndex = 11;
            // 
            // BtnRegister
            // 
            this.BtnRegister.Image = global::MaskedTestApp.Properties.Resources.register;
            this.BtnRegister.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnRegister.Location = new System.Drawing.Point(94, 257);
            this.BtnRegister.Name = "BtnRegister";
            this.BtnRegister.Size = new System.Drawing.Size(66, 30);
            this.BtnRegister.TabIndex = 12;
            this.BtnRegister.Text = "등록";
            this.BtnRegister.UseVisualStyleBackColor = true;
            this.BtnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 303);
            this.Controls.Add(this.BtnRegister);
            this.Controls.Add(this.TxtEmail);
            this.Controls.Add(this.TxtSocialNumber);
            this.Controls.Add(this.TxtMobile);
            this.Controls.Add(this.TxtAddress);
            this.Controls.Add(this.TxtZipcode);
            this.Controls.Add(this.TxtHiredDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "사원정보 등록";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox TxtHiredDate;
        private System.Windows.Forms.MaskedTextBox TxtZipcode;
        private System.Windows.Forms.MaskedTextBox TxtAddress;
        private System.Windows.Forms.MaskedTextBox TxtMobile;
        private System.Windows.Forms.MaskedTextBox TxtSocialNumber;
        private System.Windows.Forms.MaskedTextBox TxtEmail;
        private System.Windows.Forms.Button BtnRegister;
    }
}

