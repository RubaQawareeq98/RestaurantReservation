using RestaurantReservation.DB;
using RestaurantReservation.DB.Models.Entities;
using RestaurantReservation.DB.Repositories.Interfaces;
using RestaurantReservation.DB.Repositories.Repos;

namespace RestaurantReservation;

static class Program
{
    private static RestaurantReservationDbContext _context = new RestaurantReservationDbContext();

    private static async Task CallCustomerCrudOperations()
    {
        ICustomerRepository customerRepository = new CustomerRepository( _context );
        var customer = new Customer { FirstName = "Eman", LastName = "Ahmad", Email = "emanahmad@gmail.com", PhoneNumber = "123456789" };
        await customerRepository.AddAsync(customer);
        
        customer.PhoneNumber = "059789456";
        await customerRepository.UpdateAsync(customer);

        var customers = await customerRepository.GetAllAsync();
        var deletedCustomer = customers.FirstOrDefault();
        await customerRepository.DeleteAsync(deletedCustomer);
        
        customers.ForEach(Console.WriteLine);
    }
    
    private static async Task CallEmployeeCrudOperations()
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository(_context);
        
        var employee = new Employee { FirstName = "Eman", LastName = "Ahmad", PositionId = 2, RestaurantId = 3};
        await employeeRepository.AddAsync(employee);

        employee.RestaurantId = 2;
        await employeeRepository.UpdateAsync(employee);

        var employees = await employeeRepository.GetAllAsync();
        var deletedEmployee = employees.FirstOrDefault();
        await employeeRepository.DeleteAsync(deletedEmployee);
        
        employees.ForEach(Console.WriteLine);
    }
 
    private static async Task CallRestaurantCrudOperations()
    {
        IRestaurantRepository restaurantRepository = new RestaurantRepository(_context);
        
        var restaurant = new Restaurant {Name = "Restaurant7", Address = "Nablus", PhoneNumber = "123456789"};
        await restaurantRepository.AddAsync(restaurant);

        restaurant.Name = "KFC";
        await restaurantRepository.UpdateAsync(restaurant);

        var restaurants = await restaurantRepository.GetAllAsync();
        var deletedRestaurant = restaurants.FirstOrDefault();
        await restaurantRepository.DeleteAsync(deletedRestaurant);
        
        restaurants.ForEach(Console.WriteLine);
    }
 
    private static async Task CallReservationCrudOperations()
    {
        IReservationRepository reservationRepository = new ReservationRepository(_context);
        
        var reservation = new Reservation { CustomerId = 2, RestaurantId = 3, TableId = 1, PartySize = 5, ReservationDate = DateTime.Now };
        await reservationRepository.AddAsync(reservation);

        reservation.PartySize = 7;
        await reservationRepository.UpdateAsync(reservation);

        var restaurants = await reservationRepository.GetAllAsync();
        var deletedRestaurant = restaurants.FirstOrDefault();
        await reservationRepository.DeleteAsync(deletedRestaurant);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallTableCrudOperations()
    {
        ITableRepository tableRepository = new TableRepository(_context);

        var table = new Table { RestaurantId = 4, Capacity = 5};
        await tableRepository.AddAsync(table);

        table.Capacity = 9;
        await tableRepository.UpdateAsync(table);

        var restaurants = await tableRepository.GetAllAsync();
        var deletedTable = restaurants.FirstOrDefault();
        await tableRepository.DeleteAsync(deletedTable);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallOrderCrudOperations()
    {
        IOrderRepository orderRepository = new OrderRepository(_context);

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

    private static async Task CallOrderItemCrudOperations()
    {
        IOrderItemRepository orderItemRepository = new OrderItemRepository(_context);

        var orderItem = new OrderItem { OrderId = 2, MenuItemId = 1, Quantity = 7 };
        await orderItemRepository.AddAsync(orderItem);

        orderItem.Quantity = 12;
        await orderItemRepository.UpdateAsync(orderItem);

        var restaurants = await orderItemRepository.GetAllAsync();
        var deletedOrderItem = restaurants.FirstOrDefault();
        await orderItemRepository.DeleteAsync(deletedOrderItem);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task CallMenuItemCrudOperations()
    {
        IMenuItemRepository menuItemRepository = new MenuItemRepository(_context);

        var menuItem = new MenuItem { RestaurantId = 4, Description = "New Item", Name = "Item7", Price = 108 };
        await menuItemRepository.AddAsync(menuItem);

        menuItem.Price = 122;
        await menuItemRepository.UpdateAsync(menuItem);

        var restaurants = await menuItemRepository.GetAllAsync();
        var deletedOrderItem = restaurants.FirstOrDefault();
        await menuItemRepository.DeleteAsync(deletedOrderItem);
        
        restaurants.ForEach(Console.WriteLine);
    }

    private static async Task ListManagers()
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository(_context);
        var managers = await employeeRepository.GetManagersAsync();

        if (managers.Count == 0)
        {
            Console.WriteLine("There are no managers");
        }
        managers.ForEach(Console.WriteLine);
    }

    private static async Task GetReservationsByCustomer()
    {
        Console.WriteLine("Getting Enter the Customer ID");
        var isValid = int.TryParse(Console.ReadLine(), out var customerId);
        if (!isValid)
        {
            throw new ArgumentException("Please enter a valid integer");
        }
        IReservationRepository reservationRepository = new ReservationRepository(_context);
        var reservations = await reservationRepository.GetReservationsByCustomer(customerId);

        if (reservations.Count == 0)
        {
            Console.WriteLine("There are no reservations");
        }
        reservations.ForEach(Console.WriteLine);
    }

    private static async Task ListOrdersAndMenuItems(int reservationId)
    {
        IOrderRepository orderRepository = new OrderRepository(_context);
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

    private static async Task ListOrderedMenuItems(int reservationId)
    {
        IMenuItemRepository menuItemRepository = new MenuItemRepository(_context);
        var menuItems = await menuItemRepository.ListOrderedMenuItems(reservationId);
        if (menuItems.Count == 0)
        {
            Console.WriteLine("There are no ordered items");
        }
        menuItems.ForEach(Console.WriteLine);
    }

    private static async Task CalculateAverageOrderAmount(int employeeId)
    {
        IEmployeeRepository employeeRepository = new EmployeeRepository(_context);
        var averageOrderAmount = await employeeRepository.CalculateAverageOrderAmount(employeeId);
        Console.WriteLine($"Average order amount: {averageOrderAmount}");
    }
    
    static async Task Main()
    {
        // await CallCustomerCrudOperations();
        // await CallEmployeeCrudOperations();
        // await CallRestaurantCrudOperations();
        // await CallReservationCrudOperations();
        // await CallTableCrudOperations();
        // await CallOrderCrudOperations();
        // await CallOrderItemCrudOperations();
        // await CallMenuItemCrudOperations();
        // await ListManagers();
        // await GetReservationsByCustomer();

        //await ListOrdersAndMenuItems(1);
        //await ListOrderedMenuItems(4);
        await CalculateAverageOrderAmount(4);
    }
}
