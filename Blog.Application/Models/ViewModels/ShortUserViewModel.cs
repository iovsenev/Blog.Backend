namespace Blog.Application.Models.ViewModels;
public record ShortUserViewModel
{
    
    public ShortUserViewModel(Guid id, string user_name, DateTime register_date)
    {
        Id = id;
        UserName = user_name;
        RegisterDate = register_date;
    }

    public Guid Id{get;set;}
    public string UserName { get; set; }
    public DateTime RegisterDate{get;set;}
}
