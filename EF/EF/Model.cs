using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF;

[Table("Models")]
public partial class Model
{
    [Column("ID")]
    public int Id { get; set; }

    [Column("Name")]
    public string? Name { get; set; }
    [Column("Year")]
    public int? Year { get; set; }

    [Column("ManufacturerId")]
    public int? ManufacturerId { get; set; }

    public virtual Manufacture? Manufacturer { get; set; }
}
