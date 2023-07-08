﻿// <auto-generated />
using System;
using ConsultorioApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ConsultorioApp.Data.Migrations
{
    [DbContext(typeof(ConsultorioAppContext))]
    [Migration("20230708144354_AdicionadoTelefone")]
    partial class AdicionadoTelefone
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Criacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("DataNascimento")
                        .IsRequired()
                        .HasColumnType("varchar");

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("DocumentoIndetificador");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Nome");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(1)")
                        .HasDefaultValue("M");

                    b.Property<DateTime?>("UltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name", "Sexo");

                    b.ToTable("Tb_Clientes", (string)null);
                });

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Endereco", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int>("CEP")
                        .HasColumnType("int");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClienteId");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Telefone", b =>
                {
                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ClienteId", "Numero");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Endereco", b =>
                {
                    b.HasOne("ConsultorioApp.Core.Domain.Cliente", "Cliente")
                        .WithOne("Endereco")
                        .HasForeignKey("ConsultorioApp.Core.Domain.Endereco", "ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Telefone", b =>
                {
                    b.HasOne("ConsultorioApp.Core.Domain.Cliente", "cliente")
                        .WithMany("Telefones")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("cliente");
                });

            modelBuilder.Entity("ConsultorioApp.Core.Domain.Cliente", b =>
                {
                    b.Navigation("Endereco")
                        .IsRequired();

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
