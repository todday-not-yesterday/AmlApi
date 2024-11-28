using AmlApi.Business.Creators.Interfaces;
using AmlApi.DataAccess;
using AmlApi.DataAccess.Entities;
using AmlApi.DataAccess.Queries.Commands.Interfaces;
using AmlApi.DataAccess.Queries.Interfaces;
using System;

namespace AmlApi.Business.Creators;

public class UserCreator : IUserCreator
{
    private readonly IInsertEntityCommand insertEntityCommand;
    private readonly IDataContextFactory dataContextFactory;
    private readonly ICheckUserIsntPreExisting checkUserIsntPreExisting;

    public UserCreator(IInsertEntityCommand insertEntityCommand,
                       IDataContextFactory dataContextFactory,
                       ICheckUserIsntPreExisting checkUserIsntPreExisting)
    {
        this.insertEntityCommand = insertEntityCommand;
        this.dataContextFactory = dataContextFactory;
        this.checkUserIsntPreExisting = checkUserIsntPreExisting;
    }

    public void Create(User user)
    {
        var context = this.dataContextFactory.Create();

        if (!IsValid(user, out string errorMessage))
        {
            throw new ArgumentException(errorMessage);
        }

        user.UserLevel = 1;
        user.IsVerified = false;

        var AlreadyExists = checkUserIsntPreExisting.UserExists(user);

        if (AlreadyExists)
        {
            throw new InvalidOperationException("The user already exists.");
        }

        insertEntityCommand.Execute(user, context);
    }
    private bool IsValid(User user, out string errorMessage)
    {
        errorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(user.FirstName))
        {
            errorMessage = "First Name is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.LastName))
        {
            errorMessage = "Last Name is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.Address))
        {
            errorMessage = "Address is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.PostCode))
        {
            errorMessage = "PostCode is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.Email))
        {
            errorMessage = "Email is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.ContactNumber))
        {
            errorMessage = "Contact Number is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.UserName))
        {
            errorMessage = "Username is required.";
            return false;
        }
        if (string.IsNullOrWhiteSpace(user.Password))
        {
            errorMessage = "Password is required.";
            return false;
        }
        if (user.DateOfBirth == default(DateTime))
        {
            errorMessage = "Date of Birth is required.";
            return false;
        }

        if (!user.Consent)
        {
            errorMessage = "Consent is required.";
            return false;
        }

        return true;
    }
}