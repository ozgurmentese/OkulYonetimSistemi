using Entities.Concrete;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.NHibernate.Mappings
{
    public class EntityMap : ClassMap<Ogrenci>
    {
        public EntityMap()
        {
            Table(@"Categories");

            LazyLoad();

            Id(x => x.Id);
            
        }
    }
}
