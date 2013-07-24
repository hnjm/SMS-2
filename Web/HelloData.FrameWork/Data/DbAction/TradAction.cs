using System.Collections.Generic;
using System.Data;

namespace HelloData.FrameWork.Data
{
    /// <summary>
    /// ָ����һЩ������
    /// </summary>
    public class TradAction : DataBaseAction
    {
        public TradAction(BaseEntity entity, int index = 0)
            : base(entity, index)
        {
            CurrentOperate = OperateEnum.None;
        }
        public TradAction(int index = 0)
            : base(index)
        { CurrentOperate = OperateEnum.None; }
        /// <summary>
        /// ����sql����ָ����Ӧ�Ĳ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public T QueryEntity<T>(string sqlStr) where T : new()
        {
            return base.QueryEntity<T>(sqlStr);
        }
        /// <summary>
        /// ����sql����ָ����Ӧ�Ĳ�����
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public List<T> QueryList<T>(string sqlStr) where T : new()
        {
            return base.QueryList<T>(sqlStr);
        }
        /// <summary>
        /// ִ��һ��sql 
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="commandParameters"></param>
        public void Excute(string sqlStr, params DataParameter[] commandParameters)
        {
            foreach (var item in commandParameters)
            {
                this.AddParmarms(item.ParameterName, item.DbType, item.Value);
            }
            DbHelper.Parameters = this.Parameters;
            ReturnCode = DbHelper.ExecuteSql(sqlStr);
        }

        /// <summary>
        /// ��ѯ��datatable
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public DataTable QueryTable(string sqlStr)
        {
            return DbHelper.ExeDataTable(sqlStr);
        }
        /// <summary>
        /// ��һ�е�һ��
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        public object QuerySingle(string sqlStr)
        {
            return DbHelper.GetSingle(sqlStr);
        }

        public int ExecuteSqlTran(List<string> cmdlist)
        {
            ReturnCode = DbHelper.ExecuteTransaction(cmdlist);
            return ReturnCode;
        }
        #region �����洢����
        /// <summary>
        /// ִ�д洢���� 
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="commandParameters"></param>
        public void ExcuteStoredProcedure(string sqlStr, params DataParameter[] commandParameters)
        {
            foreach (var item in commandParameters)
            {
                this.AddParmarms(item.ParameterName, item.DbType, item.Value);
            }
            DbHelper.Parameters = this.Parameters;
            ReturnCode = DbHelper.ExecuteStoredProcedure(sqlStr);
        }
        /// <summary>
        /// ִ�д洢���� (��out)
        /// </summary>
        /// <param name="sqlStr"></param>
        /// <param name="commandParameters"></param>
        public List<DataParameter> ExcuteStoredOutProcedure(string sqlStr, params DataParameter[] commandParameters)
        {
            foreach (var item in commandParameters)
            {
                this.AddParmarms(item.ParameterName, item.DbType, item.Value);
            }
            DbHelper.Parameters = this.Parameters;
            return DbHelper.ExecuteStoredOutProcedure(sqlStr);
        }

        #endregion
    }
}