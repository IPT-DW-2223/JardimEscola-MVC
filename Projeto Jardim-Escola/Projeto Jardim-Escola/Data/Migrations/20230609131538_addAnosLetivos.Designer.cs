﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto_Jardim_Escola.Data;

#nullable disable

namespace Projeto_Jardim_Escola.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230609131538_addAnosLetivos")]
    partial class addAnosLetivos
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AlunosTurmas", b =>
                {
                    b.Property<int>("AlunosId")
                        .HasColumnType("int");

                    b.Property<int>("TurmasId")
                        .HasColumnType("int");

                    b.HasKey("AlunosId", "TurmasId");

                    b.HasIndex("TurmasId");

                    b.ToTable("AlunosTurmas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "adm",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "prof",
                            Name = "Professor",
                            NormalizedName = "PROFESSOR"
                        },
                        new
                        {
                            Id = "enc",
                            Name = "Enc. de Educação",
                            NormalizedName = "ENC. DE EDUCAÇÃO"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ab01f9ce-d7f7-478d-9215-2c4633d6966a",
                            Email = "admin@jardimescola.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@JARDIMESCOLA.COM",
                            NormalizedUserName = "ADMIN@JARDIMESCOLA.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEFCbOd92fHHLwP2aH/Iz62TBGnPW17LiAQmmW5EBCTfXNy/uDxzmFv2C4lP63dsanA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cbff03f7-97ea-454f-adad-625e2f32b525",
                            TwoFactorEnabled = false,
                            UserName = "admin@jardimescola.com"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e02ca9e7-bd69-416b-8731-748a49b89bdf",
                            Email = "resp@jardimescola.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "RESP@JARDIMESCOLA.COM",
                            NormalizedUserName = "RESP@JARDIMESCOLA.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEK8oKi3qqneF6ebh4BDXVy5O2kGHpBTbUnMN/ck92BmWGaJp+16I9l93IYBW5fknGw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fac12aba-8ad9-404c-bb9e-b0cf85a953d1",
                            TwoFactorEnabled = false,
                            UserName = "resp@jardimescola.com"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "29841504-4ddf-4bc8-b2b3-ff390144ab07",
                            Email = "prof@jardimescola.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "PROF@JARDIMESCOLA.COM",
                            NormalizedUserName = "PROF@JARDIMESCOLA.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEOo9h84Vjyb/qnSn/EAtS2/AnHd0iXxmYcai/nyzoDdjq4R5c5huw3NuJopa5o1Tog==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7401229d-a506-4eda-a55e-ae38f4ac3b2f",
                            TwoFactorEnabled = false,
                            UserName = "prof@jardimescola.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "0",
                            RoleId = "adm"
                        },
                        new
                        {
                            UserId = "1",
                            RoleId = "enc"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "prof"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.AnosLetivos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnoLetivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AnosLetivos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnoLetivo = "2021-2022"
                        },
                        new
                        {
                            Id = 2,
                            AnoLetivo = "2022-2023"
                        },
                        new
                        {
                            Id = 3,
                            AnoLetivo = "2023-2024"
                        },
                        new
                        {
                            Id = 4,
                            AnoLetivo = "2024-2025"
                        });
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Pessoas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Identificacao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIF")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoIdentificacaoFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoIdentificacaoFK");

                    b.ToTable("Pessoas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Pessoas");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.TiposIdentificacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TiposIdentificacao");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Cartão de Cidadão"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Bilhete de Identidade"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Passaporte"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Título de Residência"
                        });
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Turmas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnoLetivoFK")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnoLetivoFK");

                    b.HasIndex("ProfessorFK");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Alunos", b =>
                {
                    b.HasBaseType("Projeto_Jardim_Escola.Models.Pessoas");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Foto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ResponsavelFK")
                        .HasColumnType("int");

                    b.HasIndex("ResponsavelFK");

                    b.HasDiscriminator().HasValue("Alunos");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Professores", b =>
                {
                    b.HasBaseType("Projeto_Jardim_Escola.Models.Pessoas");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Professores");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Responsaveis", b =>
                {
                    b.HasBaseType("Projeto_Jardim_Escola.Models.Pessoas");

                    b.Property<string>("CodPostal")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Escolaridade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Morada")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telemovel")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Pessoas", t =>
                        {
                            t.Property("Email")
                                .HasColumnName("Responsaveis_Email");

                            t.Property("Telemovel")
                                .HasColumnName("Responsaveis_Telemovel");

                            t.Property("UserID")
                                .HasColumnName("Responsaveis_UserID");
                        });

                    b.HasDiscriminator().HasValue("Responsaveis");
                });

            modelBuilder.Entity("AlunosTurmas", b =>
                {
                    b.HasOne("Projeto_Jardim_Escola.Models.Alunos", null)
                        .WithMany()
                        .HasForeignKey("AlunosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Jardim_Escola.Models.Turmas", null)
                        .WithMany()
                        .HasForeignKey("TurmasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Pessoas", b =>
                {
                    b.HasOne("Projeto_Jardim_Escola.Models.TiposIdentificacao", "TipoIdentificacao")
                        .WithMany("Pessoas")
                        .HasForeignKey("TipoIdentificacaoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoIdentificacao");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Turmas", b =>
                {
                    b.HasOne("Projeto_Jardim_Escola.Models.AnosLetivos", "AnoLetivo")
                        .WithMany("Turmas")
                        .HasForeignKey("AnoLetivoFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto_Jardim_Escola.Models.Professores", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AnoLetivo");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Alunos", b =>
                {
                    b.HasOne("Projeto_Jardim_Escola.Models.Responsaveis", "Responsavel")
                        .WithMany("Alunos")
                        .HasForeignKey("ResponsavelFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Responsavel");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.AnosLetivos", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.TiposIdentificacao", b =>
                {
                    b.Navigation("Pessoas");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Professores", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("Projeto_Jardim_Escola.Models.Responsaveis", b =>
                {
                    b.Navigation("Alunos");
                });
#pragma warning restore 612, 618
        }
    }
}
