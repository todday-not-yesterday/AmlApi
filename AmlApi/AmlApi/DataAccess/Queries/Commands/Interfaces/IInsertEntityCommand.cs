﻿using System.Threading.Tasks;

namespace AmlApi.DataAccess.Queries.Commands.Interfaces;

public interface IInsertEntityCommand
{
    Task Execute<T>(T entity) where T : class;
    Task Execute<T>(T entity, IAppDbContext context) where T : class;
}