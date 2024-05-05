using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class ПациентыДиагнозы
{
    public int Id { get; set; }

    public int Idдиагноз { get; set; }

    public int Idприём { get; set; }

    public virtual Диагнозы IdдиагнозNavigation { get; set; } = null!;

    public virtual Приёмы IdприёмNavigation { get; set; } = null!;
}
