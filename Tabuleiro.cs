using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Aprendizado_com_interface
{
    public partial class Tabuleiro : Form
    {
        private List<No> nos = new List<No>();
        private List<Trilha> trilhas = new List<Trilha>();
        private List<Button> botoes = new List<Button>();
        private readonly int[,] matrix = { { 0, 1, 2 }, { 3, 4, 5 }, { 6, 7, 8 }, 
                                           { 9, 10, 11 }, { 12, 13, 14 }, { 15, 16, 17 }, 
                                           { 18, 19, 20 }, { 21, 22, 23 }, { 0, 9, 21 }, 
                                           { 3, 10, 18 }, { 6, 11, 15 }, { 1, 4, 7 }, { 16, 19, 22 }, 
                                           { 8, 12, 17 }, { 5, 13, 20 }, { 2, 14, 23 } };

        private readonly Color[] cor = { Color.Transparent, Color.Red, Color.Blue };
        private string[] nicks = { "Missigno", "Jogador 1", "Jogador 2"};
        private bool suaVez = false;
        private bool removePeca = false;
        private int jogador = 0;
        private int oponente = 0;
        private const int padraoQntPecas = 9;
        private int pecasTotal = padraoQntPecas;
        private int pecasPJogar = padraoQntPecas;
        private int ultimaPosicao = -1;
        private int contPassVez = 5;
        private int tempoRestante = 60;
        
        //Conexão
        Conexao conexao;

        public Tabuleiro()
        {
            Configuracao configTela = new Configuracao();
            
            InitializeComponent();
            
            configTela.ShowDialog();
            conexao = configTela.receberConexao();
            jogador = configTela.receberJogador();
            String nickDoJogador = configTela.receberNick();

            inicializaVariaveis();

            if(nickDoJogador == "Jogador")
            {
                nickDoJogador += " "+jogador;
            }

            if (jogador==1)
            {
                suaVez = true;
                oponente = 2;
                nicks[1] = nickDoJogador;
            }
            else
            {
                oponente = 1;
                nicks[2] = nickDoJogador;
            }

            new Thread(new ThreadStart(this.recebeMensagens)).Start();
            this.Show();

            timer.Stop();
            MessageBox.Show("Bem vindo a Trilha " + nickDoJogador, "");
            conexao.escreveMensagem("chat>Seu oponente é o " + nickDoJogador);
            conexao.escreveMensagem("nick>" + nickDoJogador);
            timer.Start();

            inicializaBotoes();
            SoundPlayer som = new SoundPlayer(Properties.Resources.econsideradoduelotbm);
            som.PlayLooping();
        }

        private void inicializaVariaveis()
        {
            for(int i = 0; i < 24; i++)
            {
                nos.Add(new No(i,0));
            }

            for (int i = 0; i < 16; i++)
            {
                trilhas.Add(new Trilha(i));
                for (int j = 0; j < 3; j++)
                {
                    trilhas[i].nos[j] = nos[matrix[i, j]];
                    nos[matrix[i, j]].trilhas.Add(trilhas[i]);
                }
            }
        }

        private void inicializaBotoes()
        {
            botoes.Add(botao1);
            botoes.Add(botao2);
            botoes.Add(botao3);
            botoes.Add(botao4);
            botoes.Add(botao5);
            botoes.Add(botao6);
            botoes.Add(botao7);
            botoes.Add(botao8);
            botoes.Add(botao9);
            botoes.Add(botao10);
            botoes.Add(botao11);
            botoes.Add(botao12);
            botoes.Add(botao13);
            botoes.Add(botao14);
            botoes.Add(botao15);
            botoes.Add(botao16);
            botoes.Add(botao17);
            botoes.Add(botao18);
            botoes.Add(botao19);
            botoes.Add(botao20);
            botoes.Add(botao21);
            botoes.Add(botao22);
            botoes.Add(botao23);
            botoes.Add(botao24);

            atualizaInterface();
        }

        private void atualizaInterface()
        {
            int i = 0;
            foreach(Button botao in botoes)
            {
                botao.Text = "";
                botao.BackColor = cor[nos[i].propriedade];
                i++;
            }

            if (suaVez)
            {
                display.Text = "Sua vez";
                display.BackColor = cor[jogador];
            }
            else
            {
                display.Text = "Vez do oponente";
                display.BackColor = cor[oponente];
            }

            if(pecasPJogar > 0)
            {
                dispPcRest.Text = "Peças para Jogar: " + pecasPJogar;
            }
            else
            {
                dispPcRest.Visible = false;
                display.Location = new System.Drawing.Point(178, 185);
                displayTempo.Location = new System.Drawing.Point(204, 221);
            }
        }

        private void adquirePropriedade(int propriedade, int posicao)
        {
            nos[posicao].propriedade = propriedade;
        }

        private bool verificaTrinca()
        {
            foreach (Trilha trilha in trilhas)
            {
                if (trilha.verificaTrinca())
                {
                    MessageBox.Show("Jogador " + nicks[trilha.nos[0].propriedade] + " formou Trinca");
                    return true;
                }
            }
            return false;
        }

        private void verificaVitoria()
        {
            if (pecasTotal < 3)
            {
                MessageBox.Show("Você Perdeu", "Finalizar");
                conexao.escreveMensagem("desi>");
                finalizarPrograma(new Object(), new FormClosedEventArgs(new CloseReason()));
            }
        }

        private void acaoDoContador(object sender, EventArgs e)
        {
            if (suaVez)
            {
                if (tempoRestante < 1)
                {
                    conexao.escreveMensagem("seuT>");
                    suaVez = false;
                    contPassVez = 5;
                    tempoRestante = 60;
                    atualizaInterface();
                }
                tempoRestante--;
                displayTempo.Text = Convert.ToString(tempoRestante);
            }
        }

        private void acaoDoBotao(object sender, EventArgs e)
        {
            if (suaVez)
            {
                if (removePeca)
                {
                    bool possuiTrinca = false;
                    foreach (Trilha trilha in nos[botoes.IndexOf((Button)sender)].trilhas)
                    {
                        if (trilha.possuiTrinca())
                        {
                            possuiTrinca = true;
                        }
                    }

                    if (!possuiTrinca)
                    {
                        conexao.escreveMensagem("joga>" + 0 + "//" + botoes.IndexOf((Button)sender));
                        conexao.escreveMensagem("remP>");
                        adquirePropriedade(0, botoes.IndexOf((Button)sender));
                        removePeca = false;
                        suaVez = false;
                        conexao.escreveMensagem("seuT>");
                        tempoRestante = 60;
                        contPassVez = 5;
                        atualizaInterface();
                    }
                    else
                    {
                        contPassVez--;
                    }
                }
                else if (nos[botoes.IndexOf((Button)sender)].propriedade == 0 && pecasPJogar > 0)
                {
                    conexao.escreveMensagem("joga>" + jogador + "//" + botoes.IndexOf((Button)sender));
                    adquirePropriedade(jogador, botoes.IndexOf((Button)sender));
                    pecasPJogar--;
                    if (verificaTrinca())
                    {
                        removePeca = true;
                    }
                    else
                    {
                        suaVez = false;
                        conexao.escreveMensagem("seuT>");
                        tempoRestante = 60;
                    }
                    atualizaInterface();
                }
                else if (nos[botoes.IndexOf((Button)sender)].propriedade == jogador)
                {
                    ultimaPosicao = botoes.IndexOf((Button)sender);
                    contPassVez--;
                }
                else if (nos[botoes.IndexOf((Button)sender)].propriedade == 0 && ultimaPosicao != -1)
                {
                    bool adjacenteETrilha = false;
                    foreach (Trilha trilha in nos[botoes.IndexOf((Button)sender)].trilhas)
                    {
                        if (nos[ultimaPosicao].trilhas.Contains(trilha) && 
                            Math.Abs(Array.IndexOf(trilha.nos, nos[ultimaPosicao]) - Array.IndexOf(trilha.nos, nos[botoes.IndexOf((Button)sender)])) == 1)
                        {
                            adjacenteETrilha = true;
                        }
                    }

                    if (adjacenteETrilha || pecasTotal == 3)
                    {
                        conexao.escreveMensagem("joga>" + 0 + "//" + ultimaPosicao);
                        conexao.escreveMensagem("joga>" + jogador + "//" + botoes.IndexOf((Button)sender));
                        adquirePropriedade(0, ultimaPosicao);
                        adquirePropriedade(jogador, botoes.IndexOf((Button)sender));
                        if (verificaTrinca())
                        {
                            removePeca = true;
                        }
                        else
                        {
                            suaVez = false;
                            conexao.escreveMensagem("seuT>");
                            tempoRestante = 60;
                        }
                        contPassVez = 5;
                        atualizaInterface();
                    }
                }

                if (contPassVez < 1)
                {
                    DialogResult resposta = MessageBox.Show("Passar a vez?", "Sem jogadas possiveis", MessageBoxButtons.YesNo);
                    if (resposta == DialogResult.Yes)
                    {
                        conexao.escreveMensagem("seuT>");
                        suaVez = false;
                        contPassVez = 5;
                    }
                    else
                    {
                        contPassVez = 2;
                    }
                }
            }
        }

        private void apertouEnter(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 13 && chat.Text!="")
            {
                e.Handled = true;
                string mensagem = nicks[jogador] + ": " + chat.Text;
                conexao.escreveMensagem("chat>"+mensagem);
                textoChat.Text += mensagem+"\r\n";
                chat.Clear();
            }
        }

        private void fecharFormulario(object sender, FormClosingEventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Desistir?", "Desistir e Fechar", MessageBoxButtons.YesNo);
            if (resposta == DialogResult.Yes)
            {
                MessageBox.Show("Você Perdeu", "Finalizar");
                conexao.escreveMensagem("desi>");
            }
            else if (resposta == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void finalizarPrograma(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void recebeMensagens()
        {
            while (true)
            {
                string mensagem;

                try
                {
                    mensagem = conexao.leMensagem();
                }
                catch (IOException)
                {
                    MessageBox.Show("A conexão foi encerrada de forma inesperada.\nO Jogo será encerrado.", "Erro de conexão");
                    mensagem = "desi>";
                }
                
                string comando = mensagem.Substring(0, 5);
                mensagem = mensagem.Remove(0, 5);
                
                if(comando == "chat>")
                {
                    textoChat.Text += mensagem + "\r\n";
                }
                else if(comando == "joga>")
                {
                    string[] chavesSplit = {"//"};
                    string[] jogada = mensagem.Split(chavesSplit, StringSplitOptions.RemoveEmptyEntries);
                    adquirePropriedade(Convert.ToInt32(jogada[0]), Convert.ToInt32(jogada[1]));
                    atualizaInterface();
                    verificaTrinca();
                }
                else if(comando == "remP>")
                {
                    pecasTotal--;
                }
                else if(comando == "seuT>")
                {
                    suaVez = true;
                    atualizaInterface();
                    verificaVitoria();
                }
                else if(comando == "desi>")
                {
                    MessageBox.Show("Você Venceu", "Finalizar");
                    finalizarPrograma(new Object(), new FormClosedEventArgs(new CloseReason()));
                }
                else if(comando == "nick>")
                {
                    if(jogador == 1)
                    {
                        nicks[2] = mensagem;
                    }
                    else
                    {
                        nicks[1] = mensagem;
                    }
                }
            }
        }
    }
}
