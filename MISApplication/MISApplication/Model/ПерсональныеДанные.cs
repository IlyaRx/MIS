using System;
using System.Collections.Generic;

namespace MISApplication.Model;

public partial class ПерсональныеДанные
{
    public int Id { get; set; }

    public string НомерСтраховогоПолиса { get; set; } = null!;

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string Отчество { get; set; } = null!;

    public DateOnly ДатаРождения { get; set; }

    public string АдресПроживания { get; set; } = null!;

    public string Телефон { get; set; } = null!;

    public string Паспорт { get; set; } = null!;

    public string Почта { get; set; } = null!;

    public string Снилс { get; set; } = null!;

    public virtual ICollection<ДанныеРаботников> ДанныеРаботниковs { get; set; } = new List<ДанныеРаботников>();

    public virtual Страховки НомерСтраховогоПолисаNavigation { get; set; } = null!;

    public virtual ICollection<Пациент> Пациентs { get; set; } = new List<Пациент>();
}
