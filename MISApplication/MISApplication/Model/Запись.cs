using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Запись
{
    public int Id { get; set; }

    public int Idуслуги { get; set; }

    public int Idврача { get; set; }

    public int Idпациента { get; set; }

    public DateOnly ДатаПроведения { get; set; }

    public TimeOnly ВремяПроведения { get; set; }

    public bool ПоситилЛи { get; set; }

    public virtual Врачи IdврачаNavigation { get; set; } = null!;

    public virtual Пациент IdпациентаNavigation { get; set; } = null!;

    public virtual Услуги IdуслугиNavigation { get; set; } = null!;
}
