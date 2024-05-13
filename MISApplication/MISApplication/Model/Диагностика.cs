using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Диагностика
{
    public int Id { get; set; }

    public int Idпациента { get; set; }

    public string Название { get; set; } = null!;

    public DateOnly ДатаСдачи { get; set; }

    public string? Результаты { get; set; }

    public virtual Пациент IdпациентаNavigation { get; set; } = null!;
}
