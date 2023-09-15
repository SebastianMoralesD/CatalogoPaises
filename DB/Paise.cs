using System;
using System.Collections.Generic;

namespace CatalogoPaises.DB;

public partial class Paise
{
    public int Id { get; set; }

    public string? NombrePais { get; set; }

    public string? CodigoIso { get; set; }

    public virtual ICollection<Hotele> Hoteles { get; set; } = new List<Hotele>();

    public virtual ICollection<Restaurante> Restaurantes { get; set; } = new List<Restaurante>();
}
