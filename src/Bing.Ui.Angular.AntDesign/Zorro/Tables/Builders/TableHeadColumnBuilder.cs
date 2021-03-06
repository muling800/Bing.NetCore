﻿using Bing.Ui.Builders;
using Bing.Utils.Extensions;

namespace Bing.Ui.Zorro.Tables.Builders
{
    /// <summary>
    /// 表格标题列th生成器
    /// </summary>
    public class TableHeadColumnBuilder : TagBuilder
    {
        /// <summary>
        /// 初始化一个<see cref="TableHeadColumnBuilder"/>类型的实例
        /// </summary>
        public TableHeadColumnBuilder() : base("th")
        {
        }

        /// <summary>
        /// 设置标题
        /// </summary>
        public void Title(string title)
        {
            this.AppendContent(title);
        }

        /// <summary>
        /// 添加复选框
        /// </summary>
        /// <param name="tableId">表格标识</param>
        public void AddCheckBox(string tableId)
        {
            AddAttribute("nzShowCheckbox");
            AddAttribute("(nzCheckedChange)", $"{tableId}_wrapper.masterToggle()");
            AddAttribute("[nzChecked]", $"{tableId}_wrapper.isMasterChecked()");
            AddAttribute("[nzDisabled]", $"!{tableId}_wrapper.dataSource.length");
            AddAttribute("[nzIndeterminate]", $"{tableId}_wrapper.isMasterIndeterminate()");
        }

        /// <summary>
        /// 添加排序
        /// </summary>
        /// <param name="sortKey">排序字段</param>
        public void AddSort(string sortKey)
        {
            if (sortKey.IsEmpty())
            {
                return;
            }

            AddAttribute("[nzShowSort]", "true");
            AddAttribute("nzSortKey", sortKey);
        }

        /// <summary>
        /// 添加宽度
        /// </summary>
        /// <param name="width">宽度</param>
        public void AddWidth(string width)
        {
            if (width.IsEmpty())
            {
                return;
            }

            if (Bing.Utils.Helpers.Valid.IsNumber(width))
            {
                width += "px";
            }

            AddAttribute("nzWidth", width);
        }
    }
}
