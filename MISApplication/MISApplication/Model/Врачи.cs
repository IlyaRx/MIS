using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Врачи
{
    public int Id { get; set; }

    public int IdданныеРаботника { get; set; }

    public int Idотделения { get; set; }

    public virtual ДанныеРаботников IdданныеРаботникаNavigation { get; set; } = null!;

    public virtual Отделение IdотделенияNavigation { get; set; } = null!;

    public virtual ICollection<Запись> Записьs { get; set; } = new List<Запись>();

    public virtual ICollection<Приёмы> Приёмыs { get; set; } = new List<Приёмы>();
}
