using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CorePoker.Data;

namespace CorePoker.Data.Migrations
{
    [DbContext(typeof(CorePokerContext))]
    [Migration("20170124165913_TableNameIndex")]
    partial class TableNameIndex
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("CorePoker.Data.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("Nickname")
                        .IsUnique();

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CorePoker.Data.Table", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("OwnerId");

                    b.Property<string>("PublicId")
                        .IsRequired()
                        .HasMaxLength(36);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("OwnerId");

                    b.HasIndex("PublicId")
                        .IsUnique();

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("CorePoker.Data.TablePlayer", b =>
                {
                    b.Property<int>("TableId");

                    b.Property<int>("PlayerId");

                    b.HasKey("TableId", "PlayerId");

                    b.HasIndex("PlayerId");

                    b.ToTable("TablePlayer");
                });

            modelBuilder.Entity("CorePoker.Data.Table", b =>
                {
                    b.HasOne("CorePoker.Data.Player", "Owner")
                        .WithMany("OwnedTables")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CorePoker.Data.TablePlayer", b =>
                {
                    b.HasOne("CorePoker.Data.Player", "Player")
                        .WithMany("MemberTables")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CorePoker.Data.Table", "Table")
                        .WithMany("TablePlayers")
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
