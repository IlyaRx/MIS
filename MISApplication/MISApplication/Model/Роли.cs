using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Роли
{
    public int Id { get; set; }

    public string Название { get; set; } = null!;

    public virtual ICollection<ДанныеРаботников> ДанныеРаботниковs { get; set; } = new List<ДанныеРаботников>();
}
