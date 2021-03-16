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

namespace AddressInfoApp
{
    public partial class FrmMain : Form
    {
        public string Conn = "Data Source=127.0.0.1;" +
            "Initial Catalog=PMS;" +
            "Persist Security Info=True;" +
            "User ID=sa;" +
            "Password=mssql_p@ssw0rd!";

        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnInit_Click(object sender, EventArgs e)
        {
            RefreshData();
            ClearInput();
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IdxBox.Text, out int result))
            {
                if (result > 0)
                {
                    MessageBox.Show("초기화를 하십시오.");
                    return;
                }
            }

            if(string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("값을 입력하세요.");
                return;
            }

                using (SqlConnection conn = new SqlConnection(Conn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                // SqlCommand, SqlDataReader or Object 사용 방법

                // 1. SqlCommand
                // SqlCommand cmd = new SqlCommand(query, conn);
                // SqlDataReader reader = cmd.ExecuteReader();

                string query = $"INSERT INTO dbo.Address " + 
                               $"( FullName, " +
                               $" Mobile, " +
                               $" Address, " +
                               $" RegId, " +
                               $" RegDate) " +
                               $" VALUES " +
                               $"( '{NameBox.Text}', " +
                               $" '{maskedTextBox1.Text.Replace("-","")}', " +
                               $" '{AddressBox.Text}', " +
                               $" 'admin', " +
                               $" GETDATE() ); ";

                SqlCommand cmd = new SqlCommand(query, conn);
                if (cmd.ExecuteNonQuery() == 1)
                    MessageBox.Show("입력 성공!");
                else
                    MessageBox.Show("입력 실패!");
            }

            RefreshData();
            ClearInput();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (int.TryParse(IdxBox.Text, out int result))
            {
                if (result == 0)
                {
                    MessageBox.Show("데이터를 선택하십시오.");
                    return;
                }
                else
                {
                    using (SqlConnection conn = new SqlConnection(Conn))
                    {
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();

                        string query = $"UPDATE Address " +
                                       $" SET " +
                                       $" FullName = '{NameBox.Text}', " +
                                       $" Mobile = '{maskedTextBox1.Text.Replace("-", "")}', " +
                                       $" Address = '{AddressBox.Text}', " +
                                       $" ModId = 'admin', " +
                                       $" ModDate = GETDATE() " +
                                       $" WHERE Idx = {result} ;";

                        SqlCommand cmd = new SqlCommand(query, conn);
                        if (cmd.ExecuteNonQuery() == 1)
                            MessageBox.Show("수정 성공!");
                        else
                            MessageBox.Show("수정 실패!");
                        RefreshData();
                        ClearInput();
                    }
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if(int.TryParse(IdxBox.Text, out int result))
            {
                if (result == 0)
                {
                    MessageBox.Show("데이터를 선택하십시오.");
                    return;
                }
                else
                {
                    if (MessageBox.Show("삭제하시겠습니까?", "삭제",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (SqlConnection conn = new SqlConnection(Conn))
                        {
                            if (conn.State == ConnectionState.Closed)
                                conn.Open();

                            string query = $"DELETE FROM dbo.Address WHERE idx = {result};";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            if (cmd.ExecuteNonQuery() == 1)
                                MessageBox.Show("삭제 성공!");
                            else
                                MessageBox.Show("삭제 실패!");
                            RefreshData();
                            ClearInput();
                        }
                    }
                }
            }
        }

        private void NameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // 엔터(13)
                maskedTextBox1.Focus();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                AddressBox.Focus();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            using (SqlConnection conn = new SqlConnection(Conn))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();

                string query = " SELECT Idx, FullName, Mobile, Address " +
                               " FROM dbo.Address ";

                // SqlCommand, SqlDataReader or Object 사용 방법


                // 2. SqlDataAdapter & DateSet
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                DgvAddress.DataSource = ds.Tables[0];
            }
        }

        private void ClearInput()
        {
            IdxBox.Text = NameBox.Text = maskedTextBox1.Text = AddressBox.Text = string.Empty;
        }

        private void DgvAddress_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectData = DgvAddress.Rows[e.RowIndex].Cells;

            IdxBox.Text = selectData[0].Value.ToString();
            NameBox.Text = selectData[1].Value.ToString();
            maskedTextBox1.Text = selectData[2].Value.ToString();
            AddressBox.Text = selectData[3].Value.ToString();
        }
    }
}
