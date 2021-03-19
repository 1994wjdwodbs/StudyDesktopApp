using MetroFramework;
using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookRentalShopApp
{
    public partial class FrmRental : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규
        private bool IsNew { get; set; }
        private bool DelFlag { get; set; }

        public string test;

        #endregion

        #region 이벤트 영역
        public FrmRental()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            InitCboData(); // 콤보박스 데이터 초기화
            RefreshData();

            DtpRentalDate.CustomFormat = "yyyy-MM-dd";
            DtpRentalDate.Format = DateTimePickerFormat.Custom;

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
                BtnSearchBook.Enabled = BtnSearchMember.Enabled = false;
                DtpRentalDate.Enabled = false;
            }
        }

        private void AsignToControls(DataGridViewRow selData)
        {

            TxtIdx.Text = selData.Cells[0].Value.ToString();
            selMemberIdx = (int)selData.Cells[1].Value;
            // 디버그 모드에서만 표시
            Debug.WriteLine($">>>> selMemberIdx : {selMemberIdx}");
            TxtMemberName.Text = selData.Cells[2].Value.ToString();
            selBookIdx = (int)selData.Cells[3].Value;
            TxtBookName.Text = selData.Cells[4].Value.ToString();
            // CboDivision.SelectedValue = selData.Cells[2].Value; // 값으로 매칭
            // selData.Cells[3].Value 안씀
            // TxtNames.Text = selData.Cells[4].Value.ToString();
            // ReleaseDate
            Debug.WriteLine($">>>> 문제의 값 : {selData.Cells[6].Value}");
            
            DtpRentalDate.Value = (DateTime) selData.Cells[5].Value;
            if (!(selData.Cells[6].Value is DBNull))
                DtpReturnDate.Value = (DateTime)selData.Cells[6].Value;
            else
                DtpReturnDate.Value = new DateTime(1900, 12, 31);


            CboRentalState.SelectedValue = selData.Cells[7].Value;
            // TxtISBN.Text = selData.Cells[6].Value.ToString();
            // TxtPrice.Text = selData.Cells[7].Value.ToString();
            // TxtDescriptions.Text = selData.Cells[8].Value.ToString();
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
                var temp = new Dictionary<string, string>();
                temp.Add("R", "대여중");
                temp.Add("T", "반납");

                CboRentalState.DataSource = new BindingSource(temp, null);
                CboRentalState.DisplayMember = "Value";
                CboRentalState.ValueMember = "Key";
                CboRentalState.SelectedIndex = -1;

                using (SqlConnection conn = new SqlConnection(Helper.Common.ConnString))
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();

                    string query = "SELECT Division, Names FROM dbo.divtbl";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        // var temp = new Dictionary<string, string>();
                        while (reader.Read())
                        {
                            // Key : Divisions , Value : Names
                        //    temp.Add(reader[0].ToString(), reader[1].ToString());
                        }
                        
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
                    var query = @"SELECT r.Idx
                                      ,r.memberIdx
                                      ,m.Names AS memberName
	                                  ,r.bookIdx
	                                  ,b.Names AS bookName
                                      ,r.rentalDate
                                      ,r.returnDate
	                                  ,r.rentalState
	                                  ,CASE r.rentalState 
		                                WHEN 'R' then '대여중'
		                                WHEN 'T' then '반납'
		                                ELSE '상태없음' END
	                                   AS StateDesc 
                                  FROM [dbo].[rentaltbl] AS r
                                  JOIN dbo.membertbl AS m
                                  ON (r.memberIdx = m.Idx)
                                  JOIN dbo.bookstbl AS b
                                  ON (r.bookIdx = b.Idx)"; 
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
            DgvData.Columns[1].Visible = false; // memberIdx
            DgvData.Columns[3].Visible = false; // bookIdx
            DgvData.Columns[7].Visible = false; // rentalState

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
                        query = @"INSERT INTO [dbo].[rentaltbl]
                                       ([memberIdx]
                                       ,[bookIdx]
                                       ,[rentalDate]
                                       ,[rentalState])
                                 VALUES
                                       (@memberIdx
                                       ,@bookIdx
                                       ,@rentalDate
                                       ,@rentalState)";
                    }
                    else
                    {
                        query = @"UPDATE [dbo].[rentaltbl]
                                   SET [returnDate] = 
                                   CASE @rentalState
	                                WHEN 'T' THEN GETDATE()
	                                WHEN 'R' THEN NULL
                                   END
                                  , [rentalState] = @rentalState
                                WHERE Idx = @Idx";
                    }

                    cmd.CommandText = query;
                    if (IsNew)
                    {
                        SqlParameter pMemberIdx = new SqlParameter("@memberIdx", SqlDbType.Int);
                        pMemberIdx.Value = selMemberIdx;
                        cmd.Parameters.Add(pMemberIdx);

                        SqlParameter pBookIdx = new SqlParameter("@bookIdx", SqlDbType.Int);
                        pBookIdx.Value = selBookIdx;
                        cmd.Parameters.Add(pBookIdx);

                        SqlParameter pRentalDate = new SqlParameter("@rentalDate", SqlDbType.Date);
                        pRentalDate.Value = DtpRentalDate.Value;
                        cmd.Parameters.Add(pRentalDate);

                        SqlParameter pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);
                    }
                    else // 업데이트 일땐
                    {
                        SqlParameter pRentalState = new SqlParameter("@rentalState", SqlDbType.Char, 1);
                        pRentalState.Value = CboRentalState.SelectedValue;
                        cmd.Parameters.Add(pRentalState);

                        SqlParameter pIdx = new SqlParameter("@Idx", SqlDbType.Int);
                        pIdx.Value = TxtIdx.Text;
                        cmd.Parameters.Add(pIdx);
                    }

                    // cmd.Prepare();

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
            selMemberIdx = selBookIdx = 0;
            selMemberName = selBookName = string.Empty;
            TxtIdx.Text = TxtBookName.Text = TxtMemberName.Text = string.Empty;
            // TxtNames.Text = TxtISBN.Text = string.Empty;
            // TxtPrice.Text  = TxtDescriptions.Text = "";
            // CboDivision.SelectedIndex = -1;
            DtpRentalDate.Value = DateTime.Now; // 오늘 날짜로 초기화
            DtpReturnDate.Value = DateTime.Now; // 오늘 날짜로 초기화
            TxtIdx.ReadOnly = true;
            CboRentalState.SelectedIndex = -1;

            BtnSearchBook.Enabled = BtnSearchMember.Enabled = true;
            DtpRentalDate.Enabled = true;
            IsNew = true;
        }
        // 입력값 유효성 체크
        private bool CheckValidation()
        {
            // Validation 체크 (저자, 책이름, 장르, 출판일)
            if (string.IsNullOrEmpty(TxtMemberName.Text)
                || string.IsNullOrEmpty(TxtBookName.Text)
                || DtpRentalDate.Value == null
                || CboRentalState.SelectedIndex < 0)
                
            {
                MetroMessageBox.Show
                    (this, "빈 값은 처리할 수 없습니다.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        #endregion
        private int selMemberIdx = 0;
        private string selMemberName = string.Empty;

        private void BtnSearchMember_Click(object sender, EventArgs e)
        {
            FrmMemberPopup frm = new FrmMemberPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selMemberIdx = frm.SelIdx;
                TxtMemberName.Text = selMemberName = frm.SelName;
            }
        }

        private int selBookIdx = 0;
        private string selBookName = string.Empty;

        private void BtnSearchBook_Click(object sender, EventArgs e)
        {
            FrmBooksPopup frm = new FrmBooksPopup();
            frm.StartPosition = FormStartPosition.CenterParent;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                selBookIdx = frm.SelIdx;
                TxtBookName.Text = selBookName = frm.SelName;
            }
        }
    }
}
