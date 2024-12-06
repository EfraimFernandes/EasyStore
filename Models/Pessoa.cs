using System.ComponentModel.DataAnnotations;
namespace EasyStore.Models
{
    public class Pessoa
    {
        public int idPessoa { get; set; }
        public string nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF {  get; set; }
        public string CPFNome { get; set; }
        public int intIdTipoPessoa { get; set; }
    }
}
