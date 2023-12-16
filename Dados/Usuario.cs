using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Dados;

[Table("usuario", Schema = "public")]
public class Usuario
{
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? nome { get; set; }

    [Required]
    public string? email { get; set; }

    [Required]
    public string? senha { get; set; }

    public string? role { get; set; }

    public override string ToString()
    {
        return "Id = " + id + " ;; nome = " + nome;
    }
}
