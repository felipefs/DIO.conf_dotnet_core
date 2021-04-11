using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Usuarios
{

     /// <summary>
    ///  LoginViewModelInput
    /// </summary>
    /// <param ></param>
    /// <returns></returns>
    public class LoginViewModelInput
    {
        [Required(ErrorMessage = "O Login é obrigatório")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "A Senha é obrigatória")]
        public string  Senha { get; set; }
    }
}