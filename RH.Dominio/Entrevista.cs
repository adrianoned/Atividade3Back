using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RH.Dominio
{
    public class Entrevista
    {
        public Entrevista()
        {
            
        }

        public int Id { get; set; }
        public string observacoes { get; set; }

        public int VagaId { get; set; }
        public Vaga Vaga { get; set; }
        
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }
    }
}
