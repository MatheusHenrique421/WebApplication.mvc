﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication.mvc.Data;

namespace WebApplication.mvc.Migrations
{
    [DbContext(typeof(ContextBase))]
    [Migration("20220216015459_PrimeiraMigracao")]
    partial class PrimeiraMigracao
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication.mvc.Models.Inscricao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DataVencimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataVencimento");

                    b.Property<int>("InscritoId")
                        .HasColumnType("int")
                        .HasColumnName("InscritoId");

                    b.Property<int>("LiveId")
                        .HasColumnType("int")
                        .HasColumnName("LiveId");

                    b.Property<int>("StatusPagamento")
                        .HasColumnType("int")
                        .HasColumnName("StatusPagamento");

                    b.Property<int?>("ValorInscricaoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InscritoId");

                    b.HasIndex("LiveId");

                    b.HasIndex("ValorInscricaoId");

                    b.ToTable("Inscricao");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Inscrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DtNascimento");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<int?>("InscricaoId")
                        .HasColumnType("int");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Instagram");

                    b.Property<int?>("LiveId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("InscricaoId");

                    b.HasIndex("LiveId");

                    b.ToTable("Inscrito");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Instrutor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtNascimento")
                        .HasColumnType("datetime2")
                        .HasColumnName("DtNascimento");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<string>("Instagram")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Instagram");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Instrutor");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Live", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Descicao");

                    b.Property<int>("DuracaoMin")
                        .HasColumnType("int")
                        .HasColumnName("DuracaoMin");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("datetime2")
                        .HasColumnName("HoraInicio");

                    b.Property<int>("InscritoId")
                        .HasColumnType("int")
                        .HasColumnName("InscritoId");

                    b.Property<int>("InstrutorId")
                        .HasColumnType("int")
                        .HasColumnName("InstrutorId");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Nome");

                    b.Property<decimal>("ValorInscricao")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("ValorInscricao");

                    b.HasKey("Id");

                    b.HasIndex("InscritoId");

                    b.HasIndex("InstrutorId");

                    b.ToTable("Live");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Inscricao", b =>
                {
                    b.HasOne("WebApplication.mvc.Models.Inscrito", "Inscrito")
                        .WithMany()
                        .HasForeignKey("InscritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.mvc.Models.Live", "Live")
                        .WithMany()
                        .HasForeignKey("LiveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.mvc.Models.Live", "ValorInscricao")
                        .WithMany()
                        .HasForeignKey("ValorInscricaoId");

                    b.Navigation("Inscrito");

                    b.Navigation("Live");

                    b.Navigation("ValorInscricao");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Inscrito", b =>
                {
                    b.HasOne("WebApplication.mvc.Models.Inscricao", null)
                        .WithMany("Inscritos")
                        .HasForeignKey("InscricaoId");

                    b.HasOne("WebApplication.mvc.Models.Live", "Live")
                        .WithMany("Inscritos")
                        .HasForeignKey("LiveId");

                    b.Navigation("Live");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Live", b =>
                {
                    b.HasOne("WebApplication.mvc.Models.Inscrito", "Inscrito")
                        .WithMany()
                        .HasForeignKey("InscritoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication.mvc.Models.Instrutor", "Instrutor")
                        .WithMany()
                        .HasForeignKey("InstrutorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Inscrito");

                    b.Navigation("Instrutor");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Inscricao", b =>
                {
                    b.Navigation("Inscritos");
                });

            modelBuilder.Entity("WebApplication.mvc.Models.Live", b =>
                {
                    b.Navigation("Inscritos");
                });
#pragma warning restore 612, 618
        }
    }
}
