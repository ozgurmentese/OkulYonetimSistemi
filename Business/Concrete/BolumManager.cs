using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BolumManager : IBolumService
    {
        private readonly IBolumDal _bolumDal;

        public BolumManager(IBolumDal bolumDal)
        {
            _bolumDal = bolumDal;
        }

        [CacheRemoveAspect("IBolumService.Get")]
        [ValidationAspect(typeof(BolumValidator))]
        public IResult Add(Bolum bolum)
        {
            _bolumDal.Add(bolum);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IBolumService.Get")]
        public IResult Delete(Bolum bolum)
        {
            _bolumDal.Delete(bolum);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Bolum>> GetAll()
        {
            return new SuccessDataResult<List<Bolum>>(_bolumDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Bolum> GetById(int bolumId)
        {
            return new SuccessDataResult<Bolum>(_bolumDal.Get(b => b.Id == bolumId), Messages.Listed);
        }

        [CacheRemoveAspect("IBolumService.Get")]
        [ValidationAspect(typeof(BolumValidator))]
        public IResult Update(Bolum bolum)
        {
            _bolumDal.Update(bolum);
            return new SuccessResult(Messages.Updated);
        }
    }
}
