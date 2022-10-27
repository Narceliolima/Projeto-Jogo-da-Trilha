using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogo_da_Trilha
{
    internal class No
    {
        public int enderecoNo;
        public int propriedade;
        public List<Trilha> trilhas = new List<Trilha>();

        public No(int enderecoNo, int propriedade)
        {
            this.enderecoNo = enderecoNo;
            this.propriedade = propriedade;
        }
    }
}
