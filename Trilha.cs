namespace Jogo_da_Trilha
{
    /*
     * Classe responsável por as trilhas que compôem o jogo, cada trilha possui três nós, terá um endereço,
     * possui uma variável booleana que indica se ela está em trinca e possui funções para verificar se possui
     * ou se ainda continua em trinca.
     */
    internal class Trilha
    {
        public int enderecoTrilha;      //Identificador da trilha.
        private bool trinca = false;    //Se possuir trinca é verdadeiro, se não.
        public No[] nos = new No[3];    //Cada trilha possui um vetor com 3 nós.

        /*
         * Instancia uma Trilha com um identificador inteiro sendo passado pro parametro.
         */
        public Trilha(int enderecoTrilha)
        {
            this.enderecoTrilha = enderecoTrilha;
        }

        /*
         * Função utilizada para verificar se nessa Trilha possui alguma trinca, caso ela possua seta a variavel
         * trinca para verdadeiro e retorna verdadeiro, caso não ela seta a variavel trinca para falso e retorna
         * falso, a segunda situação ocorre quando o Jogador possuir uma trinca, mas desfaz durante uma jogada.
         */
        public bool verificaTrinca()
        {
            if (!trinca && nos[0].propriedade != 0 && nos[0].propriedade == nos[1].propriedade && nos[1].propriedade == nos[2].propriedade && nos[0].propriedade == nos[2].propriedade)
            {
                trinca = true;
                return true;
            }
            else if ((nos[0].propriedade != nos[1].propriedade || nos[1].propriedade != nos[2].propriedade || nos[0].propriedade != nos[2].propriedade) && trinca)
            {
                trinca = false;
            }
            return false;
        }

        /*
         * Função para adquirir o valor da variável trinca.
         */
        public bool possuiTrinca()
        {
            return trinca;
        }
    }
}
