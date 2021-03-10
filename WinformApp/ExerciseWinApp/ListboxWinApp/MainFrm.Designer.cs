
namespace ListboxWinApp
{
    partial class MainFrm
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
            this.LsbGdpCountry = new System.Windows.Forms.ListBox();
            this.LsbGoodCity = new System.Windows.Forms.ListBox();
            this.LsbHappyCountry = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtIndexGdp = new System.Windows.Forms.TextBox();
            this.TxtItemGdp = new System.Windows.Forms.TextBox();
            this.TxtIndexCity = new System.Windows.Forms.TextBox();
            this.TxtItemCity = new System.Windows.Forms.TextBox();
            this.TxtIndexCountry = new System.Windows.Forms.TextBox();
            this.TxtItemCountry = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BtnInit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LsbGdpCountry
            // 
            this.LsbGdpCountry.FormattingEnabled = true;
            this.LsbGdpCountry.ItemHeight = 12;
            this.LsbGdpCountry.Items.AddRange(new object[] {
            "미국",
            "러시아",
            "중국",
            "독일",
            "프랑스",
            "일본",
            "이스라엘",
            "사우디아라비아",
            "UAE",
            "대한민국",
            "필리핀"});
            this.LsbGdpCountry.Location = new System.Drawing.Point(113, 47);
            this.LsbGdpCountry.Name = "LsbGdpCountry";
            this.LsbGdpCountry.Size = new System.Drawing.Size(187, 292);
            this.LsbGdpCountry.TabIndex = 0;
            this.LsbGdpCountry.SelectedIndexChanged += new System.EventHandler(this.LsbGdpCountry_SelectedIndexChanged);
            // 
            // LsbGoodCity
            // 
            this.LsbGoodCity.FormattingEnabled = true;
            this.LsbGoodCity.ItemHeight = 12;
            this.LsbGoodCity.Location = new System.Drawing.Point(338, 47);
            this.LsbGoodCity.Name = "LsbGoodCity";
            this.LsbGoodCity.Size = new System.Drawing.Size(187, 292);
            this.LsbGoodCity.TabIndex = 1;
            this.LsbGoodCity.SelectedIndexChanged += new System.EventHandler(this.LsbGoodCity_SelectedIndexChanged);
            // 
            // LsbHappyCountry
            // 
            this.LsbHappyCountry.FormattingEnabled = true;
            this.LsbHappyCountry.ItemHeight = 12;
            this.LsbHappyCountry.Location = new System.Drawing.Point(563, 47);
            this.LsbHappyCountry.Name = "LsbHappyCountry";
            this.LsbHappyCountry.Size = new System.Drawing.Size(187, 292);
            this.LsbHappyCountry.TabIndex = 2;
            this.LsbHappyCountry.SelectedIndexChanged += new System.EventHandler(this.LsbHappyCountry_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(111, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "GDP 국가순위";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "살기좋은 도시";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "행복한 나라";
            // 
            // TxtIndexGdp
            // 
            this.TxtIndexGdp.Location = new System.Drawing.Point(113, 345);
            this.TxtIndexGdp.Name = "TxtIndexGdp";
            this.TxtIndexGdp.Size = new System.Drawing.Size(187, 21);
            this.TxtIndexGdp.TabIndex = 6;
            // 
            // TxtItemGdp
            // 
            this.TxtItemGdp.Location = new System.Drawing.Point(113, 372);
            this.TxtItemGdp.Name = "TxtItemGdp";
            this.TxtItemGdp.Size = new System.Drawing.Size(187, 21);
            this.TxtItemGdp.TabIndex = 7;
            // 
            // TxtIndexCity
            // 
            this.TxtIndexCity.Location = new System.Drawing.Point(338, 345);
            this.TxtIndexCity.Name = "TxtIndexCity";
            this.TxtIndexCity.Size = new System.Drawing.Size(187, 21);
            this.TxtIndexCity.TabIndex = 8;
            // 
            // TxtItemCity
            // 
            this.TxtItemCity.Location = new System.Drawing.Point(338, 372);
            this.TxtItemCity.Name = "TxtItemCity";
            this.TxtItemCity.Size = new System.Drawing.Size(187, 21);
            this.TxtItemCity.TabIndex = 9;
            // 
            // TxtIndexCountry
            // 
            this.TxtIndexCountry.Location = new System.Drawing.Point(563, 345);
            this.TxtIndexCountry.Name = "TxtIndexCountry";
            this.TxtIndexCountry.Size = new System.Drawing.Size(187, 21);
            this.TxtIndexCountry.TabIndex = 10;
            // 
            // TxtItemCountry
            // 
            this.TxtItemCountry.Location = new System.Drawing.Point(563, 372);
            this.TxtItemCountry.Name = "TxtItemCountry";
            this.TxtItemCountry.Size = new System.Drawing.Size(187, 21);
            this.TxtItemCountry.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 348);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Selected Index";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "Selected Item";
            // 
            // BtnInit
            // 
            this.BtnInit.Location = new System.Drawing.Point(24, 302);
            this.BtnInit.Name = "BtnInit";
            this.BtnInit.Size = new System.Drawing.Size(83, 37);
            this.BtnInit.TabIndex = 14;
            this.BtnInit.Text = "초기화";
            this.BtnInit.UseVisualStyleBackColor = true;
            this.BtnInit.Click += new System.EventHandler(this.BtnInit_Click);
            // 
            // MainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 423);
            this.Controls.Add(this.BtnInit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtItemCountry);
            this.Controls.Add(this.TxtIndexCountry);
            this.Controls.Add(this.TxtItemCity);
            this.Controls.Add(this.TxtIndexCity);
            this.Controls.Add(this.TxtItemGdp);
            this.Controls.Add(this.TxtIndexGdp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LsbHappyCountry);
            this.Controls.Add(this.LsbGoodCity);
            this.Controls.Add(this.LsbGdpCountry);
            this.Name = "MainFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Listbox Test";
            this.Load += new System.EventHandler(this.MainFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LsbGdpCountry;
        private System.Windows.Forms.ListBox LsbGoodCity;
        private System.Windows.Forms.ListBox LsbHappyCountry;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtIndexGdp;
        private System.Windows.Forms.TextBox TxtItemGdp;
        private System.Windows.Forms.TextBox TxtIndexCity;
        private System.Windows.Forms.TextBox TxtItemCity;
        private System.Windows.Forms.TextBox TxtIndexCountry;
        private System.Windows.Forms.TextBox TxtItemCountry;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BtnInit;
    }
}

