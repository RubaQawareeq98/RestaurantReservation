using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestaurantReservation.DB;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation;

static class Program
{
    private const string Message = "Please enter a valid integer";
    
        static async Task Main()
    {
        using IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices((_, services) =>
            {
                services.AddDbContext<RestaurantReservationDbContext>();
                services.AddScoped<ICustomerRepository, CustomerRepository>();
                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<IReservationRepository, ReservationRepository>();
                services.AddScoped<IOrderRepository, OrderRepository>();
                services.AddScoped<IOrderItemRepository, OrderItemRepository>();
                services.AddScoped<IMenuItemRepository, MenuItemRepository>();
                services.AddScoped<IRestaurantRepository, RestaurantRepository>();
                services.AddScoped<ITableRepository, TableRepository>();
            })
            .Build();
        
        using var scope = host.Services.CreateScope();
        var services = scope.ServiceProvider;
        
        var context = services.GetRequiredService<RestaurantReservationDbContext>();
        
        var customerRepo = services.GetRequiredService<ICustomerRepository>();
        var employeeRepo = services.GetRequiredService<IEmployeeRepository>();
        var orderRepo = services.GetRequiredService<IOrderRepository>();
        var orderItemRepo = services.GetRequiredService<IOrderItemRepository>();
        var restaurantRepo = services.GetRequiredService<IRestaurantRepository>();
        var reservationRepo = services.GetRequiredService<IReservationRepository>();
        var menuItemRepo = services.GetRequiredService<IMenuItemRepository>();
        var tableRepository = services.GetRequiredService<ITableRepository>();
        
        await CallCustomerCrudOperations(customerRepo);
        await CallEmployeeCrudOperations(employeeRepo);
        await CallRestaurantCrudOperations(restaurantRepo);
        await CallReservationCrudOperations(reservationRepo);
        await CallTableCrudOperations(tableRepository);
        await CallOrderCrudOperations(orderRepo);
        await CallOrderItemCrudOperations(orderItemRepo);
        await CallMenuItemCrudOperations(menuItemRepo);
        await ListManagers(employeeRepo);
        await GetReservationsByCustomer(reservationRepo);
        await ListOrdersAndMenuItems(orderRepo);
        await ListOrderedMenuItems(menuItemRepo);
        await CalculateAverageOrderAmount(employeeRepo);
        await QueryReservationDetailsView(context);
        await QueryEmployeeWithRestaurantDetailsView(context);
    }

    private static async Task CallCustomerCrudOperations(ICustomerRepository customerRepository)
    {
        var customer = new Customer { FirstName = "Eman", LastName = "Ahmad", Email = "emanahmad@gmail.com", PhoneNumber = "123456789" };
        await customerRepository.AddAsync(customer);
        
        customer.PhoneNumber = "059789456";
        await customerRepository.UpdateAsync(customer);

        var customers = await customerRepository.GetAllAsync();
        var deletedCustomer = customers.FirstOrDefault();
        await customerRepository.DeleteAsync(deletedCustomer);
        
        customers.ForEach(Console.WriteLine);
    }
    
    private static async Task CallEmployeeCrudOperations(IEmployeeRepository employeeRepository)
    {
        var employee = new Employee { FirstName = "Eman", LastName = "Ahmad", PositionId = 2, RestaurantId = 3};
        await employeeRepository.AddAsync(employee);

        employee.RestaurantId = 2;
        await employeeRepository.UpdateAsync(employee);

        var employees = await employeeRepository.GetAllAsync();
        var deletedEmployee = employees.FirstOrDefault();
        await employeeRepository.DeleteAsync(deletedEmployee);
        
        employees.ForEach(Console.WriteLine);
    }
 
    private static async Task CallRestaurantCrudOperations(IRestaurantRepository restaurantRepository)
    {
        var restaurant = new Restaurant {Name = "Restaurant7", Address = "Nablus", PhoneNumber = "123456789"};
        await restaurantRepository.AddAsync(restaurant);

        restaurant.Name = "KFC";
        await restaurantRepository.UpdateAsync(restaurant);

        var restaurants = await restaurantRepository.GetAllAsync();
        var deletedRestaurant = restaurants.FirstOrDefault();
        await restaurantRepository.DeleteAsync(deletedRestaurant);
        
        restaurants.ForEach(Console.WriteLine);
    }
 
