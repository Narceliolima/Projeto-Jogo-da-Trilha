using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Aprendizado_com_interface
{
    public partial class Configuracao : Form
    {
        private string ip = null;
        private int porta = 0;
        private bool isServer = false;
        public Configuracao()
        {
            InitializeComponent();
        }

        private void conectarCliente(object sender, EventArgs e)
        {
            this.ip = textoIP.Text;
            this.porta = Convert.ToInt32(textoPorta.Text);
            this.Close();
        }

        private void criarServidor(object sender, EventArgs e)
        {
            this.porta = Convert.ToInt32(textoPorta.Text);
            this.isServer = true;
            this.Close();
        }

        public Conexao receberConexao()
        {
            return new Conexao(ip, porta, isServer);
        }

        public int receberJogador()
        {
            if (isServer)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        public string receberNick()
        {
            return textoNick.Text;
        }
    }
}
