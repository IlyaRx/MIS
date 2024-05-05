using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Услуги
{
    public int Id { get; set; }

    public int IdкатегорияУслуг { get; set; }

    public string Название { get; set; } = null!;

    public string Описание { get; set; } = null!;

    public virtual КатегорияУслуг IdкатегорияУслугNavigation { get; set; } = null!;

    public virtual ICollection<Запись> Записьs { get; set; } = new List<Запись>();
}
