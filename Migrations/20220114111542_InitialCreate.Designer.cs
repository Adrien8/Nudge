﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nudge.Migrations
{
    [DbContext(typeof(NudgeContext))]
    [Migration("20220114111542_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Nudge.Models.Defi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Commentaire")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateFin")
                        .HasColumnType("TEXT");

                    b.Property<string>("Intitule")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonneId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Progression")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Repetition")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Reussite")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Theme")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TousLesJours")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PersonneId");

                    b.ToTable("Defi");
                });

            modelBuilder.Entity("Nudge.Models.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdresseMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("LienPhoto")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .HasColumnType("TEXT");

                    b.Property<string>("NumTel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("Nudge.Models.Trophee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DefiId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomTrophee")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonneId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("DefiId");

                    b.HasIndex("PersonneId");

                    b.ToTable("Trophee");
                });

            modelBuilder.Entity("Nudge.Models.Defi", b =>
                {
                    b.HasOne("Nudge.Models.Personne", "Personne")
                        .WithMany("ListeDefi")
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personne");
                });

            modelBuilder.Entity("Nudge.Models.Trophee", b =>
                {
                    b.HasOne("Nudge.Models.Defi", "Defi")
                        .WithMany()
                        .HasForeignKey("DefiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nudge.Models.Personne", "Personne")
                        .WithMany("ListeTrophee")
                        .HasForeignKey("PersonneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Defi");

                    b.Navigation("Personne");
                });

            modelBuilder.Entity("Nudge.Models.Personne", b =>
                {
                    b.Navigation("ListeDefi");

                    b.Navigation("ListeTrophee");
                });
#pragma warning restore 612, 618
        }
    }
}