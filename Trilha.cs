using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Aprendizado_com_interface
{
    internal class Trilha
    {
        public int enderecoTrilha;
        private bool trinca = false;
        public No[] nos = new No[3];

        public Trilha(int enderecoTrilha)
        {
            this.enderecoTrilha = enderecoTrilha;
        }

        public bool verificaTrinca()
        {
            if (!trinca && nos[0].propriedade !=0 && nos[0].propriedade == nos[1].propriedade && nos[1].propriedade == nos[2].propriedade && nos[0].propriedade == nos[2].propriedade)
            {
                trinca = true;
                return true;
            }
            else if((nos[0].propriedade != nos[1].propriedade || nos[1].propriedade != nos[2].propriedade || nos[0].propriedade != nos[2].propriedade) && trinca)
            {
                trinca = false;
            }
            return false;
        }

        public bool possuiTrinca()
        {
            return trinca;
        }
    }
}
