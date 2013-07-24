using HelloData.FWCommon.Cache;

namespace HelloData.FrameWork.Data
{
    /// <summary>
    /// ɾ��
    /// </summary>8907yjmedc`   `   
    public class DeleteAction : DataBaseAction
    {
        public DeleteAction(BaseEntity entity, int index = 0)
            : base(entity, index)
        {
            CurrentOperate = OperateEnum.Delete;
        }
        public DeleteAction(string tbName, int index = 0)
            : base(tbName, index)
        {
            CurrentOperate = OperateEnum.Delete;
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
        /// ��where����д��json��str���;Ϳ���{id:1,name:'123'}
        /// </summary>
        /// <param name="jsonStr"></param>
        public void Excute(string jsonStr)
        {

        }
    }
}