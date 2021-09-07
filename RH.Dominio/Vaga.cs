using System;
using System.Collections.Generic;

namespace RH.Dominio
{
    public class Vaga
    {
        public Vaga()
        {
            this.Candidatos = new List<Candidato>();
            this.TecnologiasVaga = new List<TecnologiaVaga>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataPublicacao { get; set; }

        public ICollection<Candidato> Candidatos { get; set; }
        public ICollection<TecnologiaVaga> TecnologiasVaga { get; set; }
    }
}