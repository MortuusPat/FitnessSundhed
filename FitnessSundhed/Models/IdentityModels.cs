using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FitnessSundhed.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Workouts> Workoutss { get; set; }
        public DbSet<Execises> Execisess { get; set; }
        public DbSet<Sets> Setss { get; set; }
        public DbSet<Recipes> Recipess { get; set; }
        public DbSet<Ingredients> Ingredientss { get; set; }

        public DbSet<RecipeDetails> RecipeDetailss { get; set; }

        public DbSet<Plan> Planss { get; set; }

        public DbSet<PlanWorkoutDistribution> PlanWorkoutDistributionss { get; set; }
        public DbSet<PlanRecipeDistribution> PlanRecipeDistributionss { get; set; }




        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}