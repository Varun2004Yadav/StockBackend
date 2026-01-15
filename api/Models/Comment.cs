using System;

namespace api.Models;

public class Comment
{
    public int Id {get; set; }

    public int Title {get; set; }

    public string Content {get; set; } = string.Empty;

    public DateTime CreatedOn { get; set; } = DateTime.Now;

    public int? StockId {get; set; }
    //Navigation Property
    public Stock? Stock {get; set; }

}
