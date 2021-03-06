﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebCommon
{
    /// <summary>
    /// 分页方法
    /// </summary>
    public class Pagination
    {
        /// <summary>
        /// 每页数据条数,默认10条
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总数据条数，默认0
        /// </summary>
        public long TotalCount { get; set; }
        /// <summary>
        /// 当前页码（从 1 开始），默认1
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 点击提交转向地址(ajax提交为一个js方法)，默认javascript:getPage({pn});
        /// </summary>
        public string UrlPattern { get; set; }
        /// <summary>
        /// 最多的页码数，默认10
        /// </summary>
        public int MaxPagerCount { get; set; }
        /// <summary>
        /// 当前页标的〈a〉标签样式名，默认curPager
        /// </summary>
        public string CurrentLinkClassName { get; set; }

        public Pagination()
        {
            this.PageSize = 10;
            this.TotalCount = 0;
            this.PageIndex = 1;
            this.UrlPattern = "javascript:getPage({pn});";
            this.MaxPagerCount = 5;
            this.CurrentLinkClassName = "curPager";
        }

        public Pagination(int pageIndex, int pageSize, long totalCount)
        {
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.PageIndex = pageIndex;
            this.UrlPattern = "javascript:getPage({pn});";
            this.MaxPagerCount = 5;
            this.CurrentLinkClassName = "curPager";
        }

        public string GetPagerHtml()
        {
            StringBuilder sb = new StringBuilder();
            //算出来的页数
            int pageCount = (int)Math.Ceiling(TotalCount * 1.0f / PageSize);
            int startPageIndex = Math.Max(1, PageIndex - MaxPagerCount / 2);//第一个页码
            int endPageIndex = Math.Min(pageCount, startPageIndex + MaxPagerCount - 1);//最后一个页码
            sb.AppendLine("<div style='margin-top: 50px;'>");
            sb.AppendLine("<ul id='page' class='pagination'>");
            if (PageIndex > 1)
            {
                sb.AppendLine("<li><a href='javascript:getPage(1);' data-original-title='' title=''>首页</a></li>");
                sb.Append("<li><a href='").Append(UrlPattern.Replace("{pn}", (PageIndex - 1).ToString())).Append("' data -original-title='' title=''>上一页</a></li>").AppendLine();
            }
            else
            {
                sb.AppendLine("<li><a data-original-title='' title=''>首页</a></li>");
                sb.AppendLine("<li><a data-original-title='' title=''>上一页</a></li>");
            }
            for (int i = startPageIndex; i <= endPageIndex; i++)
            {
                if (i == PageIndex)
                {
                    sb.Append("<li class='").Append(CurrentLinkClassName).Append(" active'><a data-original-title='' title=''>").Append(i).Append("</a></li>").AppendLine();
                }
                else
                {
                    sb.Append("<li><a data-original-title='' title='' href='").Append(UrlPattern.Replace("{pn}", i.ToString())).Append("'>").Append(i).Append("</a></li>").AppendLine();
                }
            }
            if (PageIndex < pageCount)
            {
                sb.Append("<li><a href='").Append(UrlPattern.Replace("{pn}", (pageCount).ToString())).Append("' data -original-title='' title=''>尾页</a></li>");
                sb.Append("<li><a href='").Append(UrlPattern.Replace("{pn}", (PageIndex + 1).ToString())).Append("' data -original-title='' title=''>下一页</a></li>").AppendLine();
            }
            else
            {
                sb.AppendLine("<li><a data-original-title='' title=''>下一页</a></li>");
                sb.AppendLine("<li><a data-original-title='' title=''>尾页</a></li>");
            }
            sb.AppendLine("<li><span><input type='text'id='txtPage' style='width: 30px;height: 20px;'></span></li><li><span><a id='go'  data-original-title='' title=''>跳转</a></span></li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");
            return sb.ToString();
        }
    }
}
