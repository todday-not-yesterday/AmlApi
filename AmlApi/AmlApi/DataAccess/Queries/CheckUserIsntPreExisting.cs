using System;
using System.Linq;
using System.Threading.Tasks;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AmlApi.DataAccess.Queries;

public class CheckUserIsntPreExisting : ICheckUserIsntPreExisting
{

    private readonly IDataContextFactory dataContextFactory;

    public CheckUserIsntPreExisting(IDataContextFactory dataContextFactory)
    {
        this.dataContextFactory = dataContextFactory;
    }

    public bool UserExists(User user)
    {
        using (var context = dataContextFactory.Create())
        {
            var exists = context.Users
                .Any(x => x.UserName == user.UserName);

            return exists;
        }
    }
}