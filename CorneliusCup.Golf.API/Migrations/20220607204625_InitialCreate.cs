using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CorneliusCup.Golf.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    startDate = table.Column<DateOnly>(type: "date", nullable: false),
                    endDate = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(320)", maxLength: 320, nullable: true),
                    Handicap = table.Column<int>(type: "integer", nullable: false, defaultValue: 54)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "Resorts",
                columns: table => new
                {
                    ResortId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resorts", x => x.ResortId);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    CompetitionId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamId);
                    table.ForeignKey(
                        name: "FK_Teams_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId");
                });

            migrationBuilder.CreateTable(
                name: "GolfCourses",
                columns: table => new
                {
                    GolfCourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ResortId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GolfCourses", x => x.GolfCourseId);
                    table.ForeignKey(
                        name: "FK_GolfCourses_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "ResortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerTeam",
                columns: table => new
                {
                    PlayersPlayerId = table.Column<int>(type: "integer", nullable: false),
                    TeamsTeamId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerTeam", x => new { x.PlayersPlayerId, x.TeamsTeamId });
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Players_PlayersPlayerId",
                        column: x => x.PlayersPlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerTeam_Teams_TeamsTeamId",
                        column: x => x.TeamsTeamId,
                        principalTable: "Teams",
                        principalColumn: "TeamId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ScoreCards",
                columns: table => new
                {
                    ScoreCardId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Handicap = table.Column<int>(type: "integer", nullable: false),
                    Stableford = table.Column<int>(type: "integer", nullable: false),
                    Gross = table.Column<int>(type: "integer", nullable: false),
                    Nett = table.Column<int>(type: "integer", nullable: false),
                    Tee_TeeId = table.Column<int>(type: "integer", nullable: true),
                    Tee_Type = table.Column<string>(type: "text", nullable: true),
                    Tee_Par = table.Column<int>(type: "integer", nullable: true),
                    Tee_SSS = table.Column<int>(type: "integer", nullable: true),
                    Tee_CourseRating = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: true),
                    Tee_SlopeRating = table.Column<int>(type: "integer", nullable: true),
                    PlayerId = table.Column<int>(type: "integer", nullable: false),
                    CompetitionId = table.Column<int>(type: "integer", nullable: false),
                    GolfCourseId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreCards", x => x.ScoreCardId);
                    table.CheckConstraint("CK_ScoreCards_Tee_Type_Enum", "\"Tee_Type\" IN ('White', 'Yellow', 'Red')");
                    table.ForeignKey(
                        name: "FK_ScoreCards_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_GolfCourses_GolfCourseId",
                        column: x => x.GolfCourseId,
                        principalTable: "GolfCourses",
                        principalColumn: "GolfCourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScoreCards_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tees",
                columns: table => new
                {
                    TeeId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GolfCourseId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Par = table.Column<int>(type: "integer", nullable: false),
                    SSS = table.Column<int>(type: "integer", nullable: false),
                    CourseRating = table.Column<decimal>(type: "numeric(3,1)", precision: 3, scale: 1, nullable: false),
                    SlopeRating = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tees", x => new { x.GolfCourseId, x.TeeId });
                    table.CheckConstraint("CK_Tees_Type_Enum", "\"Type\" IN ('White', 'Yellow', 'Red')");
                    table.ForeignKey(
                        name: "FK_Tees_GolfCourses_GolfCourseId",
                        column: x => x.GolfCourseId,
                        principalTable: "GolfCourses",
                        principalColumn: "GolfCourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoleScore",
                columns: table => new
                {
                    TeeHoleScoreScoreCardId = table.Column<int>(name: "Tee<HoleScore>ScoreCardId", type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Strokes = table.Column<int>(type: "integer", nullable: false),
                    Nett = table.Column<int>(type: "integer", nullable: false),
                    Stableford = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Yards = table.Column<int>(type: "integer", nullable: false),
                    Par = table.Column<int>(type: "integer", nullable: false),
                    StrokeIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleScore", x => new { x.TeeHoleScoreScoreCardId, x.Id });
                    table.ForeignKey(
                        name: "FK_HoleScore_ScoreCards_Tee<HoleScore>ScoreCardId",
                        column: x => x.TeeHoleScoreScoreCardId,
                        principalTable: "ScoreCards",
                        principalColumn: "ScoreCardId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoleDetail",
                columns: table => new
                {
                    TeeGolfCourseId = table.Column<int>(type: "integer", nullable: false),
                    TeeId = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    Yards = table.Column<int>(type: "integer", nullable: false),
                    Par = table.Column<int>(type: "integer", nullable: false),
                    StrokeIndex = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoleDetail", x => new { x.TeeGolfCourseId, x.TeeId, x.Id });
                    table.ForeignKey(
                        name: "FK_HoleDetail_Tees_TeeGolfCourseId_TeeId",
                        columns: x => new { x.TeeGolfCourseId, x.TeeId },
                        principalTable: "Tees",
                        principalColumns: new[] { "GolfCourseId", "TeeId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_Name",
                table: "Competitions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GolfCourses_Name",
                table: "GolfCourses",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GolfCourses_ResortId",
                table: "GolfCourses",
                column: "ResortId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_Email",
                table: "Players",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlayerTeam_TeamsTeamId",
                table: "PlayerTeam",
                column: "TeamsTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Resorts_Name",
                table: "Resorts",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_CompetitionId",
                table: "ScoreCards",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_GolfCourseId",
                table: "ScoreCards",
                column: "GolfCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_PlayerId",
                table: "ScoreCards",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScoreCards_Tee_Type",
                table: "ScoreCards",
                column: "Tee_Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_CompetitionId",
                table: "Teams",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tees_Type",
                table: "Tees",
                column: "Type",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoleDetail");

            migrationBuilder.DropTable(
                name: "HoleScore");

            migrationBuilder.DropTable(
                name: "PlayerTeam");

            migrationBuilder.DropTable(
                name: "Tees");

            migrationBuilder.DropTable(
                name: "ScoreCards");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "GolfCourses");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Resorts");
        }
    }
}
