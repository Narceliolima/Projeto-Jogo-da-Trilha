using System.Collections.Generic;

namespace Jogo_da_Trilha
{
    /*
     * Classe responsável em armazenar os pontos presentes no tabuleiro, cada nó irá conter um endereço (ou ID),
     * uma propriedade (descrevendo a quem pertence aquele nó) e uma lista de trilhas da qual aquele nó faz parte.
     */
    internal class No
    {
        public int enderecoNo;          //Variável responsável pelo ID do Nó.
        public int propriedade;         //Descreve a quem pertence o nó (ou o dono dele).
        public List<Trilha> trilhas = new List<Trilha>(); //Lista contendo as trilhas ao qual o nó participa.

        public No(int enderecoNo, int propriedade)
        {
            this.enderecoNo = enderecoNo;
            this.propriedade = propriedade;
        }
    }
}
