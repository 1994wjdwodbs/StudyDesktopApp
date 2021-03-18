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
    public partial class FrmMemberPopup : MetroForm
    {
        #region 전역 변수 영역
        // false : 수정, true : 신규


        public int SelIdx { get; set; }
        public string SelName { get; set; }

        private bool DelFlag { get; set; }

        #endregion

        #region 이벤트 영역
        public FrmMemberPopup()
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


        #endregion

        #region 사용자 커스텀 메서드 영역

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

        #endregion

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void BtnSelect_Click(object sender, EventArgs e)
        {
            if (DgvData.SelectedRows.Count == 0)
            {
                MetroMessageBox.Show(this, "데이터를 선택하세요.", "경고", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SelIdx = (int) DgvData.SelectedRows[0].Cells[0].Value;
            SelName = (string) DgvData.SelectedRows[0].Cells[1].Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
