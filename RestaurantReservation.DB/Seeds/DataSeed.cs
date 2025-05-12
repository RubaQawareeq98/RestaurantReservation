using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Models.Enums;

namespace RestaurantReservation.DB.Seeds;

public static class DataSeed
{
    public static List<Restaurant> SeedRestaurants()
    {
        return
        [
            new Restaurant { Id = 1, Name = "Restaurant 1", Address = "Nablus", PhoneNumber = "256478912" },
            new Restaurant { Id = 2, Name = "Restaurant 2", Address = "Jenin", PhoneNumber = "256478459" },
            new Restaurant { Id = 3, Name = "Restaurant 3", Address = "Nablus", PhoneNumber = "123478912" },
            new Restaurant { Id = 4, Name = "Restaurant 4", Address = "Jericho", PhoneNumber = "785478912" },
            new Restaurant { Id = 5, Name = "Restaurant 5", Address = "Nablus", PhoneNumber = "587478912" }
        ];
    }

    public static List<Reservation> SeedReservations()
    {
        return
        [
            new Reservation { Id = 1, CustomerId = 1, RestaurantId = 1, TableId = 1, ReservationDate = new DateTime(2025, 4, 15, 7, 55, 55, 612, DateTimeKind.Local).AddTicks(8581), PartySize = 2 },
            new Reservation { Id = 2, CustomerId = 2, RestaurantId = 2, TableId = 2, ReservationDate = new DateTime(2025, 4, 20, 7, 46, 45, 612, DateTimeKind.Local), PartySize = 4 },
            new Reservation { Id = 3, CustomerId = 3, RestaurantId = 3, TableId = 3, ReservationDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), PartySize = 11 },
            new Reservation { Id = 4, CustomerId = 4, RestaurantId = 4, TableId = 4, ReservationDate = new DateTime(2025, 3, 20, 7, 46, 45, 612, DateTimeKind.Local), PartySize = 5 },
            new Reservation { Id = 5, CustomerId = 5, RestaurantId = 5, TableId = 5, ReservationDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), PartySize = 4 }
        ];
    }

    public static List<Table> SeedTables()
    {
        return
        [
            new Table { Id = 1, RestaurantId = 1, Capacity = 3 },
            new Table { Id = 2, RestaurantId = 2, Capacity = 4 },
            new Table { Id = 3, RestaurantId = 3, Capacity = 5 },
            new Table { Id = 4, RestaurantId = 4, Capacity = 6 },
            new Table { Id = 5, RestaurantId = 5, Capacity = 7 }
        ];
    }
    
    public static List<Customer> SeedCustomers()
    {
        return
        [
            new Customer { Id = 1, FirstName = "John", LastName = "Doe", Email = "johndoe@gmail.com", PhoneNumber = "12345678" },
            new Customer { Id = 2, FirstName = "Ruba", LastName = "Qa", Email = "ruban@gmail.com", PhoneNumber = "42345678" },
            new Customer { Id = 3, FirstName = "Ali", LastName = "Doe", Email = "ali@gmail.com", PhoneNumber = "52345678" },
            new Customer { Id = 4, FirstName = "Hiba", LastName = "Doe", Email = "hiba@gmail.com", PhoneNumber = "62345678" },
            new Customer { Id = 5, FirstName = "Mohammad", LastName = "Doe", Email = "mohammad@gmail.com", PhoneNumber = "52345678" }
        ];
    }

    public static List<Employee> SeedEmployees()
    {
        return
        [
            new Employee { Id = 1, FirstName = "Masa", LastName = "Ahmad", RestaurantId = 1, Position  = Position.Cashier},
            new Employee { Id = 2, FirstName = "Khaled", LastName = "Isa", RestaurantId = 2, Position = Position.Manager },
            new Employee { Id = 3, FirstName = "Jehad", LastName = "Mohammad", RestaurantId = 3, Position = Position.Chef },
            new Employee { Id = 4, FirstName = "Wael", LastName = "Khaled", RestaurantId = 4, Position = Position.Waiter },
            new Employee { Id = 5, FirstName = "Waleed", LastName = "Awad", RestaurantId = 5, Position = Position.Manager }
        ];
    }

    public static List<MenuItem> SeedMenuItems()
    {
        return
        [
            new MenuItem { Id = 1, Name = "Home", Price = 10, Description = "Description1", RestaurantId = 1},
            new MenuItem { Id = 2, Name = "Menu", Price = 10, Description = "Description2", RestaurantId = 2 },
            new MenuItem { Id = 3, Name = "Menu", Price = 10, Description = "Description3", RestaurantId = 3 },
            new MenuItem { Id = 4, Name = "Menu", Price = 10, Description = "Description4", RestaurantId = 4 },
            new MenuItem { Id = 5, Name = "Menu", Price = 10, Description = "Description5", RestaurantId = 5 }
        ];
    }

    public static List<OpeningHour> SeedOpeningHours()
    {
        return
        [
            new OpeningHour
            {
                Id = 1,
                DayOfWeek = DayOfWeek.Monday,
                OpenHour = new TimeSpan(9, 0, 0),
                CloseHour = new TimeSpan(17, 0, 0),
                RestaurantId = 1
            },

            new OpeningHour
            {
                Id = 2,
                DayOfWeek = DayOfWeek.Tuesday,
                OpenHour = new TimeSpan(10, 30, 0),
                CloseHour = new TimeSpan(17, 0, 0),
                RestaurantId = 1
            },

            new OpeningHour
            {
                Id = 3,
                DayOfWeek = DayOfWeek.Wednesday,
                OpenHour = new TimeSpan(9, 0, 0),
                CloseHour = new TimeSpan(17, 0, 0),
                RestaurantId = 2
            },

            new OpeningHour
            {
                Id = 4,
                DayOfWeek = DayOfWeek.Thursday,
                OpenHour = new TimeSpan(9, 0, 0),
                CloseHour = new TimeSpan(20, 0, 0),
                RestaurantId = 3
            },

            new OpeningHour
            {
                Id = 5,
                DayOfWeek = DayOfWeek.Friday,
                OpenHour = new TimeSpan(9, 0, 0),
                CloseHour = new TimeSpan(21, 0, 0),
                RestaurantId = 3
            },

            new OpeningHour
            {
                Id = 6,
                DayOfWeek = DayOfWeek.Saturday,
                OpenHour = new TimeSpan(10, 0, 0),
                CloseHour = new TimeSpan(18, 0, 0),
                RestaurantId = 3
            },

            new OpeningHour
            {
                Id = 7,
                DayOfWeek = DayOfWeek.Sunday,
                OpenHour = new TimeSpan(8, 0, 0),
                CloseHour = new TimeSpan(18, 0, 0),
                RestaurantId = 4
            }
        ];
    }

    public static List<OrderItem> SeedOrderItems()
    {
        return
        [
            new OrderItem { Id = 1, OrderId = 1, MenuItemId = 1, Quantity = 1 },
            new OrderItem { Id = 2, OrderId = 2, MenuItemId = 2, Quantity = 1 },
            new OrderItem { Id = 3, OrderId = 3, MenuItemId = 3, Quantity = 1 },
            new OrderItem { Id = 4, OrderId = 4, MenuItemId = 4, Quantity = 1 }
        ];
    }

    public static List<Order> SeedOrders()
    {
        return
        [
            new Order
            {
                Id = 1,
                OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                EmployeeId = 1,
                ReservationId = 1
            },
            new Order
            {
                Id = 2,
                OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                EmployeeId = 2,
                ReservationId = 2
                
            },
            new Order
            {
                Id = 3,
                OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                EmployeeId = 3,
                ReservationId = 3
            },
            new Order
            {
                Id = 4,
                OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                EmployeeId = 4,
                ReservationId = 4
            },
            new Order
            {
                Id = 5,
                OrderDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local),
                EmployeeId = 5,
                ReservationId = 5
            }
        ];
    }

    public static List<PaymentDetail> SeedPaymentDetails()
    {
        return
        [
            new PaymentDetail
            {
                PaymentNumber = 1, PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), OrderId = 1, PaymentMethod = PaymentMethod.Cash,
                Amount = 4
            },
            new PaymentDetail
            {
                PaymentNumber = 2, PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), OrderId = 2, PaymentMethod = PaymentMethod.Cash,
                Amount = 5
            },
            new PaymentDetail
            {
                PaymentNumber = 3, PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), OrderId = 3, PaymentMethod = PaymentMethod.CreditCard,
                Amount = 6
            },
            new PaymentDetail
            {
                PaymentNumber = 4, PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), OrderId = 4, PaymentMethod = PaymentMethod.CreditCard,
                Amount = 7
            },
            new PaymentDetail
            {
                PaymentNumber = 5, PaymentDate = new DateTime(2025, 3, 15, 7, 46, 45, 612, DateTimeKind.Local), OrderId = 5, PaymentMethod = PaymentMethod.CreditCard,
                Amount = 8
            }
        ];
    }

    public static List<User> SeedUsers()
    {
        return
        [
            new User
            {
                Id = 1,
                Username = "ruba",
                Password = "12345",
                Role = UserRole.User
            },
            new User
            {
                Id = 2,
                Username = "ali",
                Password = "12345",
                Role = UserRole.Admin
            }
        ];
    }
}
