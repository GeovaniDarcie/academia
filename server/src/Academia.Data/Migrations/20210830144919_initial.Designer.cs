﻿// <auto-generated />
using System;
using Academia.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Academia.Data.Migrations
{
    [DbContext(typeof(AcademiaContext))]
    [Migration("20210830144919_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Academia.Domain.Entities.AcademiaEntity", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Academias");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Admin", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AcademiaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademiaId");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Aluno", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AcademiaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataDeNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InicioDeMatricula")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademiaId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Anamnese", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AlunoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Cirurgias")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HabitosGerais")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sedentarismo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Anamneses");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Antropometria", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Altura")
                        .HasColumnType("float");

                    b.Property<long>("AlunoId")
                        .HasColumnType("bigint");

                    b.Property<int>("IMC")
                        .HasColumnType("int");

                    b.Property<double>("MassaMuscular")
                        .HasColumnType("float");

                    b.Property<int>("PercentualDeGordura")
                        .HasColumnType("int");

                    b.Property<double>("Peso")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("Antropometrias");
                });

            modelBuilder.Entity("Academia.Domain.Entities.DobrasCutaneas", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Abdominal")
                        .HasColumnType("float");

                    b.Property<long>("AlunoId")
                        .HasColumnType("bigint");

                    b.Property<double>("AxilarMedia")
                        .HasColumnType("float");

                    b.Property<double>("Biciptal")
                        .HasColumnType("float");

                    b.Property<double>("Coxa")
                        .HasColumnType("float");

                    b.Property<double>("PanturrilhaMedial")
                        .HasColumnType("float");

                    b.Property<double>("Subescapular")
                        .HasColumnType("float");

                    b.Property<double>("SupraIliaca")
                        .HasColumnType("float");

                    b.Property<double>("Toracica")
                        .HasColumnType("float");

                    b.Property<double>("Triciptal")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("DobrasCutaneas");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Professor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AcademiaId")
                        .HasColumnType("bigint");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademiaId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Admin", b =>
                {
                    b.HasOne("Academia.Domain.Entities.AcademiaEntity", "Academia")
                        .WithMany()
                        .HasForeignKey("AcademiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academia");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Aluno", b =>
                {
                    b.HasOne("Academia.Domain.Entities.AcademiaEntity", "Academia")
                        .WithMany()
                        .HasForeignKey("AcademiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academia");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Anamnese", b =>
                {
                    b.HasOne("Academia.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Antropometria", b =>
                {
                    b.HasOne("Academia.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Academia.Domain.Entities.DobrasCutaneas", b =>
                {
                    b.HasOne("Academia.Domain.Entities.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");
                });

            modelBuilder.Entity("Academia.Domain.Entities.Professor", b =>
                {
                    b.HasOne("Academia.Domain.Entities.AcademiaEntity", "Academia")
                        .WithMany()
                        .HasForeignKey("AcademiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Academia");
                });
#pragma warning restore 612, 618
        }
    }
}
