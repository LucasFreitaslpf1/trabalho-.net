using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados;

[Table("usuario", Schema = "public")]
public class Usuario
{
    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? nome { get; set; }

    public override string ToString()
    {
        return "Id = " + id + " ;; nome = " + nome;
    }
}
