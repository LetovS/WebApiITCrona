﻿using Microsoft.EntityFrameworkCore;
using WebApiITCrona.Infrastructure.Context.Abstract.Context;
using WebApiITCrona.Infrastructure.Context.Entity;

namespace WebApiITCrona.Infrastructure.Context;

/// <summary>
/// Контекст базы данных
/// </summary>
public class CallStorageContext :
    DbContext,
    ICallStorageContext,
    IDbReader,
    IDbWriter,
    IUnitOfWork
{
    /// <summary>
    /// ctor.
    /// </summary>
    public CallStorageContext(DbContextOptions<CallStorageContext> options) : base(options) { }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    /// <inheritdoc />
    public DbSet<CallEntity> Calls => Set<CallEntity>();

    IQueryable<TEntity> IDbReader.Read<TEntity>() => base.Set<TEntity>().AsNoTracking().AsQueryable();

    void IDbWriter.Add<TEntity>(TEntity data) => base.Entry(data).State = EntityState.Added;

    void IDbWriter.Update<TEntity>(TEntity data) => base.Entry(data).State = EntityState.Modified;

    void IDbWriter.Delete<TEntity>(TEntity data) => base.Entry(data).State = EntityState.Deleted;

    /// <inheritdoc cref="IUnitOfWork"/>
    public override async Task<int> SaveChangesAsync(CancellationToken ct)
    {
        var count = await base.SaveChangesAsync(ct);

        foreach (var entry in base.ChangeTracker.Entries().ToArray())
        {
            entry.State = EntityState.Detached;
        }

        return count;
    }
}
