using System;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Crypto.Tls;
using Pizzeria.Data.Sql.DAO;



namespace Pizzeria.Data.Sql.Migrations
{
    //klasa odpowiadająca za wypełnienie testowymi danymi bazę danych
    public class DatabaseSeed
    {
        private readonly PizzeriaDbContext _context;

        //wstrzyknięcie instancji klasy FoodlyDbContext poprzez konstruktor
        public DatabaseSeed(PizzeriaDbContext context)
        {
            _context = context;
        }

        //metoda odpowiadająca za uzupełnienie utworzonej bazy danych testowymi danymi
        //kolejność wywołania ma niestety znaczenie, ponieważ nie da się utworzyć rekordu
        //w bazie dnaych bez znajmości wartości klucza obcego
        //dlatego należy zacząć od uzupełniania tabel, które nie posiadają kluczy obcych
        //--OFFTOP
        //w przeciwną stronę działa ręczne usuwanie tabel z wypełnionymi danymi w bazie danych
        //należy zacząć od tabel, które posiadają klucze obce, a skończyć na tabelach, które 
        //nie posiadają
        public void Seed()
        {
            //regiony pozwalają na zwinięcie kodu w IDE
            //nie sa dobrą praktyką, kod w danej klasie/metodzie nie powinien wymagać jego zwijania
            //zastosowałem je z lenistwa nie powinno to mieć miejsca 

            #region CreateUsers

            var clientList = BuildClientList();

            _context.Client.AddRange(clientList);

            _context.SaveChanges();

            #endregion

         

            #region CreateProduct

            var productList = BuildProductList();

            _context.Product.AddRange(productList);

            _context.SaveChanges();

            #endregion
            
            
            
            
        }
        

        private IEnumerable<Client> BuildClientList()
            {
                var clientList = new List<Client>();
                var client = new Client()
                {
                    ClientId = 1,
                    ClientFirstName = "Marek",
                    ClientLastName = "Rokita",
                    ClientPesel = 12312312312,
                    ClientEmail = "MarekRokita@wp.pl",
                    ClientHash = "091cbaf8fc9a3d12ce957d6228b3c04c",
                    ClientRole = "Klient"
                };
                clientList.Add(client);

                var client2 = new Client()
                {
                    ClientId = 2,
                    ClientFirstName = "Darek",
                    ClientLastName = "Mokita",
                    ClientPesel = 12312312312,
                    ClientEmail = "DarekRokita@wp.pl",
                    ClientHash = "812ca07c7681a0b18cbe4c3e4b45a9d9",
                    ClientRole = "Admin"

                };
                clientList.Add(client2);

                return clientList;
            }


            private IEnumerable<Product> BuildProductList()
            {
                var productList = new List<Product>();
                var product = new Product()
                {
                    ProductId = 1,
                    ProductName = "Margaritta",
                    ProductIngredients = "Ciasto, sos pomidorowy, ser mozzarella, bazylia.",
                    ProductPrice = 35,


                };
                productList.Add(product);

                var product2 = new Product()
                {
                    ProductId = 2,
                    ProductName = "Capriciosa",
                    ProductIngredients = "Ciasto, sos pomidorowy, szynka, pieczarki, ser mozzarella, bazylia",
                    ProductPrice = 38
                    

                };
                productList.Add(product2);

                var product3 = new Product()
                {
                    ProductId = 3,
                    ProductName = "Salami",
                    ProductIngredients = "Ciasto, sos pomidorowy, salami, pieczarki, ser mozzarella, bazylia.",
                    ProductPrice = 38
                    

                };
                productList.Add(product3);
                
                var product4 = new Product()
                {
                    ProductId = 4,
                    ProductName = "Quattro fromaggi",
                    ProductIngredients = "Ciasto, sos pomidorowy, ser mozzarella, ser parmezan, ser cheddar, ser blue cheese, bazylia.",
                    ProductPrice = 40
                    

                };
                productList.Add(product4);
                
                var product5 = new Product()
                {
                    ProductId = 5,
                    ProductName = "Pepperoni",
                    ProductIngredients = "Ciasto, sos pomidorowy, ser mozzarella, pepperoni, bazylia.",
                    ProductPrice = 38
                    

                };
                productList.Add(product5);
                
                var product6 = new Product()
                {
                    ProductId = 6,
                    ProductName = "Carbonara",
                    ProductIngredients = "Ciasto, sos pomidorowy, guanciale, ser parmezan, bazylia.",
                    ProductPrice = 42
                    

                };
                productList.Add(product6);

                return productList;
            }



    }

    
}