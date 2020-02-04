﻿using System;

namespace ILBLI.SqlSugar
{
    /// <summary>
    /// 用户指定实体类默认的排序方式[ASC排序]
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class OrderByAttribute : Attribute
    {

    }
}
