using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class КатегорияУслуг
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Услуги> Услугиs { get; set; } = new List<Услуги>();
}
