using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.ViewModels
{
    public class ResultViewModel
    {
        public bool Sucesso { get; set; } = false;
        public string Mensagem { get; set; }
        public object Data { get; set; }
    }
}
