using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jogo_da_Trilha
{
    public class Conexao
    {
        private string ip = null;
        private int porta = 0;
        private bool isServer = false;
        private StreamReader iStream = null;
        private StreamWriter oStream = null;

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
                MessageBox.Show("Não foi possível fazer a conexão.\nStackTrace: "+e.StackTrace,"Falha na Conexão");
                Console.WriteLine("Não foi Possivel criar uma conexão.");
                Console.WriteLine(e.StackTrace);
                Environment.Exit(-10);
            }
        }

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


        private void inicializa()
        {
            TcpClient conexao = null;

            Console.WriteLine("Esperando conexao...");

            if (isServer)
            {
                conexao = criaConexaoServidor(porta);
            }
            else
            {
                conexao = criaConexaoCliente(ip, porta);
            }

            iStream = new StreamReader(conexao.GetStream());
            oStream = new StreamWriter(conexao.GetStream());
        }

        private TcpClient criaConexaoServidor (int porta)
        {
            TcpListener servidor = new TcpListener(IPAddress.Parse("0.0.0.0"), porta);
            servidor.Start();

            TcpClient conexao = servidor.AcceptTcpClient();
            servidor.Stop();

            return conexao;
        }

        private TcpClient criaConexaoCliente(string ip, int porta)
        {
            TcpClient conexao = new TcpClient(ip, porta);

            return conexao;
        }

        public void escreveMensagem(string mensagem)
        {
            oStream.WriteLine(mensagem);
            oStream.Flush();
        }

        public string leMensagem()
        {
            return iStream.ReadLine();
        }
    }
}
