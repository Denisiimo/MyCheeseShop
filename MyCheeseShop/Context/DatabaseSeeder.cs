using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyCheeseShop.Model;

namespace MyCheeseShop.Context
{
    public class DatabaseSeeder
    {
        private readonly DatabaseContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DatabaseSeeder(DatabaseContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task Seed()
        {
            await _context.Database.MigrateAsync();

            if(!_context.Users.Any())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));

                var adminEmail = "admin@cheese.com";
                var adminPassword = "Cheese123!";

                var admin = new User
                {
                    UserName = adminEmail,
                    Email = adminPassword,
                    FirstName = "Admin",
                    LastName = "User",
                    Address = "123 Admin Street",
                    City = "Adminville",
                    PostCode = "AD12 MIN"
                };
            }
            
            if (!_context.Cheeses.Any())
            {
                var cheeses = GetCheeses();
                _context.Cheeses.AddRange(cheeses);
                await _context!.SaveChangesAsync();
            }
        }

        private List<Cheese> GetCheeses()
        {
            return 
            [
                new Cheese { Name = "Cheddar", Type = "Hard", Description = "A sharp and aged cheese", Strength = "Medium", Price = 8.99m, ImageUrl = "cheddar.jpg" },
                new Cheese { Name = "Brie", Type = "Soft", Description = "A soft and creamy cheese", Strength = "Mild", Price = 12.49m, ImageUrl = "brie.jpg" },
                new Cheese { Name = "Gouda", Type = "Semi-Hard", Description = "A semi-hard cheese with a rich flavor", Strength = "Medium", Price = 10.75m, ImageUrl = "gouda.jpg"},
                new Cheese { Name = "Blue Cheese", Type = "Blue", Description = "A pungent and crumbly cheese", Strength = "Strong", Price = 9.25m, ImageUrl = "blue-cheese.jpg"},
                new Cheese { Name = "Parmigiano-Reggiano", Type = "Hard", Description = "An Italian hard cheese with a nutty flavor", Strength = "Strong", Price = 14.99m, ImageUrl = "parmegiano-reggiano.jpg"},
                new Cheese { Name = "Camembert", Type = "Soft", Description = "A creamy French cheese with a bloomy rind", Strength = "Mild", Price = 11.99m, ImageUrl = "camember.jpg"},
                new Cheese { Name = "Roquefort", Type = "Blue", Description = "A tangy and crumbly blue cheese from France", Strength = "Strong", Price = 13.75m, ImageUrl = "roquefort.jpg"},
                new Cheese { Name = "Manchego", Type = "Hard", Description = "A Spanish sheep's milk cheese with a nutty taste", Strength = "Medium", Price = 9.99m, ImageUrl = "manchego.jpg"},
                new Cheese { Name = "Gruyère", Type = "Hard", Description = "A Swiss cheese with a sweet and nutty flavor", Strength = "Medium", Price = 11.25m, ImageUrl = "gruyere.jpg"},
                new Cheese { Name = "Feta", Type = "Soft", Description = "A brined Greek cheese made from sheep's milk", Strength = "Mild", Price = 7.49m, ImageUrl = "feta.jpg"},
                new Cheese { Name = "Emmental", Type = "Hard", Description = "A Swiss cheese known for its characteristic holes", Strength = "Medium", Price = 10.50m, ImageUrl = "emmental.jpg"},
                new Cheese { Name = "Havarti", Type = "Semi-Soft", Description = "A Danish cheese with a buttery and creamy texture", Strength = "Mild", Price = 8.75m, ImageUrl = "havarti.jpg"},
                new Cheese { Name = "Monterey Jack", Type = "Semi-Hard", Description = "A mild American cheese often used in melting", Strength = "Mild", Price = 6.99m, ImageUrl = "monterey-jack.jpg"},
                new Cheese { Name = "Provolone", Type = "Semi-Hard", Description = "An Italian cheese with a sharp and tangy flavor", Strength = "Medium", Price = 9.50m, ImageUrl = "provolone.jpg"},
                new Cheese { Name = "Edam", Type = "Semi-Hard", Description = "A Dutch cheese with a mild and slightly nutty taste", Strength = "Mild", Price = 8.25m, ImageUrl = "edam.jpg"},
                new Cheese { Name = "Colby", Type = "Semi-Hard", Description = "A milder American cheese similar to cheddar", Strength = "Mild", Price = 7.25m, ImageUrl = "colby.jpg"},
                new Cheese { Name = "Boursault", Type = "Soft", Description = "A French triple-cream cheese with a rich and creamy texture", Strength = "Mild", Price = 15.99m, ImageUrl = "boursault.jpg"},
                new Cheese { Name = "Fontina", Type = "Semi-Soft", Description = "An Italian cheese with a fruity and earthy flavor", Strength = "Medium", Price = 12.99m, ImageUrl = "fontina.jpg"},
                new Cheese { Name = "Mozzarella", Type = "Soft", Description = "A fresh Italian cheese known for its stretchy texture", Strength = "Mild", Price = 5.99m, ImageUrl = "mozzarella.jpg"},
                new Cheese { Name = "Cambozola", Type = "Blue", Description = "A German cheese combining the creaminess of Camembert with blue veins", Strength = "Medium", Price = 13.49m, ImageUrl = "cambozola.jpg"}
            ];
        }
    }
}
