using Core.Utilities.Results;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IDigerPersonelService
    {
        IResult Add(DigerPersonel digerPersonel);
        IResult Update(DigerPersonel digerPersonel);
        IResult Delete(DigerPersonel digerPersonel);
        IDataResult<List<DigerPersonel>> GetAll();
        IDataResult<DigerPersonel> GetById(int digerPersonelId);
    }
}
