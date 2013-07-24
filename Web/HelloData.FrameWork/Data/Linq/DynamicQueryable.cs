﻿#region Version Info
/* ========================================================================
* 【本类功能概述】
* 
* 作者：王军 时间：2013/3/31 21:17:51
* 文件名：DynamicQueryable
* 版本：V1.0.1
* 联系方式：511522329  
*
* 修改者： 时间： 
* 修改说明：
* ========================================================================
*/
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using HelloData.FrameWork.Data.Linq;

namespace HelloData.FrameWork.Data
{

    public static class DynamicQueryable
    {
        /// <summary>
        ///  查找，删除，更新的where条件的添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataBaseAction"></param>
        /// <param name="wherePredicate"></param>
        /// <returns></returns>
        public static LinqQueryAction<T> Where<T>(this LinqQueryAction<T> dataBaseAction, Expression<Func<T, bool>> wherePredicate)
            where T : BaseEntity
        {
            string command = string.Empty;

            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(wherePredicate.Body);

            if (!String.IsNullOrEmpty(conditionBuilder.Condition))
            {
                command = conditionBuilder.Condition;
            }
            dataBaseAction.CAction.SqlWhere(command);
            return dataBaseAction;
        }

        /// <summary>
        /// 新增，修改的条件的添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="iExpression"></param>
        /// <returns></returns>
        public static LinqQueryAction<T> SqlValue<T>(this LinqQueryAction<T> action,
                                                       Expression<Func<T, bool>> iExpression)
        {
            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(iExpression.Body);
            for (int i = 0; i < conditionBuilder.ConObjects.Count; i++)
            {
                action.CAction.SqlKeyValue(conditionBuilder.ConObjects[i].ToString(), conditionBuilder.Arguments[i]);
            }
            return action;
        }


        /// <summary>
        /// 新增，修改的条件的添加
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="iExpression">直接添加实体类</param>
        /// <returns></returns>
        public static LinqQueryAction<T> SqlValue<T>(this LinqQueryAction<T> action,
                                                       Expression<Func<T, T>> iExpression)
        {
            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(iExpression.Body);
            if (conditionBuilder.ConObjects.Count > 0)
                action.CAction.SetDbEntity((BaseEntity)conditionBuilder.ConObjects[0]);
            return action;
        }
        /// <summary>
        /// 多个新增同时操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        /// <param name="iExpression">直接添加实体类</param>
        /// <returns></returns>
        public static LinqQueryAction InsertList(this LinqQueryAction action,
                                                       Expression<Func<List<BaseEntity>>> iExpression)
        {
            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(iExpression.Body);
            if (conditionBuilder.Arguments.Length > 0)
            {
                List<BaseEntity> entities = ((List<BaseEntity>)conditionBuilder.Arguments[0]).Cast<BaseEntity>().ToList();
                ((InserAction)action.CAction).InsertList(entities);
            }
            return action;
        }


        /// <summary>
        /// order by
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectAction"></param>
        /// <param name="iExpression"></param>
        /// <param name="eByEnum"></param>
        /// <returns></returns>
        public static LinqQueryAction<T> OrderBy<T>(
            this LinqQueryAction<T> selectAction,
               Expression<Func<T, object>> iExpression, OrderByEnum eByEnum)
        {
            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(iExpression.Body);
            selectAction.CAction.SqlOrderBy(conditionBuilder.Condition, eByEnum);
            return selectAction;
        }
        /// <summary>
        /// group by 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selectAction"></param>
        /// <param name="iExpression"></param>
        /// <returns></returns>
        public static LinqQueryAction<T> GroupBy<T>(
                    this LinqQueryAction<T> selectAction,
                    Expression<Func<T, object[]>> iExpression)
        {
            ConditionBuilder conditionBuilder = new ConditionBuilder();
            conditionBuilder.Build(iExpression.Body);
            selectAction.CAction.SqlGroupBy(conditionBuilder.Condition);
            return selectAction;
        }
    }
}
