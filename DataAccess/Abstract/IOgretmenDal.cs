﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.Dtos;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IOgretmenDal : IEntityRepository<Ogretmen>
    {
        List<OgretmenOgrenciSayisiDto> OgretmenOgrenciSayisi();
    }
}
