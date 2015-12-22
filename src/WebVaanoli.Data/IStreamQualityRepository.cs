﻿using System;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Domain;

namespace WebVaanoli.Data
{
    public interface IStreamQualityRepository
    {
        StreamQuality Find(int id);
        IQueryable<StreamQuality> FindAll(Expression<Func<StreamQuality, bool>> filter = null);
    }
}
