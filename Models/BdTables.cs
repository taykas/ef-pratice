using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;


public class UserData
{
    public int ID { get; set; }
    public string Username { get; set; }
    public string Pass { get; set; }
    public bool IsAdm { get; set; }
    public ICollection<Sale> Sales { get; set; }
}

public class ProductItem
{
    public int ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}

public class Sale
{
    public int ID { get; set; }
    public int ProductId { get; set; }
    public ProductItem ProductItem { get; set; }
    public int UserDataId { get; set; }
    public UserData UserData { get; set; }
    public DateTime BuyDate { get; set; }
}