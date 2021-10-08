using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IOgrenciService
    {
        IResult Add(Ogrenci ogrenci);
        IResult Update(Ogrenci ogrenci);
        IResult Delete(Ogrenci ogrenci);
        IDataResult<List<Ogrenci>> GetAll();
        IDataResult<Ogrenci> GetById(int ogrenciId);
        IDataResult<List<OgrenciOgretmenDto>> GetOgrenciOgretmen();
    }
}