    private static async Task CallReservationCrudOperations(IReservationRepository reservationRepository)
    {
        var reservation = new Reservation { CustomerId = 7, RestaurantId = 3, TableId = 1, PartySize = 5, ReservationDate = DateTime.Now };
        await reservationRepository.AddAsync(reservation);

        reservation.PartySize = 7;
        await reservationRepository.UpdateAsync(reservation);

        var restaurants = await reservationRepository.GetAllAsync();
        var deletedRestaurant = restaurants.FirstOrDefault();
        await reservationRepository.DeleteAsync(deletedRestaurant);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallTableCrudOperations(ITableRepository tableRepository)
    {
        var table = new Table { RestaurantId = 4, Capacity = 5};
        await tableRepository.AddAsync(table);

        table.Capacity = 9;
        await tableRepository.UpdateAsync(table);

        var restaurants = await tableRepository.GetAllAsync();
        var deletedTable = restaurants.FirstOrDefault();
        await tableRepository.DeleteAsync(deletedTable);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallOrderCrudOperations(IOrderRepository orderRepository)
    {
        var order = new Order
        {
            ReservationId = 4, OrderDate = DateTime.Now, EmployeeId = 2,
            PaymentDetail = new PaymentDetail { PaymentDate = DateTime.Now, PaymentMethod = PaymentMethod.CreditCard, PaymentNumber = 7, Amount = 11 }
        };
        await orderRepository.AddAsync(order);

        order.EmployeeId = 4;
        await orderRepository.UpdateAsync(order);
        
        var restaurants = await orderRepository.GetAllAsync();
        var deletedOrder = restaurants.FirstOrDefault();
        await orderRepository.DeleteAsync(deletedOrder);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallOrderItemCrudOperations(IOrderItemRepository orderItemRepository)
    {
        var orderItem = new OrderItem { OrderId = 2, MenuItemId = 1, Quantity = 7 };
        await orderItemRepository.AddAsync(orderItem);

        orderItem.Quantity = 12;
        await orderItemRepository.UpdateAsync(orderItem);

        var restaurants = await orderItemRepository.GetAllAsync();
        var deletedOrderItem = restaurants.FirstOrDefault();
        await orderItemRepository.DeleteAsync(deletedOrderItem);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallMenuItemCrudOperations(IMenuItemRepository menuItemRepository)
    {
        var menuItem = new MenuItem { RestaurantId = 4, Description = "New Item", Name = "Item7", Price = 108 };
        await menuItemRepository.AddAsync(menuItem);

        menuItem.Price = 122;
        await menuItemRepository.UpdateAsync(menuItem);

        var restaurants = await menuItemRepository.GetAllAsync();
        var deletedOrderItem = restaurants.FirstOrDefault();
        await menuItemRepository.DeleteAsync(deletedOrderItem);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task ListManagers(IEmployeeRepository employeeRepository)
    {
        var managers = await employeeRepository.GetManagersAsync();

        if (managers.Count == 0)
        {
            Console.WriteLine("There are no managers");
        }
        managers.ForEach(Console.WriteLine);
    }

    private static async Task GetReservationsByCustomer(IReservationRepository reservationRepository)
    {
        Console.WriteLine("Getting Enter the Customer ID");
        var isValid = int.TryParse(Console.ReadLine(), out var customerId);
        if (!isValid)
        {
            throw new ArgumentException(Message);
        }
        var reservations = await reservationRepository.GetReservationsByCustomer(customerId);

        if (reservations.Count == 0)
        {
            Console.WriteLine("There are no reservations");
        }
        reservations.ForEach(Console.WriteLine);
    }

    private static async Task ListOrdersAndMenuItems(IOrderRepository orderRepository)
    {
        Console.WriteLine("Getting Enter the Reservation ID");
        var isValid = int.TryParse(Console.ReadLine(), out var reservationId);
        if (!isValid)
        {
            throw new ArgumentException(Message);
        }
        
        var orders = await orderRepository.ListOrdersAndMenuItems(reservationId);
        foreach (var order in orders)
        {
            Console.WriteLine(order);
            foreach (var orderItem in order.OrderItems)
            {
                Console.WriteLine(orderItem);
            }
        }
    }

    private static async Task ListOrderedMenuItems(IMenuItemRepository menuItemRepository)
    {
        Console.WriteLine("Getting Enter the Reservation ID");
        var isValid = int.TryParse(Console.ReadLine(), out var reservationId);
        if (!isValid)
        {
            throw new ArgumentException(Message);
        }

        var menuItems = await menuItemRepository.ListOrderedMenuItems(reservationId);
        if (menuItems.Count == 0)
        {
            Console.WriteLine("There are no ordered items");
        }
        menuItems.ForEach(Console.WriteLine);
    }

    private static async Task CalculateAverageOrderAmount(IEmployeeRepository employeeRepository)
    {
        Console.WriteLine("Getting Enter the Employee ID");
        var isValid = int.TryParse(Console.ReadLine(), out var employeeId);
        if (!isValid)
        {
            throw new ArgumentException(Message);
        }

        var averageOrderAmount = await employeeRepository.CalculateAverageOrderAmount(employeeId);
        Console.WriteLine($"Average order amount: {averageOrderAmount}");
    }

    private static async Task QueryReservationDetailsView(RestaurantReservationDbContext context)
    {
        var reservationDetails = await context.ReservationDetails.ToListAsync();
        reservationDetails.ForEach(Console.WriteLine);
    }
    
    private static async Task QueryEmployeeWithRestaurantDetailsView(RestaurantReservationDbContext context)
    {
        var reservationDetails = await context.EmployeeWithRestaurantDetails.ToListAsync();
        reservationDetails.ForEach(Console.WriteLine);
    }
}
