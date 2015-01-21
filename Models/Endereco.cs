using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteEntityFramework.Models
{
    public class Endereco
    {
        public int EnderecoID { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string CEP { get; set; }
    

    }
}