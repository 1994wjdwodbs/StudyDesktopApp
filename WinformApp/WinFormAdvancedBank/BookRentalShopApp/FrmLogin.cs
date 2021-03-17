using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class FrmLogin : MetroForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // 폼 활성화, 포커스 제공
            // this.Activate();
            // TxtUserId.Focus();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var strUserId = string.Empty; // 

            if (string.IsNullOrEmpty(TxtUserId.Text) || string.IsNullOrEmpty(TxtPassword.Text))
            {
                MetroMessageBox.Show(this, "아이디/패스워드를 입력하세요!", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // MessageBox.Show("아이디/패스워드를 입력하세요!", "오류",
                //    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            { }

            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var query = " SELECT userID FROM memberTBL " +
                                " WHERE userID = @userId " +
                                " AND passwords = @passwords " +
                                " AND levels = 'S'; ";

                    // SqlCommand 생성
                    SqlCommand cmd = new SqlCommand(query, conn);

                    // SQLInjection 해킹 막기위해서 사용
                    SqlParameter pUserID = new SqlParameter("@userId", SqlDbType.VarChar, 20);
                    pUserID.Value = TxtUserId.Text;
                    SqlParameter pPasswords = new SqlParameter("@passwords", SqlDbType.VarChar, 20);
                    pPasswords.Value = TxtPassword.Text;

                    cmd.Parameters.Add(pUserID);
                    cmd.Parameters.Add(pPasswords);
                    cmd.Prepare();

                    // ~~~ (SQL 처리)
                    // ~~~ ...

                    // SqlDataReader 실행(1)
                    SqlDataReader reader = cmd.ExecuteReader();

                    // reader로 처리...
                    reader.Read();
                    strUserId = reader["userID"] != null ? reader["userID"].ToString() : string.Empty;
                    reader.Close();

                    // MessageBox.Show(strUserId);
                    if (string.IsNullOrEmpty(strUserId))
                    {
                        MetroMessageBox.Show(this, "접속실패", "로그인실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var updateQuery = $@"UPDATE membertbl 
                                             SET lastLoginDt = GETDATE(), loginIpAddr = '{Helper.Common.GetLocalIp()}'
                                             WHERE userId = '{strUserId}' "; // 로그인 정보 남기기
                        cmd.CommandText = updateQuery;
                        cmd.ExecuteNonQuery();

                        MetroMessageBox.Show(this, "접속성공", "로그인성공", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"Error : {ex.Message}", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtUserId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // 엔터
                TxtPassword.Focus();
        }

        private void TxtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // 엔터
                BtnLogin.Focus();
        }
    }
}
