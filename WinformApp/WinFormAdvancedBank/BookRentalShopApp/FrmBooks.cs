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
    public partial class FrmBooks : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규
        private bool IsNew { get; set; }
        private bool DelFlag { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmBooks()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            InitCboData(); // 콤보박스 데이터 초기화
            RefreshData();

            DtpReleaseDate.CustomFormat = "yyyy-MM-dd";
            DtpReleaseDate.Format = DateTimePickerFormat.Custom;

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

                AsignToControls(selData);
                IsNew = false; // 수정(플래그)로 변경
            }
        }

        private void AsignToControls(DataGridViewRow selData)
        {

            TxtIdx.Text = selData.Cells[0].Value.ToString();
            TxtAuthor.Text = selData.Cells[1].Value.ToString();
            CboDivision.SelectedValue = selData.Cells[2].Value; // 값으로 매칭
            // selData.Cells[3].Value 안씀
            TxtNames.Text = selData.Cells[4].Value.ToString();
            // ReleaseDate
            DtpReleaseDate.Value = (DateTime) selData.Cells[5].Value;
            TxtISBN.Text = selData.Cells[6].Value.ToString();
            TxtPrice.Text = selData.Cells[7].Value.ToString();
            TxtDescriptions.Text = selData.Cells[8].Value.ToString();

            TxtIdx.ReadOnly = !IsNew;
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

        private void InitCboData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "SELECT Division, Names FROM dbo.divtbl";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        var temp = new Dictionary<string, string>();
                        while (reader.Read())
                        {
                            // Key : Divisions , Value : Names
                            temp.Add(reader[0].ToString(), reader[1].ToString());
                        }
                        CboDivision.DataSource = new BindingSource(temp, null);
                        CboDivision.ValueMember = "Key";
                        CboDivision.DisplayMember = "Value";
                        CboDivision.SelectedIndex = -1;
                        
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

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
                    string query = "DELETE FROM dbo.bookstbl WHERE Idx = @Idx;";
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

                    // 21.03.18 : Descriptions 컬럼 추가
                    var query = @"SELECT b.[Idx]
                                      ,b.[Author]
                                      ,d.[Division]
                                      ,d.Names as [DivName]
	                                  ,b.Names
                                      ,b.[ReleaseDate]
                                      ,b.[ISBN]
                                      ,b.[Price]
                                      ,b.Descriptions
                                  FROM [dbo].[bookstbl] AS b
                                  INNER JOIN dbo.divtbl AS d
                                  ON b.Division = d.Division;"; 
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "bookstbl");

                    DgvData.DataSource = ds;
                    DgvData.DataMember = "bookstbl";
                }
            }
            catch (Exception ex)
            {
                MetroMessageBox.Show(this, $"예외발생 : {ex.Message}", "오류", MessageBoxButtons.OK);
            }

            // 데이터그리드뷰 컬럼(Division) 화면에서 안보이게 해줌
            DgvData.Columns[2].Visible = false; // Division Col
            DgvData.Columns[8].Visible = false; // Descriptions Col

            DgvData.Columns[4].Width = 250;
            DgvData.Columns[4].HeaderText = "도서명";

            DgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

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
                        query = @"INSERT INTO [dbo].[bookstbl]
                                       ([Author]
                                       ,[Division]
                                       ,[Names]
                                       ,[ReleaseDate]
                                       ,[ISBN]
                                       ,[Price]
                                       ,[Descriptions])
                                 VALUES
                                       ( @Author
                                       , @Division
                                       , @Names
                                       , @ReleaseDate
                                       , @ISBN
                                       , @Price
                                       , @Descriptions)";
                    }
                    else
                    {
                        query = @"UPDATE [dbo].[bookstbl]
                                   SET [Author] = @Author
                                      ,[Division] = @Division
                                      ,[Names] = @Names
                                      ,[ReleaseDate] = @ReleaseDate
                                      ,[ISBN] = @ISBN
                                      ,[Price] = @Price
                                      ,[Descriptions] = @Descriptions
                                 WHERE Idx = @Idx ";
                    }

                    cmd.CommandText = query;

                    SqlParameter pAuthor = new SqlParameter("@Author", SqlDbType.NVarChar, 50);
                    pAuthor.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pAuthor);

                    SqlParameter pDivision = new SqlParameter("@Division", SqlDbType.VarChar, 8);
                    pDivision.Value = CboDivision.SelectedValue; // B001
                    cmd.Parameters.Add(pDivision);

                    SqlParameter pNames = new SqlParameter("@Names", SqlDbType.NVarChar, 100);
                    pNames.Value = TxtAuthor.Text;
                    cmd.Parameters.Add(pNames);

                    SqlParameter pReleaseDate = new SqlParameter("@ReleaseDate", SqlDbType.Date, 10);
                    pReleaseDate.Value = DtpReleaseDate.Value;
                    cmd.Parameters.Add(pReleaseDate);

                    SqlParameter pISBN = new SqlParameter("@ISBN", SqlDbType.VarChar, 200);
                    pISBN.Value = TxtISBN.Text;
                    cmd.Parameters.Add(pISBN);

                    SqlParameter pPrice = new SqlParameter("@Price", SqlDbType.Decimal, TxtPrice.Text.Length);
                    pPrice.Precision = 10;
                    pPrice.Scale = 0;
                    pPrice.Value = decimal.Parse(TxtPrice.Text);
                    cmd.Parameters.Add(pPrice);

                    SqlParameter pDescriptions = new SqlParameter("@Descriptions", SqlDbType.NVarChar, TxtDescriptions.Text.Length);
                    pDescriptions.Value = TxtDescriptions.Text;
                    cmd.Parameters.Add(pDescriptions);

                    if (!IsNew)
                    {
                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int, TxtIdx.Text.Length);
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
            TxtIdx.Text = TxtAuthor.Text = string.Empty;
            TxtNames.Text = TxtISBN.Text = string.Empty;
            TxtPrice.Text  = TxtDescriptions.Text = "";
            CboDivision.SelectedIndex = -1;
            DtpReleaseDate.Value = DateTime.Now; // 오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            IsNew = true;
        }
        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // Validation 체크 (저자, 책이름, 장르, 출판일)
            if (string.IsNullOrEmpty(TxtAuthor.Text)
                || string.IsNullOrEmpty(TxtNames.Text)
                || CboDivision.SelectedIndex == -1
                || DtpReleaseDate.Value == null)
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
