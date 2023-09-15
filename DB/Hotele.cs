using System;
using System.Collections.Generic;

namespace CatalogoPaises.DB;

public partial class Hotele
{
    public int Id { get; set; }

    public string? NombreHotel { get; set; }

    public int? PaisId { get; set; }

    public virtual Paise? Pais { get; set; }
}
