using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOgretmenService
    {
        IResult Add(Ogretmen ogretmen);
        IResult Update(Ogretmen ogretmen);
        IResult Delete(Ogretmen ogretmen);
        IDataResult<List<Ogretmen>> GetAll();
        IDataResult<Ogretmen> GetById(int ogretmenId);
        IDataResult<List<OgretmenOgrenciSayisiDto>> OgretmenOgrenciSayisi();
    }
}
