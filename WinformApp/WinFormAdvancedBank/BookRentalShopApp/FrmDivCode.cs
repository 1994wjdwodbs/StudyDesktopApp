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
    public partial class FrmDivCode : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규
        private bool IsNew { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmDivCode()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData();
            IsNew = true; // 신규로 초기화
            TxtDivision.ReadOnly = !IsNew;
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
                TxtDivision.Text = selData.Cells[0].Value.ToString();
                TxtNames.Text = selData.Cells[1].Value.ToString();

                IsNew = false; // 수정(플래그)로 변경
                TxtDivision.ReadOnly = !IsNew;
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
                    string query = "DELETE FROM dbo.divtbl WHERE Division = @Division;";
                    cmd.CommandText = query;

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(pDivision);
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

                    var query = "SELECT [Division], [Names] FROM [dbo].[divtbl] ";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "divtbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "divtbl";
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
                        query = "INSERT INTO dbo.divtbl VALUES (@Division, @Names);";
                    }
                    else
                    {
                        query = "UPDATE dbo.divtbl SET Names = @Names WHERE Division = @Division;";
                    }

                    cmd.CommandText = query;

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 45);
                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pNames.Value = TxtNames.Text;
                    pDivision.Value = TxtDivision.Text;
                    cmd.Parameters.Add(pNames);
                    cmd.Parameters.Add(pDivision);
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
            TxtDivision.Text = string.Empty;
            TxtNames.Text = string.Empty;
            TxtDivision.ReadOnly = false;
            IsNew = true;
        }
        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // Validation 체크
            if (string.IsNullOrEmpty(TxtDivision.Text) || string.IsNullOrEmpty(TxtNames.Text))
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
