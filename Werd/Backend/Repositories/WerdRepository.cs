using System;
using System.Collections.Generic;
using System.Linq;
using Backend.Entities;
using Backend.Enumerations;

namespace Backend.Repositories
{
    public class WerdRepository
    {
        private const int AccountId = 980317;

        private static readonly IEnumerable<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                AccountId = AccountId,
                FirstName = "Jared",
                LastName = "Bebb"
            },
            new User
            {
                Id = 2,
                AccountId = AccountId,
                FirstName = "Drew",
                LastName = "Coleman"
            },
            new User
            {
                Id = 3,
                AccountId = AccountId,
                FirstName = "Brandon",
                LastName = "Martin"
            },
            new User
            {
                Id = 4,
                AccountId = AccountId,
                FirstName = "Chris",
                LastName = "Olson"
            },
            new User
            {
                Id = 5,
                AccountId = AccountId,
                FirstName = "James",
                LastName = "Pickett"
            },
            new User
            {
                Id = 6,
                AccountId = AccountId,
                FirstName = "Melvin",
                LastName = "Rowlett"
            }
        };

        private readonly IEnumerable<Return> _returns = new List<Return>
        {
            new Return
            {
                Id = "XKS201",
                Product = ReturnType.Individual,
                TaxYear = 2017,
                Preparer = Users.First(x => x.Id == 6),
                TaxPayer = Users.First(x => x.Id == 1),
                FederalStatus = ReturnStatus.Rejected,
                FederalDate = DateTime.Parse("03/17/2018"),
                State = State.KS,
                StateStatus = ReturnStatus.Accepted,
                StateDate = DateTime.Parse("03/17/2018")
            },
            new Return
            {
                Id = "XKS202",
                Product = ReturnType.Individual,
                TaxYear = 2017,
                Preparer = Users.First(x => x.Id == 6),
                TaxPayer = Users.First(x => x.Id == 2),
                FederalStatus = ReturnStatus.Accepted,
                FederalDate = DateTime.Parse("03/19/2018"),
                State = State.KS,
                StateStatus = ReturnStatus.Accepted,
                StateDate = DateTime.Parse("03/19/2018")
            },
            new Return
            {
                Id = "XKS203",
                Product = ReturnType.Individual,
                TaxYear = 2017,
                Preparer = Users.First(x => x.Id == 6),
                TaxPayer = Users.First(x => x.Id == 3),
                FederalStatus = ReturnStatus.Accepted,
                FederalDate = DateTime.Parse("03/23/2018"),
                State = State.KS,
                StateStatus = ReturnStatus.SchemaValidationError,
                StateDate = DateTime.Parse("03/23/2018")
            },
            new Return
            {
                Id = "XKS204",
                Product = ReturnType.Individual,
                TaxYear = 2017,
                Preparer = Users.First(x => x.Id == 6),
                TaxPayer = Users.First(x => x.Id == 4),
                FederalStatus = ReturnStatus.Accepted,
                FederalDate = DateTime.Parse("03/13/2018"),
                State = State.KS,
                StateStatus = ReturnStatus.Accepted,
                StateDate = DateTime.Parse("03/13/2018")
            },
            new Return
            {
                Id = "XKS205",
                Product = ReturnType.Individual,
                TaxYear = 2017,
                Preparer = Users.First(x => x.Id == 6),
                TaxPayer = Users.First(x => x.Id == 5),
                FederalStatus = ReturnStatus.ReadyToRelease,
                FederalDate = DateTime.Parse("04/01/2018"),
                State = State.KS,
                StateStatus = ReturnStatus.ReadyToRelease,
                StateDate = DateTime.Parse("04/05/2018")
            }
        };

        public IEnumerable<Return> GetReturns()
        {
            return _returns;
        }

        public Return GetReturn(string id)
        {
            return _returns.First(x => x.Id == id);
        }

        public IEnumerable<User> GetUsers()
        {
            return Users;
        }

        public User GetUser(int id)
        {
            return Users.First(x => x.Id == id);
        }
    }
}