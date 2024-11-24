using System;
using AmlApi.Business.Creators.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Enums;
using AmlApi.DataAccess.Queries.Commands.Interfaces;

namespace AmlApi.Business.Creators;

public class UserInventoryCreator : IUserInventoryCreator
{
    private readonly IInsertEntityCommand insertEntityCommand;

    public UserInventoryCreator(IInsertEntityCommand insertEntityCommand)
    {
        this.insertEntityCommand = insertEntityCommand;
    }

    public async void Create(int mediaKey, int userKey)
    {
        var userInventory = new UserInventory
        {
            InventoryKey = mediaKey,
            UserKey = userKey,
            BorrowedDate = DateTime.Today.Date,
            ReturnDate = DateTime.Today.AddDays(10).Date,
            StatusKey = (int)MediaStatusEnum.Borrowed
        };

        await insertEntityCommand.Execute(userInventory);
    }
}