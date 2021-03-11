
namespace AlarmClockApp
{
    partial class FrmAlarm
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
            this.components = new System.ComponentModel.Container();
            this.tabDigitalClock = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblTime = new System.Windows.Forms.Label();
            this.LblAlarm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TapAlarm = new System.Windows.Forms.TabPage();
            this.BtnRelease = new System.Windows.Forms.Button();
            this.BtnSetting = new System.Windows.Forms.Button();
            this.DtpAlarmTime = new System.Windows.Forms.DateTimePicker();
            this.DtpAlarmDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabClock = new System.Windows.Forms.TabControl();
            this.MyTimer = new System.Windows.Forms.Timer(this.components);
            this.tabDigitalClock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TapAlarm.SuspendLayout();
            this.TabClock.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDigitalClock
            // 
            this.tabDigitalClock.Controls.Add(this.groupBox1);
            this.tabDigitalClock.Controls.Add(this.LblAlarm);
            this.tabDigitalClock.Controls.Add(this.label3);
            this.tabDigitalClock.Location = new System.Drawing.Point(4, 22);
            this.tabDigitalClock.Name = "tabDigitalClock";
            this.tabDigitalClock.Padding = new System.Windows.Forms.Padding(3);
            this.tabDigitalClock.Size = new System.Drawing.Size(380, 328);
            this.tabDigitalClock.TabIndex = 1;
            this.tabDigitalClock.Text = "디지털시계";
            this.tabDigitalClock.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblDate);
            this.groupBox1.Controls.Add(this.LblTime);
            this.groupBox1.Location = new System.Drawing.Point(30, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 213);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "현재시간";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(28, 32);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(30, 12);
            this.LblDate.TabIndex = 3;
            this.LblDate.Text = "Date";
            // 
            // LblTime
            // 
            this.LblTime.AutoSize = true;
            this.LblTime.Font = new System.Drawing.Font("나눔고딕코딩", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblTime.Location = new System.Drawing.Point(28, 66);
            this.LblTime.Name = "LblTime";
            this.LblTime.Size = new System.Drawing.Size(79, 32);
            this.LblTime.TabIndex = 2;
            this.LblTime.Text = "Time";
            // 
            // LblAlarm
            // 
            this.LblAlarm.AutoSize = true;
            this.LblAlarm.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.LblAlarm.Location = new System.Drawing.Point(41, 69);
            this.LblAlarm.Name = "LblAlarm";
            this.LblAlarm.Size = new System.Drawing.Size(58, 12);
            this.LblAlarm.TabIndex = 1;
            this.LblAlarm.Text = "Alarm : ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "알람설정";
            // 
            // TapAlarm
            // 
            this.TapAlarm.Controls.Add(this.BtnRelease);
            this.TapAlarm.Controls.Add(this.BtnSetting);
            this.TapAlarm.Controls.Add(this.DtpAlarmTime);
            this.TapAlarm.Controls.Add(this.DtpAlarmDate);
            this.TapAlarm.Controls.Add(this.label2);
            this.TapAlarm.Controls.Add(this.label1);
            this.TapAlarm.Location = new System.Drawing.Point(4, 22);
            this.TapAlarm.Name = "TapAlarm";
            this.TapAlarm.Padding = new System.Windows.Forms.Padding(3);
            this.TapAlarm.Size = new System.Drawing.Size(380, 328);
            this.TapAlarm.TabIndex = 0;
            this.TapAlarm.Text = "알람설정";
            this.TapAlarm.UseVisualStyleBackColor = true;
            // 
            // BtnRelease
            // 
            this.BtnRelease.Location = new System.Drawing.Point(281, 289);
            this.BtnRelease.Name = "BtnRelease";
            this.BtnRelease.Size = new System.Drawing.Size(93, 33);
            this.BtnRelease.TabIndex = 5;
            this.BtnRelease.Text = "해제";
            this.BtnRelease.UseVisualStyleBackColor = true;
            this.BtnRelease.Click += new System.EventHandler(this.BtnRelease_Click);
            // 
            // BtnSetting
            // 
            this.BtnSetting.Location = new System.Drawing.Point(182, 289);
            this.BtnSetting.Name = "BtnSetting";
            this.BtnSetting.Size = new System.Drawing.Size(93, 33);
            this.BtnSetting.TabIndex = 4;
            this.BtnSetting.Text = "설정";
            this.BtnSetting.UseVisualStyleBackColor = true;
            this.BtnSetting.Click += new System.EventHandler(this.BtnSetting_Click);
            // 
            // DtpAlarmTime
            // 
            this.DtpAlarmTime.CustomFormat = "hh:mm:ss";
            this.DtpAlarmTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtpAlarmTime.Location = new System.Drawing.Point(22, 105);
            this.DtpAlarmTime.Name = "DtpAlarmTime";
            this.DtpAlarmTime.Size = new System.Drawing.Size(200, 21);
            this.DtpAlarmTime.TabIndex = 3;
            // 
            // DtpAlarmDate
            // 
            this.DtpAlarmDate.Location = new System.Drawing.Point(22, 35);
            this.DtpAlarmDate.Name = "DtpAlarmDate";
            this.DtpAlarmDate.Size = new System.Drawing.Size(200, 21);
            this.DtpAlarmDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "시간 설정";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "날짜 설정";
            // 
            // TabClock
            // 
            this.TabClock.Controls.Add(this.TapAlarm);
            this.TabClock.Controls.Add(this.tabDigitalClock);
            this.TabClock.Location = new System.Drawing.Point(12, 12);
            this.TabClock.Name = "TabClock";
            this.TabClock.SelectedIndex = 0;
            this.TabClock.Size = new System.Drawing.Size(388, 354);
            this.TabClock.TabIndex = 0;
            // 
            // MyTimer
            // 
            this.MyTimer.Enabled = true;
            this.MyTimer.Interval = 1000;
            // 
            // FrmAlarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 378);
            this.Controls.Add(this.TabClock);
            this.Name = "FrmAlarm";
            this.Text = "알람시계";
            this.Load += new System.EventHandler(this.FrmAlarm_Load);
            this.tabDigitalClock.ResumeLayout(false);
            this.tabDigitalClock.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TapAlarm.ResumeLayout(false);
            this.TapAlarm.PerformLayout();
            this.TabClock.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabDigitalClock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblTime;
        private System.Windows.Forms.Label LblAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage TapAlarm;
        private System.Windows.Forms.Button BtnRelease;
        private System.Windows.Forms.Button BtnSetting;
        private System.Windows.Forms.DateTimePicker DtpAlarmTime;
        private System.Windows.Forms.DateTimePicker DtpAlarmDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl TabClock;
        private System.Windows.Forms.Timer MyTimer;
    }
}

