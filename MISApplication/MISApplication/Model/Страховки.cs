using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Страховки
{
    public string НомерСтраховогоПолиса { get; set; } = null!;

    public string КомпанияСтрахователь { get; set; } = null!;

    public DateOnly? СрокДействия { get; set; }

    public virtual ICollection<ПерсональныеДанные> ПерсональныеДанныеs { get; set; } = new List<ПерсональныеДанные>();
}
