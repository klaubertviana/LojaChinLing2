using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LojaCL {
    public partial class FrmCrudCartao : Form {
        public FrmCrudCartao ( ) {
            InitializeComponent ( );
            CarregaDgvCartao ( );
        }

        public void CarregaDgvCartao ( ) {
            SqlConnection con = Class1.obterConexao();
            String query = "select * from cartaovenda";
            SqlCommand cmd = new SqlCommand(query, con);
            Class1.obterConexao ( );
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable cartao = new DataTable();
            da.Fill ( cartao );
            dgvCartaoVenda.DataSource = cartao;
            Class1.fecharConexao ( );
        }

        private void lblCpf_Click ( object sender , EventArgs e ) {

        }

        private void btnSair_Click ( object sender , EventArgs e ) {
            this.Close ( );
        }

        private void btnCadastro_Click ( object sender , EventArgs e ) {
            try {
                SqlConnection con = Class1.obterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "InserirCartaoVenda";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ( "@numero" , this.txtNumero.Text );
                cmd.Parameters.AddWithValue ( "@usuario" , this.txtUsuario.Text );
                Class1.obterConexao ( );
                cmd.ExecuteNonQuery ( );
                CarregaDgvCartao ( );
                MessageBox.Show ( "Registro inserido com sucesso!" , "Cadastro" , MessageBoxButtons.OK );
                Class1.fecharConexao ( );
                txtIdCartao.Text = "";
                txtNumero.Text = "";
                txtUsuario.Text = "";
            } catch ( Exception er ) {
                MessageBox.Show ( er.Message );
            }
        }

        private void btnEditar_Click ( object sender , EventArgs e ) {
            try {
                SqlConnection con = Class1.obterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "AtualizarCartaoVenda";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ( "@Id" , this.txtIdCartao.Text );
                cmd.Parameters.AddWithValue ( "@numero" , this.txtNumero.Text );
                cmd.Parameters.AddWithValue ( "@usuario" , this.txtUsuario.Text );
                Class1.obterConexao ( );
                cmd.ExecuteNonQuery ( );
                CarregaDgvCartao ( );
                MessageBox.Show ( "Registro atualizado com sucesso!" , "Atualizar Registro" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                Class1.fecharConexao ( );
                txtIdCartao.Text = "";
                txtNumero.Text = "";
                txtUsuario.Text = "";
            } catch ( Exception er ) {
                MessageBox.Show ( er.Message );
            }
        }

        private void btnExcluir_Click ( object sender , EventArgs e ) {
            try {
                SqlConnection con = Class1.obterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "ExcluirCartaoVenda";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ( "@Id" , this.txtIdCartao.Text );
                Class1.obterConexao ( );
                cmd.ExecuteNonQuery ( );
                CarregaDgvCartao ( );
                MessageBox.Show ( "Registro apagado com sucesso!" , "Excluir Registro" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                con.Close ( );
                txtIdCartao.Text = "";
                txtNumero.Text = "";
                txtUsuario.Text = "";
            } catch ( Exception er ) {
                MessageBox.Show ( er.Message );
            }
        }

        private void btnPesquisa_Click ( object sender , EventArgs e ) {
            try {
                SqlConnection con = Class1.obterConexao();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "LocalizarCartaoVenda";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ( "@Id" , this.txtIdCartao.Text );
                Class1.obterConexao ( );
                SqlDataReader rd = cmd.ExecuteReader();
                if ( rd.Read ( ) ) {
                    txtIdCartao.Text = rd["Id"].ToString ( );
                    txtNumero.Text = rd["numero"].ToString ( );
                    txtUsuario.Text = rd["usuario"].ToString ( );
                } else {
                    MessageBox.Show ( "Nenhum registro encontrado!" , "Sem registro!" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                }
            } finally {
            }
        }
    }

}
