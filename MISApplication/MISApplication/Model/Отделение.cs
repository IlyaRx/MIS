using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Отделение
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<Врачи> Врачиs { get; set; } = new List<Врачи>();

    public virtual ICollection<Госпитализация> Госпитализацияs { get; set; } = new List<Госпитализация>();
}
