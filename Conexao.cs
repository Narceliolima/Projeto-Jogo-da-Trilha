using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Jogo_da_Trilha
{
    /*
     * Classe responsável pela conexão entre cliente e servidor, ela possui os métodos necessários para construir
     * a parte do cliente e do servidor, assim como fazer o envio e o recebimento de dados entre eles.
     */
    public class Conexao
    {
        private string ip = null;           //Variável responsavel para guardar o IP do servidor a qual o cliente irá se conectar.
        private int porta = 0;              //Porta para configurar no servidor e para conectar o cliente.
        private bool isServer = false;      //Se verdadeiro durante a construção da classe será repassado os parametros para criação de um servidor.
        private StreamReader iStream = null;//Fluxo para leitura/recebimento dos dados.
        private StreamWriter oStream = null;//Fluxo para a escrita/envio dos dados.

        /*
         * Esse construtor é chamado quando se é instanciado um servidor (no caso clicado em criar, a porta e o booleano será passado por parametro)
         */
        public Conexao(String ip, int porta, bool isServer)
        {
            this.ip = ip;
            this.porta = porta;
            this.isServer = isServer;

            try
            {
                inicializa();
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível fazer a conexão.\nStackTrace: " + e.StackTrace, "Falha na Conexão");
                Console.WriteLine("Não foi Possivel criar uma conexão.");
                Console.WriteLine(e.StackTrace);
                Environment.Exit(-10);
            }
        }

        /*
         * E esse é chamado quando se cria um cliente (ou seja é tentado conectar a um servidor, será passado os parametros de ip e porta)
         */
        public Conexao(String ip, int porta)
        {
            this.ip = ip;
            this.porta = porta;

            try
            {
                inicializa();
            }
            catch (Exception e)
            {
                MessageBox.Show("Não foi possível fazer a conexão.\nStackTrace: " + e.StackTrace, "Falha na Conexão");
                Console.WriteLine("Não foi Possivel criar uma conexão.");
                Console.WriteLine(e.StackTrace);
                Environment.Exit(-10);
            }
        }

        /*
         * Inicia a conexão e cria os fluxos de comunicação
         */
        private void inicializa()
        {
            TcpClient conexao = null;

            Console.WriteLine("Esperando conexao...");

            //Se isServer = true, será criado um servidor passando a variavel porta por parametro
            //Se não será criado um cliente passando ip e porta por parametro.
            if (isServer)
            {
                conexao = criaConexaoServidor(porta);
            }
            else
            {
                conexao = criaConexaoCliente(ip, porta);
            }

            iStream = new StreamReader(conexao.GetStream()); //Fluxo de dados de entrada.
            oStream = new StreamWriter(conexao.GetStream()); //Fluxo de dados de saída.
        }

        /*
         * Função que cria uma conexão "Servidor", será criado um "Listener" que irá aguardar um cliente se conectar,
         * o IP será local e a porta será passada por parametro, retorna uma conexao.
         */
        private TcpClient criaConexaoServidor(int porta)
        {
            TcpListener servidor = new TcpListener(IPAddress.Parse("0.0.0.0"), porta); //Criando uma escuta no localhost.
            servidor.Start(); //Inicia/Aguarda

            TcpClient conexao = servidor.AcceptTcpClient(); //Foi recebido uma conexão do cliente, então cria uma conexão tcp.
            servidor.Stop();                                //Finaliza escuta.

            return conexao;
        }

        /*
         * Função que cria uma conexão "Cliente", apartir do ip e porta passados por parametro, ele cria uma conexao TCP
         * que é retornada ao fim da função.
         */
        private TcpClient criaConexaoCliente(string ip, int porta)
        {
            TcpClient conexao = new TcpClient(ip, porta);

            return conexao;
        }

        /*
         * Função responsável para enviar mensagens para o outro ponto.
         */
        public void escreveMensagem(string mensagem)
        {
            oStream.WriteLine(mensagem);
            oStream.Flush();
        }

        /*
         * Função responsável para receber mensagens do outro ponto.
         */
        public string leMensagem()
        {
            return iStream.ReadLine();
        }
    }
}
