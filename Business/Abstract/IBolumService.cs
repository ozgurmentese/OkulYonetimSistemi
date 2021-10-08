using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBolumService
    {
        IResult Add(Bolum bolum);
        IResult Update(Bolum bolum);
        IResult Delete(Bolum bolum);
        IDataResult<List<Bolum>> GetAll();
        IDataResult<Bolum> GetById(int bolumId);
    }
}
