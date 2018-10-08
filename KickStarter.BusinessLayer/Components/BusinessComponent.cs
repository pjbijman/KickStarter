using KickStarter.BusinessLayer.Components.Interfaces;
using KickStarter.DataLayer.DI;
using KickStarter.Library.Entities;
using System;
using System.Collections.Generic;
using FluentValidation;

namespace KickStarter.BusinessLayer.Components
{
    public class BusinessComponent : IBusinessComponent
    {
        protected IUnitOfWork UnitOfWork;

        protected BusinessComponent(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            InstanceGuid = Guid.NewGuid();
            ValidationResults = new HashSet<string>();
        }

        public Guid InstanceGuid { get; protected set; }
        public HashSet<string> ValidationResults { get; protected set; }
        public bool IsValid => ValidationResults.Count == 0;

        public virtual void Dispose()
        {
            if (UnitOfWork != null) UnitOfWork.Dispose();
        }

        public bool Validate<T>(IValidator<T> validator, T entity) where T : BaseEntity
        {
            var validationResult = validator.Validate(entity);
            foreach (var error in validationResult.Errors)
                if (string.IsNullOrEmpty(error.PropertyName))
                {
                    if (!ValidationResults.Contains(error.ErrorMessage)) ValidationResults.Add(error.ErrorMessage);
                }
                else
                {
                    entity.AddError(error.PropertyName, error.ErrorMessage);
                }

            return validationResult.IsValid;
        }
    }
}
