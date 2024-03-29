﻿using Modelo.Domain.Interfaces.Repositories;
using Modelo.Domain.Interfaces.Services;
using Modelo.Infra.Cross.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Modelo.Service
{
    public abstract class BaseService<TEntity, TEntityDTO> : IDisposable, IBaseService<TEntityDTO>
        where TEntity : class
        where TEntityDTO : IEntityDTO
    {
        private readonly IBaseRepository<TEntity, TEntityDTO> _repository;

        public BaseService(IBaseRepository<TEntity, TEntityDTO> repository)
        {
            _repository = repository;
        }

        public void Add(TEntityDTO entity)
        {
            _repository.Add(entity);
        }

        public IEnumerable<TEntityDTO> GetAll()
        {
            return _repository.GetAll();
        }

        public TEntityDTO GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Remove(int id)
        {
            _repository.Remove(id);
        }

        public void Update(TEntityDTO entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
