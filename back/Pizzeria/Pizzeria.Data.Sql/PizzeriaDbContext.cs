using Pizzeria.Data.Sql.DAO;
using Microsoft.EntityFrameworkCore;
using Pizzeria.Data.Sql.DAOConfigurations;


namespace Pizzeria.Data.Sql
{
    //Klasa odpowiadająca za konfigurację Entity Framework Core
    //Przy pomocy instancji klasy FoodlyDbContext możliwe jest wykonywanie
    //wszystkich operacji na bazie danych od tworzenia bazy danych po zapytanie do bazy danych itd.
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options) {}
        
        //Ustawienie klas z folderu DAO jako tabele bazy danych
        public virtual DbSet<Product> Product { get; set; }        
               
        public virtual DbSet<Client> Client { get; set; }

        //Przykład konfiguracji modeli/encji poprzez klasy konfiguracyjne z folderu DAOConfigurations
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ProductConfiguration());
            
            builder.ApplyConfiguration(new ClientConfiguration());
        }
    }
}