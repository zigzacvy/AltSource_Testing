using System;
using System.Data.SqlTypes;
using  System.Collections;
using System.Collections.Generic;
using AltSource_TestingProject.Model;

namespace AltSource_TestingProject.Service
{
    public interface IBaseService<T>
        where T :class

    {
    bool Sell(T clothes, int quanlity);
    bool Buy(T clothes);
    T FindById(string Id);
    }
}