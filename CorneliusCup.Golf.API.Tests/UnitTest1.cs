using CorneliusCup.Golf.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CorneliusCup.Golf.API.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private ServiceCollection Services { get; set; } = default!;
        private ServiceProvider ServiceProvider { get; set; } = default!;

        [TestInitialize]
        public void Initialise()
        {
            Services = new ServiceCollection();

            Services.AddDbContext<CorneliusCupDbContext>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"), ServiceLifetime.Scoped, ServiceLifetime.Scoped);

            ServiceProvider = Services.BuildServiceProvider();

            var context = ServiceProvider.GetService<CorneliusCupDbContext>();

            if (context == null)
            {
                throw new InvalidOperationException("context is null");
            }

            // All Competitions
            var competition2020Entry = context.Add(new Competition { Name = "Cornelius Cup 2020", startDate = new DateOnly(2020, 04, 01), endDate = new DateOnly(2020, 04, 03) });
            var competition2022Entry = context.Add(new Competition { Name = "Cornelius Cup 2022", startDate = new DateOnly(2022, 04, 01), endDate = new DateOnly(2022, 04, 03) });
            var competition2023Entry = context.Add(new Competition { Name = "Cornelius Cup 2023", startDate = new DateOnly(2023, 04, 01), endDate = new DateOnly(2023, 04, 03) });
            var competition2024Entry = context.Add(new Competition { Name = "Cornelius Cup 2024", startDate = new DateOnly(2024, 04, 01), endDate = new DateOnly(2024, 04, 03) });

            // All Players
            var danielPlayerEntry = context.Players.Add(new Player { Name = "Daniel Coates", Email = "daniel@coatesy.co.uk", Handicap = 30 });
            var markPlayerEntry = context.Players.Add(new Player { Name = "Mark Coates", Email = "mark@coatesy.co.uk", Handicap = 30 });
            var colinPlayerEntry = context.Players.Add(new Player { Name = "Colin Coates", Email = "colin@coatesy.co.uk", Handicap = 29 });
            var paulPlayerEntry = context.Players.Add(new Player { Name = "Paul Coates", Email = "paul@coatesy.co.uk", Handicap = 21 });

            // Competition 2020
            competition2020Entry.Entity.Players = new List<Player> { danielPlayerEntry.Entity, markPlayerEntry.Entity, colinPlayerEntry.Entity, paulPlayerEntry.Entity };

            var peakyTeamEntry = context.Teams.Add(new Team { Name = "Peaky", competition = competition2020Entry.Entity });
            peakyTeamEntry.Entity.Players.Add(danielPlayerEntry.Entity);
            peakyTeamEntry.Entity.Players.Add(markPlayerEntry.Entity);

            var blindersTeamEntry = context.Teams.Add(new Team { Name = "Blinders", competition = competition2020Entry.Entity });
            blindersTeamEntry.Entity.Players.Add(colinPlayerEntry.Entity);
            blindersTeamEntry.Entity.Players.Add(paulPlayerEntry.Entity);

            // Competition 2022
            competition2022Entry.Entity.Players = new List<Player> { danielPlayerEntry.Entity, markPlayerEntry.Entity, colinPlayerEntry.Entity, paulPlayerEntry.Entity };

            var redTeamEntry = context.Teams.Add(new Team { Name = "Red", competition = competition2022Entry.Entity });
            redTeamEntry.Entity.Players.Add(danielPlayerEntry.Entity);
            redTeamEntry.Entity.Players.Add(markPlayerEntry.Entity);

            var blueTeamEntry = context.Teams.Add(new Team { Name = "Blue", competition = competition2022Entry.Entity });
            blueTeamEntry.Entity.Players.Add(colinPlayerEntry.Entity);
            blueTeamEntry.Entity.Players.Add(paulPlayerEntry.Entity);

            // Competition 2023
            competition2023Entry.Entity.Players = new List<Player> { danielPlayerEntry.Entity, markPlayerEntry.Entity, colinPlayerEntry.Entity, paulPlayerEntry.Entity };


            var scoreCardTest = context.ScoreCards.Add(new ScoreCard { Player = danielPlayerEntry.Entity, Competition = competition2022Entry.Entity });

            var venueTestEntry = context.Venues.Add(new Venue { Name = "foobar" });

            

            var holeDetails = new List<HoleDetail>
            {
                new HoleDetail { Number = 1, Par = 3, StrokeIndex = 18, Yards = 400 },
                new HoleDetail { Number = 2, Par = 4, StrokeIndex = 17, Yards = 300 },
                new HoleDetail { Number = 3, Par = 4, StrokeIndex = 16, Yards = 350 },
                new HoleDetail { Number = 4, Par = 3, StrokeIndex = 15, Yards = 222 },
                new HoleDetail { Number = 5, Par = 5, StrokeIndex = 14, Yards = 333 },
                new HoleDetail { Number = 6, Par = 3, StrokeIndex = 13, Yards = 444 },
                new HoleDetail { Number = 7, Par = 3, StrokeIndex = 12, Yards = 432 },
                new HoleDetail { Number = 8, Par = 4, StrokeIndex = 11, Yards = 321 },
                new HoleDetail { Number = 9, Par = 3, StrokeIndex = 10, Yards = 123 }
            };

            var tees = new List<Tee>
            {
                new Tee { HoleDetails = holeDetails }
            };

            venueTestEntry.Entity.GolfCourses.Add(new GolfCourse { Name = "c1", Tees = tees });

            context.SaveChanges();
        }

        [TestCleanup]
        public void Cleanup()
        {
            var context = ServiceProvider.GetService<CorneliusCupDbContext>();

            if (context == null)
            {
                throw new InvalidOperationException("context is null");
            }

            context.Players.RemoveRange(context.Players);
            context.Teams.RemoveRange(context.Teams);
            context.Competitions.RemoveRange(context.Competitions);

            context.SaveChanges();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var context = ServiceProvider.GetService<CorneliusCupDbContext>();

            if (context == null)
            {
                throw new InvalidOperationException("context is null");
            }
        }
    }
}