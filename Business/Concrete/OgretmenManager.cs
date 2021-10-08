using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OgretmenManager : IOgretmenService
    {
        private readonly IOgretmenDal _ogretmenDal;

        public OgretmenManager(IOgretmenDal ogretmenDal)
        {
            _ogretmenDal = ogretmenDal;
        }

        [CacheRemoveAspect("IOgretmenService.Get")]
        [ValidationAspect(typeof(OgretmenValidator))]
        public IResult Add(Ogretmen ogretmen)
        {
            _ogretmenDal.Add(ogretmen);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IOgretmenService.Get")]
        public IResult Delete(Ogretmen ogretmen)
        {
            _ogretmenDal.Delete(ogretmen);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Ogretmen>> GetAll()
        {
            return new SuccessDataResult<List<Ogretmen>>(_ogretmenDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Ogretmen> GetById(int ogretmenId)
        {
            return new SuccessDataResult<Ogretmen>(_ogretmenDal.Get(o => o.Id == ogretmenId));
        }

        [CacheAspect]
        public IDataResult<List<OgretmenOgrenciSayisiDto>> OgretmenOgrenciSayisi()
        {
            var result = new SuccessDataResult<List<OgretmenOgrenciSayisiDto>>(_ogretmenDal.OgretmenOgrenciSayisi(), Messages.Listed);
            return result;
        }

        [CacheRemoveAspect("IOgretmenService.Get")]
        [ValidationAspect(typeof(OgretmenValidator))]
        public IResult Update(Ogretmen ogretmen)
        {
            _ogretmenDal.Update(ogretmen);
            return new SuccessResult(Messages.Updated);
        }
    }
}
