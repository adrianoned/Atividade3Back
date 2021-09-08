using System;
using System.Collections.Generic;

namespace RH.Dominio
{
    public class Candidato
    {
        public Candidato()
        {
            this.Vagas = new List<Vaga>();
            this.Tecnologias = new List<Tecnologia>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public List<Vaga> Vagas { get; set; }
        public List<Tecnologia> Tecnologias { get; set; }

        public void AddTecnologia(Tecnologia tecnologia)
        {
            this.Tecnologias.Add(tecnologia);
        }

        public void AddTecnologias(List<Tecnologia> tecnologias)
        {
            this.Tecnologias.AddRange(tecnologias);
        }

        public void RemoveTecnologia(Tecnologia tecnologia)
        {
            this.Tecnologias.Remove(tecnologia);
        }

    }
}