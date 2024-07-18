using System.Threading.Tasks.Dataflow;
using PetStore.Domain.Common;
using PetStore.Domain.Enums;

namespace PetStore.Domain.Entities;

public class Pet : BaseAuditableEntity
{
  public required string  Uuid { get; set; }
  public required string Name { get; set; }
  public required Species Species { get; set; }
  public required bool IsAvailable { get; set; } 
  public required DateOnly BirthYear { get; set; }
  public required DateTime DateAdded { get; set; }
  public required string PhotoUrl { get; set; }
  
}
