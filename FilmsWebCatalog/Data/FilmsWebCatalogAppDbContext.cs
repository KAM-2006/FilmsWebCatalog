using FilmsWebCatalog.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmsWebCatalog.Data
{
	public class FilmsWebCatalogAppDbContext : IdentityDbContext
	{
		public FilmsWebCatalogAppDbContext(DbContextOptions<FilmsWebCatalogAppDbContext> options)
			: base(options)
		{
			if (Database.IsRelational())
			{
				Database.EnsureCreated();
			}
			Database.Migrate();
		}
		public DbSet<Film> Films { get; set; }
		public DbSet<Actor> Actors { get; set; }
		public DbSet<FilmActor> FilmsActors { get; set; }
		public DbSet<Genre> Genres { get; set; }
		public DbSet<Director> Directors { get; set; }

		private IdentityUser TestUser { get; set; }
		private List<Genre> GenresList { get; set; }
		private List<Director> DirectorsList { get; set; }
		private List<Actor> ActorsList { get; set; }
		private List<FilmActor> FilmActorsList { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//да няма повтарящи се редове в свързващата таблица
			modelBuilder.Entity<FilmActor>().HasKey(fa => new
			{ fa.FilmId, fa.ActorId });

			TestUser = SeedUsers();
			modelBuilder.Entity<IdentityUser>()
				.HasData(TestUser);

			GenresList = SeedGenres();
			modelBuilder.Entity<Genre>()
				.HasData(GenresList);

			DirectorsList = SeedDirectors();
			modelBuilder.Entity<Director>()
				.HasData(DirectorsList);

			ActorsList = SeedActors();
			modelBuilder.Entity<Actor>()
				.HasData(ActorsList);


			modelBuilder.Entity<Film>()
				.HasData(new Film()
				{
					Id = 1,
					Title = "Spider-Man: No Way Home",
					DateOfReleasing = "12/17/2021",
					Rating = 8.2,
					GenreID = GenresList[0].Id,
					DirectorID = DirectorsList[1].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 2,
					Title = "Anyone But You",
					DateOfReleasing = "12/22/2023",
					Rating = 6.3,
					GenreID = GenresList[1].Id,
					DirectorID = DirectorsList[2].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 3,
					Title = "Madame Web",
					DateOfReleasing = "2/14/2024",
					Rating = 3.7,
					GenreID = GenresList[0].Id,
					DirectorID = DirectorsList[1].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 4,
					Title = "Last Call",
					DateOfReleasing = "6/4/2021",
					Rating = 7.8,
					GenreID = GenresList[1].Id,
					DirectorID = DirectorsList[3].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 5,
					Title = "Guardians of the Galaxy Vol. 3",
					DateOfReleasing = "5/5/2023",
					Rating = 7.9,
					GenreID = GenresList[0].Id,
					DirectorID = DirectorsList[0].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 6,
					Title = "Avengers: Infinity War",
					DateOfReleasing = "4/27/2018",
					Rating = 8.4,
					GenreID = GenresList[4].Id,
					DirectorID = DirectorsList[4].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 7,
					Title = "Sherlok Holmes",
					DateOfReleasing = "1/1/2010",
					Rating = 7.6,
					GenreID = GenresList[2].Id,
					DirectorID = DirectorsList[5].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 8,
					Title = "10 things I hate you about you",
					DateOfReleasing = "3/31/1999",
					Rating = 7.3,
					GenreID = GenresList[1].Id,
					DirectorID = DirectorsList[0].Id,
					UserID = TestUser.Id
				},
				new Film()
				{
					Id = 9,
					Title = "Oppenheimer",
					DateOfReleasing = "7/21/2023",
					Rating = 8.4,
					GenreID = GenresList[4].Id,
					DirectorID = DirectorsList[1].Id,
					UserID = TestUser.Id
				}
				);

			FilmActorsList = SeedFilmActors();
			modelBuilder.Entity<FilmActor>()
				.HasData(FilmActorsList);

			base.OnModelCreating(modelBuilder);
		}
		private IdentityUser SeedUsers()
		{
			var hasher = new PasswordHasher<IdentityUser>();

			TestUser = new IdentityUser()
			{
				UserName = "test@softuni.bg",
				NormalizedUserName = "TEST@SOFTUNI.BG",
			};

			TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");

			return TestUser;
		}

		private List<Genre> SeedGenres()
		{
			GenresList = new List<Genre>
		{
			new Genre() { Id = 1, Name = "action" },
			new Genre() { Id = 2, Name = "comedy" },
			new Genre() { Id = 3, Name = "mystery" },
			new Genre() { Id = 4, Name = "thriller" },
			new Genre() { Id = 5, Name = "drama" },
			new Genre() { Id = 6, Name = "romance" }
		};

			return GenresList;
		}
		private List<Director> SeedDirectors()
		{
			DirectorsList = new List<Director>
		{
			new Director() { Id = 1, Name = "Gil Junger", DateOfBirth = "11/7/1954" },
			new Director() { Id = 2, Name = "Jon Watts", DateOfBirth = "6/28/1981" },
			new Director() { Id = 3, Name = "Will Gluck", DateOfBirth = "11/7/1978" },
			new Director() { Id = 4, Name = "Ivaylo Penchev", DateOfBirth = "3/10/1970" },
			new Director() { Id = 5, Name = "Joe Russo", DateOfBirth = "7/18/1971"},
			new Director() { Id = 6, Name = "Guy Ritchie", DateOfBirth = "9/10/1968" }
		};

			return DirectorsList;
		}
		private List<Actor> SeedActors()
		{
			ActorsList = new List<Actor>
		{
			new Actor() { Id = 1, FirstName = "Tom", LastName = "Holland", Years = 27, DateOfBirth = "6/1/1996" },
			new Actor() { Id = 2, FirstName = "Zendaya", LastName = "Coleman", Years = 27, DateOfBirth = "9/1/1996" },
			new Actor() { Id = 3, FirstName = "Tobey", LastName = "Maguire", Years = 48, DateOfBirth = "6/27/1975" },
			new Actor() { Id = 4, FirstName = "Andrew", LastName = "Garfield", Years = 40, DateOfBirth = "8/20/1983" },
			new Actor() { Id = 5, FirstName = "Jacob", LastName = "Batalon", Years = 27, DateOfBirth = "10/9/1996" },
			new Actor() { Id = 6, FirstName = "Sydney", LastName = "Sweeney", Years = 26, DateOfBirth = "9/12/1997" },
			new Actor() { Id = 7, FirstName = "Dakota", LastName = "Johnson", Years = 34, DateOfBirth = "10/4/1989" },
			new Actor() { Id = 8, FirstName = "Maria", LastName = "Bakalova", Years = 27, DateOfBirth = "6/4/1996" },
			new Actor() { Id = 9, FirstName = "Chriss", LastName = "Pratt", Years = 44, DateOfBirth = "6/21/1979" },
			new Actor() { Id = 10, FirstName = "Robert", LastName = "Downey Jr.", Years = 58, DateOfBirth = "4/4/1965" },
			new Actor() { Id = 11, FirstName = "Julia", LastName = "Stiles", Years = 42, DateOfBirth = "3/28/1981" }
		};

			return ActorsList;
		}
		private List<FilmActor> SeedFilmActors()
		{
			FilmActorsList = new List<FilmActor>
		{
			new FilmActor() { FilmId = 1, ActorId = 1 },
			new FilmActor() { FilmId = 1, ActorId = 2 },
			new FilmActor() { FilmId = 1, ActorId = 3 },
			new FilmActor() { FilmId = 1, ActorId = 4 },
			new FilmActor() { FilmId = 1, ActorId = 5 },
			new FilmActor() { FilmId = 2, ActorId = 6 },
			new FilmActor() { FilmId = 3, ActorId = 6 },
			new FilmActor() { FilmId = 3, ActorId = 7 },
			new FilmActor() { FilmId = 4, ActorId = 8 },
			new FilmActor() { FilmId = 5, ActorId = 8 },
			new FilmActor() { FilmId = 5, ActorId = 9 },
			new FilmActor() { FilmId = 6, ActorId = 1 },
			new FilmActor() { FilmId = 6, ActorId = 9 },
			new FilmActor() { FilmId = 6, ActorId = 10 },
			new FilmActor() { FilmId = 7, ActorId = 10 },
			new FilmActor() { FilmId = 8, ActorId = 11 },
			new FilmActor() { FilmId = 9, ActorId = 10 }
		};

			return FilmActorsList;
		}
	}
}
