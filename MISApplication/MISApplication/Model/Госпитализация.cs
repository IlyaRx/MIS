using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Госпитализация
{
    public int Id { get; set; }

    public int Idотделения { get; set; }

    public int Idпациента { get; set; }

    public DateOnly ДатаНачала { get; set; }

    public virtual Отделение IdотделенияNavigation { get; set; } = null!;

    public virtual Пациент IdпациентаNavigation { get; set; } = null!;
}
