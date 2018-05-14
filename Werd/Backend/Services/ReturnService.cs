using System.Collections.Generic;
using Backend.Entities;
using Backend.Repositories;

namespace Backend.Services
{
    public class ReturnService
    {
        private readonly WerdRepository _repository;

        public ReturnService()
        {
            _repository = new WerdRepository();
        }

        public IEnumerable<Return> Get()
        {
            var returns = _repository.GetReturns();

            return returns;
        }

        public Return Get(string id)
        {
            return _repository.GetReturn(id);
        }
    }
}