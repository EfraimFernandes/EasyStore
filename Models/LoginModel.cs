using System.ComponentModel.DataAnnotations;


namespace EasyStore.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome do usuário deve ter no máximo 50 caracteres.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}
