

using System.Collections.Generic;

namespace RH.Dominio
{
    public class Tecnologia
    {
        public Tecnologia()
        {
            this.Candidatos = new List<Candidato>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }


        public ICollection<Candidato> Candidatos { get; set; }
    }
}