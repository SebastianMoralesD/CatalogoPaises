using System;
using System.Collections.Generic;

namespace CatalogoPaises.DB;

public partial class Restaurante
{
    public int Id { get; set; }

    public string? NombreRestaurante { get; set; }

    public int? PaisId { get; set; }

    public virtual Paise? Pais { get; set; }
}
