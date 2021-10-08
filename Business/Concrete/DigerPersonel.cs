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
    public class DigerPersonelManager : IDigerPersonelService
    {
        private readonly IDigerPersonelDal _digerPersonelDal;

        public DigerPersonelManager(IDigerPersonelDal digerPersonelDal)
        {
            _digerPersonelDal = digerPersonelDal;
        }

        [CacheRemoveAspect("IDigerBolumService.Get")]
        [ValidationAspect(typeof(DigerPersonelValidator))]
        public IResult Add(DigerPersonel digerPersonel)
        {
            _digerPersonelDal.Add(digerPersonel);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IDigerBolumService.Get")]
        public IResult Delete(DigerPersonel digerPersonel)
        {
            _digerPersonelDal.Delete(digerPersonel);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<DigerPersonel>> GetAll()
        {
            return new SuccessDataResult<List<DigerPersonel>>(_digerPersonelDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<DigerPersonel> GetById(int digerPersonelId)
        {
            return new SuccessDataResult<DigerPersonel>(_digerPersonelDal.Get(d => d.Id == digerPersonelId),Messages.Listed);
        }

        [CacheRemoveAspect("IDigerBolumService.Get")]
        [ValidationAspect(typeof(DigerPersonelValidator))]
        public IResult Update(DigerPersonel digerPersonel)
        {
            _digerPersonelDal.Update(digerPersonel);
            return new SuccessResult(Messages.Updated);
        }
    }
}