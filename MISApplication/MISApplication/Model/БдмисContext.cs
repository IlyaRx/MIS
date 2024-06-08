using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MISApplication.Model;

public partial class БдмисContext : DbContext
{
    public БдмисContext()
    {
    }

    public БдмисContext(DbContextOptions<БдмисContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Врачи> Врачиs { get; set; }

    public virtual DbSet<Госпитализация> Госпитализацияs { get; set; }

    public virtual DbSet<ДанныеРаботников> ДанныеРаботниковs { get; set; }

    public virtual DbSet<Диагнозы> Диагнозыs { get; set; }

    public virtual DbSet<Диагностика> Диагностикаs { get; set; }

    public virtual DbSet<Должности> Должностиs { get; set; }

    public virtual DbSet<Запись> Записьs { get; set; }

    public virtual DbSet<КатегорияУслуг> КатегорияУслугs { get; set; }

    public virtual DbSet<Отделение> Отделениеs { get; set; }

    public virtual DbSet<Пациент> Пациентs { get; set; }

    public virtual DbSet<ПациентыДиагнозы> ПациентыДиагнозыs { get; set; }

    public virtual DbSet<ПерсональныеДанные> ПерсональныеДанныеs { get; set; }

    public virtual DbSet<Приёмы> Приёмыs { get; set; }

    public virtual DbSet<Роли> Ролиs { get; set; }

    public virtual DbSet<Сотрудники> Сотрудникиs { get; set; }

    public virtual DbSet<Страховки> Страховкиs { get; set; }

    public virtual DbSet<Услуги> Услугиs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9G1JMCS\\SQLEXPRESS;Database=БДМИС;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Врачи>(entity =>
        {
            entity.ToTable("Врачи");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdданныеРаботника).HasColumnName("IDДанныеРаботника");
            entity.Property(e => e.Idотделения).HasColumnName("IDОтделения");

            entity.HasOne(d => d.IdданныеРаботникаNavigation).WithMany(p => p.Врачиs)
                .HasForeignKey(d => d.IdданныеРаботника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Врачи_ДанныеРаботников");

            entity.HasOne(d => d.IdотделенияNavigation).WithMany(p => p.Врачиs)
                .HasForeignKey(d => d.Idотделения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Врачи_Отделение");
        });

        modelBuilder.Entity<Госпитализация>(entity =>
        {
            entity.ToTable("Госпитализация");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idотделения).HasColumnName("IDОтделения");
            entity.Property(e => e.Idпациента).HasColumnName("IDПациента");

            entity.HasOne(d => d.IdотделенияNavigation).WithMany(p => p.Госпитализацияs)
                .HasForeignKey(d => d.Idотделения)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Госпитализация_Отделение");

            entity.HasOne(d => d.IdпациентаNavigation).WithMany(p => p.Госпитализацияs)
                .HasForeignKey(d => d.Idпациента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Госпитализация_Пациент");
        });

        modelBuilder.Entity<ДанныеРаботников>(entity =>
        {
            entity.ToTable("ДанныеРаботников");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdперсональныеДанные).HasColumnName("IDПерсональныеДанные");
            entity.Property(e => e.Idроль).HasColumnName("IDРоль");
            entity.Property(e => e.Инн)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ИНН");
            entity.Property(e => e.Логин)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ОбразованиеИквалификация)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ОбразованиеИКвалификация");
            entity.Property(e => e.Пароль)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ТрудоваяИстория).HasColumnType("text");

            entity.HasOne(d => d.IdперсональныеДанныеNavigation).WithMany(p => p.ДанныеРаботниковs)
                .HasForeignKey(d => d.IdперсональныеДанные)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ДанныеРаботников_ПерсональныеДанные");

            entity.HasOne(d => d.IdрольNavigation).WithMany(p => p.ДанныеРаботниковs)
                .HasForeignKey(d => d.Idроль)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ДанныеРаботников_Роли");
        });

        modelBuilder.Entity<Диагнозы>(entity =>
        {
            entity.ToTable("Диагнозы");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.КодМкб10)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("КодМКБ10");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Диагностика>(entity =>
        {
            entity.ToTable("Диагностика");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idпациента).HasColumnName("IDПациента");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Результаты)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdпациентаNavigation).WithMany(p => p.Диагностикаs)
                .HasForeignKey(d => d.Idпациента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Диагностика_Пациент");
        });

        modelBuilder.Entity<Должности>(entity =>
        {
            entity.ToTable("Должности");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Запись>(entity =>
        {
            entity.ToTable("Запись");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idврача).HasColumnName("IDВрача");
            entity.Property(e => e.Idпациента).HasColumnName("IDПациента");
            entity.Property(e => e.Idуслуги).HasColumnName("IDУслуги");

            entity.HasOne(d => d.IdврачаNavigation).WithMany(p => p.Записьs)
                .HasForeignKey(d => d.Idврача)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Запись_Врачи");

            entity.HasOne(d => d.IdпациентаNavigation).WithMany(p => p.Записьs)
                .HasForeignKey(d => d.Idпациента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Запись_Пациент");

            entity.HasOne(d => d.IdуслугиNavigation).WithMany(p => p.Записьs)
                .HasForeignKey(d => d.Idуслуги)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Запись_Услуги");
        });

        modelBuilder.Entity<КатегорияУслуг>(entity =>
        {
            entity.ToTable("КатегорияУслуг");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Отделение>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_КатегорииУслуг");

            entity.ToTable("Отделение");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Пациент>(entity =>
        {
            entity.ToTable("Пациент");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdперсональныеДанные).HasColumnName("IDПерсональныеДанные");
            entity.Property(e => e.Пол)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdперсональныеДанныеNavigation).WithMany(p => p.Пациентs)
                .HasForeignKey(d => d.IdперсональныеДанные)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пациент_ПерсональныеДанные");
        });

        modelBuilder.Entity<ПациентыДиагнозы>(entity =>
        {
            entity.ToTable("Пациенты_Диагнозы");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idдиагноз).HasColumnName("IDДиагноз");
            entity.Property(e => e.Idприём).HasColumnName("IDПриём");

            entity.HasOne(d => d.IdдиагнозNavigation).WithMany(p => p.ПациентыДиагнозыs)
                .HasForeignKey(d => d.Idдиагноз)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пациенты_Диагнозы_Диагнозы");

            entity.HasOne(d => d.IdприёмNavigation).WithMany(p => p.ПациентыДиагнозыs)
                .HasForeignKey(d => d.Idприём)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Пациенты_Диагнозы_Приёмы");
        });

        modelBuilder.Entity<ПерсональныеДанные>(entity =>
        {
            entity.ToTable("ПерсональныеДанные");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.АдресПроживания)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Имя)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.НомерСтраховогоПолиса)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.Отчество)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Паспорт)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Почта)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Снилс)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("СНИЛС");
            entity.Property(e => e.Телефон)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Фамилия)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.НомерСтраховогоПолисаNavigation).WithMany(p => p.ПерсональныеДанныеs)
                .HasForeignKey(d => d.НомерСтраховогоПолиса)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ПерсональныеДанные_Страховки");
        });

        modelBuilder.Entity<Приёмы>(entity =>
        {
            entity.ToTable("Приёмы");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Idврача).HasColumnName("IDВрача");
            entity.Property(e => e.Idпациента).HasColumnName("IDПациента");
            entity.Property(e => e.Жалобы)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.КурсЛечения)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Назначение)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Результаты)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdврачаNavigation).WithMany(p => p.Приёмыs)
                .HasForeignKey(d => d.Idврача)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Приёмы_Врачи");

            entity.HasOne(d => d.IdпациентаNavigation).WithMany(p => p.Приёмыs)
                .HasForeignKey(d => d.Idпациента)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Приёмы_Пациент");
        });

        modelBuilder.Entity<Роли>(entity =>
        {
            entity.ToTable("Роли");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Название)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Сотрудники>(entity =>
        {
            entity.ToTable("Сотрудники");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdданныеРаботника).HasColumnName("IDДанныеРаботника");
            entity.Property(e => e.Idдолжность).HasColumnName("IDДолжность");

            entity.HasOne(d => d.IdданныеРаботникаNavigation).WithMany(p => p.Сотрудникиs)
                .HasForeignKey(d => d.IdданныеРаботника)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сотрудники_ДанныеРаботников");

            entity.HasOne(d => d.IdдолжностьNavigation).WithMany(p => p.Сотрудникиs)
                .HasForeignKey(d => d.Idдолжность)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Сотрудники_Должности");
        });

        modelBuilder.Entity<Страховки>(entity =>
        {
            entity.HasKey(e => e.НомерСтраховогоПолиса);

            entity.ToTable("Страховки");

            entity.Property(e => e.НомерСтраховогоПолиса)
                .HasMaxLength(16)
                .IsUnicode(false);
            entity.Property(e => e.КомпанияСтрахователь)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Услуги>(entity =>
        {
            entity.ToTable("Услуги");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdкатегорияУслуг).HasColumnName("IDКатегорияУслуг");
            entity.Property(e => e.Название)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Описание)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdкатегорияУслугNavigation).WithMany(p => p.Услугиs)
                .HasForeignKey(d => d.IdкатегорияУслуг)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Услуги_КатегорияУслуг");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
