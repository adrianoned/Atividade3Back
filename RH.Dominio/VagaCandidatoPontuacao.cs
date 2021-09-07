using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Dominio
{
    public class VagaCandidatoPontuacao
    {
        public Vaga Vaga { get; set; }
        public List <CandidatoPontuacao> lstcandidatoPontucao { get; set; }

        public VagaCandidatoPontuacao()
        {
            lstcandidatoPontucao = new List<CandidatoPontuacao>();
            Vaga = new Vaga();
        }
    }

    
}
