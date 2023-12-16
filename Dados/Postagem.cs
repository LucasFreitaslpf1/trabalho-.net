using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Dados;
using Services;

namespace Dados;

[Table("postagem", Schema = "public")]
public class Postagem
{
    public Postagem()
    {
        texto = "";
    }

    [Key]
    public int id { get; set; }

    public DateTime datahora { get; set; }

    [Required]
    public string texto { get; set; }

    public int usuario_id {get;set;}

}
