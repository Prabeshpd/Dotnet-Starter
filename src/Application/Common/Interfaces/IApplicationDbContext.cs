using Microsoft.EntityFrameworkCore;
using PetStore.Domain.Entities;

namespace PetStore.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Pet> Pets {get;}
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
