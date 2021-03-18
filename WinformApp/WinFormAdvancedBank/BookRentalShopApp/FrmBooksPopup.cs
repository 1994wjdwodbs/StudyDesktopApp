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
    public partial class FrmBooksPopup : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규
        private bool IsNew { get; set; }
        private bool DelFlag { get; set; }


        public int SelIdx { get; set; }
        public string SelName { get; set; }


        #endregion

        #region 이벤트 영역
        public FrmBooksPopup()
        {
            InitializeComponent();
        }
        private void FrmDivCode_Load(object sender, EventArgs e)
        {
            RefreshData();
            // 초기 셀 선택 모드
            DgvData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void FrmDivCode_Resize(object sender, EventArgs e)
        {
        }

        private void DgvData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택된 값이 존재하면
            if (e.RowIndex > -1)
            {
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
            

            DgvData.Columns[4].Width = 250;
            DgvData.Columns[4].HeaderText = "도서명";

            DgvData.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

        }


        #endregion

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvData.SelectedRows.Count == 4)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelIdx = (int)DgvData.SelectedRows[0].Cells[0].Value;
            SelName = (string)DgvData.SelectedRows[0].Cells[4].Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
