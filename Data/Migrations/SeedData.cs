using OlympicsWeb.Models;

namespace OlympicsWeb.Data.Migrations
{
    public class SeedData
    {
        public static void Initialize(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope()) {
            var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
            context.Database.EnsureCreated();


            // Look for any students.
            if (context.Game.Any()) {
                return;   // DB has already been seeded
            }


            var game = GetGames();
            context.Game.AddRange(game);
            context.SaveChanges();
        }
    }
public static Game[] GetGames()
	{
    	// Process CSV
    	List<Game> games = new List<Game>();
    	string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "olympics.csv");   	 
    	using (StreamReader sr = File.OpenText(path))
    	{
        	string? line;
        	bool isFirstLine = true;

        	while ((line = sr.ReadLine()) != null)
        	{
            	// 2,Ann,Fay,Mining => ["2", "Ann", "Fay", "Mining"]
            	string[] lineInfo = line.Split(',');
            	if (!isFirstLine)
            	{
                	string[] gameinfo = lineInfo;
                	Game game = new Game()
                	{
                    	Id = gameinfo[0],
                    	City = gameinfo[1],
                    	Country = gameinfo[2],
                    	Continent = gameinfo[3],
                        Season = gameinfo[4],
                    	Year = gameinfo[5],
                    	Opening = gameinfo[6],
                        Closing = gameinfo[7]
                	};
                	games.Add(game);
            	}
            	isFirstLine = false;
        	}
    	}


    	return games.ToArray();
	}
    }
}