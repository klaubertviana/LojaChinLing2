using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace LojaCL {

    public partial class FrmPedido : Form {

        SqlConnection con = Class1.obterConexao();

        public FrmPedido ( ) {
            
            InitializeComponent ( );

        }

        static int botaoclicado = 0; 

        public void CarregarCbxCartao() {

            String car = "SELECT * FROM cartaovenda";
            SqlCommand cmd = new SqlCommand(car, con);
            Class1.obterConexao ( );
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(car, con);
            DataSet ds = new DataSet();
            da.Fill ( ds , "numero" );
            cbxCartao.ValueMember = "Id";
            cbxCartao.DisplayMember = "numero";
            cbxCartao.DataSource = ds.Tables["numero"];
            Class1.fecharConexao ( );

        }

        public void CarregarCbxProduto ( ) {

            String pro = "SELECT Id, nome FROM produto";
            SqlCommand cmd = new SqlCommand(pro, con);
            Class1.obterConexao ( );
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(pro, con);
            DataSet ds = new DataSet();
            da.Fill ( ds , "nome" );
            cbxProduto.ValueMember = "Id";
            cbxProduto.DisplayMember = "nome";
            cbxProduto.DataSource = ds.Tables["nome"];
            Class1.fecharConexao ( );

        }
                     
        private void btnSair_Click ( object sender , EventArgs e ) {

            this.Close ( );
        }

        private void FrmPedido_Load ( object sender , EventArgs e ) {

            cbxProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            btnNovoItem.Enabled = false;
            btnFinalizar.Enabled = false;
            btnEcluirItem.Enabled = false;
            btnEditarItem.Enabled = false;
            btnAtualizar.Enabled = false;
            CarregarCbxCartao ( );
            cbxCartao.Text = ""; 

        }

        private void cbxCartao_SelectedIndexChanged ( object sender , EventArgs e ) {

            SqlCommand cmd = new SqlCommand("LocalizarCartaoVenda", con);
            cmd.Parameters.AddWithValue ( "@Id" , cbxCartao.SelectedValue );
            cmd.CommandType = CommandType.StoredProcedure;
            Class1.obterConexao ( );
            SqlDataReader rd = cmd.ExecuteReader();


            if (rd.Read()) {

                txtUsuario.Text = rd["usuario"].ToString ( );
                Class1.fecharConexao ( );
            }
            else {

                MessageBox.Show ( "Nenhum registro encontrado!" , "Falha na Pesquisa" , MessageBoxButtons.OK , MessageBoxIcon.Information);
                Class1.fecharConexao ( );

            }

        }

        private void btnPedido_Click ( object sender , EventArgs e ) {

            cbxProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            dgvPedido.Enabled = true;
            btnNovoItem.Enabled = true;
            btnFinalizar.Enabled = true;
            btnEcluirItem.Enabled = true;
            btnEditarItem.Enabled = true;
            btnAtualizar.Enabled = false;
            CarregarCbxProduto ( );
            cbxProduto.Text = "";
            dgvPedido.Columns.Add ( "ID" , "IDProduto" );
            dgvPedido.Columns.Add ( "Usuario" , "Usuario" );
            dgvPedido.Columns.Add ( "Produto" , "Produto" );
            dgvPedido.Columns.Add ( "Quantidade" , "Quantidade" );
            dgvPedido.Columns.Add ( "Valor" , "Valor" );
            dgvPedido.Columns.Add ( "Total" , "Total" );

        }

        private void cbxProduto_SelectedIndexChanged ( object sender , EventArgs e ) {

            SqlCommand cmd = new SqlCommand("LocalizarProduto", con);
            cmd.Parameters.AddWithValue ( "@Id" , cbxProduto.SelectedValue );
            cmd.CommandType = CommandType.StoredProcedure;
            Class1.obterConexao ( );
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.Read()) {

                txtValorTotal.Text = rd["valor"].ToString();
                txtID.Text = rd["Id"].ToString ( );
                Class1.fecharConexao ( );

            }
            else {

                MessageBox.Show ( "Nenhum registro encontrado!" , "Falha de pesquisa" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                Class1.fecharConexao ( );
            }
            
        }

        private void btnNovoItem_Click ( object sender , EventArgs e ) {

            if (botaoclicado ==1 ) {

                SqlCommand pedidos2 = new SqlCommand ("InserirPedidos", con);
                pedidos2.CommandType = CommandType.StoredProcedure;
                pedidos2.Parameters.AddWithValue ( "@Id_cartaovenda" , SqlDbType.Int ).Value = cbxCartao.SelectedValue;
                pedidos2.Parameters.AddWithValue ( "@Id_produto" , SqlDbType.Int ).Value = cbxProduto.SelectedValue;
                pedidos2.Parameters.AddWithValue ( "@usuario" , SqlDbType.NChar ).Value = txtUsuario.Text;
                pedidos2.Parameters.AddWithValue ( "@quantidade" , SqlDbType.Int ).Value = Convert.ToInt32 ( txtQuantidade.Text );
                pedidos2.Parameters.AddWithValue ( "@dia_hora" , SqlDbType.DateTime ).Value = DateTime.Now;
                pedidos2.Parameters.AddWithValue ( "@valor" , SqlDbType.Int ).Value = Convert.ToDecimal ( txtValorTotal.Text );
                pedidos2.Parameters.AddWithValue ( "@total" , SqlDbType.Int ).Value = Convert.ToDecimal ( txtQuantidade.Text ) * Convert.ToDecimal ( txtValorUnitario.Text );
                Class1.obterConexao ( );
                pedidos2.ExecuteNonQuery ( );
                Class1.fecharConexao ( );
                MessageBox.Show ( "Pedido Atualizado!" , "Atualizado Pedido" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                botaoclicado = 0; 

            }
            else {

                DataGridViewRow item = new DataGridViewRow();
                item.CreateCells ( dgvPedido );
                item.Cells[0].Value = txtID.Text;
                item.Cells[1].Value = txtUsuario.Text;
                item.Cells[2].Value = cbxProduto.Text;
                item.Cells[3].Value = txtQuantidade.Text;
                item.Cells[4].Value = txtValorUnitario.Text;
                item.Cells[5].Value = Convert.ToDecimal ( txtValorUnitario ) * Convert.ToDecimal ( txtQuantidade.Text );
                dgvPedido.Rows.Add ( item );
                cbxProduto.Text = "";
                cbxProduto.Text = "";
                txtValorUnitario.Text = "";
                txtQuantidade.Text = "";

                decimal soma = 0;

                foreach (DataGridViewRow dr in dgvPedido.Rows) {

                    soma += Convert.ToDecimal ( dr.Cells[5].Value );
                    txtValorTotal.Text = Convert.ToString ( soma );
                }
                 
            }
        }

        private void dgvPedido_CellClick ( object sender , DataGridViewCellEventArgs e ) {

            DataGridViewRow row = this.dgvPedido.Rows[e.RowIndex];
            cbxProduto.Text = row.Cells[2].Value.ToString ( );
            txtQuantidade.Text = row.Cells[3].Value.ToString ( );
            txtValorUnitario.Text = row.Cells[4].Value.ToString ( );
            int linha = dgvPedido.CurrentRow.Index;


        }

        private void btnEditarItem_Click ( object sender , EventArgs e ) {

            int linha = dgvPedido.CurrentRow.Index;
            dgvPedido.Rows[linha].Cells[0].Value = txtID.Text;
            dgvPedido.Rows[linha].Cells[2].Value = cbxProduto.Text;
            dgvPedido.Rows[linha].Cells[3].Value = txtQuantidade.Text;
            dgvPedido.Rows[linha].Cells[4].Value = txtValorUnitario.Text;
            dgvPedido.Rows[linha].Cells[5].Value = Convert.ToDecimal ( txtValorTotal.Text ) * Convert.ToDecimal ( txtQuantidade.Text );

            decimal soma = 0;
            
            foreach (DataGridViewRow dr in dgvPedido.Rows) {

                soma += Convert.ToDecimal ( dr.Cells[5].Value );
                txtValorTotal.Text = Convert.ToString ( soma );
                cbxProduto.Text = "";
                txtQuantidade.Text = "";
                txtValorUnitario.Text = "";

            }

        }

        private void btnEcluirItem_Click ( object sender , EventArgs e ) {

            int linha = dgvPedido.CurrentRow.Index;
            string sql = "DELETE FROM pedido WHERE (id_cartaovenda = @id_cartaovenda AND id_produto = @id_produto)";
            SqlCommand cmd = new SqlCommand ( sql , con );
            DataGridViewRow row = dgvPedido.Rows[linha];
            cmd.Parameters.AddWithValue ( "@id_cartaovenda" , cbxCartao.SelectedValue );
            cmd.Parameters.AddWithValue ( "@id_produto" , row.Cells[0].Value );
            Class1.obterConexao ( );
            cmd.ExecuteNonQuery ( );
            Class1.fecharConexao ( );
            dgvPedido.Rows.RemoveAt ( linha );
            dgvPedido.Refresh ( );
            decimal soma = 0;

            foreach(DataGridViewRow dr in dgvPedido.Rows) {

                soma += Convert.ToDecimal ( dr.Cells[5].Value );
                txtValorTotal.Text = Convert.ToString ( soma );
                cbxProduto.Text = "";
                txtQuantidade.Text = "";
                txtValorUnitario.Text = "";

            }

        }

        private void btnFinalizar_Click ( object sender , EventArgs e ) {

            Class1.obterConexao ( );
            SqlCommand card = new SqlCommand("AtualizarStatusCartaoVenda", con);
            card.CommandType = CommandType.StoredProcedure;
            card.Parameters.AddWithValue ( "@Id" , SqlDbType.Int ).Value = cbxCartao.SelectedValue;

            foreach(DataGridViewRow dr in dgvPedido.Rows) {

                SqlCommand pedidos = new SqlCommand("InserirPedidos", con);
                pedidos.CommandType = CommandType.StoredProcedure;
                pedidos.Parameters.AddWithValue ( "@id_cartaovenda" , SqlDbType.Int ).Value = cbxCartao.SelectedValue;
                pedidos.Parameters.AddWithValue ( "@id_produto" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[0].Value );
                pedidos.Parameters.AddWithValue ( "@usuario" , SqlDbType.NChar ).Value = dr.Cells[1].Value;
                pedidos.Parameters.AddWithValue ( "@quantidade" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[3].Value );
                pedidos.Parameters.AddWithValue ( "@dia_hora" , SqlDbType.DateTime ).Value = DateTime.Now;
                pedidos.Parameters.AddWithValue ( "@valor" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[4].Value );
                pedidos.Parameters.AddWithValue ( "@total" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[5].Value );
                Class1.obterConexao ( );
                pedidos.ExecuteNonQuery ( );
                card.ExecuteNonQuery ( );
                Class1.fecharConexao ( );

            }

            MessageBox.Show ( "Pedidos realizados com sucesso!" , "Pedido" , MessageBoxButtons.OK , MessageBoxIcon.Information );

            cbxProduto.Text = "";
            txtQuantidade.Text = "";
            txtValorUnitario.Text = "";
            txtValorTotal.Text = "";
            cbxProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValorUnitario.Enabled = false;
            btnNovoItem.Enabled = false;
            btnEditarItem.Enabled = false;
            btnEcluirItem.Enabled = false;
            btnFinalizar.Enabled = false;

            dgvPedido.Rows.Clear ( );
            dgvPedido.Refresh ( );
            FrmPrincipal obj = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];
            obj.CarregaDgvCartao ( );

        }

        private void btnLocalizar_Click ( object sender , EventArgs e ) {

            botaoclicado = 1;
            cbxProduto.Enabled = true;
            txtQuantidade.Enabled = true;
            btnNovoItem.Enabled = true;
            btnEcluirItem.Enabled = true;
            btnEditarItem.Enabled = true;
            btnFinalizar.Enabled = true;
            CarregarCbxProduto ( );

            try {

                SqlConnection con = Class1.obterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "LocalizarPedidoGrid";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ( "@id_cartaovenda" , cbxCartao.SelectedValue );
                Class1.obterConexao ( );
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                if (ds.Tables[0].Rows.Count > 0 ) {

                    dgvPedido.ReadOnly = true;
                    dgvPedido.DataSource = ds.Tables[0];
                    Class1.fecharConexao ( );

                }
                else {

                    MessageBox.Show ( "Nenhum registro encontrado!" , "Falha" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    Class1.fecharConexao ( );

                }

                decimal soma = 0;

                foreach (DataGridViewRow dr in dgvPedido.Rows) {

                    soma += Convert.ToDecimal ( dr.Cells[5].Value );
                    txtValorTotal.Text = Convert.ToString ( soma );
                    
                }

            } catch (Exception er) {

                MessageBox.Show ( "Erro: " + er );
            }

        }

        private void btnAtualizar_Click ( object sender , EventArgs e ) {

            Class1.obterConexao ( );

            foreach ( DataGridViewRow dr in dgvPedido.Rows ) {

                SqlCommand pedidos = new SqlCommand("AtualizarPedidos", con);
                pedidos.CommandType = CommandType.StoredProcedure;
                pedidos.Parameters.AddWithValue ( "@id_cartaovenda" , SqlDbType.Int ).Value = cbxCartao.SelectedValue;
                pedidos.Parameters.AddWithValue ( "@id_produto" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[0].Value );
                pedidos.Parameters.AddWithValue ( "@usuario" , SqlDbType.NChar ).Value = dr.Cells[1].Value;
                pedidos.Parameters.AddWithValue ( "@quantidade" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[3].Value );
                pedidos.Parameters.AddWithValue ( "@dia_hora" , SqlDbType.DateTime ).Value = DateTime.Now;
                pedidos.Parameters.AddWithValue ( "@valor" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[4].Value );
                pedidos.Parameters.AddWithValue ( "@total" , SqlDbType.Int ).Value = Convert.ToInt32 ( dr.Cells[5].Value );
                Class1.obterConexao ( );
                pedidos.ExecuteNonQuery ( );                
                Class1.fecharConexao ( );

            }
            MessageBox.Show ( "Pedido Atualizado com sucesso!" , "Atualizar" , MessageBoxButtons.OK , MessageBoxIcon.Information);
            Class1.fecharConexao ( );

            cbxProduto.Text = "";
            txtQuantidade.Text = "";
            txtValorUnitario.Text = "";
            txtValorTotal.Text = "";
            cbxProduto.Enabled = false;
            txtQuantidade.Enabled = false;
            txtValorUnitario.Enabled = false;
            txtValorTotal.Enabled = false;
            btnNovoItem.Enabled = false;
            btnEditarItem.Enabled = false;
            btnEcluirItem.Enabled = false;
            btnFinalizar.Enabled = false;
            dgvPedido.Enabled = false;
            dgvPedido.DataSource = null;

            FrmPrincipal obj = (FrmPrincipal)Application.OpenForms["FrmPrincipal"];
            obj.CarregaDgvCartao ( );

        }
    }
}
