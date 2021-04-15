using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Usuarios
{
    
    /// <summary>
    ///  UsuarioViewModelOutput
    /// </summary>
    /// <param ></param>
    /// <returns></returns>
    public class UsuarioViewModelOutput
    {
       [Required(ErrorMessage = "O Login é obrigatório")]
       public string Login { get; set; }
     
       [Required(ErrorMessage = "O Email é obrigatório")]
       public string Email { get; set; }
     
       [Required(ErrorMessage = "O Codigo é obrigatório")]
       public int Codigo { get; set; }
    }
}