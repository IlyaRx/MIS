using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Должности
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Сотрудники> Сотрудникиs { get; set; } = new List<Сотрудники>();
}
