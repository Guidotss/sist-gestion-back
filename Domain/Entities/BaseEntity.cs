namespace Domain.Entities;

public class BaseEntity
{
   public Guid Id { get; set; }
   public string? Name { get; set; }
   public string? Desctiption { get; set; }
   public DateTime CreatedAt { get; set; }
   public DateTime UpdatedAt { get; set; }
   public bool IsDeleted { get; set; }


   protected BaseEntity() {}

   public void Initialize()
   {
      DateTime stamp = DateTime.Now;
      CreatedAt = stamp;
      UpdatedAt = stamp;
      IsDeleted = false;
   }
}