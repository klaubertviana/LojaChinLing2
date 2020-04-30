using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LojaCL {

    public partial class FrmPrincipal : Form {
        public FrmPrincipal ( ) {
            InitializeComponent ( );
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
            dgvPrincipal.DataSource = cartao;
            DataGridViewButtonColumn fechar = new DataGridViewButtonColumn();
            fechar.Name = "Fechar Conta";
            fechar.HeaderText = "Fechar Conta";
            fechar.Text = "Fechar Conta";
            fechar.UseColumnTextForButtonValue = true;
            int columIndex = 4;
            dgvPrincipal.Columns.Insert(columIndex , fechar );            
            dgvPrincipal.CellClick += dgvPrincipal_CellClick;
            int colunas = dgvPrincipal.ColumnCount;
            if (colunas > 5 ) {
                dgvPrincipal.Columns.Remove ( "Fechar Contas" );
            }
            Class1.fecharConexao ( );

        }

        private void sairToolStripMenuItem_Click ( object sender , EventArgs e ) {
            Environment.Exit ( 0 );
        }

        private void clientesToolStripMenuItem_Click ( object sender , EventArgs e ) {
            FrmCrudCliente cli = new FrmCrudCliente();
            cli.Show ( );
        }

        private void testarBancoDeDadosToolStripMenuItem_Click ( object sender , EventArgs e ) {
            try {
                SqlConnection con = Class1.obterConexao();
                String query = "select * from cliente";
                SqlCommand cmd = new SqlCommand(query, con);
                Class1.obterConexao ( );
                DataSet ds = new DataSet();
                MessageBox.Show ( "Conectado ao Banco de Dados com Sucesso!" , "Teste de Conexão" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                Class1.fecharConexao ( );
            } catch ( Exception er ) {
                MessageBox.Show ( er.Message );
            }
        }

        private void produtosToolStripMenuItem_Click ( object sender , EventArgs e ) {
            FrmCrudProduto pro = new FrmCrudProduto();
            pro.Show ( );
        }

        private void vendasToolStripMenuItem1_Click ( object sender , EventArgs e ) {
            FrmVenda ven = new FrmVenda();
            ven.Show ( );
        }

        private void usuáriosToolStripMenuItem_Click ( object sender , EventArgs e ) {
            FrmCrudUsuario usu = new FrmCrudUsuario();
            usu.Show ( );
        }

        private void FrmPrincipal_Load ( object sender , EventArgs e ) {
            CarregaDgvCartao ( );
        }

        private void CadastrosToolStripMenuItem_Click ( object sender , EventArgs e ) {

        }

        private void MenuStrip1_ItemClicked ( object sender , ToolStripItemClickedEventArgs e ) {

        }

        private void cartToolStripMenuItem_Click ( object sender , EventArgs e ) {

            FrmCrudCartao car = new FrmCrudCartao();
            car.Show ( );

        }

        private void dgvPrincipal_CellClick ( object sender , DataGridViewCellEventArgs e ) {

            try {

                if (e.ColumnIndex == dgvPrincipal.Columns["Fechar Conta"].Index) {

                    if ( Application.OpenForms["FrmVenda"] == null){

                        FrmVenda ven = new FrmVenda();
                        ven.Show ( );
                    }

                }

            } catch {

            }
        }

        private void pedidoToolStripMenuItem_Click ( object sender , EventArgs e ) {

            FrmPedido ped = new FrmPedido();
            ped.Show ( );

        }
    }
}
