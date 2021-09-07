using System;
using System.Collections.Generic;

namespace RH.Dominio
{
    public class TecnologiaVaga
    {
        public TecnologiaVaga()
        {
            this.Tecnologia = new Tecnologia();
        }

        public int VagaId { get; set; }
        public Vaga Vaga { get; set;}

        public int TecnologiaId { get; set; }
        public Tecnologia Tecnologia { get; set;}

        public Decimal Peso { get; set; }
       
    }
}