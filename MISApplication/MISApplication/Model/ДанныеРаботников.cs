using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class ДанныеРаботников
{
    public int Id { get; set; }

    public int Idроль { get; set; }

    public int IdперсональныеДанные { get; set; }

    public string Пароль { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Инн { get; set; } = null!;

    public string? ОбразованиеИквалификация { get; set; }

    public string? ТрудоваяИстория { get; set; }

    public virtual ПерсональныеДанные IdперсональныеДанныеNavigation { get; set; } = null!;

    public virtual Роли IdрольNavigation { get; set; } = null!;

    public virtual ICollection<Врачи> Врачиs { get; set; } = new List<Врачи>();

    public virtual ICollection<Сотрудники> Сотрудникиs { get; set; } = new List<Сотрудники>();
}
