﻿// <auto-generated />
using System;
using CorneliusCup.Golf.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    [DbContext(typeof(CorneliusCupDbContext))]
    [Migration("20220514140857_AddTeeId")]
    partial class AddTeeId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CompetitionPlayer", b =>
                {
                    b.Property<int>("CompetitionsCompetitionId")
                        .HasColumnType("integer");

                    b.Property<int>("PlayersPlayerId")
                        .HasColumnType("integer");

                    b.HasKey("CompetitionsCompetitionId", "PlayersPlayerId");

                    b.HasIndex("PlayersPlayerId");

                    b.ToTable("CompetitionPlayer");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CompetitionId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateOnly>("endDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("startDate")
                        .HasColumnType("date");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.GolfCourse", b =>
                {
                    b.Property<int>("GolfCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("GolfCourseId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("VenueId")
                        .HasColumnType("integer");

                    b.HasKey("GolfCourseId");

                    b.HasIndex("VenueId");

                    b.ToTable("GolfCourses");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PlayerId"));

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Handicap")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(54);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("PlayerId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.ScoreCard", b =>
                {
                    b.Property<int>("ScoreCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ScoreCardId"));

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("integer");

                    b.Property<int?>("GolfCourseId")
                        .HasColumnType("integer");

                    b.Property<int>("Gross")
                        .HasColumnType("integer");

                    b.Property<int>("Handicap")
                        .HasColumnType("integer");

                    b.Property<int>("Nett")
                        .HasColumnType("integer");

                    b.Property<int?>("PlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("Stableford")
                        .HasColumnType("integer");

                    b.HasKey("ScoreCardId");

                    b.HasIndex("CompetitionId");

                    b.HasIndex("GolfCourseId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ScoreCards");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("TeamId"));

                    b.Property<int?>("CompetitionId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("TeamId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Venue", b =>
                {
                    b.Property<int>("VenueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("VenueId"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("VenueId");

                    b.ToTable("Venues");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.Property<int>("PlayersPlayerId")
                        .HasColumnType("integer");

                    b.Property<int>("TeamsTeamId")
                        .HasColumnType("integer");

                    b.HasKey("PlayersPlayerId", "TeamsTeamId");

                    b.HasIndex("TeamsTeamId");

                    b.ToTable("PlayerTeam");
                });

            modelBuilder.Entity("CompetitionPlayer", b =>
                {
                    b.HasOne("CorneliusCup.Golf.API.Entities.Competition", null)
                        .WithMany()
                        .HasForeignKey("CompetitionsCompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorneliusCup.Golf.API.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.GolfCourse", b =>
                {
                    b.HasOne("CorneliusCup.Golf.API.Entities.Venue", "Venue")
                        .WithMany("GolfCourses")
                        .HasForeignKey("VenueId");

                    b.OwnsMany("CorneliusCup.Golf.API.Entities.Tee", "Tees", b1 =>
                        {
                            b1.Property<int>("GolfCourseId")
                                .HasColumnType("integer");

                            b1.Property<int>("TeeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("TeeId"));

                            b1.Property<int>("CourseRating")
                                .HasColumnType("integer");

                            b1.Property<int>("Par")
                                .HasColumnType("integer");

                            b1.Property<int>("SSS")
                                .HasColumnType("integer");

                            b1.Property<int>("SlopeRating")
                                .HasColumnType("integer");

                            b1.Property<string>("TeeType")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("GolfCourseId", "TeeId");

                            b1.ToTable("Tees");

                            b1.WithOwner()
                                .HasForeignKey("GolfCourseId");

                            b1.OwnsMany("CorneliusCup.Golf.API.Entities.HoleDetail", "HoleDetails", b2 =>
                                {
                                    b2.Property<int>("TeeGolfCourseId")
                                        .HasColumnType("integer");

                                    b2.Property<int>("TeeId")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b2.Property<int>("Id"));

                                    b2.Property<int>("Number")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Par")
                                        .HasColumnType("integer");

                                    b2.Property<int>("StrokeIndex")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Yards")
                                        .HasColumnType("integer");

                                    b2.HasKey("TeeGolfCourseId", "TeeId", "Id");

                                    b2.ToTable("HoleDetail");

                                    b2.WithOwner()
                                        .HasForeignKey("TeeGolfCourseId", "TeeId");
                                });

                            b1.Navigation("HoleDetails");
                        });

                    b.Navigation("Tees");

                    b.Navigation("Venue");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.ScoreCard", b =>
                {
                    b.HasOne("CorneliusCup.Golf.API.Entities.Competition", "Competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.HasOne("CorneliusCup.Golf.API.Entities.GolfCourse", "GolfCourse")
                        .WithMany()
                        .HasForeignKey("GolfCourseId");

                    b.HasOne("CorneliusCup.Golf.API.Entities.Player", "Player")
                        .WithMany("ScoreCards")
                        .HasForeignKey("PlayerId");

                    b.OwnsMany("CorneliusCup.Golf.API.Entities.Tee<CorneliusCup.Golf.API.Entities.HoleScore>", "Tees", b1 =>
                        {
                            b1.Property<int>("ScoreCardId")
                                .HasColumnType("integer");

                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer");

                            NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b1.Property<int>("Id"));

                            b1.Property<int>("CourseRating")
                                .HasColumnType("integer");

                            b1.Property<int>("Par")
                                .HasColumnType("integer");

                            b1.Property<int>("SSS")
                                .HasColumnType("integer");

                            b1.Property<int>("SlopeRating")
                                .HasColumnType("integer");

                            b1.Property<int>("TeeId")
                                .HasColumnType("integer");

                            b1.Property<string>("TeeType")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.HasKey("ScoreCardId", "Id");

                            b1.ToTable("Tee<HoleScore>");

                            b1.WithOwner()
                                .HasForeignKey("ScoreCardId");

                            b1.OwnsMany("CorneliusCup.Golf.API.Entities.HoleScore", "HoleDetails", b2 =>
                                {
                                    b2.Property<int>("Tee<HoleScore>ScoreCardId")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Tee<HoleScore>Id")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Id")
                                        .ValueGeneratedOnAdd()
                                        .HasColumnType("integer");

                                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b2.Property<int>("Id"));

                                    b2.Property<int>("Number")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Par")
                                        .HasColumnType("integer");

                                    b2.Property<int>("StrokeIndex")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Strokes")
                                        .HasColumnType("integer");

                                    b2.Property<int>("Yards")
                                        .HasColumnType("integer");

                                    b2.HasKey("Tee<HoleScore>ScoreCardId", "Tee<HoleScore>Id", "Id");

                                    b2.ToTable("HoleScore");

                                    b2.WithOwner()
                                        .HasForeignKey("Tee<HoleScore>ScoreCardId", "Tee<HoleScore>Id");
                                });

                            b1.Navigation("HoleDetails");
                        });

                    b.Navigation("Competition");

                    b.Navigation("GolfCourse");

                    b.Navigation("Player");

                    b.Navigation("Tees");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Team", b =>
                {
                    b.HasOne("CorneliusCup.Golf.API.Entities.Competition", "competition")
                        .WithMany()
                        .HasForeignKey("CompetitionId");

                    b.Navigation("competition");
                });

            modelBuilder.Entity("PlayerTeam", b =>
                {
                    b.HasOne("CorneliusCup.Golf.API.Entities.Player", null)
                        .WithMany()
                        .HasForeignKey("PlayersPlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CorneliusCup.Golf.API.Entities.Team", null)
                        .WithMany()
                        .HasForeignKey("TeamsTeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Player", b =>
                {
                    b.Navigation("ScoreCards");
                });

            modelBuilder.Entity("CorneliusCup.Golf.API.Entities.Venue", b =>
                {
                    b.Navigation("GolfCourses");
                });
#pragma warning restore 612, 618
        }
    }
}
