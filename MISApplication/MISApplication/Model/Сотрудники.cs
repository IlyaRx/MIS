using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class Сотрудники
{
    public int Id { get; set; }

    public int IdданныеРаботника { get; set; }

    public int Idдолжность { get; set; }

    public virtual ДанныеРаботников IdданныеРаботникаNavigation { get; set; } = null!;

    public virtual Должности IdдолжностьNavigation { get; set; } = null!;
}
