using PetStore.Domain.Common;

namespace PetStore.Domain.Entities;

public class Pet : BaseAuditableEntity
{
  public required string  Uuid { get; set; }
  public required string Name { get; set; }
  
}
