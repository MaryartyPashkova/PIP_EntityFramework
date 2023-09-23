using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF;
[Table("Manufactures")]
public partial class Manufacture
{
    [Column("id")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; }

    public virtual ICollection<Model> Models { get; set; } = new List<Model>();
}
