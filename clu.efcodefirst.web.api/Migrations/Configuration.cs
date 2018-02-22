namespace clu.efcodefirst.web.api.Migrations
{
    using clu.efcodefirst.web.api.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.ProductReviewsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Models.ProductReviewsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Products.AddOrUpdate(p => p.ProductId,
                new Product { Name = "Product 1", Category = "Category 1", Price = 200 },
                new Product { Name = "Product 2", Category = "Category 2", Price = 500 },
                new Product { Name = "Product 3", Category = "Category 3", Price = 700 }
                );

            context.Reviews.AddOrUpdate(r => r.ReviewId,
                new Review { Title = "Review 1.1", Description = "Test review 1.1", ProductId = 1 },
                new Review { Title = "Review 1.2", Description = "Test review 1.2", ProductId = 1 }
                );
        }
    }
}
