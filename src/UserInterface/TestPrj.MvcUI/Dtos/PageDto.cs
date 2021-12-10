namespace SecretMadonna.TestPrj.MvcUI.Dtos
{
    public class PageDto<Data>
    {
        /// <summary>
        /// 当前页（当前是第几页）
        /// </summary>
        public int CurrentPageIndex { get; set; }
        /// <summary>
        /// 每页记录数
        /// </summary>
        public int PrePageRecordCount { get; set; }
        /// <summary>
        /// 总记录数
        /// </summary>
        public int TotalRecordCount { get; set; }
        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                if (TotalRecordCount <= 0 || PrePageRecordCount <= 0)
                    return 0;
                return (TotalRecordCount / PrePageRecordCount) + (TotalRecordCount % PrePageRecordCount > 0 ? 1 : 0);
            }
        }
        /// <summary>
        /// 当前页的数据
        /// </summary>
        public Data CurrentPageData { get; set; }
    }
}
