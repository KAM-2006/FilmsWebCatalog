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

			//TestUser = SeedUsers();
			modelBuilder.Entity<IdentityUser>()
				.HasData(TestUser);

			//GenresList = SeedGenres();
			modelBuilder.Entity<Genre>()
				.HasData(GenresList);

			//DirectorsList = SeedDirectors();
			modelBuilder.Entity<Director>()
				.HasData(DirectorsList);

			//ActorsList = SeedActors();
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

			//FilmActorsList = SeedFilmActors();
			modelBuilder.Entity<FilmActor>()
				.HasData(FilmActorsList);

			base.OnModelCreating(modelBuilder);
		}
	}
}
