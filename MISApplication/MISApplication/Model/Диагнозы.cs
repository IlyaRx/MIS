using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Диагнозы
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public string КодМкб10 { get; set; } = null!;

    public virtual ICollection<ПациентыДиагнозы> ПациентыДиагнозыs { get; set; } = new List<ПациентыДиагнозы>();
}
