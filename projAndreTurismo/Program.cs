using Controllers;
using Models;
using Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Projeto - Andre Turismo");

        Console.WriteLine("Teste inclusão de dados");


        Package package = new Package()
        {
            Hotel = new Hotel()
            {
                Name = "Hotel Fasano Rio de Janeiro",
                Address = new Address()
                {
                    Street = "Avenida Vieira Souto",
                    Number = 80,
                    District = "Ipanema",
                    ZipCode = "22420002",
                    Complement = "null",
                    City = new City()
                    {
                        Name = "Rio de Janeiro",
                        RegisterDate = DateTime.Now
                    },
                    RegisterDate = DateTime.Now
                },
                Value = 500,
                RegisterDate = DateTime.Now
            },
            Ticket = new Ticket()
            {
                Departure = new Address()
                {
                    Street = "Rodovia Hélio Smidt",
                    Number = 123,
                    District = "Cumbica",
                    ZipCode = "07190100",
                    Complement = "null",
                    City = new City()
                    {
                        Name = "São Paulo",
                        RegisterDate = DateTime.Now
                    },
                    RegisterDate = DateTime.Now
                },
                Arrival = new Address()
                {
                    Street = "Avenida Vinte de Janeiro",
                    Number = 321,
                    District = "Galeão",
                    ZipCode = "21941900",
                    Complement = "null",
                    City = new City()
                    {
                        Name = "Rio de Janeiro",
                        RegisterDate = DateTime.Now
                    },
                    RegisterDate = DateTime.Now
                },
                Value = 100,
                RegisterDate = DateTime.Now
            },
            Client = new Client()
            {
                Name = "Ana Silva",
                Phone = "11987654321",
                Address = new Address()
                {
                    Street = "Rua das Flores",
                    Number = 123,
                    District = "Jardim Paulista",
                    ZipCode = "01423001",
                    Complement = "apto 456",
                    City = new City()
                    {
                        Name = "São Paulo",
                        RegisterDate = DateTime.Now
                    },
                    RegisterDate = DateTime.Now
                },
                RegisterDate = DateTime.Now
            },
            Value = 2600,
            RegisterDate = DateTime.Now
        };

        //Console.WriteLine(new PackageController().Insert(package) ? "Inserido" : "Erro");


        /*
        Package package2 = new Package()
        {
            Id = 8,
            Hotel = new Hotel()
            {
                Id = 13,
                Name = "Hotel Copacabana Palace",
                Address = new Address()
                {
                    Id = 49,
                    Street = "Avenida Atlântica",
                    Number = 1702,
                    District = "Copacabana",
                    ZipCode = "22021001",
                    Complement = "null",
                    City = new City()
                    {
                        Id = 49,
                        Name = "Rio de Janeiro",
                    }
                },
                Value = 8000,
            },
            Ticket = new Ticket()
            {
                Id = 11,
                Departure = new Address()
                {
                    Id = 52,
                    Street = "Aeroporto Internacional de São Paulo - Guarulhos",
                    Number = 0,
                    District = "Cumbica",
                    ZipCode = "07190100",
                    Complement = "null",
                    City = new City()
                    {
                        Id = 52,
                        Name = "São Paulo",
                    }
                },
                Arrival = new Address()
                {Id = 51,
                    Street = "Avenida Almirante Silvio de Noronha",
                    Number = 365,
                    District = "Centro",
                    ZipCode = "20021010",
                    Complement = "null",
                    City = new City()
                    {Id = 51,
                        Name = "Rio de Janeiro"
                    }
                },
                Value = 1500,
            },
            Client = new Client()
            {Id = 13,
                Name = "Pedro Souza",
                Phone = "11999999999",
                Address = new Address()
                {Id = 50,
                    Street = "Rua Augusta",
                    Number = 1000,
                    District = "Consolação",
                    ZipCode = "01304001",
                    Complement = "apto 1001",
                    City = new City()
                    {Id = 50,
                        Name = "São Paulo",
                    }
                }
            },
            Value = 7500,
        };
        */

        //Console.WriteLine(new PackageController().Insert(package) ? "Inserido" : "Erro");
        //Console.WriteLine(new PackageController().Update(package2) ? "Alterado" : "Não encontrado");
        //Console.WriteLine(new CityController().Delete(matao) ? "Deletado" : "Não encontrado");

        Address address = new()
        {
            //Id = 1,
            Street = "Rua putin2",
            Number = 4442,
            District = "Urso fofo2",
            ZipCode = "01304001",
            Complement = "apto 444",
            RegisterDate = DateTime.Now,
            City = new City()
            {
                //Id = 1,
                Name = "Vaskóvia2",
                RegisterDate = DateTime.Now
            }
        };

        City city = new City()
        {
            Id= 1,
            Name = "matão",
            //RegisterDate = DateTime.Now
        };

        Client pedro = new Client()
        {
            Id = 1,
            Name = "Pedro de Melo Souza",
            Phone = "11999999999",
            //RegisterDate = DateTime.Now,
            Address = new Address()
            {
                Id = 1,
                Street = "Rua Augusta de Damião",
                Number = 1000,
                District = "Consolação",
                ZipCode = "01304001",
                Complement = "apto 1001",
                //RegisterDate = DateTime.Now,
                City = new City()
                {
                    Id = 1,
                    Name = "São Bernardo do Campo",
                    //RegisterDate = DateTime.Now
                }
            }
        };

        Hotel hotel = new Hotel()
        {
            Id = 1,
            Name = "Hotel Oton",
            RegisterDate = DateTime.Now,
            Address = new Address()
            {
                Id = 1,
                Street = "Avenida Baldan",
                Number = 1702,
                District = "Baldan",
                ZipCode = "22021001",
                Complement = "null",
                RegisterDate = DateTime.Now,
                City = new City()
                {
                    Id = 1,
                    Name = "Matão",
                    RegisterDate = DateTime.Now
                }
            },
            Value = 3000,
        };

        Ticket ticket= new Ticket()
        {
            Id= 1,
            Departure = new Address()
            {
                Id = 1,
                Street = "Rodovia 2233",
                Number = 123,
                District = "Cumbica",
                ZipCode = "07190100",
                Complement = "null",
                City = new City()
                {
                    Id = 1,
                    Name = "São jose rio preto",
                    RegisterDate = DateTime.Now
                },
                RegisterDate = DateTime.Now
            },
            Arrival = new Address()
            {Id = 2,
                Street = "Avenida 15 de novembro",
                Number = 321,
                District = "Galeão",
                ZipCode = "21941900",
                Complement = "null",
                City = new City()
                {Id = 2,
                    Name = "Rio grande",
                    RegisterDate = DateTime.Now
                },
                RegisterDate = DateTime.Now
            },
            Value = 200,
            RegisterDate = DateTime.Now
        };

        //Console.WriteLine(new PackageController().Insert(package));
        //Console.WriteLine(new TicketController().Update(ticket));
        Console.WriteLine(new PackageController().Delete(1));

        new PackageController().FindAll().ForEach(x => Console.WriteLine(x + "\n\n"));
    }
}