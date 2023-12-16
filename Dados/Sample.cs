//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dados;

[Table("sample", Schema = "public")]

public class Sample
{

    [Key]
    public int id { get; set; }

    [Required(ErrorMessage = "Data de postagem é obrigatória")]
    public string? dataPostagem { get; set; }

    public override string ToString()
    {
        return "Id = " + id + " ;; data de postagem= " + dataPostagem;
    }



}