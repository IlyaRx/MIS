using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Пациент
{
    public int Id { get; set; }

    public int IdперсональныеДанные { get; set; }

    public string Пол { get; set; } = null!;

    public DateOnly ПоследнееВремяПосещения { get; set; }

    public virtual ПерсональныеДанные IdперсональныеДанныеNavigation { get; set; } = null!;

    public virtual ICollection<Госпитализация> Госпитализацияs { get; set; } = new List<Госпитализация>();

    public virtual ICollection<Диагностика> Диагностикаs { get; set; } = new List<Диагностика>();

    public virtual ICollection<Запись> Записьs { get; set; } = new List<Запись>();

    public virtual ICollection<Приёмы> Приёмыs { get; set; } = new List<Приёмы>();
}
