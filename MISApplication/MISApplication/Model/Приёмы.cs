using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Приёмы
{
    public int Id { get; set; }

    public int Idпациента { get; set; }

    public int Idврача { get; set; }

    public DateOnly ДатаПроведения { get; set; }

    public string? Результаты { get; set; }

    public string? Жалобы { get; set; }

    public string? КурсЛечения { get; set; }

    public string? Назначение { get; set; }

    public virtual Врачи IdврачаNavigation { get; set; } = null!;

    public virtual Пациент IdпациентаNavigation { get; set; } = null!;

    public virtual ICollection<ПациентыДиагнозы> ПациентыДиагнозыs { get; set; } = new List<ПациентыДиагнозы>();
}
