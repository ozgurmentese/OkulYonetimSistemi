using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class OgrenciManager : IOgrenciService
    {
        private readonly IOgrenciDal _ogrenciDal;

        public OgrenciManager(IOgrenciDal ogrenciDal)
        {
            _ogrenciDal = ogrenciDal;
        }

        [CacheRemoveAspect("IOgrenciService.Get")]
        [ValidationAspect(typeof(OgrenciValidator))]
        public IResult Add(Ogrenci ogrenci)
        {
            var result = BusinessRules.Run(OgrenciAdiKontrol(ogrenci.Ad));
            if (result !=null)
            {
                return result;
            }
            _ogrenciDal.Add(ogrenci);
            return new SuccessResult(Messages.Added);
        }

        [CacheRemoveAspect("IOgrenciService.Get")]
        public IResult Delete(Ogrenci ogrenci)
        {
            _ogrenciDal.Delete(ogrenci);
            return new SuccessResult(Messages.Deleted);
        }

        [CacheAspect]
        public IDataResult<List<Ogrenci>> GetAll()
        {
            return new SuccessDataResult<List<Ogrenci>>(_ogrenciDal.GetAll(), Messages.Listed);
        }

        [CacheAspect]
        public IDataResult<Ogrenci> GetById(int ogrenciId)
        {
            return new SuccessDataResult<Ogrenci>(_ogrenciDal.Get(o => o.Id == ogrenciId));
        }

        [CacheAspect]
        public IDataResult<List<OgrenciOgretmenDto>> GetOgrenciOgretmen()
        {
            return new SuccessDataResult<List<OgrenciOgretmenDto>>(_ogrenciDal.GetOgrenciOgretmen(), Messages.Listed);
        }

        [CacheRemoveAspect("IOgrenciService.Get")]
        [ValidationAspect(typeof(OgrenciValidator))]
        public IResult Update(Ogrenci ogrenci)
        {
            _ogrenciDal.Update(ogrenci);
            return new SuccessResult(Messages.Updated);
        }

        private IResult OgrenciAdiKontrol(string ogrenciAdi)
        {
            var result = _ogrenciDal.GetAll(o => o.Ad == ogrenciAdi).Any();
            if (result)
            {
                return new SuccessResult(Messages.OgrenciZatenMevcut);
            }
            return new SuccessResult();
        }
    }
}
