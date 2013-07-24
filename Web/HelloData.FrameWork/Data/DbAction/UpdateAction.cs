using HelloData.FWCommon.Cache;

namespace HelloData.FrameWork.Data
{
    /// <summary>
    /// ����
    /// </summary>
    public class UpdateAction : DataBaseAction
    {
        public UpdateAction(BaseEntity entity, int index = 0)
            : base(entity, index)
        {
            CurrentOperate = OperateEnum.Update;
        }
        public UpdateAction(string tbName, int index = 0)
            : base(tbName, index)
        {
            CurrentOperate = OperateEnum.Update;
        }
        private string BuildSql()
        {
            return CreateSql(CurrentOperate);
        }

        public override DataBaseAction Excute()
        {
            CacheHelper.RemoveByPreFix(string.Format("entity_{0}", this.TbName));
            DbHelper.Parameters = this.Parameters;
            ReturnCode = DbHelper.ExecuteSql(BuildSql());
            return this;
        }
        /// <summary>
        /// ������ھ͸���û�оͲ����µ�һ������
        /// </summary>
        public void UpdateSave()
        {

        }
    }
}