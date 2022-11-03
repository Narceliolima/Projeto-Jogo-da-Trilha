using System;
using System.Windows.Forms;

namespace Jogo_da_Trilha
{
    /*
     * Classe responsável por receber os parametros iniciais para a conexão do jogo, no caso será configurado
     * o IP para a conexão com o servidor, a porta que pode ser usada tanto para configurar o servidor quanto
     * para conectar a um servidor e um Nick para identificar o jogador. Será disponibilizado as opções
     * "Conectar" caso o jogador já tenha conhecimento de um servidor e queira conectar a ele e a opção
     * "Criar" caso queira criar um servidor para receber uma conexão.
     */
    public partial class Configuracao : Form
    {
        private string ip = null;       //Variável responsavel para guardar o IP do servidor a qual o cliente irá se conectar.
        private int porta = 0;          //Porta para configurar no servidor e para conectar o cliente.
        private bool isServer = false;  //Se verdadeiro durante a construção da classe será repassado os parametros para criação de um servidor.
        public Configuracao()
        {
            InitializeComponent();
        }

        /*
         * Esta função é chamada quando o usuário clica no botão de conectar, no caso é setado os parametros
         * para a conexão com o servidor e ao fim dela o formulário é fechado.
         */
        private void conectarCliente(object sender, EventArgs e)
        {
            this.ip = textoIP.Text;
            this.porta = Convert.ToInt32(textoPorta.Text);
            this.Close();
        }

        /*
         * Essa função será chamada quando o usuário clicar no botão de criar, será setado os parametros para
         * a configuração de um servidor local e o formulário será fechado ao final dela.
         */
        private void criarServidor(object sender, EventArgs e)
        {
            this.porta = Convert.ToInt32(textoPorta.Text);
            this.isServer = true;
            this.Close();
        }

        /*
         * Essa função é utilizada para passar uma nova conexão como parametro para dentro do formulário
         * que possui a lógica do jogo, utilizando as variáveis que foram setadas pelo usuário.
         */
        public Conexao receberConexao()
        {
            return new Conexao(ip, porta, isServer);
        }

        /*
         * No caso foram setados por padrão o usuário de posse do servidor ser o jogador 1, enquanto o 
         * usuário de posse do cliente seria o jogador 2, essa identificação foi utilizada para diferenciar
         * os jogadores entre as conexões.
         */
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

        /*
         * Essa função para o parametro contido dentro da variavel textoNick, da qual possui o Nickname ou
         * a identificação setada pelo usuário.
         */
        public string receberNick()
        {
            return textoNick.Text;
        }
    }
}
