using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoIHC.Models
{
    public class CadUsuario
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public int Cep { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string ConfSenha { get; set; }
        public int teste { get; set; }
    }
}