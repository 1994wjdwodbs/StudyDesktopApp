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
    public partial class FrmMember : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규
        private bool IsNew { get; set; }
        private bool DelFlag { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmMember()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData();
            IsNew = true; // 신규로 초기화
            TxtIdx.ReadOnly = !IsNew;
        }
        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
            DgvData.Height = this.ClientRectangle.Height - 90;
            GrbDetail.Height = this.ClientRectangle.Height - 90;
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택된 값이 존재하면
            if (e.RowIndex > -1)
            {
                var selData = DgvData.Rows[e.RowIndex];
                TxtIdx.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();
                CboLevels.SelectedItem = selData.Cells[2].Value;

                TxtAddr.Text = selData.Cells[3].Value.ToString();
                TxtMobile.Text = selData.Cells[4].Value.ToString();
                TxtEmail.Text = selData.Cells[5].Value.ToString();
                TxtId.Text = selData.Cells[6].Value.ToString();

                IsNew = false; // 수정(플래그)로 변경
                TxtIdx.ReadOnly = !IsNew;
            }
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (!CheckValidation())
                return;

            if (MetroMessageBox.Show(this, "삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            DeleteData();
            RefreshData();
            ClearInputs();
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation 체크
            if (!CheckValidation())
                return;

            SaveData();
            RefreshData();
        }
        #endregion

        #region 사용자 커스텀 메서드 영역
        private void DeleteData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string query = "DELETE FROM dbo.membertbl WHERE Idx = @Idx;";
                    cmd.CommandText = query;

                    SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.VarChar, 8);
                    pIdx.Value = TxtIdx.Text;
                    cmd.Parameters.Add(pIdx);
                    cmd.Prepare();

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    { // 저장 성공
                        MetroMessageBox.Show(this, "삭제 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    { // 저장 실패
                        MetroMessageBox.Show(this, "삭제 실패", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK);
            }
        }

        private void RefreshData()
        {
            // throw new NotImplementedException();
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    var query = @"SELECT [Idx]
                              ,[Names]
                              ,[Levels]
                              ,[Addr]
                              ,[Mobile]
                              ,[Email]
                              ,[userID]
                              ,[lastLoginDt]
                              ,[loginIpAddr]
                          FROM [dbo].[membertbl]";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "membertbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "membertbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK);
            }
        }

        private void SaveData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    string query;

                    if (IsNew)
                    {
                        query = @"INSERT INTO [dbo].[membertbl]
                                       ([Names]
                                       ,[Levels]
                                       ,[Addr]
                                       ,[Mobile]
                                       ,[Email]
                                       ,[userID]
                                       ,[passwords])
                                 VALUES
                                       ( @Names
                                       , @Levels
                                       , @Addr
                                       , @Mobile
                                       , @Email
                                       , @userID
                                       , @passwords)";
                    }
                    else
                    {
                        query = @"UPDATE [dbo].[membertbl]
                               SET [Names] = @Names
                                  ,[Levels] = @Levels
                                  ,[Addr] = @Addr
                                  ,[Mobile] = @Mobile
                                  ,[Email] = @Email
                                  ,[userID] = @userID
                                  ,[passwords] = @passwords
                             WHERE Idx = @Idx;";
                    }

                    cmd.CommandText = query;

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 50);
                    pNames.Value = TxtNames.Text;
                    cmd.Parameters.Add(pNames);

                    SqlParameter pLevels = new SqlParameter("@Levels", SqlDbType.Char, 1);
                    pLevels.Value = CboLevels.SelectedItem.ToString();
                    cmd.Parameters.Add(pLevels);

                    SqlParameter pAddr = new SqlParameter("@Addr", SqlDbType.NVarChar, 100);
                    pAddr.Value = TxtAddr.Text;
                    cmd.Parameters.Add(pAddr);

                    SqlParameter pMobile = new SqlParameter("@Mobile", SqlDbType.VarChar, 13);
                    pMobile.Value = TxtMobile.Text;
                    cmd.Parameters.Add(pMobile);

                    SqlParameter pEmail = new SqlParameter("@Email", SqlDbType.VarChar, 50);
                    pEmail.Value = TxtEmail.Text;
                    cmd.Parameters.Add(pEmail);

                    SqlParameter pUserId = new SqlParameter("@UserID", SqlDbType.NVarChar, 20);
                    pUserId.Value = TxtId.Text;
                    cmd.Parameters.Add(pUserId);

                    SqlParameter pPasswords = new SqlParameter("@passwords", SqlDbType.NVarChar, 13);
                    pPasswords.Value = TxtPasswords.Text;
                    cmd.Parameters.Add(pPasswords);

                    if (!IsNew)
                    {
                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    cmd.Prepare();

                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    { // 저장 성공
                        MetroMessageBox.Show(this, "저장 성공", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    { // 저장 실패
                        MetroMessageBox.Show(this, "저장 실패", "저장",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK);
            }
        }
        private void ClearInputs()
        {
            TxtIdx.Text = TxtNames.Text = string.Empty;
            TxtMobile.Text = TxtAddr.Text = TxtEmail.Text = string.Empty;
            TxtId.Text = TxtPasswords.Text = "";
            CboLevels.SelectedIndex = -1;
            TxtIdx.ReadOnly = true;
            IsNew = true;
        }
        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // Validation 체크
            if (string.IsNullOrEmpty(TxtNames.Text)
                || string.IsNullOrEmpty(TxtAddr.Text) || string.IsNullOrEmpty(TxtMobile.Text)
                || string.IsNullOrEmpty(TxtEmail.Text) || CboLevels.SelectedIndex == -1
                || string.IsNullOrEmpty(TxtId.Text))
            {
                MetroMessageBox.Show
                    (this, "빈 값은 처리할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
        
    }
}
